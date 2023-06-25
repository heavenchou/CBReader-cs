using System;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows;

namespace CBReader
{
    public class CCBXML
    {
        bool IsDebug = false;

        // MARK: Private 私人成員變數
        string XMLFile = ""; // XML 檔名
        string HTMLText = "";	// HTML 的結果
        string HTMLCollation = "";    // HTML 校注
        CSetting Setting;       // 呈現用的設定
        string JSFile = "";  	// javascript 的位置

        XmlDocument Document = new XmlDocument();

        // --------------------------

        bool IsAIPunc = false;          // 判斷是不是 AI 標點文件

        string[] DivType = new string[30];		// 最多 20 層
        int DivCount = 0;   		        // Div 的層次

        bool InByline = false;  		// 用來判斷是否是作譯者

        // 偈頌相關
        bool IsFindLg = false;			// 一遇到 <lg> 就 true, 第一個 <l> 就會處理並設為 false;
        bool InLg = false;           	// 判斷是不是在 <lg> 之中, 主要是用來處理偈頌中的標點要不要呈現.
        bool LgNormal = true;		    // lg 的 type 是不是 normal? 有 normal 及 abnormal 二種
        bool LgInline = false;          // lg 的 place 是不是 inline?
        string LgMarginLeft = "";	    // lg 整段要空的格
        // L
        //int LTagNum = 0;		    // <l> 出現的數字, 用來判斷要在普及版寫幾個空格
        //string LMarginLeft = "";	    // L的空格

        string MarginLeft = "";     // 移位

        // list TextIndent, 若 item 沒有 TextIndent 就用 list 的 TextIndent。
        // 若 item 有 TextIndent，就忽略 list 的 TextIndent。
        string ListTextIndent = "";     

        int ListCount = 0;			// 計算 list 的數目, 有一些地方需要用到
        int[] ItemNum = new int[100];		// 用來判斷 item 出現的次數, 每一層 list 都有不同的內容

        int CellNum = 0;            // 計算第幾個 Cell, 用來判斷要在普及版寫幾個空格
        int OtherColspan = 0;       // 因本 cell 佔 n 格以上, 所以和後面的 cell 要空 (n-1)*3 的空格, 此即記錄 n-1 的數字

        int FuWenCount = 0;		// 用來判斷是否是附文, 因為有巢狀, 所以用 int
        bool InSutraNum = false;	   	// 用來判斷本行是否是經號
        bool InPinHead = false;			// 用來判斷本行是否是品名
        bool InFuWenHead = false;		// 用來判斷本行是否是附文標題
        bool InOtherHead = false;		// 用來判斷本行是否是其它標題
        bool InHead = false;			// 用來判斷本行是否是標題
        bool InNoteOrig = false;  		// 用來判斷是不是在 Note type=orig
        bool InNoteMod = false;			// 用來判斷是不是在 Note type=mod
        bool InNoteAdd = false;  		// 用來判斷是不是在 Note type=add

        bool InTTNormal = false;		// 在 <tt rend="normal"> 中, 這時每一個 <t> 都要換行 , T54n2133A : <lb n="1194c17"/><p><tt rend="normal"><t lang="san-sd">
        int PreFormatCount = 0;	// 判斷是否是要依據原始經文格式切行, 要累加的, 因為可能有巢狀的 pre

        int NoNormal = 0;			// 用來判斷是否可用通用字 , 大於 0 就不用通用字, 這二種就不用通用字 <text rend="no_nor"> 及 <term rend="no_nor">

        //string NormalWords; 	// 通用詞處理法, 若是 orig , 就是呈現 <orig> 中的字, 若是 "reg" 就是呈現 <reg> 中的字, 這是在 choice 標記中判斷

        // 要判斷品的範圍, 若出現品的 mulu, 則記錄 level, 等到 level 數字再次大於或等於時, 此品才結束
        //<mulu level="3" label="3 轉輪聖王品" type="品"/>
        int MuluLevel = 999;          // 目錄的層次
        string MuluLabel = "";		// 目錄的名稱
        bool InMulu = false;			// 在 <cb:mulu>...</cb:mulu> 的範圍內, 文字則不呈現,
        bool InMuluPin = false;         // 在 <cb:mulu>...</cb:mulu> 的範圍內, 而且是 "品" , 則文字不呈現, 但要記錄至 MuluLabel

        int NoteAddNum = 0;			// 自訂校注 <note type="add" 的流水號, 由 1 開始
        Dictionary<string, int> mpNoteAddNum = new Dictionary<string, int>();	// 由 id 找出 流水號, 沒有就設定一個
        Dictionary<string, int> mpNoteStarNum = new Dictionary<string, int>(); // 記錄每一個 id 有多少個星號了

        CNextLine NextLine = new CNextLine();     // 用來處理隔行 <tt> 的物件

        // 若有 <note type="cf1">XXX</note><note type="cf2">YYY</note>
        // 則 NoteCF = "XXX; YYY"
        // 在校注會呈現 (cf. XXX; YYY)
        // 例：(cf. 楊郁文《阿含辭典》編輯體例說明 (大) 1,6a4,a7; K17n0647_p0820a22)
        string NoteCF = "";

        // =========================
        // MARK: public 公開成員變數

        CSeries Series;
        
        // 缺字
        Dictionary<string, string> CB2des = new Dictionary<string, string>();     // 缺字 CB 碼查組字式
        Dictionary<string, string> CB2nor = new Dictionary<string, string>();     // 缺字 CB 碼查通用字
        Dictionary<string, string> CB2uni = new Dictionary<string, string>();     // 缺字 CB 碼查 unicode
        Dictionary<string, string> CB2nor_uni = new Dictionary<string, string>(); // 缺字 CB 碼查通用 unicode

        Dictionary<string, string> SD2roma = new Dictionary<string, string>();    // 悉曇字 SD 碼查羅馬轉寫字 (純文字)
        Dictionary<string, string> SD2uni = new Dictionary<string, string>();     // 悉曇字 SD 碼查羅馬轉寫字 (Unicode)
        Dictionary<string, string> SD2char = new Dictionary<string, string>();    // 悉曇字 SD 碼查對映 TTF 字型的字
        Dictionary<string, string> SD2big5 = new Dictionary<string, string>();    // 悉曇字 SD 碼查 Big5

        //Dictionary<string, string> RJ2roma;    // 蘭札字 RJ 碼查羅馬轉寫字 (純文字)
        //Dictionary<string, string> RJ2uni;     // 蘭札字 RJ 碼查羅馬轉寫字 (Unicode)
        //Dictionary<string, string> RJ2char;    // 蘭札字 RJ 碼查對映 TTF 字型的字
        //Dictionary<string, string> RJ2big5;    // 蘭札字 RJ 碼查 Big5

        Dictionary<string, string> mOrigNote = new Dictionary<string, string>();  // 暫存的 orig note

        // 處理 XML 過程需要的變數

        string BookId = "";		// 內容是 'T'(大正藏), 'X'(卍續藏)
        string VolId = "";      	// 內容是 01
        string SutraId = "";		// 內容是 "0001" or "0143a"
        string SutraId_ = "";	// 內容是 "0001_" or "0143a"
        string SutraName = "";	// 經名
        int JuanNum = 0;		// 第幾卷
        int TotalJuan = 0;   // 共幾卷, 用來判斷是不是只有一卷
        //string GotoPageLine = "";	// 本網頁要跳到的地點 (因為不一定是卷首)
        string BookVolnSutra = "";	// 內容是 T01n0001_
        string PageLine = "";		// 內容是 0001a01
        string LineHead = "";		// 內容是 T01n0001_p0001a01║

        bool ShowHighlight = false; 	// 是否塗色
        string BookVerName = "";     // 例如大正藏是 【大】,這是要由其他資料找出來的
        string SerialPath = "";      // 主要目錄, 要找圖檔位置用的

        // ======================================
        // 建構式, 傳入參數為 XML 檔, 呈現的設定
        public CCBXML(string sFile, string sLink, CSetting csSetting, string sJSFile, bool bShowHighlight = false, CSeries csSeries = null)
        {
            XMLFile = sFile;
            Setting = csSetting;
            JSFile = sJSFile;
            ShowHighlight = bShowHighlight;
            Series = csSeries;

            GetInitialFromFileName();   // 由經名取得一切相關資訊

            // 處理 XML -----------------------------------------------------------

            Document.PreserveWhitespace = true;
            Document.Load(XMLFile);

            HTMLText += MakeHTMLHead(); // 先產生 html 的 head

            // 是否有塗色? 有就表示有檢索字串
            if (bShowHighlight) {
                // 加上搜尋字串的 <div>
                // 把搜尋字串中的 ? 換成 ⍰
                string s = Series.SearchEngine.SearchSentence;
                s = s.Replace("?", "⍰");
                HTMLText += "<div id='SearchHead'>檢索字串：" + s + "<hr></div>";
            }

            HTMLText += ParseXML();             // 處理內文

            HTMLText = AddOrigNote(HTMLText);   // 原本的 orig 校勘還沒加入, 此時才要加入
            HTMLCollation = AddOrigNote(HTMLCollation);

            // 塗色否?
            if(bShowHighlight) {
                CHighlight HL = new CHighlight(Series.SearchEngine);
                HTMLText = HL.AddHighlight(HTMLText);
            }

            // 版本資訊

            string sVerInfo = GetVerInfo();
            HTMLText += sVerInfo;

            // 記錄校勘
            HTMLText += "<div id='CollationList' style='display:none'>\n";
            HTMLText += HTMLCollation;
            HTMLText += "</div>\n";

            HTMLText += "<script>\n";
            // 是否呈現校注 cf
            if(Setting.ShowCollationCF) {
                HTMLText += "\tShowCollationCF = true;\n";
            } else {
                HTMLText += "\tShowCollationCF = false;\n";
            }
            if (sLink != "") {
                HTMLText += $"\tlocation.href='#{sLink}';\n";
            } else if(bShowHighlight) {
                HTMLText += "\tlocation.href='#Search_0_1';\n";
            } else {
                // 如果不加底下這行，webview2 不會重新載入同樣檔名的內容
                HTMLText += "\tlocation.href='#';\n";
            }
            HTMLText += "</script>\n</body>\n</html>";
        }
        
        // 由經名取得一切相關資訊
        void GetInitialFromFileName()
        {
            // 檔名是 T01n0001_001.xml
            Regex re = new Regex(@"([A-Z]+)(\d+)n(.*?)_(\d\d\d)\.xml");
            Match match = re.Match(XMLFile);

            if (!match.Success) {   
                // 失敗
                CGlobalMessage.push($"檔名格式不正確, 無法分析: {XMLFile}");
                return;
            }

            GroupCollection group = match.Groups;

            BookId = group[1].Value;      // 內容是 'T'(大正藏), 'X'(卍續藏)
            VolId = group[2].Value;      // 內容是 01
            SutraId = group[3].Value;     // 內容是 "0001" or "0143a"
            SutraId_ = SutraId;
            if(SutraId.Length == 4) SutraId_ += "_";
            JuanNum = Convert.ToInt32(group[4].Value);     // 第幾卷
            BookVolnSutra = BookId + VolId + "n" + SutraId_;   // 內容是 T01n0001_

            int iIndex = Series.Catalog.FindIndexBySutraNum(BookId, VolId, SutraId);
            SutraName = Series.Catalog.SutraName[iIndex];
            TotalJuan = Convert.ToInt32(Series.Catalog.JuanNum[iIndex]);

            // 由 c://xxx/xxx/xml/T/T01/T01n0001_001.xml
            // 找出這個主要目錄 c://xxx/xxx/

            SerialPath = Regex.Replace(XMLFile, @"([\\/][^\\/]+?){4}$", "/");

            // 取得版本, 例如 'T' 的版本是 【大】
            BookVerName = Series.BookData.GetVerName(BookId);
            if(BookVerName == "") {   // 失敗
                CGlobalMessage.push("版本名稱找不到");
                return;
            }
        }

        // 先產生 html 的 head
        string MakeHTMLHead()
        {
            // 字型大小說明 : 主要為了用中文和等寬英文畫圖, 中文要 21px, 英文用 17.5px 才能對齊

            string sJqueryFile = JSFile.Replace("cbreader.js", "jquery.min.js");
            string sSiddamFile = JSFile.Replace("cbreader.js", "font/Siddam.otf");
            // 底下一定要用 / 才能使用
            sSiddamFile = sSiddamFile.Replace("\\", "/");
            string sRanjanaFile = sSiddamFile.Replace("Siddam.otf", "Ranjana.otf");

            var sHtml = $@"<!DOCTYPE html>
<html>
<head>
    <meta charset='utf-8'>
    <title>{BookId}{SutraId} {SutraName}</title>
    <script src='{sJqueryFile}'></script>
    <script src='{JSFile}'></script>
    <style type='text/css'>
        @font-face {{
            font-family: CBFont;
            src: local('Times New Roman'), local(MingLiU), local(細明體), local(PMingLiU), local(新細明體), local(NSimSun), local(SimSun), local('Songti TC');
        }}
        @font-face {{
            font-family: CBFont;
            unicode-range: U+2500-25ff;
            src: local(MingLiU), local(細明體), local(NSimSun), local('Songti TC');
        }}
        @font-face {{
            font-family: siddam;
            src: local(siddam), url('{sSiddamFile}');
        }}
        @font-face {{
            font-family: Ranjana;
            src: local(Ranjana), url('{sRanjanaFile}');
        }}";
            // text-center: 因為 p 設為 center 會空四格，head 整段空二格，所以置中的 head 要用 0 去取消
            sHtml += @"
        body { background:#DDF1DC; font-weight: normal; line-height:26px; color:#000000; font-size:21px; font-family:CBFont;}
        .bold {font-weight:bold;}
        .no-bold {font-weight:normal;}
        .italic {font-style:italic;}        
        .no-italic {font-style:normal;}  
        .songti {font-family:'Times New Roman',MingLiU,細明體,PMingLiU,新細明體,SimSun,NSimSun,'Songti TC';}
        .mingti {font-family:'Times New Roman',MingLiU,細明體,PMingLiU,新細明體,SimSun,NSimSun,'Songti TC';}
        .kaiti {font-family:'Times New Roman',DFKai-SB,標楷體,STKaiti,'Kaiti TC';}
        .heiti {font-family:'Times New Roman','Microsoft JhengHei',微軟正黑體,'Microsoft YaHei',simhei,'Heiti TC';}
        .sup {vertical-align:super;font-size:70%;}
        .sub {vertical-align:sub;font-size:70%;}
        .over {text-decoration:overline;}
        .under {text-decoration:underline;}
        .del {text-decoration:line-through;}
        .border {border:1px black solid;}
        .no-border {border:0;}
        .text-left {text-align:left;}
        .text-center {text-align:center; text-indent:0em !important; margin-left:0em !important;}
        .text-right {text-align:right;}
        .larger {font-size:larger;}
        .smaller {font-size:smaller;}
        .xx-small {font-size:xx-small;}
        .x-small {font-size:x-small;}
        .small {font-size:small;}
        .medium {font-size:medium;}
        .large {font-size:large;}
        .x-large {font-size:x-large;}
        .xx-large {font-size:xx-large;}
        .no-marker {list-style:none;}
        .circle-above {text-emphasize:circle-above;}
        #AIPuncRemind {color:#ffffff; background: #d80000;}
        #SearchHead {font-family:'Times New Roman','Hanazono Mincho B','Hanazono Mincho C','TH-Tshyn-P1';}
        a.SearchWord0 {color:#0000ff; background: #ffff66;}
        a.SearchWord1 {color:#0000ff; background: #a0ffff;}
        a.SearchWord2 {color:#0000ff; background: #99ff99;}
        a.SearchWord3 {color:#0000ff; background: #ff9999;}
        a.SearchWord4 {color:#0000ff; background: #ff66ff;}
        span.guess1 {background: #fff0a0;}
        span.guess2 {background: #ffd080;}
        span.guess3 {background: #ffb060;}
        span.guess4 {background: #ff9040;}
        a.hover   {color:#0000ff;}
        a:visited {color:#0000ff;}
        a:link    {color:#0000ff;}
        a:active  {color:#0000ff;}
        .foreign  {font-family:'Times New Roman', 'Gandhari Unicode';}
        .preformat {font-family:細明體,MingLiU,NSimSun,'Songti TC'; font-size:21px;}
        .preformat .foreign {font-family:'Courier New'; font-size:17.5px;}
        .gaiji {font-family:'Times New Roman','Hanazono Mincho B','Hanazono Mincho C','TH-Tshyn-P1';}
        .juannum  {color:#008000; font-size:21px;}
        .juanname {color:#0000FF; font-weight: bold; font-size:24px;}
        .xu {color:#0000A0; font-size:21px;}
        .w {color:#0000A0; font-size:21px;}
        .div-orig {font-weight: bold;}
        .byline {color:#408080; font-size:21px;}
        .headname  {color:#0000A0; font-weight: bold; font-size:24px;}
        .headname2 {color:#0000A0; font-weight: bold; font-size:24px;}
        .headname3 {color:#0000A0; font-weight: bold; font-size:24px;}
        .headname4 {color:#0000A0; font-weight: bold; font-size:24px;}
        .linehead {color:#0000A0; font-weight: normal; font-size:18px;font-family:MingLiU,細明體,NSimSun,'Songti TC';font-style:normal;}
        .parahead {color:#0000A0; font-weight: normal; font-size:18px;font-family:MingLiU,細明體,NSimSun,'Songti TC';font-style:normal;}
        .pts_head {color:#0000A0; font-weight: normal; font-size:18px;font-family:MingLiU,細明體,NSimSun,'Songti TC';font-style:normal;}
        .lg {color:#008040; font-size:21px;}
        .corr {color:#FF0000; }
        .note {color:#9F5000; font-size:18px;}
        table {border-collapse: collapse; margin: 20px; border: 1px solid black;}
        th, td { padding: 0.5em; border: 1px solid black;}
        table.no-border td, table.no-border th {border: 0px solid black;}
        table td.border-top {border-top:1px black solid;}
        table td.border-bottom {border-bottom:1px black solid;}
        table td.border-left {border-left:1px black solid;}
        table td.border-right {border-right:1px black solid;}
        td.pl-1 { padding-left: 1.5em; }
        td.pl-2 { padding-left: 2.5em; }
        td.pl-3 { padding-left: 3.5em; }
        td.pl-4 { padding-left: 4.5em; }
        td.pl-5 { padding-left: 5.5em; }
        td.pl-6 { padding-left: 6.5em; }
        td.pl-7 { padding-left: 7.5em; }
        td.pl-8 { padding-left: 8.5em; }";

            if (Setting.VerticalMode) {
                sHtml += "      body {writing-mode: tb-rl;}\n";
            }

            // 行首格式
            if(Setting.ShowLineFormat) {
                // 原書
                sHtml += @"
        div {display:inline;}
        p {display:inline;}
        #div_notearea_box div {display:block;}
        #div_notearea_box p {display:block;}
        br.lb_br {display:inline;}
        br.para_br  {display:none;}
        p.juannum   {display:inline; margin-left:0em;}
        p.headname2 {display:inline; margin-left:0em;}
        p.headname3 {display:inline; margin-left:0em;}
        p.headname4 {display:inline; margin-left:0em;}
        p.byline    {display:inline; margin-left:0em;}
        table-bak {border-style: none;}
        td-bak {padding: 0px;}
        #div_notearea_box table {border-style:solid; border-collapse:collapse;}
        #div_notearea_box td {padding: 0.5em;}
        span.line_space {display:inline;}
        span.para_space {display:none;}";
            } else {
                // 段落格式
                sHtml += @"
        div {display:block;}
        p {display:block;}
        br.lb_br {display:none;}
        br.para_br {display:inline;}
        p.juannum   {display:block; margin-left:2em;}
        p.headname2 {display:block; margin-left:2em;}
        p.headname3 {display:block; margin-left:3em;}
        p.headname4 {display:block; margin-left:4em;}
        p.byline    {display:block; text-align:right;}
        p.byline.text-center    {display:block; text-align:center;}
        p.byline.text-left    {display:block; text-align:left;}
        span.line_space {display:none;}
        span.para_space {display:inline;}";
            }

            // 校勘呈現
            if(Setting.ShowCollation == false) {
                sHtml += @"
        .note_orig {display:none;}
        .note_mod  {display:none;}
        .note_add  {display:none;}
        .note_star {display:none;}
        .note_star_removed {display:none;}";

            } else if(Setting.CollationType == ECollationType.Orig) {
                sHtml += @"
        .note_mod  {display:none;}
        .note_orig {display:inline;}
        .note_add  {display:none;}
        .note_star {display:inline;}
        .note_star_removed {display:inline;}";

            } else if(Setting.CollationType == ECollationType.CBETA) {

                sHtml += @"
        .note_orig {display:none;}
        .note_mod  {display:inline;}
        .note_add  {display:inline;}
        .note_star {display:inline;}
        .note_star_removed {display:none;}";
            }
            // 校勘 cf 呈現
            if (Setting.ShowCollationCF == true) {
                sHtml += @"
        .note_cf {display:inline;}";
            } else {
                sHtml += @"
        .note_cf {display:none;}";
            }
                sHtml += "\n    </style>\n";

            // 自訂 CSS
            if(Setting.UseCSSFile) {
                sHtml += $"    <link rel=stylesheet type='text/css' href='{Setting.CSSFileName}'>\n";
            }

            sHtml += $@"</head>
<body data-sutraname='{SutraName}' data-juan='{JuanNum}' data-totaljuan='{TotalJuan}'";

            // data-notetype 用來判斷目前是呈現何種校注
            if(Setting.ShowCollation == false) {
                sHtml += " data-notetype='none'";
            } else if(Setting.CollationType == ECollationType.Orig) {
                sHtml += " data-notetype='orig'";
            } else if(Setting.CollationType == ECollationType.CBETA) {
                sHtml += " data-notetype='cbeta'";
            }
            sHtml += ">\n";
            return sHtml;
        }

        // 處理 XML
        // 解析 XML , 儲存到 TreeRoot 中
        string ParseXML()
        {
            XmlNode node;
            string sHtml = "";

            // 讀取缺字
            XmlNode NodeGaijis = Document.DocumentElement["teiHeader"]["encodingDesc"]["charDecl"];
            if (NodeGaijis != null) {
                ReadGaiji(NodeGaijis); // 讀取缺字
            }

            // 檢查是不是 AI 標點
            XmlNode NodeEdition = Document.DocumentElement["teiHeader"]["encodingDesc"]["editorialDecl"]["punctuation"];
            string sEdition = NodeEdition.InnerXml;
            if(sEdition.Contains("AI 標點")) {
                IsAIPunc = true;
                sHtml += "<div><span id='AIPuncRemind'>【案：此資料標點由AI標點引擎提供，可從「設定/經文格式」選擇是否呈現。】</span></div>\n";
            }

            // 遍歷 XML

            node = Document.DocumentElement.GetElementsByTagName("text")[0];

            if(node.ChildNodes.Count == 0) {
                CGlobalMessage.push("錯誤：找不到 text 標記。");
            } else {
                sHtml += ParseNode(node);
            }

            return sHtml;
        }

        // 解析 XML Node
        string ParseNode(XmlNode node)
        {
            string sHtml = "";

            XmlNodeType nodetype = node.NodeType;

            /* Node Type
            1	ELEMENT_NODE
            2	ATTRIBUTE_NODE
            3	TEXT_NODE
            4	CDATA_SECTION_NODE
            5	ENTITY_REFERENCE_NODE
            6	ENTITY_NODE
            7	PROCESSING_INSTRUCTION_NODE
            8	COMMENT_NODE
            9	DOCUMENT_NODE
            10	DOCUMENT_TYPE_NODE
            11	DOCUMENT_FRAGMENT_NODE
            12	NOTATION_NODE
            */

            if(nodetype == XmlNodeType.Element) {
                // 一般節點
                string sTagName = node.Name;

                if(sTagName == "anchor") { sHtml = tagAnchor(node); }
                else if(sTagName == "app") { sHtml = tagApp(node); }
                else if(sTagName == "biblScope") { sHtml = tagBiblScope(node); }
                else if(sTagName == "byline") { sHtml = tagByline(node); }
                else if(sTagName == "caesura") { sHtml = tagCaesura(node); }
                else if(sTagName == "cell") { sHtml = tagCell(node); }
                else if(sTagName == "cb:div") { sHtml = tagDiv(node); }
                else if(sTagName == "cb:docNumber") { sHtml = tagDocNumber(node); }
                else if(sTagName == "entry") { sHtml = tagEntry(node); }
                else if(sTagName == "figDesc") { sHtml = tagFigdesc(node); }
                else if(sTagName == "foreign") { sHtml = tagForeign(node); }
                else if(sTagName == "form") { sHtml = tagForm(node); }
                else if(sTagName == "formula") { sHtml = tagFormula(node); }
                else if(sTagName == "g") { sHtml = tagG(node); }
                else if(sTagName == "graphic") { sHtml = tagGraphic(node); }
                else if(sTagName == "head") { sHtml = tagHead(node); }
                else if(sTagName == "hi") { sHtml = tagHi(node); }  // 二標記處理法相同
                else if(sTagName == "item") { sHtml = tagItem(node); }
                else if(sTagName == "cb:juan") { sHtml = tagJuan(node); }
                else if(sTagName == "l") { sHtml = tagL(node); }
                else if(sTagName == "lb") { sHtml = tagLb(node); }
                else if(sTagName == "lem") { sHtml = tagLem(node); }
                else if(sTagName == "lg") { sHtml = tagLg(node); }
                else if(sTagName == "list") { sHtml = tagList(node); }
                else if(sTagName == "cb:mulu") { sHtml = tagMulu(node); }
                else if(sTagName == "note") { sHtml = tagNote(node); }
                else if(sTagName == "p") { sHtml = tagP(node); }
                else if(sTagName == "pb") { sHtml = tagPb(node); }
                else if(sTagName == "rdg") { sHtml = tagRdg(node); }
                else if(sTagName == "ref") { sHtml = tagRef(node); }
                else if(sTagName == "row") { sHtml = tagRow(node); }
                else if(sTagName == "seg") { sHtml = tagHi(node); }
                else if(sTagName == "cb:sg") { sHtml = tagSg(node); }
                else if(sTagName == "space") { sHtml = tagSpace(node); }
                else if(sTagName == "cb:t") { sHtml = tagT(node); }
                else if(sTagName == "table") { sHtml = tagTable(node); }
                else if(sTagName == "term") { sHtml = tagTerm(node); }
                else if(sTagName == "text") { sHtml = tagTerm(node); } // text 和 term 處理法相同
                else if(sTagName == "trailer") { sHtml = tagTrailer(node); }
                else if(sTagName == "cb:tt") { sHtml = tagTt(node); }
                else if(sTagName == "unclear") { sHtml = tagUnclear(node); }
                else { sHtml = tagDefault(node); }
            } else if(nodetype == XmlNodeType.Text) {
                // 文字節點
                sHtml = node.Value;
                sHtml = sHtml.Replace("\r\n", "");
                sHtml = sHtml.Replace("\r", "");
                sHtml = sHtml.Replace("\n", "");
                sHtml = sHtml.Replace("\t", "");
                // xml 有 &amp; &lt;, 轉成 html 預設是 & < , CBR 程式讓 html 依然保持 &amp; &lt;
                // 實際呈現會自動轉成 & <, 但引用複製需要處理校注的部份
                // 所以只有 note_text 要處理 &amp; &lt; , text 不用處理
                sHtml = sHtml.Replace("&", "&amp;");
                sHtml = sHtml.Replace("<", "&lt;");

                // 移除標點
                if((Setting.ShowPunc == false) ||
                   (Setting.NoShowLgPunc == true && InLg == true) ||
                   (Setting.NoShowAIPunc == true && IsAIPunc == true)) {
                    // 校勘中不用移除標點
                    if(!InNoteOrig && !InNoteMod && !InNoteAdd) {
                        sHtml = RemovePunc(sHtml);
                    }
                }
            } else if(nodetype == XmlNodeType.Whitespace) {
                sHtml = node.Value;
                sHtml = sHtml.Replace("\r\n", "");
                sHtml = sHtml.Replace("\r", "");
                sHtml = sHtml.Replace("\n", "");
                sHtml = sHtml.Replace("\t", "");
            }
            return sHtml;
        }

        // 解析 XML Child
        string parseChild(XmlNode node)
        {
            string sHtml = "";
            for(int i = 0; i < node.ChildNodes.Count; i++) {
                XmlNode n = node.ChildNodes[i];
                sHtml += ParseNode(n);
            }
            return sHtml;
        }

        // 處理標記
        string tagDefault(XmlNode node)
        {
            var sHtml = "";
            sHtml += parseChild(node);
            return sHtml;
        }

        // ---------------------------------------------
        // 舊版 CBReader 有很多種 anchor , 現在剩二種
        // 1. 沒有處理的星號
        // <anchor xml:id="fxT01p0009a09"/>
        // 2. 雙圈 ◎
        // <anchor type="circle"/>
        string tagAnchor(XmlNode node)
        {
            string sHtml = "";
            string sXMLId = GetAttr(node, "xml:id");
            string sType = GetAttr(node, "type");

            // 沒有處理的星號 <anchor xml:id="fxT01p0009a09"/>
            if (sXMLId.StartsWith("fx")) {
                sHtml += "<span class='note_star'>[＊]</span>";
            }

            // 雙圈 ◎ <anchor type="circle"/>
            if (sType == "circle") {
                sHtml += "◎";
            }

            //sHtml = parseChild(node); // 處理內容
            return sHtml;
        }
        string tagApp(XmlNode node)
        {
            string sHtml = "";

            string sId = GetAttr(node, "n");
            string sType = GetAttr(node, "type");

            if (sId != "" && mpNoteAddNum.ContainsKey(sId)) {
                // 表示是 <note type="add"> 的 CBETA 自訂 <app>
                // 取回流水號, 把 Id 改成 Axx
                string sIdNum = Get_Add_IdNum(sId).ToString();
                sId = "A" + sIdNum;
            }

            if (sType == "star") {
                // 星號

                string sCorresp = GetAttr(node, "corresp");
                sCorresp = sCorresp.Remove(0,1);   // remove '#'
                int iStar = 1;
                if (mpNoteStarNum.ContainsKey(sCorresp)) {
                    iStar = mpNoteStarNum[sCorresp] + 1;    // 星號加 1
                } else {
                    iStar = 1;  // 第一個星號
                }
                mpNoteStarNum[sCorresp] = iStar;
                sCorresp += "-" + iStar.ToString();

                string sDisplay = "";   // 呈現的情況
                if (Setting.ShowCollation == false) { sDisplay = "none"; } 
                else if (Setting.CollationType == ECollationType.Orig) { sDisplay = "inline"; } 
                else if (Setting.CollationType == ECollationType.CBETA) { sDisplay = "inline"; }

                // 底下幾個順序不要錯亂, 尤其二個 HTMLCollation 要夾著 parseChild(Node)
                HTMLCollation += "<div id='txt_note_app_" + sCorresp + "'>\n";
                sHtml += "<a id='note_star_" + sCorresp + "' class='note_star' "
                       + "href='' style='display:" + sDisplay
                       + "' onclick='return ShowCollation($(this));'>[＊]</a>";
                sHtml += "<span id='note_app_" + sCorresp + "' class='note_app'>"
                         + parseChild(node) // 處理內容, 裡面的資料也會存在 HTMLCollation 中
                         + "</span>";
                HTMLCollation += "</div>\n";
            } else if (sType == "star_removed") {
                // 移除的星號

                string sCorresp = GetAttr(node, "corresp");
                sCorresp = sCorresp.Remove(0, 1);   // remove '#'
                int iStar = 1;
                if (mpNoteStarNum.ContainsKey(sCorresp)) {
                    iStar = mpNoteStarNum[sCorresp] + 1;    // 星號加 1
                } else {
                    iStar = 1;  // 第一個星號
                }
                mpNoteStarNum[sCorresp] = iStar;
                sCorresp += "-" + iStar.ToString();

                string sDisplay = "";   // 呈現的情況
                if (Setting.ShowCollation == false) { sDisplay = "none"; } 
                else if (Setting.CollationType == ECollationType.Orig) { sDisplay = "inline"; } 
                else if (Setting.CollationType == ECollationType.CBETA) { sDisplay = "none"; }

                // 底下幾個順序不要錯亂, 尤其二個 HTMLCollation 要夾著 parseChild(Node)
                HTMLCollation += "<div id='txt_note_app_" + sId + "'>\n";
                sHtml += "<a id='note_star_" + sCorresp + "' class='note_star_removed' "
                       + "href='' style='display:" + sDisplay
                       + "' onclick='return ShowCollation($(this));'>[＊]</a>";
                sHtml += "<span id='note_app_" + sId + "' class='note_app'>"
                      + parseChild(node) // 處理內容, 裡面的資料也會存在 HTMLCollation 中
                      + "</span>";
                HTMLCollation += "</div>\n";
            } else {
                // 這裡要注意順序
                // 1. 先處理校注區的 <div id="txt_note_app_xxxx">
                // 2. 進行 parseChild , 這裡面會處理校注區 lem ,rdg 的內容
                // 3. 再加上校注區的 </div>

                // 底下幾個順序不要錯亂, 尤其二個 HTMLCollation 要夾著 parseChild(Node)
                HTMLCollation += "<div id='txt_note_app_" + sId + "'>\n";
                sHtml += "<span id='note_app_" + sId + "' class='note_app'>"
                         + parseChild(node) // 處理內容, 裡面的資料也會存在 HTMLCollation 中
                         + "</span>";
                HTMLCollation += "</div>\n";
            }

            return sHtml;
        }

        //  <biblScope n="41" unit="卷" rend="small">
        string tagBiblScope(XmlNode node)
        {
            string sHtml = "";
            string sRend = GetAttr(node, "rend");
            string sStyle = GetAttr(node, "style");

            string sStyleClass = getStyleClass("", sStyle, sRend);
            if (sStyleClass != "") {
                sHtml += $"<span{sStyleClass}>";
            }
            sHtml += parseChild(node); // 處理內容
            if (sStyleClass != "") {
                sHtml += "</span>";
            }
            return sHtml;
        }

        // <byline cb:type="Translator">
        string tagByline(XmlNode node)
        {
            string sHtml = "";
            if (ListCount == 0) {
                InByline = true;
            }

            string sRend = GetAttr(node, "rend");
            string sStyle = GetAttr(node, "style");

            string sStyleClass = getStyleClass("byline", sStyle, sRend);

            sHtml += parseChild(node); // 處理內容

            if (ListCount > 0) {
                sHtml = "<span" + sStyleClass + ">　" + sHtml + "</span>";
            } else {
                InByline = false;
                if (Setting.ShowLineFormat) {
                    sHtml = "<span class='line_space'>　　　　</span>" +
                    "<span" + sStyleClass + " data-tagname='p'>" + sHtml + "</span>";
                } else {
                    sHtml = "<span class='line_space' style='display:none'>　　　　</span>" +
                    "<p" + sStyleClass + " data-tagname='p'>" + sHtml + "</p>"; 
                }
            }
            return sHtml;
        }

        // 2020/06 偈頌改成 <l>...<caesura/>...<caesura/>...</l>
        // <caesura/> , <caesura style="text-indent:1em;"/>
        // 預設空二格, 有 style 依 style 空格
        // 不依原書處理時，<l> 負責換行, <caesura> 為句中間隔
        string tagCaesura(XmlNode node)
        {
            string sHtml = "";
            string sLTextIndent = "";   // caesura 要空的格
            int iTextIndent;

            string sStyle = GetAttr(node, "style");
            CStyleAttr myStyle = new CStyleAttr(sStyle);

            if (myStyle.HasTextIndent) {
                iTextIndent = myStyle.TextIndent;
            } else {
                iTextIndent = 2;
            }

            sLTextIndent += StringRepeat("　", iTextIndent);
            // l 本身要空的格
            sHtml += sLTextIndent;
            // -----------------------------------
            // sHtml += parseChild(node); // 處理內容
            // -----------------------------------
            return sHtml;
        }

        string tagCell(XmlNode node)
        {
            string sHtml = "";
            string sCols = GetAttr(node, "cols");
            string sRows = GetAttr(node, "rows");
            string sRend = GetAttr(node, "rend");
            string sStyle = GetAttr(node, "style");
            CRendAttr myRend = new CRendAttr(sRend);
            CStyleAttr myStyle = new CStyleAttr(sStyle);
            string sNewStyle = myStyle.NewStyle;
            string sNewClass = myRend.NewClass;
            if (sNewStyle != "") {
                sNewStyle = " style='" + sNewStyle + "'";
            }
            if (sNewClass != "") {
                sNewClass = " class='" + sNewClass + "'";
            }

            CellNum++;        // cell 格式數量累加
            string sColspan = "";
            string sRowspan = "";

            int iColspan = 0;
            if (sCols != "") {
                iColspan = int.TryParse(sCols, out iColspan) ? iColspan : 1;
                iColspan = iColspan - 1;
                sColspan = " colspan = '" + sCols + "'";
            }

            if (sRows != "") {
                sRowspan = " rowspan = '" + sRows + "'";
            }

            // 這種格式 !InNoteOrig && !InNoteMod && !InNoteAdd
            // 表示在校注中的文字一律比照段落格式呈現，不要切換成原書行格式
            if (Setting.ShowLineFormat && !InNoteOrig && !InNoteMod && !InNoteAdd) {
                sHtml += "<span";
            } else {
                sHtml += "<td";
            }

            sHtml += sColspan;
            sHtml += sRowspan;
            sHtml += sNewStyle;
            sHtml += sNewClass;
            if (!InNoteOrig && !InNoteMod && !InNoteAdd) {
                sHtml += " data-tagname='td'>";
            } else {
                sHtml += ">";
            }

            // 第一個空一格, 其它空三格
            // 因為第一個 <cell> 之後通常會有 <lb>，所以空格要在 <lb> 之後
            // 原本是
            // ...<span class='line_space'>　</span>...
            // ...<span class='linehead'>ZW01na003_p0027a11║</span>...
            // 換成
            // ...<span class='linehead'>ZW01na003_p0027a11║</span>
            // <span class='line_space'>　</span>...

            string sCellSpace = "";

            if (Setting.ShowLineFormat && !InNoteOrig && !InNoteMod && !InNoteAdd) {
                sCellSpace += "<span class='line_space'>";
            } else {
                sCellSpace += "<span class='line_space' style='display:none'>";
            }
            if (CellNum == 1) {
                sCellSpace += "　";
            } else {
                sCellSpace += "　　　";
            }
            // 若 class="pl-2"，就要加上 2 個空格
            int iPos = sNewClass.IndexOf("pl-");
            if (iPos >= 0) {
                string sPlNum = sNewClass.Substring(iPos + 3, 2); // 先取二個
                if (sPlNum.Substring(1, 1) == " ") {
                    sPlNum = sPlNum.Remove(1, 1);
                }
                int iPlNum = int.TryParse(sPlNum, out iPlNum) ? iPlNum : 0;
                sCellSpace += StringRepeat("　", iPlNum);
            }

            for (int i = 0; i < OtherColspan; i++) {
                sCellSpace += "　　　";                  //印出前一個 cell 應有的空格
            }

            OtherColspan = iColspan;
            sCellSpace += "</span>";

            string sChild = parseChild(node); // 處理內容

            // 第一個 cell 因為會在前一行行尾，所以要把 cell 空格移到行首後面
            if (CellNum == 1) {
                string sHead = "";
                string sTail = sChild;
                int iPos2 = sTail.IndexOf("║</span>");

                while (iPos2 >= 0) {
                    // sHead = .....║</span>
                    sHead += sTail.Substring(0, iPos2 + 8);
                    // sTail = 剩下的
                    sTail = sTail.Substring(iPos2 + 8, sTail.Length - iPos2 - 8);
                    iPos2 = sTail.IndexOf("║</span>");
                }
                sChild = sHead + sCellSpace + sTail;
                sCellSpace = "";
            }
            sHtml += sCellSpace + sChild;

            if (Setting.ShowLineFormat && !InNoteOrig && !InNoteMod && !InNoteAdd) {
                sHtml += "</span>";
            } else {
                sHtml += "</td>";
            }
            return sHtml;
        }

        // 附文: <cb:div type="w"><p xml:id="pT02p0029b2201"><anchor xml:id="nkr_note_orig_0029009" n="0029009"/>
        // 序: <cb:div type="xu"><cb:mulu level="1" type="序">序</cb:mulu><anchor xml:id="nkr_note_orig_0001001" n="0001001"/><head><title>長阿含經</title>序</head>
        string tagDiv(XmlNode node)
        {
            string sHtml = "";
            string sType = GetAttr(node, "type");
            string sRend = GetAttr(node, "rend");
            string sStyle = GetAttr(node, "style");

            CRendAttr myRend = new CRendAttr(sRend);
            CStyleAttr myStyle = new CStyleAttr(sStyle);

            string sNewStyle = myStyle.NewStyle;
            string sNewClass = myRend.NewClass;
            if (sNewStyle != "") {
                sNewStyle = $" style='{sNewStyle}'";
            }

            DivCount++;

            if (sType != "") {
                DivType[DivCount] = sType.ToLower();    // 都變成小寫
            }

            if (DivType[DivCount] == "w") { 		// 附文
                FuWenCount++;
                if (Setting.ShowLineFormat && !InNoteOrig && !InNoteMod && !InNoteAdd) {
                    sHtml += $"<span class='w {sNewClass}' data-tagname='div'{sNewStyle}>";
                } else {
                    // 要用 div , 才不會有 span 包 p 的困境
                    if (!InNoteOrig && !InNoteMod && !InNoteAdd) {
                        sHtml += $"<div class='w {sNewClass}' data-tagname='div'{sNewStyle}>";
                    } else {
                        sHtml += $"<div class='w {sNewClass}'{sNewStyle}>";
                    }
                }

                if (FuWenCount == 1) {
                    if (Setting.ShowLineFormat && !InNoteOrig && !InNoteMod && !InNoteAdd) {
                        sHtml += "<span data-margin-left='1em' data-tagname='div'>" +
                        "<span class='line_space'>　</span>";
                    } else {
                        if (!InNoteOrig && !InNoteMod && !InNoteAdd) {
                            sHtml += "<div data-margin-left='1em' style='margin-left: 1em' data-tagname='div'>" +
                        "<span class='line_space' style='display:none'>　</span>";
                        } else {
                            sHtml += "<div data-margin-left='1em' style='margin-left: 1em'>" +
                        "<span class='line_space' style='display:none'>　</span>";
                        }
                    }
                }
            } else if (DivType[DivCount] == "xu") { 		// 序文
                if (Setting.ShowLineFormat && !InNoteOrig && !InNoteMod && !InNoteAdd) {
                    sHtml += $"<span class='xu {sNewClass}' data-tagname='div'{sNewStyle}>";
                } else {
                    // 要用 div , 才不會有 span 包 p 的困境
                    if (!InNoteOrig && !InNoteMod && !InNoteAdd) {
                        sHtml += $"<div class='xu {sNewClass}' data-tagname='div'{sNewStyle}>";
                    } else {
                        sHtml += $"<div class='xu {sNewClass}'{sNewStyle}>";
                    }
                }
            } else if (DivType[DivCount] == "orig") { 		// 原書資料
                if (Setting.ShowLineFormat && !InNoteOrig && !InNoteMod && !InNoteAdd) {
                    sHtml += $"<span class='div-orig {sNewClass}' data-tagname='div'{sNewStyle}>";
                } else {
                    // 要用 div , 才不會有 span 包 p 的困境
                    if (!InNoteOrig && !InNoteMod && !InNoteAdd) {
                        sHtml += $"<div class='div-orig {sNewClass}' data-tagname='div'{sNewStyle}>";
                    } else {
                        sHtml += $"<div class='div-orig {sNewClass}'{sNewStyle}>";
                    }
                }
            } else {
                if (Setting.ShowLineFormat && !InNoteOrig && !InNoteMod && !InNoteAdd) {
                    sHtml += $"<span data-tagname='div'{sNewStyle}>";
                } else {
                    // 要用 div , 才不會有 span 包 p 的困境
                    if (!InNoteOrig && !InNoteMod && !InNoteAdd) {
                        sHtml += $"<div data-tagname='div'{sNewStyle}>";
                    } else {
                        sHtml += $"<div{sNewStyle}>";
                    }
                }
            }

            // ----------------------------------
            sHtml += parseChild(node); // 處理內容
            // ----------------------------------

            string sEndTag = "</div>";
            if (Setting.ShowLineFormat && !InNoteOrig && !InNoteMod && !InNoteAdd) {
                sEndTag = "</span>";
            }

            if (DivType[DivCount] == "w") { 		// 附文
                FuWenCount--;
                if (FuWenCount == 0) {     // 大正藏切行
                    sHtml += sEndTag;
                }
                sHtml += sEndTag;       // 不切行則要用 div , 才不會有 span 包 p 的困境
            } else if (DivType[DivCount] == "xu") {      // 序
                sHtml += sEndTag;
            } else if (DivType[DivCount] == "orig") {  // 原書資料
                sHtml += sEndTag;
            } else {
                sHtml += sEndTag;
            }

            DivCount--;

            return sHtml;
        }

        // <cb:docNumber>No. 2 [No. 1(1), Nos. 2, 4]</cb:docNumber>
        string tagDocNumber(XmlNode node)
        {
            string sHtml = "";

            if (Setting.ShowLineFormat) {
                sHtml += "<span class='line_space'>　　</span>";
                sHtml += "<span class='juannum' data-tagname='p'>";
            } else {
                sHtml += "<span class='line_space' style='display:none'>　　</span>";
                sHtml += "<p class='juannum' data-tagname='p'>";
            }

            sHtml += parseChild(node); // 處理內容

            if (Setting.ShowLineFormat) {
                sHtml += "</span>";
            } else {
                sHtml += "</p>";
            }

            return sHtml;
        }

        // 辭書的處理 <entry><form>名詞</form><cb:def>解釋..........</cb:def></entry>
        // <entry><form>多陀阿伽陀</form><cb:def><p xml:id="pX15p0218b2206" rend="margin-left:1em;inline">如來也。</p></cb:def></entry>
        // <entry rend="margin-left:1em"><form>
        // 若是行中的 <entry cb:place="inline" rend=.....> 不管 rend 如何, 一律空三格
        string tagEntry(XmlNode node)
        {
            string sHtml = "";
            string sRend = GetAttr(node, "rend");
            string sStyle = GetAttr(node, "style");
            string sPlace = GetAttr(node, "cb:place");

            CRendAttr myRend = new CRendAttr(sRend);
            CStyleAttr myStyle = new CStyleAttr(sStyle);
            
            string sNewStyle = myStyle.NewStyle;
            string sNewClass = myRend.NewClass;

            string sOldMarginLeft = MarginLeft;
            string sTextIndentSpace = "";   // 先設為原來的 MarginLeft

            int iMarginLeft = 0;
            int iTextIndent = 0;

            if (sStyle != "") {
                iMarginLeft = myStyle.MarginLeft;
                iTextIndent = myStyle.TextIndent;

                MarginLeft += StringRepeat("　", iMarginLeft);// 這是第二行之後要空的
                sTextIndentSpace += StringRepeat("　", iMarginLeft + iTextIndent);
            }

            // place="inline" 要加三個空格
            if (sPlace == "inline") {           // 行中段落加句點
                sTextIndentSpace = "　　　";
            }

            if (Setting.ShowLineFormat) {
                sNewStyle = myStyle.sTextIndent + myStyle.NewStyle;
                if(sNewStyle != "") {
                    sNewStyle = $" style='{sNewStyle}'";
                }
                sHtml += $"<span class='entry {myRend.NewClass}'{sNewStyle}";
                sHtml += $" data-margin-left='{iMarginLeft}em' data-tagname='div'>";
                sHtml += $"<span class='line_space'>{sTextIndentSpace}</span>";
            } else {
                sNewStyle = myStyle.sMarginLeft + myStyle.sTextIndent + myStyle.NewStyle;
                if (sNewStyle != "") {
                    sNewStyle = $" style='{sNewStyle}'";
                }
                sHtml += $"<div class='entry {myRend.NewClass}'{sNewStyle}";
                sHtml += $" data-margin-left='{iMarginLeft}em' data-tagname='div'>";
                sHtml += $"<span class='line_space' style='display:none'>{sTextIndentSpace}</span>";
            }

            //------------------------------------
            sHtml += parseChild(node); // 處理內容
            //------------------------------------

            if (Setting.ShowLineFormat) {
                sHtml += "</span>";
            } else {
                sHtml += "</div>";
            }
            MarginLeft = sOldMarginLeft;
            return sHtml;
        }

        string tagFigdesc(XmlNode node)
        {
            string sHtml = "<span class='figdesc'>（";
            sHtml += parseChild(node); // 處理內容
            sHtml += "）</span>";
            return sHtml;
        }

        // no.26 <foreign n="0442001" lang="pli" resp="Taisho" cb:place="foot">gabbhaseyy&amacron; punabhav&amacron;bhimbbatti.</foreign>
        // cb:place="foot" 就不要呈現
        // 印順法師著作集則有很多類似如下外文 <foreign xml:lang="sa">Patna</foreign>
        string tagForeign(XmlNode node)
        {
            string sHtml = "";
            string sPlace = GetAttr(node, "cb:place");
            if (sPlace == "foot") {
                return "";
            }

            string sRend = GetAttr(node, "rend");
            string sStyle = GetAttr(node, "style");

            CRendAttr myRend = new CRendAttr(sRend);
            CStyleAttr myStyle = new CStyleAttr(sStyle);

            string sStyleClass = getStyleClass("foreign", sStyle, sRend);

            sHtml += $"<span{sStyleClass}>";

            sHtml += parseChild(node); // 處理內容

            sHtml += "</span>";
            return sHtml;
        }

        string tagForm(XmlNode node)
        {
            string sHtml = "";
            if (Setting.ShowLineFormat) {
                sHtml = "<span data-tagname='p'>";
                sHtml += parseChild(node); // 處理內容
                sHtml += "</span>";
            } else {
                sHtml = "<p data-tagname='p'>";
                sHtml += parseChild(node); // 處理內容
                sHtml += "</p>";
            }
            return sHtml;
        }

        // <formula style="vertical-align:super">(1)</formula>
        // 轉成 <sup>(1)</sup>

        // <formula>S<hi style="vertical-align:super">n</hi></formula>
        // 轉成 S<sup>n</sup>

        // formula 或 hi , 誰有  style="vertical-align:super" 就使用 <sup>...</sup>
        // style="vertical-align:sub" 則轉成 <sub>..</sub>
        string tagFormula(XmlNode node)
        {
            string sHtml = "";
            string sStyle = GetAttr(node, "style");

            if (sStyle.Contains("vertical-align:super")) {
                sHtml += "<sup>";
                sHtml += parseChild(node); // 處理內容
                sHtml += "</sup>";
            } else if (sStyle.Contains("vertical-align:sub")) {
                sHtml += "<sub>";
                sHtml += parseChild(node); // 處理內容
                sHtml += "</sub>";
            } else {
                sHtml += parseChild(node); // 處理內容
            }
            return sHtml;
        }

        // 缺字 <g ref="#CB00166"/>
        // 悉曇字 T20n1034 <g ref="#SD-A440"/>
        // 蘭札字 T21n1419 <g ref="#RJ-C947"/>
        string tagG(XmlNode node)
        {
            string sHtml = "";
            string sCBCode = GetAttr(node, "ref");
            sCBCode = sCBCode.Remove(0, 1);
            string sCBCodeType = sCBCode.Substring(0, 2);

            if (sCBCodeType == "CB") {
                sHtml = "<span class='gaiji' data-id='" + sCBCode + "'";

                // 組字式
                string sDes = "";
                if (CB2des.ContainsKey(sCBCode)) {
                    sDes = CB2des[sCBCode];
                    sHtml += " data-des='" + CB2des[sCBCode] + "'";
                }
                // 通用字
                string sNor = "";
                if (CB2nor.ContainsKey(sCBCode) && NoNormal == 0) {   // 有 NoNormal 就不使用通用字
                    sNor = CB2nor[sCBCode];
                    sHtml += " data-nor='" + sNor + "'";
                }
                // Unicode
                string sUni = "";
                if (CB2uni.ContainsKey(sCBCode)) {
                    sUni = CB2uni[sCBCode];
                    sHtml += " data-uni='" + sUni + "'";
                }
                // Normal Unicode
                string sNorUni = "";
                if (CB2nor_uni.ContainsKey(sCBCode)) {
                    sNorUni = CB2nor_uni[sCBCode];
                    sHtml += " data-noruni='" + sNorUni + "'";
                }
                // 圖檔
                string sGaijiFile = SerialPath + "gaiji-CB\\" + sCBCode.Substring(2, 2) + "\\"
                                    + sCBCode + ".gif";
                sGaijiFile = Path.GetFullPath(sGaijiFile);
                sHtml += " data-imgfile='" + sGaijiFile + "'>";

                // 顯示的文字
                // 1. 如果 unicode 優先
                // 2. 如果 通用字 優先

                bool bHasGaiji = true;
                if (Setting.GaijiUniExtFirst) {
                    if (Setting.GaijiUseUniExt && sUni != "") {
                        // unicode 優先
                        sHtml += sUni;
                    } else if (Setting.GaijiUseUniExt && Setting.GaijiUseNormal && sNorUni != "" && NoNormal == 0) {
                        // 通用 unicode 次之
                        sHtml += sNorUni;
                    } else if (Setting.GaijiUseNormal && sNor != "" && NoNormal == 0) {
                        // 通用字最後
                        sHtml += sNor;
                    } else {
                        bHasGaiji = false;
                    }
                } else {
                    if (Setting.GaijiUseNormal && sNor != "" && NoNormal == 0) {
                        // 通用字優先
                        sHtml += sNor;
                    } else if (Setting.GaijiUseUniExt && sUni != "") {
                        // unicode 次之
                        sHtml += sUni;
                    } else if (Setting.GaijiUseUniExt && Setting.GaijiUseNormal && sNorUni != "" && NoNormal == 0) {
                        // 通用 unicode 最後
                        sHtml += sNorUni;
                    } else {
                        bHasGaiji = false;
                    }
                }

                if (bHasGaiji == false) {
                    // 還沒有 unicode 及通用字
                    if (Setting.GaijiDesFirst) {
                        // 優先使用組字式
                        if (sDes != "") {
                            sHtml += sDes;
                        } else if (File.Exists(sGaijiFile)) {
                            sHtml += "<img src='" + sGaijiFile + "'/>";
                        } else {
                            sHtml += "<span title='此缺字無法呈現'>⍰</span>";
                        }
                    } else {
                        // 圖檔優先 , 暫時不用 ????
                        if (File.Exists(sGaijiFile)) {
                            sHtml += "<img src='" + sGaijiFile + "'/>";
                        } else if (sDes != "") {
                            sHtml += sDes;
                        } else {
                            sHtml += "<span title='此缺字 " + sCBCode + " 無法呈現'>⍰</span>";
                        }
                    }
                }

                // 結束標記
                sHtml += "</span>";
            } else if (sCBCodeType == "SD" || sCBCodeType == "RJ") {
                // 悉曇字
                // 設定還沒寫 ????
                int iShowSiddamWay = Setting.ShowSiddamWay;

                // 特殊格式, 若格式是 4 自訂, 且文字是 S(R) , 就用特殊格式

                bool bSpecial = false;   // 200702 之後的加強版
                if (iShowSiddamWay == 6) {
                    bSpecial = true;                                           // 200802 版
                }

                // 悉曇字處理法 0:悉曇字型(siddam.ttf)
                if (iShowSiddamWay == 0 || bSpecial) {
                    if (SD2char.ContainsKey(sCBCode)) {
                        if (sCBCodeType == "SD") {  // 悉曇字型
                            sHtml += "<font face='siddam'>";
                        } else if (sCBCodeType == "RJ") {  // 悉曇字型
                            sHtml += "<font face='Ranjana'>";
                        }
                        sHtml += SD2char[sCBCode];
                        sHtml += "</font>";
                    } else {
                        iShowSiddamWay = 3;     // 沒有 sdchar 就先換圖檔
                    }
                }

                // 悉曇字處理法 1:羅馬轉寫(unicode)
                if (iShowSiddamWay == 1 || bSpecial) {
                    string sUnicode = "";
                    string sBig5 = "";

                    if (SD2uni.ContainsKey(sCBCode)) {
                        sUnicode = SD2uni[sCBCode];     // 悉曇
                    }
                    if (SD2big5.ContainsKey(sCBCode)) {
                        sBig5 = SD2big5[sCBCode];
                    }

                    if (sUnicode != "") {
                        sUnicode = "<span class='foreign'>" + sUnicode + "</span>";
                        if (bSpecial) {    // 特殊格式, 給悉曇網用的, 200802 加入
                            sUnicode = "(" + sUnicode + ")";
                        }
                        sHtml += sUnicode;
                        sHtml += " ";
                    } else if (sBig5 != "") {
                        // 有些悉曇字有 （　）　…　這些文字, 這些在悉曇字與轉寫字同時呈現時, 不用再呈現一次
                        if (!bSpecial) {
                            sHtml += sBig5;
                        }
                    } else if (!bSpecial) {
                        iShowSiddamWay = 3;     // 沒有 big5 就先換圖檔
                    }
                }
                // 悉曇字處理法 2:羅馬轉寫(純文字) -- 2018 新版不提供了

                // 悉曇字處理法 3:悉曇圖檔
                if (iShowSiddamWay == 3) {
                    // sCBCode = SD-A440

                    string sSDGifOrigFile = "";
                    string sSDGifFile;

                    if (sCBCodeType == "SD") {
                        sSDGifOrigFile = SerialPath + "sd-gif/" + sCBCode.Substring(3, 2) + "/"
                                    + sCBCode + ".gif";
                    } else if (sCBCodeType == "RJ") {
                        sSDGifOrigFile = SerialPath + "rj-gif/" + sCBCode.Substring(3, 2) + "/"
                                    + sCBCode + ".gif";
                    }
                    sSDGifFile = Path.GetFullPath(sSDGifOrigFile);

                    // 如果圖檔不存在, 就用 SD 碼
                    if (File.Exists(sSDGifFile)) {
                        sHtml += "<img src='";
                        sHtml += sSDGifFile;
                        sHtml += "'/>";
                    } else {
                        iShowSiddamWay = 5;     // 沒有圖檔就換 SD 碼
                    }
                }
                // 悉曇字處理法 4:自訂符號 -- 2018 不提供了
                // 悉曇字處理法 5:CB碼     -- 2018 不提供了
                if (iShowSiddamWay == 5) {
                    if (sCBCodeType == "SD") {
                        sHtml += "<span title='此悉曇字 " + sCBCode + " 無法呈現'>⍰</span>";
                    } else if (sCBCodeType == "RJ") {
                        sHtml += "<span title='此蘭札字 " + sCBCode + " 無法呈現'>⍰</span>";
                    }
                }
            }

            return sHtml;
        }

        // 圖檔 <figure><graphic url="../figures/T/T18p0146_01.gif"></graphic></figure>
        string tagGraphic(XmlNode node)
        {
            string sHtml = "";
            string sURL = GetAttr(node, "url");
            if (sURL != "") {
                string sPicOrigFile = SerialPath + sURL.Replace("../", "");
                string sPicFile = sPicOrigFile.Replace('/', '\\');

                sHtml += "<img src='";
                sHtml += sPicFile;
                sHtml += "'>";

                // 以下放棄, 前一個文字因為 svg 圖檔無法被連結, 只能連出去
                // 也就是文字的 <a name="xxx">TEXT</a> XXX 無法被使用
                // 若要使用, 也要把 12pt 改成 16px

                /*
                if(sPicFile.SubString0(sPicFile.Length()-3,3) == "svg") {
                    // svg 圖檔
                    sHtml += GetSvgFile(sPicFile);
                } else {
                    // 一般圖檔
                    sHtml += "<img src='";
                    sHtml += sPicFile;
                    sHtml += "'>";
                }
                */
            }
            //sHtml = parseChild(node); // 處理內容
            return sHtml;
        }

        // <head>
        string tagHead(XmlNode node)
        {
            string sHtml = "";
            // 處理標記

            IsFindLg = false;       // 因為 IsFindLg 是判斷 <l> 是不是第一個, 若是就不空格, 但有一種是 <lg><head>...</head><l> , 所以這也不算第一個 <l>

            string sType = GetAttr(node, "type");

            if (sType == "add") {
                // 額外的, 不處理 ,
                // 只出現在 T06, T07 <head type="added">No. 220</head>,
                // T21 <head type="added">No. 1222</head>
                return "";
            }

            string sRend = GetAttr(node, "rend");
            string sStyle = GetAttr(node, "style");

            CRendAttr myRend = new CRendAttr(sRend);
            CStyleAttr myStyle = new CStyleAttr(sStyle);
            string sNewStyle = myStyle.NewStyle;
            string sNewClass = myRend.NewClass;
            if (sNewStyle != "") {
                sNewStyle = " style='" + sNewStyle + "'";
            }
            if (sType == "pin") {     // 品名
                InPinHead = true;
            } else if (sType == "other") {   // 附文標題
                InOtherHead = true;
            }

            // head 是否在 list 中待處理
            XmlNode ParentNode = node.ParentNode;
            string sParentNodeName = "";
            if (ParentNode != null) {
                sParentNodeName = ParentNode.Name;
            }

            if (sParentNodeName == "list") {
                // list 的規則參考 list 的項目
                sHtml += $"<span class='headname {sNewClass}'{sNewStyle}>";
            } else {
                // 設定 head 待處理
                if (DivType[DivCount] == "pin") {          // 品的標題
                    InPinHead = true;
                } else if (DivType[DivCount] == "w") {      // 附文的標題
                    InFuWenHead = true;
                } else if (DivType[DivCount] == "other") {   // 其它的標題
                    InOtherHead = true;
                } else {
                    InHead = true;
                }

                // Q1 ==> 空2格
                // Q2 ==> 空3格
                // Q3 ==> 空4格
                // Q4 ==> 空2格
                // Q5 ==> 空3格
                // Q6 ==> 空4格
                // Q7 ==> 空2格
                // Q8 ==> 空3格

                // 原本不應該有 0 , 但有時 head 不在 div 中, 就會有 0 了
                if (Setting.ShowLineFormat) {
                    if (DivCount == 0 || DivCount % 3 == 1) {
                        sHtml += "<span class='line_space'>　　</span>" +
                        $"<span class='headname2 {sNewClass}'{sNewStyle} data-tagname='p'>";
                    } else if (DivCount % 3 == 2) {
                        sHtml += "<span class='line_space'>　　　</span>" +
                        $"<span class='headname3 {sNewClass}'{sNewStyle} data-tagname='p'>";
                    } else if (DivCount % 3 == 0) {
                        sHtml += "<span class='line_space'>　　　　</span>" +
                        $"<span class='headname4 {sNewClass}'{sNewStyle} data-tagname='p'>";
                    }
                } else {
                    if (DivCount == 0 || DivCount % 3 == 1) {
                        sHtml += "<span class='line_space' style='display:none'>　　</span>" +
                        $"<p class='headname2 {sNewClass}'{sNewStyle} data-tagname='p'>";
                    } else if (DivCount % 3 == 2) {
                        sHtml += "<span class='line_space' style='display:none'>　　　</span>" +
                        $"<p class='headname3 {sNewClass}'{sNewStyle} data-tagname='p'>";
                    } else if (DivCount % 3 == 0) {
                        sHtml += "<span class='line_space' style='display:none'>　　　　</span>" +
                        $"<p class='headname4 {sNewClass}'{sNewStyle} data-tagname='p'>";
                    }
                }
            }

            sHtml += parseChild(node); // 處理內容
                
            // 結束標記

            if (sType == "pin") {     // 品名
                InPinHead = false;
            } else if (sType == "other") {   // 附文標題
                InOtherHead = false;
            }

            if (sParentNodeName == "list") {
                // 詳細說明參考 list 的規則
                sHtml += "</span>";
            } else {
                if (DivType[DivCount] == "pin") {          // 品的標題
                    InPinHead = false;
                } else if (DivType[DivCount] == "w") {      // 附文的標題
                    InFuWenHead = false;
                } else if (DivType[DivCount] == "other") {   // 其它的標題
                    InOtherHead = false;
                } else {
                    InHead = false;
                }

                //sHtml += "</span>";
                if (Setting.ShowLineFormat) {
                    sHtml += "</span>";
                } else {
                    sHtml += "</p>";
                }
            }

            if (sParentNodeName == "list") {
                // 詳細說明參考 list 的規則
                if (Setting.ShowLineFormat) {
                    sHtml += "<span data-tagname='ul'>";
                } else {
                    sHtml += "<ul data-tagname='ul'>";
                }
            }
            return sHtml;
        }

        // <hi rend="border">p.12</hi> 要加外框
        // <hi,2>...</hi>空格要處理 ????
        string tagHi(XmlNode node)
        {
            string sHtml = "";
            string sRend = GetAttr(node, "rend");
            string sStyle = GetAttr(node, "style");
            string sStyleClass = getStyleClass("", sStyle, sRend);
            if (sStyleClass != "") {
                sHtml += $"<span{sStyleClass}>";
            }
            sHtml += parseChild(node); // 處理內容
            if (sStyleClass != "") {
                sHtml += "</span>";
            }
            return sHtml;
        }

        string tagItem(XmlNode node)
        {
            string sHtml = "";

            ItemNum[ListCount]++;

            // 先看其前是不是 lb, list, head.

            string sPreNodeName = "";
            string sPreChildNodeName = "";

            XmlNode PreNode = node.PreviousSibling;
            if (PreNode != null) {
                sPreNodeName = PreNode.Name;

                XmlNode PreChildNode = PreNode.LastChild;
                if (PreChildNode != null) {
                    sPreChildNodeName = PreChildNode.Name;
                }
            }

            // 這是在 item 之間空格用的, 原本 item 在第一個或行首才要依 list 的層次來空格
            // 但若它前一層有 list, 則空格也要依原來的層次.
            // 就類似 <I5>.....<I6>....<I5> , 則 <I5> 也要空5格.
            // 實例 X26n0524.xml <lb ed="X" n="0633a23"/>

            string sRend = GetAttr(node, "rend");
            string sStyle = GetAttr(node, "style");

            CRendAttr myRend = new CRendAttr(sRend);
            CStyleAttr myStyle = new CStyleAttr(sStyle);

            string sOldMarginLeft = MarginLeft;     // 記錄舊的 MarginLeft
            string sTextIndentSpace = "";   // 要空的空格

            int iMarginLeft = 0;
            int iTextIndent = 0;

            if (sStyle != "") {
                iMarginLeft = myStyle.MarginLeft;
                iTextIndent = myStyle.TextIndent;

                sTextIndentSpace = StringRepeat("　", iMarginLeft);
                MarginLeft += sTextIndentSpace;   // 這是第二行之後要空的

                // 有 TextIndent 就依自己的 TextIndent，不然就依上層的 ListTextIndent
                if (myStyle.HasTextIndent) {
                    sTextIndentSpace += StringRepeat("　", iTextIndent);
                } else {
                    sTextIndentSpace += ListTextIndent;
                }
            }

            // 原書格式的空白

            //if(Setting.CutLine)	// 大正藏切行
            {
                string sItemId = GetAttr(node, "xml:id");

                // 第一個, 或在行首, 就要依 list 數量 * 2 來空格
                if (ItemNum[ListCount] == 1 || sPreNodeName == "lb" || sPreChildNodeName == "list") {
                    //itemX63p0502b0319 是特例
                    // 在切換校注呈現時如何處理? 待研究 ????
                    //if(Setting.CorrSelect == 0 && sItemId == "itemX63p0502b0319"){}
                    //else

                    if (Setting.ShowLineFormat && !InNoteOrig && !InNoteMod && !InNoteAdd) {
                        sHtml += "<span class='line_space'>" + sTextIndentSpace + StringRepeat("　", ListCount * 2) + "</span>";
                    } else {
                        sHtml += "<span class='line_space' style='display:none'>" + sTextIndentSpace + StringRepeat("　", ListCount * 2) + "</span>";
                    }
                } else {
                    // 這幾組在呈現修訂用字時不空格
                    // 在切換校注呈現時如何處理? 待研究 ????
                    /*
                    if(Setting.CorrSelect == 0)
                    {
                        if(sItemId.SubString(1,7) == "itemX63")
                        {
                            if     (sItemId == "itemX63p0416b1820") {}
                            else if(sItemId == "itemX63p0445c0619") {}
                            else if(sItemId == "itemX63p0448b0220") {}
                            else if(sItemId == "itemX63p0450b1619") {}
                            else if(sItemId == "itemX63p0452a2319") {}
                            else if(sItemId == "itemX63p0452b0619") {}
                            else if(sItemId == "itemX63p0453b1820") {}
                            else if(sItemId == "itemX63p0455b1019") {}
                            else if(sItemId == "itemX63p0456b1319") {}
                            else if(sItemId == "itemX63p0456c1119") {}
                            else if(sItemId == "itemX63p0456c1320") {}
                            else if(sItemId == "itemX63p0456c2020") {}
                            else if(sItemId == "itemX63p0457b0919") {}
                            else if(sItemId == "itemX63p0457b1020") {}
                            else if(sItemId == "itemX63p0457b1520") {}
                            else if(sItemId == "itemX63p0468c2329") {}
                            else if(sItemId == "itemX63p0469a0337") {}
                            else if(sItemId == "itemX63p0474a0320") {}
                            else if(sItemId == "itemX63p0474a0719") {}
                            else if(sItemId == "itemX63p0474a1320") {}
                            else if(sItemId == "itemX63p0488a0919") {}
                            else if(sItemId == "itemX63p0488a1320") {}
                            else if(sItemId == "itemX63p0489a0520") {}
                            else if(sItemId == "itemX63p0489a0819") {}
                            else if(sItemId == "itemX63p0489c2420") {}
                            else if(sItemId == "itemX63p0490a2219") {}
                            else if(sItemId == "itemX63p0492c1019") {}
                            else if(sItemId == "itemX63p0493a1019") {}
                            else if(sItemId == "itemX63p0502a0919") {}
                            else if(sItemId == "itemX63p0502a1519") {}
                            else if(sItemId == "itemX63p0502b0319") {}
                            else if(sItemId == "itemX63p0505b0120") {}
                            else if(sItemId == "itemX63p0508c0220") {}
                            else if(sItemId == "itemX63p0508c1319") {}
                            else sHtml += "　";  // 行中的 item 只空一格
                        }
                        else sHtml += "　";  // 行中的 item 只空一格
                    }
                    else
                    */
                    if (Setting.ShowLineFormat && !InNoteOrig && !InNoteMod && !InNoteAdd) {
                        sHtml += "<span class='line_space'>　</span>";  // 行中的 item 只空一格
                    } else {
                        sHtml += "<span class='line_space' style='display:none'>　</span>";  // 行中的 item 只空一格
                    }
                }
            }

            // <li...>

            if (Setting.ShowLineFormat && !InNoteOrig && !InNoteMod && !InNoteAdd) {
                string sNewStyle = myStyle.sTextIndent + myStyle.NewStyle;
                if (sNewStyle.Length > 0) {
                    sNewStyle = $" style='{sNewStyle}'";
                }
                string sNewClass = myRend.NewClass;
                if (sNewClass.Length > 0) {
                    sNewClass = $" class='{sNewClass}'";
                }

                sHtml += $"<span{sNewStyle}{sNewClass}";
                if (myStyle.HasMarginLeft) {
                    sHtml += "' data-margin-left='";
                    sHtml += iMarginLeft.ToString();
                    sHtml += "em'";
                }
                sHtml += " data-tagname='li'>";
            } else {
                string sNewStyle = myStyle.sMarginLeft + myStyle.sTextIndent + myStyle.NewStyle;
                if (sNewStyle.Length > 0) {
                    sNewStyle = $" style='{sNewStyle}'";
                }
                string sNewClass = myRend.NewClass;
                if (sNewClass.Length > 0) {
                    sNewClass = $" class='{sNewClass}'";
                }

                sHtml += $"<li{sNewStyle}{sNewClass}";
                if (myStyle.HasMarginLeft) {
                    sHtml += "' data-margin-left='";
                    sHtml += iMarginLeft.ToString();
                    sHtml += "em'";
                }
                if (!InNoteOrig && !InNoteMod && !InNoteAdd) {
                    sHtml += " data-tagname='li'>";
                } else {
                    sHtml += ">";
                }
            }


            //if (myRend.NewStyle != "" || myStyle.NewStyle != "") {
            //    sHtml += "<span style='" + myRend.NewStyle + myStyle.NewStyle + "'>";
            //}

            // item 的屬性要印出來 , <list xml:lang="sa-Sidd" type="ordered">
            //                         <item n="（一）" xml:id="itemT18p0087a1401">....
            string sN = GetAttr(node, "n");
            if (sN != "") {
                sHtml += sN;
            }

            // -----------------------------------
            sHtml += parseChild(node); // 處理內容
            // -----------------------------------

            //if (myRend.NewStyle != "" || myStyle.NewStyle != "") {
            //    sHtml += "</span>";
            //}
            if (Setting.ShowLineFormat && !InNoteOrig && !InNoteMod && !InNoteAdd) {
                sHtml += "</span>";
            } else {
                sHtml += "</li>";
            }

            MarginLeft = sOldMarginLeft;
            return sHtml;
        }

        // <cb:juan n="001" fun="open"><cb:mulu n="001" type="卷"></cb:mulu><cb:jhead><title>雜阿含經</title>卷第一</cb:jhead></cb:juan>
        // T03n0158 : <lb n="0240a07" ed="T"/>尼。</p><cb:juan n="001" fun="close" place="inline">
        string tagJuan(XmlNode node)
        {
            string sHtml = "";
            sHtml = "<span class='juanname'>";
            string sPlace = GetAttr(node, "place");
            if (sPlace == "inline") {
                if (Setting.ShowLineFormat) {
                    sHtml += "<span class='line_space'>　</span>";
                } else {
                    sHtml += "<span class='line_space' style='display:none'>　</span>";
                }
            }
            sHtml += parseChild(node); // 處理內容
            sHtml += "</span>";
            return sHtml;
        }

        // <lg><l>無上二足尊<caesrua/>照世大沙門</l>  (2020/06 新的)
        // <lg><l>無上二足尊</l><l>照世大沙門</l>  (舊的)

        // <lg style=... type=...>
        //   style="margin-left:1;text-indent:0" : 表示整段偈誦都會在行首空一格

        //	 2020/06 沒有 type="normarl" 和 "abnormal" 了
        //   type="normal" (預設): 第一個 <l> 不空格, 其餘 <l> 空二格, 有 style 的 <l> 依 style 處理.
        //   type="abnormal" : <l> 皆不空格, 有 style 的 <l> 依 style 處理.

        //   若沒設 type , 一律預設為 normal ,
        //   若沒設 style , type="normal" 時, 預設為 style="margin-left:1",
        //                 type="abnormal" 時, 預設 style="margin-left:0",

        //   若 place="inline", 沒指定 style , 且 <lg> 前面的文字不是空格時, 則自動加一個空格.

        //   <l> 的 style 不論是 margin-left:1 或是 text-indent:1 , 一律當成 text-indent:1 處理. 前者是為了相容舊版的.

        // 2020/06 最新 lg 空格參考 tag_lg 的說明, lg 的 margin-left 在段落模式要在 l 處理
        string tagL(XmlNode node)
        {
            string sHtml = "";

            // LTagNum++;					// 若是第一個, 只空一格

            // LMarginLeft = "";           // l 整段要空的格
            string sLTextIndent = "";   // l 開頭要空的格

            int iMarginLeft = 0;
            int iTextIndent = 0;
            //bool bHasRend = false;	// 若有 rend 就不使用預設的空格
            // 檢查移位 <l rend="margin-left:1">

            string sStyle = GetAttr(node, "style");
            string sRend = GetAttr(node, "rend");
            CStyleAttr myStyle = new CStyleAttr(sStyle);
            CRendAttr myRend = new CRendAttr(sRend);

            if ((myStyle.HasMarginLeft || myStyle.HasTextIndent)
                && !(!Setting.ShowPunc && LgNormal)      //若不秀標點且是標準格式, 就不依 style
                && !(Setting.NoShowLgPunc && LgNormal)) {  //若在偈頌中且偈頌不秀新標
                //bHasRend = true;
                iMarginLeft = myStyle.MarginLeft;
                iTextIndent = myStyle.TextIndent;

                // l 標記應該不處理 LgMarginLeft 比較好吧
                //if(iMarginLeft)
                //	LgMarginLeft += string::stringOfChar('　',myRend.MarginLeft);  // lg 整段要空的格
            }

            //if(LTagNum == 1)
            {
                //if(!Setting.CutLine)
                {
                    // 因為 IsFindLg 是判斷 <l> 是不是第一個, 若是就不空格, 但有一種是 <lg><head>...</head><l> ,
                    // 所以在 head 就會取消 IsFindLg , 這也不算第一個 <l> 才不會有
                    // OK
                    //T10n0297_p0881b18║　圓寂宮城門　　能摧戶扇者
                    //T10n0297_p0881b19║　諸佛法受用　　救世我頂禮
                    //T10n0297_p0881b20║　自手流清水　　能除餓鬼渴
                    // no ok
                    //圓寂宮城門　　能摧戶扇者
                    //　諸佛法受用　　救世我頂禮
                    //　自手流清水　　能除餓鬼渴

                    // lg 之後的第一個 <l> , 不處理空格, 都由 lg 處理了
                    // 之後每行第一個 <l> 都要先印出整段偈頌要空的空格
                    if (IsFindLg) {
                        IsFindLg = false;
                    } else {
                        // 在 2016 之前, 標準或非標準的偈頌, 不依原書時, 第一個 <l> 都會折行.
                        // 目前的新規則, 只要是不依原書, 非標準偈頌, 且有設定 Setting.LgType = 1 ,
                        // 就不折行. 不過這只限在 GA 及 GB, 因為舊的經文還是折行較好

                        // 也就是 【GA 或 GA 的非標準偈頌不折行】, 否則就折行
                        // if(!(LgNormal == false && (BookId == "GA" || BookId == "GB")))
                        {
                            // 偈頌折行
                            if (Setting.ShowLineFormat) {
                                sHtml += "<span class='para_br' data-tagname='br'></span>";
                            } else {
                                sHtml += "<br class='para_br' data-tagname='br'/>";
                            }

                            // lg 空格在段落模式時, 由 l 處理, 行模式才由 lb 處理
                            sHtml += "<span class='para_space'>" + LgMarginLeft + "</span>";
                        }

                        // x 標準偈頌時, 整段的空格由 <l> 處理, 因為 <l> 會折行, 要折行後才能空
                        // x 非標準偈頌, 則由 <lb> 去空

                        // 因為 2020/06 不再區分有沒有 normal 了, 所以整段偈頌都要用 lb 去空
                        // if(LgNormal) sHtml += LgMarginLeft;	// 整段偈頌要空的空格
                    }
                }
            }

            // l 本身要空的格
            sHtml += StringRepeat("　", iMarginLeft + iTextIndent);

            sHtml += "<span" + getStyleClass("", myStyle, myRend) + ">";

            // -----------------------------------
            sHtml += parseChild(node); // 處理內容
            // -----------------------------------

            sHtml += "</span>";
            // LMarginLeft = "";

            return sHtml;
        }

        // <lb>
        // <lb n="0150b09" ed="T"/>
        // 有二種情況要忽略
        // 1. 卍續藏有二種 lb , ed 不是 "X" 的要忽略 : <lb ed="R150" n="0705a03"/>
        // 2. 印順導師也有二種 lb , type="old" 要忽略 : <lb n="a003a06" ed="Y" type="old"/>
        string tagLb(XmlNode node)
        {
            string sHtml = "";

            // 取出屬性
            string sType = GetAttr(node, "type");
            string sEd = GetAttr(node, "ed");
            string sN = GetAttr(node, "n");

            // Debug

            if (sN == "0012a12") {
                int deb = 10;
                deb++;
                IsDebug = true;
            }

            // 印順導師著作有 type="old" 要忽略
            if (sType == "old") {
                return "";
            }

            // 卍續藏有 R 版的 lb <lb ed="R031" n="0622a03"/>
            // 轉成 <span class='xr_head' data-linehead='R031p0622a03'></span>

            if (BookId == "X" && sEd[0] == 'R') {
                sHtml = "<span class='xr_head' data-linehead='" + sEd +
                  "p" + sN + "'></span>";
                return sHtml;
            }

            // 如果 ed 屬性不是本書, 則忽略, 主要是卍續藏是 X, 但有 ed="Rxxx" 的情況
            if (sEd != BookId) {
                return "";
            }

            // 因為換行了, 所以隔行對照一定要輸出, 因為有時還在 <t> 當中. 所以 NextLine.InNextLine要先清除, 例如: T18n0864A.xml
            // <lb n="0200a22"/><p type="dharani">....<tt><t lang="san-sd">&SD-E040;</t><t lang="chi"><yin><zi>南</zi><sg>引</sg></yin></t></tt><tt><t lang="san-sd">&SD-DA42;</t><t lang="chi">唵<note place="inline">若有祈請所求一切事者
            // <lb n="0200a23"/>
            // <lb n="0200a24"/>於此應加孔雀王陀羅尼</note></t></tt><tt><t lang="san-sd">&SD-E0EF;</t><t lang="chi"><yin><zi>部嚕唵</zi><sg>三合</sg></yin></t></tt></p>
            // <lb n="0200a25"/>

            bool bTmp = NextLine.InNextLine;
            NextLine.InNextLine = false;
            NextLine.IsOutput = true;           // 表示所有的隔行對照都可以輸出了

            // 若有隔行對照, 則要將先將上行的印出來

            if (NextLine.ThisLine != "") {
                if (Setting.ShowLineFormat) {
                    sHtml += "<span class='para_br' data-tagname='br'></span>"; // 原書切行
                } else {
                    sHtml += "<br class='para_br' data-tagname='br'/>"; // 原書切行
                }
                sHtml += NextLine.ThisLine;
                NextLine.ThisLine = "";
            }

            //LTagNum = 0;		// 還原 <l> 的數目, 要來判斷要不要折行或空格數目

            // 判斷要不要強迫切行
            // <lb ed="X" n="0070b01" type="honorific"/><lb ed="R150" n="0706a17"/>御製序文。闡揚宗淨合一之旨。
            // <lb ed="X" n="0070b02" type="honorific"/><lb ed="R150" n="0706a18"/>高宗純皇帝南巡。親詣雲棲。拈香禮佛。

            bool bForceCutLine = false;     // 強迫切行
            if (sType == "honorific") {
                bForceCutLine = true;
            }
            // 判斷此行是不是空白行
            bool bNoLineData = false;
            XmlNode NextSiblNode = GetNextSiblNode(node);
            string sNextSiblNodeName = "";
            if (NextSiblNode != null) {
                XmlNodeType nodetype = NextSiblNode.NodeType;

                if (nodetype == XmlNodeType.Text) { // 這是純 data
                    if (NextSiblNode.Value == "\n") {
                        // 可能空白行, 往下查是不是 lb 標記

                        XmlNode NextSiblNode2 = GetNextSiblNode(NextSiblNode);  // 取得下一層

                        if (NextSiblNode2 != null) {
                            nodetype = NextSiblNode2.NodeType;
                            if (nodetype == XmlNodeType.Element) {     // 這是純 element
                                string sNextSiblNode2Name = NextSiblNode2.Name;
                                if (sNextSiblNode2Name == "lb" || sNextSiblNode2Name == "pb") {
                                    bNoLineData = true;
                                }
                            }
                        }
                    }
                } else if (nodetype == XmlNodeType.Element) {  // 這是純 element
                    sNextSiblNodeName = NextSiblNode.Name;
                    if (sNextSiblNodeName == "lb" || sNextSiblNodeName == "pb") {
                        bNoLineData = true;
                    }
                }
            }

            // 原書格式會看到的行首空白
            string sSpace;
            //if(LgNormal)
            //	sSpace = MarginLeft;	// + LgMarginLeft + LMarginLeft; 這些留在 <l> 才空格
            //else
            // 行模式 LgMarginLeft 一律在 lb 處理了
            // 因為 2020/06 已經沒有 abnormal 區別, 而 l 不一定在行首, 所以用 lb 處理
            // 詳細見 tag_lg 的說明
            sSpace = MarginLeft + LgMarginLeft; // + LMarginLeft;

            {
                if (InByline) {
                    sSpace += "　　　　";   // 譯者
                }
                if (FuWenCount > 0 && !bNoLineData) {
                    sSpace += "　";          // 附文
                }
                if (InSutraNum) {
                    sSpace += "　　";     // 經號
                }

                if (InPinHead || InFuWenHead || InOtherHead || InHead) {    // 品名, 附文標題, 其它標題
                    if (DivCount == 0 || DivCount % 3 == 1) {
                        sSpace += "　　";
                    } else if (DivCount % 3 == 2) {
                        sSpace += "　　　";
                    } else if (DivCount % 3 == 0) {
                        sSpace += "　　　　";
                    }
                }

                // 下一個不是 list 或 item 才要空 item 的空格
                if (ListCount > 0 && sNextSiblNodeName != "list" && sNextSiblNodeName != "item") {
                    sSpace += StringRepeat("　", ListCount * 2);    // Item 的空格
                }
            }

            // 產生行首資訊

            PageLine = sN;
            LineHead = BookVolnSutra + "p" + PageLine + "║";
            if (PreFormatCount > 0 || bForceCutLine) {   // 強迫指定依原書
                sHtml += "<br/>";
            } else if (NextLine.NextLine != "") {   // 隔行對照, 所以要 <br>
                sHtml += "<br/>";
            } else {
                if (Setting.ShowLineFormat) {
                    sHtml += "<br class='lb_br' data-tagname='br'/>";
                } else {
                    sHtml += "<span class='lb_br' data-tagname='br'></span>";
                }
            }

            sHtml += "<a \nname='p" + PageLine + "'></a>";
            if (Setting.ShowLineHead && Setting.ShowLineFormat) {
                sHtml += "<span class='linehead'>";
            } else {
                sHtml += "<span class='linehead' style='display:none'>";
            }
            sHtml += LineHead + "</span>";

            // 加入品資料, 引用複製會用到
            // 待處理: 引用複製在品的位置也要處理 ????

            //if(MuluLabel != "")
            // T21n1251_p0233a27 有品名有缺字造成的問題, 待處理 ????
            //sHtml += "<a pin_name='" + MuluLabel + "'></a>";

            // 印出行首空格

            // 2018/07/28 強迫切行後, 空格也不一定要呈現, 例如
            // <item><p type=pre>xxxxx
            // item 本身就會縮排, 下一個 lb 若再空二格, 就會多出空格了,
            // 所以底下三行移除
            //if(PreFormatCount || bForceCutLine) // 強迫指定依原書就不輸 span 標記
            //	sHtml += sSpace;
            //else
            {
                if (sSpace != "") {
                    if (Setting.ShowLineFormat) {
                        sHtml += "<span class='line_space'>" + sSpace + "</span>";
                    } else {
                        sHtml += "<span class='line_space' style='display:none'>" + sSpace + "</span>";
                    }
                }
            }

            // 若有隔行對照, 則要將將下一行的印出來

            if (NextLine.NextLine != "") {
                sHtml += NextLine.NextLine;
                NextLine.NextLine = "";
            }

            NextLine.InNextLine = bTmp;

            // sHtml += parseChild(node); // 處理內容

            return sHtml;
        }

        /*
        <note n="0001002" resp="Taisho" type="orig" place="foot text">〔長安〕－【宋】</note>
        <note n="0001002" resp="CBETA" type="mod">長安【大】，〔－〕【宋】</note>
        <app n="0001002">
	        <lem wit="【大】">長安</lem>
	        <rdg resp="Taisho" wit="【宋】"><space quantity="0"/></rdg>
        </app>

        XML 原始標記  : <lem wit="【大】">長安</lem>
        HTML 經文轉成 : 長安
        HTML 校注轉成 : <div type="lem" data-wit="【大】">長安</div>

        有原始版的 lem 或 rdg 還要轉出一行, 讓 javascript 好處理
				        <div type="orig">XXX</div>

        若選擇原書, lem 的 wit 有【大】(或其他藏經的原書版本), 則呈現 lem 的內容.
			        lem 的 wit 沒有【大】(或其他藏經的原書版本), 則不呈現 lem 的內容, 等 rdg .
        若選擇CBETA 版, 則呈現 lem 的內容, 因為若有 CB 版, 一定在 lem 中.

        */
        string tagLem(XmlNode node)
        {
            string sHtml = "";

            string sWit = GetAttr(node, "wit");

            bool bShowLemText = true;
            bool bLemIsOrig = false;   // 判斷 lem 是否是原始校注

            if (sWit.IndexOf(BookVerName) >= 0) {
                bLemIsOrig = true;
            }

            // 選擇原書校注, 但 lem 不是原始校注, 就不呈現文字
            if (Setting.CollationType == ECollationType.Orig) {
                if (bLemIsOrig == false) {
                    bShowLemText = false;
                }
            }

            string NoteCFOld = NoteCF;
            NoteCF = "";    // 先清空
            string sLemText = parseChild(node); // 處理內容

            if (bShowLemText) {
                sHtml += sLemText;
            }

            // 記錄到校注區

            // 有些有 type 屬性要處理 : T18n0848 : <rdg resp="Taisho" wit="【丙】" type="variantRemark">乘</rdg>
            // ???? (lem , rdg 都要處理, 但大概是呈現全部校注文字的表格才會用上吧)

            string sLemTag = "";
            if (bLemIsOrig) {
                // <div type="orig">大正原版</div>
                sLemTag += "\t<div type='orig'>" + sLemText + "</div>\n";
            }

            sLemTag += "\t<div type='lem' data-wit='" +
                            sWit + "'>" + sLemText + "</div>\n";

            HTMLCollation += sLemTag;

            // 處理 NoteCF
            // <lem> 裡面有 <note type="cf1">XXX</note><note type="cf2">YYY</note>
            // NoteCF = "XXX; YYY; "
            // 移掉最後的 "; "
            // 在標記加入 <div type='cf'>XXX; YYY</div>

            if (NoteCF != "") {
                NoteCF = NoteCF.Substring(0, NoteCF.Length - 2);
                string sNoteCFTag = $"\t<div type='cf'>{NoteCF}</div>\n";
                HTMLCollation += sNoteCFTag;
            }
            NoteCF = NoteCFOld;
            return sHtml;
        }


        // <lg><l>無上二足尊</l><l>照世大沙門</l>

        // <lg rend=... type=...>
        //   rend="margin-left:1;text-indent:0" : 表示整段偈誦都會在行首空一格

        //   type="normal" (預設): 第一個 <l> 不空格, 其餘 <l> 空二格, 有 rend 的 <l> 依 rend 處理.
        //   type="abnormal" : <l> 皆不空格, 有 rend 的 <l> 依 rend 處理.

        //   若沒設 type , 一律預設為 normal ,
        //   若沒設 rend , type="normal" 時, 預設為 rend="margin-left:1",
        //                 type="abnormal" 時, 預設 rend="margin-left:0",

        //   若 place="inline", 沒指定 rend , 且 <lg> 前面的文字不是空格時, 則自動加一個空格.

        //   <l> 的 rend 不論是 margin-left:1 或是 text-indent:1 , 一律當成 text-indent:1 處理. 前者是為了相容舊版的.

        // 新標的處理法 : (2007/10/03)
        //   不呈現標點時, 在 typle=normal 的情況下, 忽略 lg 與 l 的 rend 屬性, 因為 rend 會因為新標的引號而調整. 故不呈現時就不要處理.
        //   呈現標點時, 也可以選擇偈頌不呈現標點, 這時只忽略標點, 但不忽略上下引號, 這樣比較好看.

        /* 空格處理法

        整個偈頌都要空的假設為Ｌ

        目前的設計是 lb 之後不要空，等標準偈頌遇到第一個 <l> 才空，如下所示

        <lb><l>ＬｘｘｘｘＬＬｘｘｘｘ

        為什麼不在 <lb> 之後就空呢? 因為在段落模式，<lb> 沒有換行，而 <l> 才有換行效果，
        所以空格要在 <l> 之後，才不會先空格再換行，就白空了。

        至於非標準偈頌 , 又分成二種：

        1. 原書格式 : lb 之後就要空出整段的 , 多行的偈頌才會整齊

        <lb>ＬＬＬxxxxxxxx
        <lb>ＬＬＬxxxxxxxx
        <lb>ＬＬＬxxxxxxxx

        2. 段落格式

        整段的空格用 <p style="margin:3em"> 來控制

        行首的Ｌ在段落模式會隱藏，<p> 在原書模式也會消失作用。

        2018註 : 底下這一段怪怪的, 不看好了
            // 2016 的新作法:
            // 原本整段的空格是用空格. 例如 : <lg rend="margin-left:1"> , 2014 之前的版本是每一行前面都加上一個空格. 不過折行就不會空格了.
            // 2016 就改成用段落 <p class="lg" style="margin-left:1em;"> , 因此每一行前面就不用加空格.
            // 不過因此 copy 再貼在純文字, 就會少了行首的空格.
            // 至於引用複製, 就要在原本行首的空格加上 <span data-space="1"> 表示空一格, 到時再用引用複製來還原一個空格.
        */

        /*
        2020/06 之後最新的 lg 空格處理

        lg-m : lg 的 mragin-left
        標準 : lg type="normal" (default)
        非標 : lg type="abnormal"
        line : 原書行模式
        para : 段落模式

        2020/06 之前的 lg margin 的空格方式：

        標準 line : lg-m 在第一個 l 空 (不能在 lb 空, 因為 l 在 para 會換行, 空格會在 l 之前)
        標準 para : lg-m 在第一個 l 空 (不能在 lb 空, 因為 l 在 para 會換行, 空格會在 l 之前)
        非標 line : lg-m 在 lb 空 (para 看不到)
        非標 para : lg-m 用 p 段落處理 (line 看不到)

        ========================================

        2020/06 沒有標準或非標準(abnormal) 的區別了

        標準 line : lg-m 在 lb 空 (para 看不到, 不能在 l 空, 因為 l 不一定在行首)
        標準 para : lg-m 在 l 空 (line 看不到)

        */
        string tagLg(XmlNode node)
        {
            string sHtml = "";

            IsFindLg = true;            // 一遇到 <lg> 就 true, 第一個 <l> 就會處理並設為 false;
            InLg = true;                // 判斷是不是在 <lg> 之中, 主要是用來處理偈頌中的標點要不要呈現.
            LgNormal = true;            // 預設值, 因為有些舊的 xml 沒有 <lg type=normal>
            LgInline = false;           // lg 的 place 是不是 inline?
            LgMarginLeft = "";          // lg 整段要空的格
            //LTagNum = 0;		        // 還原 <l> 的數目, 要來判斷要不要折行或空格數目

            bool bHasStyle = false;     // 先假設沒有 rend 屬性
            string sLgTextIndent = "";  // lg 開頭要空的格
            bool bIsNote = false;       // 若 type 是 note1 or note2 , 則偈誦前後要加小括號

            // 先處理 type 屬性

            string sType = GetAttr(node, "type");
            string sSubType = GetAttr(node, "subtype");
            string sPlace = GetAttr(node, "cb:place");
            string sRend = GetAttr(node, "rend");
            string sStyle = GetAttr(node, "style");

            CRendAttr myRend = new CRendAttr(sRend);
            CStyleAttr myStyle = new CStyleAttr(sStyle);

            //if(sType == "normal") LgNormal = true;		// lg 的 type 是 normal
            //if(sType == "abnormal") LgNormal = false;    // 因為舊版有 type=inline
            if (sSubType == "note1" || sSubType == "note2") {   // 在偈誦前後要加小括號
                //LgNormal = true;
                bIsNote = true;
            }

            // 處理 place="inline"
            // V2.0 之後, 由 type=inline 改成 cb:place=inline

            if (sPlace == "inline") {           // 行中段落加句點
                LgInline = true;
                //LgNormal = false;
            }

            // 再處理 style 屬性

            int iMarginLeft = 1;
            int iTextIndent = 0;
            // 檢查移位 <lg style="margin-left:1">
            if ((myStyle.HasMarginLeft || myStyle.HasTextIndent)
                && !(!Setting.ShowPunc && LgNormal)    //若不秀標點且是標準格式, 就不依 style
                && !(Setting.NoShowLgPunc && LgNormal)) {     // 若在偈頌中且偈頌不秀新標
                bHasStyle = true;

                // 若沒有設 MarginLeft，則預設是 1
                if (myStyle.HasMarginLeft) {
                    iMarginLeft = myStyle.MarginLeft;
                }
                iTextIndent = myStyle.TextIndent;

                // lg 整段要空的格
                LgMarginLeft = StringRepeat("　", iMarginLeft);
            } else {
                if (LgNormal) {
                    iMarginLeft = 1;
                    LgMarginLeft = "　"; // 非 normal 的可能是 inline, 不一定要空格
                }
            }

            // 開頭要空的格
            sLgTextIndent = StringRepeat("　", iMarginLeft + iTextIndent);

            if (LgInline && LgMarginLeft == "" && !bHasStyle) { // 即在行中, 又沒有空白, 前一個字也不是空白時, 就加上空白
                // 檢查前一個字是不是空格?
                // 先不管了, 一律加上空格 ????
                if (Setting.ShowLineFormat) {
                    sHtml += "<span class='line_space'>　</span>";
                } else {
                    sHtml += "<span class='line_space' style='display:none'>　</span>";
                }
            }

            if (LgNormal) {
                // 標準偈頌, 完全利用空格來處理, 不由 <p> 來控制縮排, copy 才會好看
                if (Setting.ShowLineFormat) {
                    sHtml += "<span data-tagname='p'";
                } else {
                    sHtml += "<p data-tagname='p'";
                }

                // 處理 style and class

                sHtml += getStyleClass("", myStyle, myRend);

                sHtml += ">";
                sHtml += sLgTextIndent;
            } else {
                // ==============================================
                // 沒有 abnormal 這種格式了, 所以底下不會再使用了
                // ==============================================

                // 如果是不依原書, 且不是 normal 偈頌, 且指定用段落的方式 (LgTYpe = 1), 則處理成 <p style="margin-left::2em;text-indent:xxem;"><lg class="lg"> 這種格式
                if (iMarginLeft != 0 || iTextIndent != 0) {
                    if (Setting.ShowLineFormat) {
                        sHtml += "<span style='";
                        if (iTextIndent != 0) {
                            sHtml += $"text-indent:{iTextIndent}em;";
                        }
                        sHtml += myStyle.NewStyle;
                        sHtml += "'";
                        if(myRend.NewClass != "") {
                            sHtml += $" class='{myRend.NewClass}'";
                        }
                        if (iMarginLeft != 0) {
                            sHtml += $" data-margin-left='{iMarginLeft}em'";
                        }
                        sHtml += " data-tagname='p'>";

                        sHtml += "<span class='line_space'>";
                        sHtml += sLgTextIndent;
                        sHtml += "</span>";
                    } else {
                        sHtml += "<p style='";
                        if (iMarginLeft != 0) {
                            sHtml += "margin-left:";
                            sHtml += iMarginLeft.ToString();
                            sHtml += "em;";
                        }
                        if (iTextIndent != 0) {
                            sHtml += "text-indent:";
                            sHtml += iTextIndent.ToString();
                            sHtml += "em;";
                        }
                        sHtml += myStyle.NewStyle;
                        sHtml += "'";
                        if (myRend.NewClass != "") {
                            sHtml += $" class='{myRend.NewClass}'";
                        }
                        if (iMarginLeft != 0) {
                            sHtml += " data-margin-left='";
                            sHtml += iMarginLeft.ToString();
                            sHtml += "em'";
                        }
                        sHtml += " data-tagname='p'>";

                        sHtml += "<span class='line_space' style='display:none'>";
                        sHtml += sLgTextIndent;
                        sHtml += "</span>";
                    }
                } else {
                    if (Setting.ShowLineFormat) {
                        sHtml += "<span data-tagname='p'";
                    } else {
                        sHtml += "<p data-tagname='p'";
                    }

                    // 處理 style
                    sHtml += getStyleClass("", myStyle, myRend);
                    sHtml += ">";
                }
            }

            sHtml += "<span class='lg'";// 偈頌折行
            if (!bIsNote) {
                sHtml += ">";
            } else {
                // type 是 note1 or note2 要在偈誦前後要加括號以及變成小字
                sHtml += " style='font-size:18px;'>(";
            }

            // -----------------------------------
            sHtml += parseChild(node); // 處理內容
            // -----------------------------------

            InLg = false;               // 判斷是不是在 <lg> 之中, 主要是用來處理偈頌中的標點要不要呈現.
            LgMarginLeft = "";
            if (bIsNote) {
                sHtml += ")";
            }
            sHtml += "</span>";
            if (Setting.ShowLineFormat) {
                sHtml += "</span>";
            } else {
                sHtml += "</p>";
            }
            return sHtml;
        }

        /* list 規則 :

	        1.遇到 list , 如果之後是 head , 則在 head 之後, 才加上 <ul>, 否則直接加上 <ul>
	        2.<item> 換成 <li>, </item> 換成 </li>
	        3.</list> 換成 </ul>

        <list><head>卷第二</head>
        <item xml:id="itemX78p0575a1401">臨濟宗</item>
        <item xml:id="itemX78p0575a1401"><list><head>臨濟宗</head>
        <item xml:id="itemX78p0575a1501">臨濟慧照禪師</item>
        <item xml:id="itemX78p0575a1507">興化獎禪師</item>
        <item xml:id="itemX78p0575a1601">南院顒禪師</item></list></item></list>

        卷第二
        <ul>
          <li>臨濟宗</li>
          <li>臨濟宗
            <ul>
              <li>臨濟慧照禪師</li>
              <li>興化獎禪師</li>
              <li>南院顒禪師</li>
            </ul>
           </li>
        </ul>

        <lb ed="X" n="0418a36"/><item xml:id="itemX86p0418a3601">中梁山崇</item>
        <lb ed="X" n="0418a37"/><item xml:id="itemX86p0418a3701">南臺勤
        <lb ed="X" n="0418a38"/><list><item xml:id="itemX86p0418a3801">石霜節誠
        <lb ed="X" n="0418a39"/><list><item xml:id="itemX86p0418a3901">岳麓珪</item></list></item>
        <lb ed="X" n="0418a40"/><item xml:id="itemX86p0418a4001">高陽法廣</item></list></item>

        依原書格式呈現 :

        行首 <list> : 不理
        行首 <item> : 依 <list> 的層數來空格, 第一個空一格, 第二個空二格....
        行中 <list> : 不理
        行中 <item> : 第一個 item 依 list 的層數來空格, 第二個之後一律空一格.
        <lb> 要依 list 留空白, 除非其後是 <list> 或 <item>

        如果 list 或 item 有用 margin-left 和 text-indent 指定空格，就依指定的空格處理。

        margin-left 是 list 和 item 加起來的。
        如果 list 和 item 同時都有 text-indent，則忽略 list 的 text-indent，以 item 的 text-indent 為主。
        
        margin-left 和 text-indent 預設都是 0，在 BM 就是每一層會加二個空格，
        所以 margin-left 為 1 就表示會空 3 格。

        當第一層的 text-indent > 0 時，底下還有多層 list 時，
        只有最後一層的 list 才會受到 text-indent 的影響，這個規則不好捉，
        BM 採取不記錄上層 list 或 item 的 text-indent，請小心。

        */

        string tagList(XmlNode node)
        {
            string sHtml = "";

            ListCount++;
            ItemNum[ListCount] = 0; // 歸零

            bool bHasHead = false;

            // 看看下一個是不是 <head>
            if (node.HasChildNodes) {
                XmlNode ChildNode = node.FirstChild;

                if (ChildNode.Name == "head") {
                    // 第一個 list 才要切斷, 不然 a06 的卷第一不會換行
                    // <lb ed="X" n="0575a04"/><div1 type="other"><mulu type="其他" level="1" label="希叟和尚正宗贊目錄"/><head>希叟和尚正宗贊目錄</head>
                    // <lb ed="X" n="0575a05"/>
                    // <lb ed="X" n="0575a06"/><list><head>卷第一</head>
                    if (ListCount == 1) {
                        // 好像不需要了
                        //sHtml += "<br class='para_br'/><br class='para_br'/>";     // 第一層才要
                    }
                    bHasHead = true;
                }
            }

            // 如果是 <list rend="no-marker"> 要轉成 <ul rend="no-marker">
            string sRend = GetAttr(node, "rend");
            string sStyle = GetAttr(node, "style");
            CRendAttr myRend = new CRendAttr(sRend);
            CStyleAttr myStyle = new CStyleAttr(sStyle);

            string sOldMarginLeft = MarginLeft;     // 記錄舊的 MarginLeft
            
            string sTextIndentSpace = "";               // 要空的空格
            string sOldListTextIndent = ListTextIndent; // 記錄舊的 ListTextIndent
            ListTextIndent = "";                        // 本層的 ListTextIndent 先設為空的

            int iMarginLeft = 0;
            int iTextIndent = 0;

            if (sStyle != "") {
                iMarginLeft = myStyle.MarginLeft;
                iTextIndent = myStyle.TextIndent;

                sTextIndentSpace = StringRepeat("　", iMarginLeft);
                MarginLeft += sTextIndentSpace;   // 這是第二行之後要空的

                // list 不要加 iTextIndent，這是留給 item 空的
                //sTextIndentSpace += StringRepeat("　", iMarginLeft);     // + iTextIndent);
                ListTextIndent = StringRepeat("　", iTextIndent);    // 本層的 ListTextIndent
            }

            if (!bHasHead) {
                if (Setting.ShowLineFormat && !InNoteOrig && !InNoteMod && !InNoteAdd) {
                    string sNewStyle = myStyle.sTextIndent + myStyle.NewStyle;
                    if(sNewStyle.Length > 0) {
                        sNewStyle = $" style='{sNewStyle}'";
                    }
                    string sNewClass = myRend.NewClass;
                    if (sNewClass.Length > 0) {
                        sNewClass = $" class='{sNewClass}'";
                    }

                    sHtml += $"<span{sNewStyle}{sNewClass}";
                    if (myStyle.HasMarginLeft) {
                        sHtml += "' data-margin-left='";
                        sHtml += iMarginLeft.ToString();
                        sHtml += "em'";
                    }
                    sHtml += " data-tagname='ul'>";

                    sHtml += "<span class='line_space'>";
                    sHtml += sTextIndentSpace;
                    sHtml += "</span>";
                } else {

                    string sNewStyle = myStyle.sMarginLeft + myStyle.sTextIndent + myStyle.NewStyle;
                    if (sNewStyle.Length > 0) {
                        sNewStyle = $" style='{sNewStyle}'";
                    }
                    string sNewClass = myRend.NewClass;
                    if (sNewClass.Length > 0) {
                        sNewClass = $" class='{sNewClass}'";
                    }

                    sHtml += $"<ul{sNewStyle}{sNewClass}";
                    if (myStyle.HasMarginLeft) {
                        sHtml += "' data-margin-left='";
                        sHtml += iMarginLeft.ToString();
                        sHtml += "em'";
                    }
                    if (!InNoteOrig && !InNoteMod && !InNoteAdd) {
                        sHtml += " data-tagname='ul'>";
                    } else {
                        sHtml += ">";
                    }

                    sHtml += "<span class='line_space' style='display:none'>";
                    sHtml += sTextIndentSpace;
                    sHtml += "</span>";
                }
            }

            sHtml += parseChild(node); // 處理內容

            if (Setting.ShowLineFormat && !InNoteOrig && !InNoteMod && !InNoteAdd) {
                sHtml += "</span>";
            } else {
                sHtml += "</ul>";
            }

            ListCount--;
            MarginLeft = sOldMarginLeft;
            ListTextIndent = sOldListTextIndent;

            return sHtml;
        }

        // 目錄
        // 要判斷品的範圍, 若出現品的 mulu, 則記錄 level, 等到 level 數字再次大於或等於時, 此品才結束

        // <mulu level="3" label="1 閻浮提州品" type="品"/>
        // <mulu n="001" type="卷"/>

        // <cb:mulu level="3" type="品">1 閻浮提州品</cb:mulu>
        // <cb:mulu level="1" type="序">序</cb:mulu>
        // <cb:mulu level="1" type="分">1 分</cb:mulu>
        // <cb:mulu n="001" type="卷"></cb:mulu>
        string tagMulu(XmlNode node)
        {
            string sHtml = "";
            string sLevel = GetAttr(node, "level");
            string sType = GetAttr(node, "type");
            int iLevel;
            int.TryParse(sLevel, out iLevel);   // 若失敗則 iLevel 為 0

            InMulu = true;

            if (sLevel == "") {
                return "";     // 不是品這種格式(應該是卷的格式), 不管它
            }

            // 處理法
            // 1. 之前是不是品?
            //    是 : 比較 level , 若 level >= 之前的, 前面的品結束.
            // 2. 檢查自己是不是品, 若是, 就加進去, 並記錄起來.

            if (MuluLabel != "") {      // 之前是品
                if (iLevel <= MuluLevel) {      // 目前的比較小, 所以舊的品要結束
                    sHtml += "<a pin_name=''></a>";
                    MuluLabel = "";
                    MuluLevel = 0;
                } else {
                    return "";     // 之前雖然是品, 但層次不夠, 保持現況
                }
            }

            if (sType == "品") {    // 而目前是品, 就記錄下來
                MuluLabel = "";
                MuluLevel = iLevel;

                sHtml += "<a pin_name='";
                InMuluPin = true;

                // 目錄的內容有可能有這些標記, 要處理掉 ????
                // 1. 羅馬拼音加上 <span class="foreign">xx</span>
                // 2. 缺字會加上 <span class="gaiji">...</span>
                // 3. 缺字的 <!--gaiji,缽,1[金*本],2&#Xxxxx;,3-->

                // 同時要注意, 若在校注中, 目錄的內容會不會跑到校注中? (舊版CBR會把文字送到校注中)
                // MuluLabel 的處理也要注意, 這大概是在 lb 會處理????

                string sMulu = parseChild(node); // 處理內容

                MuluLabel = sMulu;
                // 目錄有缺字, 所以先不呈現 T21n1251_p0233a27 ????
                // sHtml += sMulu;

                InMulu = false;
                InMuluPin = false;  // 先設成 false, 以免底下的內容被記錄至 MuluLabel 中 (舊版才會啦)
                sHtml += "'></a>";
            }

            return sHtml;
        }

        /* 目前 note 總類

        1:無 type

        <note place="inline"> : 雙行小註
        <note place="interlinear"> : 傍註 (有時是在校勘中用文字寫著 "傍註" 二字)
        <note resp="xxxxx" place="inline"> : 雙行小註
        <note resp="xxxxx" target="xxxxx"> : CBETA 自己加的註解
        <note target="xxxxx"> : 在 p4 是 <foreign> => T01n0026.xml <note target="#beg0434012"><foreign n="0434012" cb:resp="#resp1" xml:lang="pi" cb:place="foot">Niga??has?vaka.</foreign></note>
        <note xml:lang="zh" place="inline">

        2. 各種 type

        <note n="xxxxx" resp="xxxxx" type="orig" place="foot text" target="xxxxx">  : place="foot text" , 校勘同時出現在文字區(數字)及註解區(數字及文字)
        <note n="xxxxx" resp="xxxxx" type="orig" place="foot" target="xxxxx">       : place="foot" , 有時文字區沒有校勘數字, 可能用◎符號, 因此 place 只有 foot (T17n0721 一開始)
        <note n="xxxxx" resp="xxxxx" type="orig" place="text" target="xxxxx">       : place="text" , 有時文字區有校勘數字, 但校勘欄卻沒有, 因此 plaee 只有 text (T20n1144)
        <note n="xxxxx" resp="xxxxx" type="orig" target="xxxxx">                    : T02n0009 # 0003b29 有一個 CBETA 自己加進去的校勘, 所以沒有 place
        <note n="xxxxx" resp="xxxxx" type="orig" place="margin-top" target="xxxxx"> : X14n0288 有頭註型式 , 因此 place= "margin-top"

        <note n="xxxxx" resp="xxxxx" type="mod" target="xxxxx">
        <note n="xxxxx" resp="xxxxx" type="mod" place="foot text" target="xxxxx">


        <note n="xxxxx" resp="xxxxx" place="foot text" type="orig" subtype="biao" target="xxxxx">	: 卍續藏特有的 "科, 標, 解"
        <note n="xxxxx" resp="xxxxx" place="foot text" type="orig" subtype="jie" target="xxxxx">
        <note n="xxxxx" resp="xxxxx" place="foot text" type="orig" subtype="ke" target="xxxxx">
        <note n="xxxxx" resp="xxxxx" place="foot" type="orig" subtype="ke" target="xxxxx">
        <note n="xxxxx" resp="xxxxx" place="text" type="orig" subtype="ke" target="xxxxx">

        <note n="xxxxx" resp="xxxxx" type="mod" subtype="biao" target="xxxxx">
        <note n="xxxxx" resp="xxxxx" type="mod" subtype="jie" target="xxxxx">
        <note n="xxxxx" resp="xxxxx" type="mod" subtype="ke" target="xxxxx">                       : 卍續藏特有的 "科, 標, 解"


        <note n="xxxxx" type="cf." place="foot" target="xxxxx">
        <note n="xxxxx" type="equivalent" place="foot" target="xxxxx">
        <note n="xxxxx" type="rest" place="foot" target="xxxxx">
        <note n="xxxxx" resp="xxxxx" type="rest" target="xxxxx">

        <note type="cf1">
        <note type="cf2">
        <note type="cf3">

        <note type="star" corresp="xxxxx"> : 在南傳才遇到, 因為星號在之前都是出現在 app 標記, 但南傳某些沒有 app 標記, 卻需要星號來表示重覆的註解, 待處理 ?????

        2016 新增 type = "add" , 表示是編輯者自行加入的, 若 resp 是 CBETA , 就表示是 CBETA 自己加上的註解,
                                    又如 DILA 自己在佛寺志加上註解, 也是用 "add" , 表示不是佛寺志原有的註解
            B36n0159.xml
        p5a:<note n="0836001" resp="CBETA" type="add">CBETA 按：「校記 A」 條目已加入本文註標連結。</note>
        p5 :<note n="0836001" resp="#resp2" type="add" target="#nkr_note_editor_0836001">CBETA 按：「校記 A」 條目已加入本文註標連結。</note>

        */
        string tagNote(XmlNode node)
        {

        /* 目前 note 總類

        1:無 type

        <note place="inline"> : 雙行小註
        <note place="interlinear"> : 傍註 (有時是在校勘中用文字寫著 "傍註" 二字)
        <note resp="xxxxx" place="inline"> : 雙行小註
        <note resp="xxxxx" target="xxxxx"> : CBETA 自己加的註解
        <note target="xxxxx"> : 在 p4 是 <foreign> => T01n0026.xml <note target="#beg0434012"><foreign n="0434012" cb:resp="#resp1" xml:lang="pi" cb:place="foot">Niga??has?vaka.</foreign></note>
        <note xml:lang="zh" place="inline">

        2. 各種 type

        <note n="xxxxx" resp="xxxxx" type="orig" place="foot text" target="xxxxx">  : place="foot text" , 校勘同時出現在文字區(數字)及註解區(數字及文字)
        <note n="xxxxx" resp="xxxxx" type="orig" place="foot" target="xxxxx">       : place="foot" , 有時文字區沒有校勘數字, 可能用◎符號, 因此 place 只有 foot (T17n0721 一開始)
        <note n="xxxxx" resp="xxxxx" type="orig" place="text" target="xxxxx">       : place="text" , 有時文字區有校勘數字, 但校勘欄卻沒有, 因此 plaee 只有 text (T20n1144)
        <note n="xxxxx" resp="xxxxx" type="orig" target="xxxxx">                    : T02n0009 # 0003b29 有一個 CBETA 自己加進去的校勘, 所以沒有 place
        <note n="xxxxx" resp="xxxxx" type="orig" place="margin-top" target="xxxxx"> : X14n0288 有頭註型式 , 因此 place= "margin-top"

        <note n="xxxxx" resp="xxxxx" type="mod" target="xxxxx">
        <note n="xxxxx" resp="xxxxx" type="mod" place="foot text" target="xxxxx">


        <note n="xxxxx" resp="xxxxx" place="foot text" type="orig" subtype="biao" target="xxxxx">	: 卍續藏特有的 "科, 標, 解"
        <note n="xxxxx" resp="xxxxx" place="foot text" type="orig" subtype="jie" target="xxxxx">
        <note n="xxxxx" resp="xxxxx" place="foot text" type="orig" subtype="ke" target="xxxxx">
        <note n="xxxxx" resp="xxxxx" place="foot" type="orig" subtype="ke" target="xxxxx">
        <note n="xxxxx" resp="xxxxx" place="text" type="orig" subtype="ke" target="xxxxx">

        <note n="xxxxx" resp="xxxxx" type="mod" subtype="biao" target="xxxxx">
        <note n="xxxxx" resp="xxxxx" type="mod" subtype="jie" target="xxxxx">
        <note n="xxxxx" resp="xxxxx" type="mod" subtype="ke" target="xxxxx">                       : 卍續藏特有的 "科, 標, 解"


        <note n="xxxxx" type="cf." place="foot" target="xxxxx">
        <note n="xxxxx" type="equivalent" place="foot" target="xxxxx">
        <note n="xxxxx" type="rest" place="foot" target="xxxxx">
        <note n="xxxxx" resp="xxxxx" type="rest" target="xxxxx">

        <note type="cf1">
        <note type="cf2">
        <note type="cf3">

        <note type="star" corresp="xxxxx"> : 在南傳才遇到, 因為星號在之前都是出現在 app 標記, 但南傳某些沒有 app 標記, 卻需要星號來表示重覆的註解, 待處理 ????

        2016 新增 type = "add" , 表示是編輯者自行加入的, 若 resp 是 CBETA , 就表示是 CBETA 自己加上的註解,
                                    又如 DILA 自己在佛寺志加上註解, 也是用 "add" , 表示不是佛寺志原有的註解
            B36n0159.xml
        p5a:<note n="0836001" resp="CBETA" type="add">CBETA 按：「校記 A」 條目已加入本文註標連結。</note>
        p5 :<note n="0836001" resp="#resp2" type="add" target="#nkr_note_editor_0836001">CBETA 按：「校記 A」 條目已加入本文註標連結。</note>

        */

            string sHtml = "";
            string sType = GetAttr(node, "type");
            string sPlace = GetAttr(node, "place");
            string sId = GetAttr(node, "n");
            string sRend = GetAttr(node, "rend");
            string sNoteKey = GetAttr(node, "cb:note_key");
            string sIdNum = ""; // 0001001a 取得 1a

            // rend="hide" 直接取消處理, 目前只出現在 Y 和 TX

            if (sRend == "hide") {
                return "";
            }
            
            // note_key 處理成屬性
            if (sNoteKey != "") {
                sNoteKey = " note_key='" + sNoteKey + "'";
            }

            // 沒有 Type 的情況

            if (sType == "") {
                if (sPlace == "inline" || sPlace == "inline2" || sPlace == "interlinear") {
                    sHtml += "<span class='note'>(" + parseChild(node) + ")</span>";
                    return sHtml;
                }

                // 有些連 place 也沒有, 例如 :
                // <note resp="CBETA.Eva">為配合悉漢對照，故將p727a14中文與p727a15悉曇字前後對調</note>

                if (sPlace == "") {
                    return "";
                }
            }

            // 卍續藏特殊校注
            // X56n0922 <note n="0104k01" resp="Xuzangjing" place="foot text" type="orig_ke">
            // 【科01】 → xml：<note n="0001k01" resp="Xuzangjing "place="foot text" type="orig_ke">
            // 【標01】 → xml：<note n="0001b01" resp="Xuzangjing "place="foot text" type="orig_biao">
            // 【解01】 → xml：<note n="0001j01" resp="Xuzangjing" place="foot text" type="orig_jie">

            // 原書校勘
            if (sType.StartsWith("orig")) {
                if (sId == "") {
                    CGlobalMessage.push("錯誤 : 校勘沒有 n 屬性");
                } else {
                    sIdNum = NoteId2Num(sId);  // 0001001a 取得 1a
                }

                string sKBJ = "";  // 科, 標, 解專用
                char wcKBJ = sId[4];
                if (wcKBJ == 'k') { sKBJ = "科"; } else if (wcKBJ == 'b') { sKBJ = "標"; } else if (wcKBJ == 'j') { sKBJ = "解"; }

                // <a id="note_orig_0001001" class="note_orig" href="" onclick="return false;">

                // note 要暫存起來, 要同時有 note_orig 和 mod
                // 等到真的遇到 mod , 再把 class 的 note_mod 移除

                string sDisplay = "";   // 呈現的情況
                if (Setting.ShowCollation == false) { sDisplay = "none"; } else if (Setting.CollationType == ECollationType.Orig) { sDisplay = "inline"; } else if (Setting.CollationType == ECollationType.CBETA) { sDisplay = "inline"; }

                string sTmp = "<a id='note_orig_" + sId
                         + "' class='note_orig note_mod' href='' style='display:" + sDisplay
                         + "' onclick='return ShowCollation($(this));'>[" +
                         sKBJ + sIdNum + "]</a>";

                sHtml += "<<tmp_note_orig_" + sId + ">>"; // 先做個記錄

                mOrigNote[sId] = sTmp;
                InNoteOrig = true;
                string sNoteText = parseChild(node);
                InNoteOrig = false;
                // <div class='txt_note' id="txt_note_orig_0001001">校勘內容</div>
                // class='txt_note' 是讓 javascript 用來判斷這是校勘
                HTMLCollation += "<div class='txt_note' id='txt_note_orig_" + sId + "'>" + sNoteText + "</div>\n";
            } else if (sType.Substring(0, 3) == "mod") {
                if (sId == "") {
                    CGlobalMessage.push("錯誤 : 校勘沒有 n 屬性");
                } else {
                    sIdNum = NoteId2Num(sId);  // 0001001a 取得 1a
                }

                string sKBJ = "";  // 科, 標, 解專用
                char wcKBJ = sId[4];
                if (wcKBJ == 'k') sKBJ = "科";
                else if (wcKBJ == 'b') sKBJ = "標";
                else if (wcKBJ == 'j') sKBJ = "解";

                string sDisplay = "";   // 呈現的情況
                if (Setting.ShowCollation == false) { sDisplay = "none"; } else if (Setting.CollationType == ECollationType.Orig) { sDisplay = "none"; } else if (Setting.CollationType == ECollationType.CBETA) { sDisplay = "inline"; }

                sHtml += "<a id='note_mod_" + sId +
                         "' class='note_mod' href='' style='display:" + sDisplay +
                         "' onclick='return ShowCollation($(this));'>[" +
                         sKBJ + sIdNum + "]</a>";

                InNoteMod = true;
                string sNoteText = parseChild(node);
                InNoteMod = false;

                // class='txt_note' 是讓 javascript 用來判斷這是校勘
                HTMLCollation += "<div class='txt_note' id='txt_note_mod_" + sId + "'" + sNoteKey + ">" + sNoteText + "</div>\n";

                //string sIdNormal = sId.SubString0(0,7); // 取出標準的 ID, 因為有些有 abc...

                ThisNoteHasMod(sId);  // 通知 note orig , 此校勘有 mod 版
            }
            // 2016 新增加的版本 <note type="editor" (後來改成 "add" ...
            else if (sType == "editor" || sType == "add") {
                if (sId == "") {
                    CGlobalMessage.push("錯誤 : 校勘沒有 n 屬性");
                } else {
                    sIdNum = Get_Add_IdNum(sId).ToString();   // 取得自訂校勘的流水號
                }

                // <a id="note_orig_0001001" class="note_orig" href="" onclick="return false;">

                // note 要暫存起來, 要同時有 note_orig 和 mod
                // 等到真的遇到 mod , 再把 class 的 note_mod 移除

                string sDisplay = "";   // 呈現的情況
                if (Setting.ShowCollation == false) { sDisplay = "none"; } 
                else if (Setting.CollationType == ECollationType.Orig) { sDisplay = "none"; } 
                else if (Setting.CollationType == ECollationType.CBETA) { sDisplay = "inline"; }

                sHtml += "<a id='note_add_A" + sIdNum +
                         "' class='note_add' href='' style='display:" + sDisplay +
                         "' onclick='return ShowCollation($(this));'>[A" +
                         sIdNum + "]</a>";

                InNoteAdd = true;
                string sNoteText = parseChild(node);
                InNoteAdd = false;
                // <div class='txt_note' id="txt_note_orig_0001001">校勘內容</div>
                // class='txt_note' 是讓 javascript 用來判斷這是校勘
                HTMLCollation += "<div class='txt_note' id='txt_note_add_A" + sIdNum + "'" + sNoteKey + ">" + sNoteText + "</div>\n";
            }
            // 2018 新增加的版本 <note type="authorial" ...
            // Y13n0013 }<lb n="0303a11" ed="Y"/>
            // ...〈書<note type="authorial">（菊池寬）</note>復讎以後〉...
            else if (sType == "authorial") {
                sHtml += parseChild(node);
            }
            // N19n0007.xml
            // <note type="star" corresp="#0211020"></note>
            else if (sType == "star") {
                string sCorresp = GetAttr(node, "corresp");
                sCorresp = sCorresp.Substring(1);

                string sDisplay = "";   // 呈現的情況
                if (Setting.ShowCollation == false) { sDisplay = "none"; }
                else if (Setting.CollationType == ECollationType.Orig) { sDisplay = "inline"; } 
                else if (Setting.CollationType == ECollationType.CBETA) { sDisplay = "inline"; }

                string sTmp = "<a id='note_star_" + sCorresp +
                            "' class='note_orig note_mod' href='' style='display:" + sDisplay +
                            "' onclick='return ShowCollation($(this));'>[＊]</a>";
                sHtml += sTmp;
            }
            else if(sType.Substring(0, 2) == "cf") {
                string cf = parseChild(node);
                if (cf != "") {
                    NoteCF += $"{cf}; ";
                }
            }

            // parseChild(node); // 處理內容

            return sHtml;
        }

        // 注意 : 原本若 XML P4 的 <p> 有 place="inline" , 則 inline 會加至 "rend" 屬性中,
        //        其他 place 內容會變成 cb:type 屬性. 例如:
        //        P4 <p place="inline"> => P5 <p rend="inline">
        //        P4 <p place="head2"> => P5 <p cb:type="head2">

        // 段落 : <p>
        // 咒語 : <p cb:type="dharani">唵緊至囉
        // 比照 head 處理 : <p xml:id="pX82p0160b2201" cb:type="head1">臨濟宗</p>
        // 卍續特殊校注有 X14n0288  <p cb:type="各家會釋" rend="margin-left:1em"> , <p cb:type="訂解總論" ... >

        string tagP(XmlNode node)
        {
            string sHtml = "";
            string sRend = GetAttr(node, "rend");
            string sStyle = GetAttr(node, "style");
            string sType = GetAttr(node, "cb:type");
            string sPlace = GetAttr(node, "cb:place");

            CRendAttr myRend = new CRendAttr(sRend);
            CStyleAttr myStyle = new CStyleAttr(sStyle);

            XmlNodeType nodetype;

            string sTextIndentSpace = "";
            string sOldMarginLeft = MarginLeft; // 先存起舊的
            int iMarginLeft = 0;
            int iTextIndent = 0;
            //bool bHasStyle = false;	    // 若有 rend 就不使用預設的空格
            bool bHasInline = false;    // 有沒有 inline
            bool bAddSpace = false;     // 要不要加空格, 有 inline 不一定加空格, 若前面有空格就不加
            bool bHasLg = false;        // 用來判斷前面是不是 lg, 若是就要空二格了
            int iSpecialType = 0;      // 0 : 一般情況 , 1 : cb:type ="各家會釋" , 2 : cb:type="訂解總論"

            // 處理 style, rend, cb:place
            // 檢查移位 <p xml:id="pX78p0420a0401" style="margin-left:2em">
            //          <p xml:id="pX78p0802a1901" style="margin-left:1em;text-indent:-1em">
            //          <p xml:id="xxxxxxxxxxxxxx" cb:place="inline" style="margin-left:1em;text-indent:-1em">
            //          <p xml:id="xxxxxxxxxxxxxx" rend="kaiti">

            if (sStyle != "") {
                //bHasStyle = true;
                iMarginLeft = myStyle.MarginLeft;
                iTextIndent = myStyle.TextIndent;
            }

            // rend="text-center" 原書格式預設空四格
            // rend="text-right" 原書格式預設空八格
            if (myRend.Find("text-center")) {
                iTextIndent += 4;
            } else if (myRend.Find("text-right")) {
                iTextIndent += 8;
            }

            // 處理 inline
            if (sPlace == "inline") {
                bHasInline = true;
                bAddSpace = true;       // 要不要加空格

                // 新的用法, 若 <p cb:place="inline"> 前無空格, 則依原書切行時都加上空格, 否則一律不加

                XmlNode PreSiblNode = node.PreviousSibling;      // 取得上一層
                if (PreSiblNode != null) {
                    nodetype = PreSiblNode.NodeType;
                    if (nodetype == XmlNodeType.Text) { // 這是純 data
                        string sData = PreSiblNode.Value;

                        if (sData.Last() == '　') {
                            bAddSpace = false;
                        }
                    } else if (nodetype == XmlNodeType.Element) { // 這是純 element
                        if (PreSiblNode.Name == "lg") {
                            bHasLg = true;
                        }
                    }
                }
            }

            // 處理 cb:type
            // 這二種不理它 : cb:type="xx" , cb:type="interlinear"

            // 先處理卍續藏可能特有的 cb:type ="各家會釋" or cb:type="訂解總論"

            if (sType != "") {
                if (sType == "各家會釋") {  // 行中段落加句點
                    iSpecialType = 1;       // 0 : 一般情況 , 1 : cb:type ="各家會釋" , 2 : cb:type="訂解總論"
                }
                if (sType == "訂解總論") {  // 行中段落加句點
                    iSpecialType = 2;       // 0 : 一般情況 , 1 : cb:type ="各家會釋" , 2 : cb:type="訂解總論"
                }
            }

            // ------------------------------------------------------
            // 順序 : <p><span...>　(空格) [pxxxxaxx]  字
            // ------------------------------------------------------

            // 處理 <p....>
            if (iSpecialType > 0) {
                // iSpecialType > 0 只會出現在校注
                // 出現在校注需要把 p 換成 span 嗎？（答：不用）
                sHtml += "<p style='text-indent: ";
                sHtml += iTextIndent.ToString();
                sHtml += "em; margin-left: ";
                sHtml += iMarginLeft.ToString();
                sHtml += "em; margin-top: 5px; margin-bottom: 0em;";
                sHtml += myStyle.NewStyle;
                sHtml += "'";
                if (myRend.NewClass != "") {
                    sHtml += " class='" + myRend.NewClass + "'";
                }
                // sHtml += "' data-tagname='p'>";
                sHtml += ">";

                if (iSpecialType == 1) {
                    sHtml += "<font color=#800000>";
                } else if (iSpecialType == 2) {
                    sHtml += "<font color=blue>";
                }
            } else {
                if (sType.StartsWith("head")) { // 比照 head 處理
                    //IsOtherHead = true;
                    // Q1 ==> 空2格
                    // Q2 ==> 空3格
                    // Q3 ==> 空4格
                    // Q4 ==> 空2格
                    // Q5 ==> 空3格
                    // Q6 ==> 空4格
                    // Q7 ==> 空2格
                    // Q8 ==> 空3格

                    if (sType == "head1" || sType == "head4" || sType == "head7") {
                        iMarginLeft += 2;
                        bAddSpace = false;
                    } else if (sType == "head2" || sType == "head5" || sType == "head8") {
                        iMarginLeft += 3;
                        bAddSpace = false;
                    } else if (sType == "head3" || sType == "head6" || sType == "head9") {
                        iMarginLeft += 4;
                        bAddSpace = false;
                    }
                }

                if (Setting.ShowLineFormat && !InNoteOrig && !InNoteMod && !InNoteAdd) {
                    sHtml += "<span style='text-indent: ";
                    sHtml += iTextIndent.ToString();
                    sHtml += "em;";
                    sHtml += myStyle.NewStyle;
                    sHtml += "'";
                    if (myRend.NewClass != "") {
                        sHtml += " class='" + myRend.NewClass + "'";
                    }
                    sHtml += " data-margin-left='";
                    sHtml += iMarginLeft.ToString();
                    sHtml += "em' data-tagname='p'>";
                } else {
                    sHtml += "<p style='text-indent: ";
                    sHtml += iTextIndent.ToString();
                    sHtml += "em; margin-left: ";
                    sHtml += iMarginLeft.ToString();
                    sHtml += "em;";
                    sHtml += myStyle.NewStyle;
                    sHtml += "'";
                    if (myRend.NewClass != "") {
                        sHtml += " class='" + myRend.NewClass + "'";
                    }
                    // 在校注中也不要 data-tagname='p' ， 讓它無法還原
                    if (!InNoteOrig && !InNoteMod && !InNoteAdd) {
                        sHtml += " data-margin-left='";
                        sHtml += iMarginLeft.ToString();
                        sHtml += "em' data-tagname='p'>";
                    } else {
                        sHtml += ">";
                    }
                }
            }

            // 處理 <span ....> --------------------------------------------------

            if (sType == "dharani") {       // 咒
                sHtml += "<span class='dharani'>";
            } else if (sType == "pre") {    // 依原書格式
                PreFormatCount++;      // 判斷是否是要依據原始經文格式切行, 要累加的, 因為可能有巢狀的 pre
                sHtml += "<span class='preformat'>";
            } else if (sType.StartsWith("head")) {  // 比照 head 處理
                sHtml += "<span class='headname'>";
            }

            // 卍續藏校注就不用段首了, 在校勘中也不用(藏外第一經第一卷就有例子)
            if (iSpecialType == 0) {
                // 處理空格及段首
                if (sTextIndentSpace == "" && iMarginLeft + iTextIndent == 0 && bAddSpace) {
                    iTextIndent++;
                    if (bHasLg) iTextIndent++;
                }
                if (iMarginLeft >= 0) {
                    MarginLeft += StringRepeat("　", iMarginLeft);
                } else {
                    if (MarginLeft.Length + iMarginLeft >= 0) {
                        MarginLeft = MarginLeft.Remove(0, iMarginLeft * -1);
                    } else {
                        MarginLeft = "";
                    }
                }
                string sSpace = "";
                if (iMarginLeft + iTextIndent > 0) {
                    sSpace = StringRepeat("　", iMarginLeft + iTextIndent);
                }

                if (Setting.ShowLineFormat && !InNoteOrig && !InNoteMod && !InNoteAdd) {
                    sHtml += "<span class='line_space'>";
                } else {
                    sHtml += "<span class='line_space' style='display:none'>";
                }
                sHtml += sSpace;
                sHtml += "</span>";

                // 處理段首
                if (!sType.StartsWith("head")) { // 當成 head 就不要加行首資訊了
                    if (!InNoteOrig && !InNoteMod && !InNoteAdd) {  // 校注也不用加段首
                        if (Setting.ShowLineHead && !Setting.ShowLineFormat) {
                            sHtml += "<span class='parahead'>[" + PageLine + "] </span>";
                        } else {
                            sHtml += "<span class='parahead' style='display:none'>[" + PageLine + "] </span>";
                        }
                    }
                }
            }

            // -----------------------------------
            sHtml += parseChild(node); // 處理內容
            // -----------------------------------

            //sHtml += "</p>";

            MarginLeft = sOldMarginLeft;

            if (sType == "dharani") {
                sHtml += "</span>";
            } else if (sType == "pre") {            // 依原書格式
                PreFormatCount--;       // 判斷是否是要依據原始經文格式切行, 要累加的, 因為可能有巢狀的 pre
                sHtml += "</span>";
            } else if (sType.StartsWith("head")) {
                sHtml += "</span>";
            }

            if (iSpecialType > 0) {
                sHtml += "</font></p>";
            } else {
                if (Setting.ShowLineFormat && !InNoteOrig && !InNoteMod && !InNoteAdd) {
                    sHtml += "</span>";
                } else {
                    sHtml += "</p>";
                }
            }

            return sHtml;
        }

        string tagPb(XmlNode node)
        {
            string sHtml = "";
            sHtml += parseChild(node); // 處理內容
            return sHtml;
        }

        /*
        <note n="0001002" resp="Taisho" type="orig" place="foot text">〔長安〕－【宋】</note>
        <note n="0001002" resp="CBETA" type="mod">長安【大】，〔－〕【宋】</note>
        <app n="0001002">
	        <lem wit="【大】">長安</lem>
	        <rdg resp="Taisho" wit="【宋】"><space quantity="0"/></rdg>
        </app>

        XML 原始標記  : <rdg resp="Taisho" wit="【宋】"><space quantity="0"/></rdg>
        HTML 經文轉成 : (空的, 沒有字)
        HTML 校注轉成 : <div type="rdg" data-wit="【宋】">長安</div>

        有原始版的 lem 或 rdg 還要轉出一行, 讓 javascript 好處理
				        <div type="orig">XXX</div>

        若選擇原書, rdg 的 wit 有【大】(或其他藏經的原書版本), 則呈現 lem 的內容.
			        rdg 的 wit 沒有【大】(或其他藏經的原書版本), 則不呈現 lem 的內容, 等 rdg .
        若選擇CBETA 版, 則不呈現 rdg 的內容, 因為若有 CB 版, 一定在 lem 中.

        */
        string tagRdg(XmlNode node)
        {
            string sHtml = "";

            string sWit = GetAttr(node, "wit");
            string sType = GetAttr(node, "type");

            bool bShowRdgText = false;
            bool bRdgIsOrig = false;   // 判斷 lem 是否是原始校注

            if (sWit.Contains(BookVerName) && sType != "correctionRemark" && sType != "variantRemark")
                bRdgIsOrig = true;

            // 選擇原書校注, 且 rdg 是原始校注, 才呈現文字
            if (Setting.CollationType == ECollationType.Orig) {
                if (bRdgIsOrig == true) {
                    bShowRdgText = true;
                }
            }

            string sRdgText = parseChild(node); // 處理內容

            if (bShowRdgText) {
                sHtml += sRdgText;
            }

            // 記錄到校注區


            string sRdgTag = "";
            if (bRdgIsOrig) {
                // <div type="orig">大正原版</div>
                sRdgTag += "\t<div type='orig'>" + sRdgText + "</div>\n";
            }

            sRdgTag += "\t<div type='rdg' data-wit='" +
                            sWit + "'>" + sRdgText + "</div>\n";

            HTMLCollation += sRdgTag;
            return sHtml;
        }

        // 南傳經文的巴利藏對照頁數
        // <ref cRef="PTS.Vin.3.1"></ref>
        // 呈現 [P.1]
        // 實際上則是 <span class="pts_head" title="PTS.Vin.3.1">[P.1]</span>

        // 不過在各卷最前面, 可能有一個隱形的標記, 記錄著上一卷最後一個 PTS 頁碼, 這個就不要呈現出來
        // 它的格式是 <ref cRef="PTS.Vin.3.109" type="PTS_hide"></ref>
        string tagRef(XmlNode node)
        {
            string sHtml = "";
            string sType = GetAttr(node, "type");
            string sCRef = GetAttr(node, "cRef");

            bool bHidePTS = false;  // 判斷是不是隱藏版的 PTS 標記
            if (sType == "PTS_hide") {
                bHidePTS = true;
            }

            if (sCRef != "") {
                if (sCRef.StartsWith("PTS")) {
                    string sPage = sCRef;
                    int iPos = sPage.LastIndexOf(".");  // 找到最後.的位置
                    sPage = sPage.Remove(0, iPos + 1);   // 最後一個數字, 也就是頁碼

                    // 隱藏的加要寫? 可能是引用複製要用的吧, 我也忘了....
                    if (Setting.ShowLineHead) {
                        sHtml += "<span class='pts_head' title='" + sCRef + "'>";
                    } else {
                        sHtml += "<span class='pts_head' title='" + sCRef + "' style='display:none'>";
                    }
                    if (bHidePTS == false) {
                        sHtml += " [P." + sPage + "] ";
                    }
                    sHtml += "</span>";
                }
            }
            sHtml += parseChild(node); // 處理內容
            return sHtml;
        }
        string tagRow(XmlNode node)
        {
            string sHtml = "";
            //string sXXX = GetAttr(node, "xxx");
            CellNum = 0;        // cell 格式數量歸 0
            OtherColspan = 0;   // 因本 cell 佔 n 格以上, 所以和後面的 cell 要空 (n-1)*3 的空格, 此即記錄 n-1 的數字

            if (Setting.ShowLineFormat && !InNoteOrig && !InNoteMod && !InNoteAdd) {
                sHtml += "<span data-tagname='tr'>";
                sHtml += parseChild(node); // 處理內容
                sHtml += "</span>";
            } else {
                if (!InNoteOrig && !InNoteMod && !InNoteAdd) {
                    sHtml += "<tr data-tagname='tr'>";
                } else {
                    sHtml += "<tr>";
                }
                sHtml += parseChild(node); // 處理內容
                sHtml += "</tr>";
            }
            return sHtml;
        }

        // <cb:sg> 要加括號 , <cb:tt><cb:t xml:lang="sa-Sidd"><g ref="#SD-E074">??</g></cb:t><cb:t xml:lang="zh"><cb:yin><cb:zi>唵</cb:zi><cb:sg>引</cb:sg></cb:yin></cb:t></cb:tt>
        string tagSg(XmlNode node)
        {
            string sHtml = "(";
            sHtml += parseChild(node); // 處理內容
            sHtml += ")";
            return sHtml;
        }

        // 空格 <space quantity="1" unit="chars"/>
        // 沒有字 <space quantity="0"/>
        string tagSpace(XmlNode node)
        {
            string sHtml = "";
            string sUnit = GetAttr(node, "unit");

            if (sUnit != "") {
                if (sUnit == "chars") {
                    string sQuantity = GetAttr(node, "quantity");
                    int iSpace = int.TryParse(sQuantity, out iSpace) ? iSpace : 0;
                    sHtml += StringRepeat("　", iSpace);
                }
            } else {
                // 隔行對照時, 沒有字的地方也要秀出空格, 以便與悉曇字對應
                if (NextLine.InNextLine) {
                    sHtml += "　";
                } else {
                    sHtml += "";
                }
            }
            //sHtml = parseChild(node); // 處理內容
            return sHtml;
        }

        // 在校勘的巴利文不要印出來 <cb:t lang="pli" resp="Taisho" place="foot">S&amacron;vatth&imacron;.</cb:t>
        // <cb:tt type="tr"><cb:t lang="chi">&lac;</cb:t><cb:t lang="san-sd">&SD-A5A9;</cb:t></cb:tt><cb:tt type="tr"><cb:t lang="chi">&lac;</cb:t><cb:t lang="san-sd">&SD-A5F0;</cb:t></cb:tt><cb:tt type="tr"><cb:t lang="chi">如</cb:t><cb:t lang="san-sd">&SD-CFCF;</cb:t></cb:tt>
        // <cb:tt><cb:t lang="san-sd">&SD-A5A9;</cb:t><cb:t lang="chi">曩</cb:t></cb:tt>

        /* 2014 年的類型
        <cb:t cert="?" resp="#respx" xml:lang="pi" place="foot">
        <cb:t cert="?" resp="#respx" xml:lang="sa" place="foot">
        <cb:t resp="#respx" xml:lang="pi" place="foot">
        <cb:t resp="#respx" xml:lang="sa" place="foot">
        <cb:t resp="#respx" xml:lang="x-unknown" place="foot">
        <cb:t resp="#respx" xml:lang="zh" place="foot">
        <cb:t resp="#respx" xml:lang="zh">
        <cb:t xml:lang="sa-Sidd" rend="margin-left:1em">
        <cb:t xml:lang="sa-Sidd">
        <cb:t xml:lang="sa-x-rj">
        <cb:t xml:lang="zh">
        <cb:t xml:lang="zh-x-yy" rend="margin-left:1em">
        */
        string tagT(XmlNode node)
        {
            string sHtml = "";
            string sPlace = GetAttr(node, "place");
            if (sPlace == "foot") return "";

            string sRend = GetAttr(node, "rend");
            string sStyle = GetAttr(node, "style");
            string sOldMarginLeft = MarginLeft;

            //CRendAttr * myRend = new CRendAttr(sRend);
            CStyleAttr myStyle = new CStyleAttr(sStyle);

            // 如果是隔行對照, 就要累加 <t> 的計數器
            if (NextLine.InNextLine) {
                NextLine.TCount = NextLine.TCount + 1;
            }

            if (sStyle != "") {
                int iMarginLeft = myStyle.MarginLeft;
                MarginLeft += StringRepeat("　", iMarginLeft);
                sHtml += MarginLeft;
            } else if (NextLine.InNextLine) {
                // "<add_sp>" 是故意的, 在 TmyNextLineOfTT 物件處理

                // 在隔行對照時, 除非 rend = "" , 否則一律加上全型空格
                sHtml += "<add_sp>";
            }

            // <add_sp> 要先處理
            if (NextLine.InNextLine) {
                NextLine.Add(sHtml);
                sHtml = "";
            }

            if (InTTNormal) {
                if (Setting.ShowLineFormat) {
                    sHtml += "<span class='para_br' data-tagname='br'></span>";
                } else {
                    sHtml += "<br class='para_br' data-tagname='br'/>";
                }
            }

            sHtml += parseChild(node); // 處理內容

            MarginLeft = sOldMarginLeft;

            // 判斷是不是在隔行對照
            if (NextLine.InNextLine || !NextLine.IsOutput) {
                NextLine.Add(sHtml);
                return "";
            }

            return sHtml;
        }

        // 表格的處理
        // <table cols="4" border="0">
        // <table cols="3" rend="border:0">
        // <lb ed="X" n="0018b14"/><row><cell>壬寅</cell><cell></cell><cell cols="2">黃武元</cell></row>
        // 依原書格式切行： 第一個<cell>空一格，<cell>空三格。<cell cols="n"> 結束後要再多空(n-1)*3格。
        // 不依原書：border 為無線表格, <cell cols=2> 表示佔二個位置 => <td colspan="2"> => OtherColspan = 2-1
        // <cell rows="n"> 依原書不管 rows , 不依原書則變成 <td rowspan="n">
        string tagTable(XmlNode node)
        {
            string sHtml = "";
            string sRend = GetAttr(node, "rend");
            string sStyle = GetAttr(node, "style");
            //string sBorder = "1";      // 預設表格線為 1

            CRendAttr myRend = new CRendAttr(sRend);
            CStyleAttr myStyle = new CStyleAttr(sStyle);
            string sNewStyle = myStyle.NewStyle;
            string sNewClass = myRend.NewClass;

            string sOldMarginLeft = MarginLeft;
            string sTextIndentSpace = "";   // 先設為原來的 MarginLeft
            int iMarginLeft = 0;
            int iTextIndent = 0;

            if (sStyle != "") {
                iMarginLeft = myStyle.MarginLeft;
                iTextIndent = myStyle.TextIndent;
                MarginLeft += StringRepeat("　", iMarginLeft);
                sTextIndentSpace += StringRepeat("　", iMarginLeft + iTextIndent);
            }

            // 如果用 style="border:1" 只會最外圍有框線, 格子沒有, 細節要再研究
            // if (myRend.Find("no-border")) {
            //     sBorder = "0";
            // }

            if (Setting.ShowLineFormat && !InNoteOrig && !InNoteMod && !InNoteAdd) {
                sHtml += "<span class='line_space'>";
                sHtml += sTextIndentSpace;
                sHtml += "</span>";
                sHtml += "<span data-tagname='table'";
                if (sNewStyle != "" || iMarginLeft != 0 || iTextIndent != 0) {
                    sHtml += $" style='{sNewStyle}{myStyle.sTextIndent}'";
                }
                sHtml += $" class='{sNewClass}'";
                sHtml += $" data-margin-left='{iMarginLeft}em'><span data-tagname='tbody'>";
            } else {
                sHtml += "<span class='line_space' style='display:none'>";
                sHtml += sTextIndentSpace;
                sHtml += "</span>";
                if (!InNoteOrig && !InNoteMod && !InNoteAdd) {
                    sHtml += "<table data-tagname='table' ";
                } else {
                    sHtml += "<table ";
                }
                if (sNewStyle != "" || iMarginLeft != 0 || iTextIndent != 0) {
                    sHtml += $" style='{sNewStyle}{myStyle.sTextIndent}{myStyle.sMarginLeft}'";
                }
                sHtml += $" class='{sNewClass}'";
                if (!InNoteOrig && !InNoteMod && !InNoteAdd) {
                    sHtml += $" data-margin-left='{iMarginLeft}em'><tbody data-tagname='tbody'>";
                } else {
                    sHtml += $" data-margin-left='{iMarginLeft}em'><tbody>";
                }
            }

            sHtml += parseChild(node); // 處理內容

            if (Setting.ShowLineFormat && !InNoteOrig && !InNoteMod && !InNoteAdd) {
                sHtml += "</span></span>";
            } else {
                sHtml += "</tbody></table>";
            }

            //sHtml = mv_data_between_tr(sHtml);  // 把 <tr/>..<tr><td> 中間的資料移到 <td> 裡面
            MarginLeft = sOldMarginLeft;
            return sHtml;
        }

        // 用來判斷是否可用通用字 , 大於 0 就不用通用字,
        // 這二種就不用通用字 <text cb:behaviour="no-norm"> 及 <term cb:behaviour="no-norm">
        string tagTerm(XmlNode node)
        {
            string sHtml = "";
            string sBehaviour = GetAttr(node, "cb:behaviour");

            if (sBehaviour == "no-norm") {
                NoNormal++;
            }
            sHtml += parseChild(node); // 處理內容
            if (sBehaviour == "no-norm") {
                NoNormal--;
            }
            return sHtml;
        }

        // 後面的名字, 當段落用 <trailer><title>般若波羅蜜多心經</title></trailer>
        string tagTrailer(XmlNode node)
        {
            string sHtml = "";
            if (Setting.ShowLineFormat) {
                sHtml = "<span data-tagname='p'>";
                sHtml += parseChild(node); // 處理內容
                sHtml += "</span>";
            } else {
                sHtml = "<p data-tagname='p'>";
                sHtml += parseChild(node); // 處理內容
                sHtml += "</p>";
            }
            return sHtml;
        }

        /* 處理 tt

	        校勘產生的 tt		# <cb:tt type="app">	: 在 back 區中校勘中 <app> 裡面的 tt
    					        # <cb:tt type="app" from="#begxxxxxx" to="#endxxxxxx"> : 在 back 區獨立出來的
    					        # <cb:tt word-count="xx" type="app" from="#begxxxxxx" to="#endxxxxxx">

	        同一行的 tt						# <cb:tt place="inline"> 舊版是 <cb:tt rend="inline">
	        已經自動將漢字和悉曇分開的 tt	# <cb:tt type="single-line"> 舊版是 <cb:tt rend="normal">

	        這是要隔行對照的 tt 			# <cb:tt>
	        這是要隔行對照的 tt 			# <cb:tt type="tr"> : 只出現在 T20n1168B


        P5 校勘有點複雜, 尤其是有 <tt> 的
        底下有三種, 一種是純粹 tt 的.
        第二種是 back 區中的 tt 中還有 app , 但 app 中則無 tt , 這是因為在 P4 及 P5a 是 tt 包 app
        第三種是 back 區中的 app 中還有 tt , 但 tt 中則無 app , 這是因為在 P4 及 p5a 是 app 包 tt
        我想不管是哪一種, 原則上應該是只去找 app 中的 xml:id , back 中的 tt 就不管了.
        除非是 app 中還有 tt , 則只要處理 tt 中 t 不是 place=foot 的部份

        T01n0001.xml

        <anchor xml:id="nkr_note_orig_0011012" n="0011012"/>
        <anchor xml:id="beg0011012" n="0011012"/>禹舍
        <anchor xml:id="end0011012"/>

        <note n="0011012" resp="#resp1" type="orig" place="foot text" target="#nkr_note_orig_0011012">禹舍～Vassak?ra.</note>
        <cb:tt type="app" from="#beg0011012" to="#end0011012">
	        <cb:t resp="#resp1" xml:lang="zh">禹舍</cb:t>
	        <cb:t resp="#resp1" xml:lang="pi" place="foot">Vassak?ra.</cb:t>
        </cb:tt>

        ========================

        T01n0001.xml

        <anchor xml:id="nkr_note_orig_0039004" n="0039004"/>
        <anchor xml:id="nkr_note_mod_0039004" n="0039004"/>
        <anchor xml:id="beg0039004" n="0039004"/>摩羅醯搜
        <anchor xml:id="end0039004"/>

        <note n="0039004" resp="#resp1" type="orig" place="foot text" target="#nkr_note_orig_0039004">摩羅醯搜＝摩醯樓【宋】，摩羅醯樓【元】【明】～M?tul?.</note>
        <note n="0039004" resp="#resp2" type="mod" target="#nkr_note_mod_0039004">摩羅醯搜～M?tul?.，＝摩醯樓【宋】，＝摩羅醯樓【元】【明】</note>

        <app from="#beg0039004" to="#end0039004">
	        <lem wit="#wit1">摩羅醯搜</lem>
	        <rdg resp="#resp1" wit="#wit2">摩醯樓</rdg>
	        <rdg resp="#resp1" wit="#wit3 #wit4">摩羅醯樓</rdg></app>

        <cb:tt type="app" from="#beg0039004" to="#end0039004">
	        <cb:t resp="#resp1" xml:lang="zh">
		        <app n="0039004">
			        <lem wit="#wit1">摩羅醯搜</lem>
			        <rdg resp="#resp1" wit="#wit2">摩醯樓</rdg>
			        <rdg resp="#resp1" wit="#wit3 #wit4">摩羅醯樓</rdg></app></cb:t>
	        <cb:t resp="#resp1" xml:lang="pi" place="foot">M?tul?.</cb:t>
        </cb:tt>

        ======================

        T01n0026.xml

        <anchor xml:id="nkr_note_orig_0680020" n="0680020"/>
        <anchor xml:id="nkr_note_mod_0680020" n="0680020"/>
        <anchor xml:id="beg0680020" n="0680020"/>婆羅婆
        <anchor xml:id="end0680020"/>

        <note n="0680020" resp="#resp1" type="orig" place="foot text" target="#nkr_note_orig_0680020">～Bh?radv?ja. 婆＝娑【聖】</note>
        <note n="0680020" resp="#resp2" type="mod" target="#nkr_note_mod_0680020"><choice><corr>婆羅婆</corr><sic><space quantity="0"/></sic></choice>～Bh?radv?ja.，婆＝娑【聖】</note>

        <app from="#beg0680020" to="#end0680020">
	        <lem wit="#wit1">
		        <cb:tt type="app">
			        <cb:t resp="#resp2" xml:lang="zh">婆羅婆</cb:t>
			        <cb:t resp="#resp1" xml:lang="pi" place="foot">Bh?radv?ja.</cb:t></cb:tt></lem>
        <rdg resp="#resp1" wit="#wit12">娑羅婆</rdg></app>

        <cb:tt type="app" from="#beg0680020" to="#end0680020">
	        <cb:t resp="#resp2" xml:lang="zh">婆羅婆</cb:t>
	        <cb:t resp="#resp1" xml:lang="pi" place="foot">Bh?radv?ja.</cb:t>
        </cb:tt>

        */
        string tagTt(XmlNode node)
        {
            string sHtml = "";
            string sType = GetAttr(node, "type");
            string sPlace = GetAttr(node, "place");

            if ((sPlace != "inline" && sType == "tr") || (sPlace != "inline" && sType == "")) {
                NextLine.FindNextLine();   // 這是隔行對照
            }

            // 在 <cb:tt type="single-line"> 中, 這時每一個 <t> 都要換行 ,
            // T54n2133A : <lb n="1194c17"/><p><cb:tt type="single-line"><cb:t lang="san-sd">
            if (sType == "single-line") {
                InTTNormal = true;
            }

            sHtml += parseChild(node); // 處理內容

            NextLine.FindNextLineEnd();
            InTTNormal = false;
            return sHtml;
        }

        // 百品新的標記, 表示猜測字 <unclear reason="damage" cert="high"></unclear>
        // 依據猜測程度 , cert 有如下內容 高:high 中高:above_medium 中:medium 低:low
        // <unclear/> 無法辨別的字, 呈現 ▆
        string tagUnclear(XmlNode node)
        {
            string sHtml = "";
            string sCert = GetAttr(node, "cert");

            if (sCert == "high") {
                sHtml += "<span class='guess1' title='本字為推測字，信心程度：高'>";
            } else if (sCert == "above_medium") {
                sHtml += "<span class='guess2' title='本字為推測字，信心程度：中高'>";
            } else if (sCert == "medium") {
                sHtml += "<span class='guess3' title='本字為推測字，信心程度：中'>";
            }  else if (sCert == "low") {
                sHtml += "<span class='guess4' title='本字為推測字，信心程度：低'>";
            } else {
                sHtml += "<span title='此處文字無法辨識'>";
            }

            if (node.HasChildNodes) {
                sHtml += parseChild(node); // 處理內容
            } else {
                sHtml += "▆";
            }

            sHtml += "</span>";
            return sHtml;
        }

        // 傳入 xml 的 style 和 rend 內容，傳回 html 的 style 和 class
        // 第一個參數是指定的 class 名稱
        string getStyleClass(string className, string sStyle, string sRend)
        {
            CStyleAttr myStyle = new CStyleAttr(sStyle);
            CRendAttr myRend = new CRendAttr(sRend);
            return getStyleClass(className, myStyle, myRend);
        }

        string getStyleClass(string className, CStyleAttr myStyle, CRendAttr myRend)
        {
            string sNewStyle = myStyle.NewStyle;
            string sNewClass = className == "" ? myRend.NewClass : className + " " + myRend.NewClass;
            if (sNewStyle != "") {
                sNewStyle = " style='" + sNewStyle + "'";
            }
            if (sNewClass != "") {
                sNewClass = " class='" + sNewClass + "'";
            }
            return sNewStyle + sNewClass;
        }

        // 通知 note orig , 此校勘有 mod 版
        // 就會把 orig note 中 class 的 note_mod 移除
        void ThisNoteHasMod(string sId)
        {
            // 在 T27n1545 有 id = 0003002A 的校勘
            // 所以要同時處理 0003002A 與 0003002
            // 因為有時 mod 會有 a, b 還是要還原回 7 個字
            // 若有 xxxxxxxA , 就處理. 否則就處理 xxxxxxx 7 個字的版本.
            if (mOrigNote.ContainsKey(sId)) {
                mOrigNote[sId] = mOrigNote[sId].Replace("class='note_orig note_mod'", "class='note_orig'");

                // 如果是呈現 CBETA 版, 此校勘又有 mod 了, 因此要把 display:inline 換成 display:none
                if (Setting.CollationType == ECollationType.CBETA) {
                    mOrigNote[sId] = mOrigNote[sId].Replace("display:inline", "display:none");
                }
            } else if (sId.Length > 7) {
                string sIdNormal = sId.Substring(0, 7);
                if (mOrigNote.ContainsKey(sIdNormal)) {
                    mOrigNote[sIdNormal] = mOrigNote[sIdNormal].Replace("class='note_orig note_mod'", "class='note_orig'");

                    // 如果是呈現 CBETA 版, 此校勘又有 mod 了, 因此要把 display:inline 換成 display:none
                    if (Setting.CollationType == ECollationType.CBETA) {
                        mOrigNote[sIdNormal] = mOrigNote[sIdNormal].Replace("display:inline", "display:none");
                    }
                }
            }
        }

        // 原本的 orig 校勘還沒加入, 此時才要加入
        string AddOrigNote(string HTMLText)
        {
            if (HTMLText == "") {
                return "";
            }
            List<char> vOut = new List<char>();

            // System::WideChar * pPoint = HTMLText.FirstChar();
            int pPoint = 0;

            // 標記用的 <<tmp_note_orig_xxxxxxx>>
            while (pPoint < HTMLText.Length) {
                if (HTMLText[pPoint] != '<' || HTMLText[pPoint + 1] != '<') {
                    vOut.Add(HTMLText[pPoint]);
                    pPoint++;
                } else {
                    // 也許找到校勘記號
                    //string sNote = String(pPoint, 16);
                    string sNote = HTMLText.Substring(pPoint, 16);
                    if (sNote == "<<tmp_note_orig_") {
                        // 找到校勘記號
                        string sId;

                        int iShift = 23;

                        while (HTMLText[pPoint + iShift] != '>') {
                            iShift++;
                        }

                        sId = HTMLText.Substring(pPoint + 16, iShift - 16);
                        pPoint = pPoint + iShift + 2;

                        string sNoteOrig = mOrigNote[sId];  // 取出真正的校勘

                        int pNote = 0;
                        while (pNote < sNoteOrig.Length) {
                            vOut.Add(sNoteOrig[pNote]);
                            pNote++;
                        }
                    } else {
                        // 不是校勘記號
                        vOut.Add(HTMLText[pPoint]);
                        pPoint++;
                    }
                }
            }

            string sOut = string.Concat(vOut);
            return sOut;
        }

        // 傳入 note 標記的 id , 傳回流水號, 若沒有就自動 + 1 並傳回
        int Get_Add_IdNum(string sId)
        {
            if (mpNoteAddNum.ContainsKey(sId)) {
                // 找到了, 傳回流水號
                return mpNoteAddNum[sId];
            } else {
                // 沒找到, 產生一個
                NoteAddNum++;
                mpNoteAddNum[sId] = NoteAddNum;
                return NoteAddNum;
            }
        }

        // 移除標點
        string RemovePunc(string sHtml)
        {
            sHtml = sHtml.Replace("．", "");
            sHtml = sHtml.Replace("、", "");
            sHtml = sHtml.Replace("，", "");
            sHtml = sHtml.Replace("：", "");
            sHtml = sHtml.Replace("；", "");
            sHtml = sHtml.Replace("。", "");
            sHtml = sHtml.Replace("？", "");
            sHtml = sHtml.Replace("！", "");
            sHtml = sHtml.Replace("—", "");
            sHtml = sHtml.Replace("…", "");
            sHtml = sHtml.Replace("「", "");
            sHtml = sHtml.Replace("」", "");
            sHtml = sHtml.Replace("『", "");
            sHtml = sHtml.Replace("』", "");
            sHtml = sHtml.Replace("〈", "");
            sHtml = sHtml.Replace("〉", "");
            sHtml = sHtml.Replace("《", "");
            sHtml = sHtml.Replace("》", "");
            sHtml = sHtml.Replace("“", "");
            sHtml = sHtml.Replace("”", "");
            sHtml = sHtml.Replace("（", "");
            sHtml = sHtml.Replace("）", "");
            sHtml = sHtml.Replace("【", "");
            sHtml = sHtml.Replace("】", "");
            sHtml = sHtml.Replace("〔", "");
            sHtml = sHtml.Replace("〕", "");
            return sHtml;
        }

        // 取得 svg 的內容
        string GetSvgFile(string sFile)
        {
            return "";
        }

        // 儲存至 HTML
        public void SaveToHTML(string sFile)
        {
            using(StreamWriter sw = new StreamWriter(sFile)) {
                sw.Write(HTMLText);
            }
        }

        // 取得屬性
        string GetAttr(XmlNode node, string sAttr)
        {
            if (node.NodeType != XmlNodeType.Element) {
                return "";
            }
            if (node.Attributes[sAttr] != null) {
                return node.Attributes[sAttr].Value;
            } else {
                return "";
            }
        }

        // 把校勘ID 變成校勘數字 0001001 -> 1
        string NoteId2Num(string sId)
        {
            if (sId == "") {
                return "";
            }

            //int iLen = sId.Length();

            int it = 0;
            int itend = sId.Length;

            // 處理 - 號
            int iPos = sId.IndexOf('-');
            if (iPos >= 0) {
                itend = it + iPos;
            }

            it += 4; // 跳過頁碼

            // 處理科標解的校勘

            if (sId[it] == 'k' || sId[it] == 'b' || sId[it] == 'j') {
                it++;
            }

            while (sId[it] == '0' && it != itend - 1) {
                it++;
            }

            return sId.Substring(it, itend - it);
        }

        // 讀取缺字
        void ReadGaiji(XmlNode NodeGaijis)
        {
            /*
                IXMLDOMNode * xmlNodeGaiji;
                IXMLDOMNode * xmlNodeTmp;
                BSTR xmlNodeName;
                BSTR xmlNodeText;
                IXMLDOMNamedNodeMap * xmlNodeAttributes;
                AnsiString sCBCode;
                AnsiString sTmp;

                long listLength;
                NodeGaijis->get_length(&listLength);
            */
            
            for (int i = 0; i < NodeGaijis.ChildNodes.Count; i++) {
                XmlNode NodeGaiji = NodeGaijis.ChildNodes[i];

                // 逐一處理每一筆

                // <char xml:id="CB00166">
                string sCBCode = GetAttr(NodeGaiji, "xml:id");

                if (sCBCode != "") {
                    //string sType = sCBCode.Substring(0, 2);  // CB or SD or RJ
                    for (int j = 0; j < NodeGaiji.ChildNodes.Count; j++) {
                        XmlNode Node = NodeGaiji.ChildNodes[j];

                        if (Node.Name == "charProp") {
                            string sLocalName = Node["localName"].InnerText;
                            string sValue = Node["value"].InnerText;

                            // 組字式
                            if (sLocalName == "composition") {
                                CB2des[sCBCode] = sValue;
                            }
                            // 查詢通用字
                            if (sLocalName == "normalized form") {
                                CB2nor[sCBCode] = sValue;
                            }
                            // 悉曇字、蘭札字
                            // 羅馬轉寫字 (純文字)
                            if (sLocalName == "Romanized form in CBETA transcription") {
                                SD2roma[sCBCode] = sValue;
                            }
                            // 羅馬轉寫字 (unicode)
                            if (sLocalName == "Romanized form in Unicode transcription") {
                                SD2uni[sCBCode] = sValue;
                            }
                            // char (以 ttf 字型呈現)
                            if (sLocalName == "Character in the Siddham font") {
                                SD2char[sCBCode] = sValue;
                            }
                            if (sLocalName == "rjchar") {
                                SD2char[sCBCode] = sValue;
                            }
                            // 對映的 Big5 字
                            if (sLocalName == "big5") {
                                SD2big5[sCBCode] = sValue;
                            }
                        } else if (Node.Name == "mapping") {
                            string sType = GetAttr(Node, "type");
                            string sText = Node.InnerText;

                            // <mapping type="unicode">U+267DB</mapping>
                            // Unicode
                            if (sType == "unicode") {
                                UInt32 ul = StrToULong(sText.Substring(2), 16);
                                CB2uni[sCBCode] = LongToUnicode(ul);
                            }
                            // <mapping type="normal_unicode">U+25873</mapping>
                            // 通用 Unicode
                            if (sType == "normal_unicode") {
                                UInt32 ul = StrToULong(sText.Substring(2), 16);
                                CB2nor_uni[sCBCode] = LongToUnicode(ul);
                            }
                        }
                    }
                }
            }
        }

        // 取得下一個 node , 但因為有一些是 <lb type=old> , <pb type=old> <lb id=Rxx> 要忽略
        XmlNode GetNextSiblNode(XmlNode node)
        {
            XmlNode NextSiblNode = node.NextSibling;
            string sNextSiblNodeName = "";
            if (NextSiblNode == null) {
                return NextSiblNode;
            }

            XmlNodeType nodetype = NextSiblNode.NodeType;

            // 不是純 element , 傳回
            if (nodetype != XmlNodeType.Element) {
                return NextSiblNode;
            }

            // 這是純 element

            sNextSiblNodeName = NextSiblNode.Name;
            if (sNextSiblNodeName != "lb" && sNextSiblNodeName != "pb") {
                return NextSiblNode;
            }

            // 取出屬性
            string sType = GetAttr(NextSiblNode, "type");
            string sEd = GetAttr(NextSiblNode, "ed");
            string sN = GetAttr(NextSiblNode, "n");

            // 印順導師著作有 type="old" 要忽略
            if (sType == "old") {
                NextSiblNode = GetNextSiblNode(NextSiblNode);
            } else if (sEd != BookId) {
                // 如果 ed 屬性不是本書, 則忽略, 主要是卍續藏是 X, 但有 ed="Rxxx" 的情況
                NextSiblNode = GetNextSiblNode(NextSiblNode);
            }
            return NextSiblNode;
        }

        // 把 <tr/>..<tr><td> 中間的資料移到 <td> 裡面
        string mv_data_between_tr(string sHtml)
        {
            return "";
        }

        // 取代正規式 : 把 <tr/>..<tr><td> 中間的資料移到 <td> 裡面
        string TableTrReplace() //const TMatch &Match)
        {
            return "";
        }

        // 取得經文版本資訊
        string GetVerInfo()
        {
            /*
            <projectDesc>
                <p xml:lang="en" cb:type="ly">Text as provided by Mr. Hsiao Chen-Kuo, Text as provided by Mr. Chang Wen-Ming, Text as provided by Anonymous from USA, Punctuated text as provided by Dhammavassarama</p>
                <p xml:lang="zh-Hant" cb:type="ly">蕭鎮國大德提供，張文明大德提供，北美某大德提供，法雨道場提供新式標點</p>
            </projectDesc>
            */

            string sVerInfo = "";
            string sSourceFrom = "";   // 來源
            string sBookName = "";     // 版本名稱 : 大正藏
            string sVolNum = VolId.TrimStart('0');   // 冊
            string sSutraNum = SutraId.TrimStart('0');  // 經號
            string sSutraName = "";   // 經名
            string sPublishDate = "";   // 發行日期
            string sUpdateDate = "";   // 更新日期

            XmlNode xnProjectDesc = Document.DocumentElement["teiHeader"]["encodingDesc"]["projectDesc"];

            for (int i = 0; i < xnProjectDesc.ChildNodes.Count; i++) {
                XmlNode node = xnProjectDesc.ChildNodes[i];
                string sType = GetAttr(node, "cb:type");
                string sLang = GetAttr(node, "xml:lang");
                string sNodeName = node.Name;

                if (sNodeName == "p" && sType == "ly" && sLang == "zh-Hant") {
                    sSourceFrom = node.InnerText;
                }
            }

            // 讀取日期
            // <date>2019-09-12 02:11:51 +0800</date>
            XmlNode NodeDate = Document.DocumentElement["teiHeader"]["fileDesc"]["publicationStmt"]["date"];
            sUpdateDate = NodeDate.InnerText;
            if(sUpdateDate.Length > 10) {
                sUpdateDate = sUpdateDate.Substring(0,10);
            }
	        sBookName = Series.BookData.GetBookName(BookId);
            // 經名要移除 (第X卷)
            sSutraName = CCBSutraUtil.CutJuanAfterSutraName(SutraName);
	        sPublishDate = Series.PublishDate;

	        sVerInfo = "<br><br><span style='margin:15px; padding: 25px; border-radius: 20px; background-color: rgb(200, 234, 198); display:block; box-shadow:inset -3px -3px 10px #9bbc99'>\n";
	        sVerInfo += "【典籍資訊】" ;
	        sVerInfo += sBookName + "第 " + sVolNum + " 冊 No. " + sSutraNum + "《" + sSutraName + "》<br>\n";
	        sVerInfo += "【版本記錄】發行日期：" + sPublishDate;
	        if(sUpdateDate.Length == 10) {
                int d1 = int.TryParse(sUpdateDate.Substring(0, 4), out d1) ? d1 : 0;
                int d2 = int.TryParse(sUpdateDate.Substring(5, 2), out d2) ? d2 : 0;
                int d3 = int.TryParse(sUpdateDate.Substring(8, 2), out d3) ? d3 : 0;

		        if(d1 > 0 && d2 > 0 && d3 >0) {
			            sVerInfo += "，更新日期：" + sUpdateDate;
		        }
            }
            sVerInfo += "<br>\n";
            sVerInfo += "【編輯說明】本資料庫由中華電子佛典協會（CBETA）依「" + sBookName + "」所編輯<br>\n";
            //不管什麼版本, 都要列出版權宣告比較好
            //if(Application->Title == u"CBReader")
            {
                sVerInfo += "【資料說明】" + sSourceFrom + "<br>\n";
                sVerInfo += "【版權宣告】詳細說明請參閱【<a href='https://www.cbeta.org/copyright.php' target='_blank'>中華電子佛典協會資料庫版權宣告</a>】<br>\n";
            }
            sVerInfo += "</span><br>\n";

            return sVerInfo;
        }

        // 產生重複指定字串
        string StringRepeat(string str, int iCount)
        {
            // 底下不要處理，這樣負數才會出現錯誤。
            //if(iCount < 0) {
            //    iCount = iCount < 0 ? 0 : iCount;
            //}
            return string.Concat(Enumerable.Repeat(str, iCount));
        }

        UInt32 StrToULong(string str, int iBase)
        {
            UInt32 ul = Convert.ToUInt32(str, iBase);
            return ul;
        }

        string LongToUnicode(UInt32 UTF32)
        {
            if (UTF32 < 0x10000) {
                string s = ((char) UTF32).ToString();
                return s;
            }
            UInt32 t = UTF32 - 0x10000;
            UInt16 h = (UInt16) (((t << 12) >> 22) + 0xD800);
            UInt16 l = (UInt16) (((t << 22) >> 22) + 0xDC00);
            //UInt16 ret = ((h << 16) | (l & 0x0000FFFF));

            string sh = ((char) h).ToString();
            string sl = ((char) l).ToString();

            return sh + sl;
        }
    }
}
