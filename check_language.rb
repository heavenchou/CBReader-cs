# 檢查多國語系的資料
# 1. 讀入指定的語系
# 2. 逐一檢查所有 cs 檔
# 3. 設計畫面的 cs 檔，要檢查變數是否都有在語系檔中
# 4. 一般 cs 檔，檢查文字是否都在語系檔中

require 'inifile'

class CsFile
    def initialize(file_path)
        @file_name = file_path
        @log = ""
    end

    # 分析 cs 檔
    def analysic()
        if @file_name.match(/\/(.*)\.Designer\.cs/)
            @section = $1 + "Form"
            analysic_designer
        else
            @section = 'Message'
            analysic_normal
        end
        @log
    end

    # 分析表單設計程式
    def analysic_designer()
        puts @file_name
        File.readlines(@file_name).each { |line|
            line.strip!

            # 取得元件的文字
            # this.btOK.Text = "確定";
            if line.match(/this\.(.*?)\.Text\s*=\s*"(.*?)"/)
                title = $1
                text = $2
                if text.match(/\p{Han}/) 
                    if $lang[@section][title] == nil
                        @log += @section + " : " + title + " : " + text + "\n"
                    end
                end
            end

            # 取得元件 tip
            # this.toolTip1.SetToolTip(this.btMainFuncNarrow, "縮小頁面");
            # btMainFuncNarrow_tip=縮小頁面
            
            if line.match(/SetToolTip\(this\.(.*?),\s*"(.*?)"/)
                title = $1 + "_tip"
                text = $2
                if text.match(/\p{Han}/) 
                    if $lang[@section][title] == nil
                        @log += @section + " : " + title + " : " + text + "\n"
                    end
                end
            end
        }
    end

    # 分析一般程式
    def analysic_normal()
        File.readlines(@file_name).each { |line|
            line.strip!
            newline = line.sub(/\/\/.*/,'') # 移除註解
            newline = newline.gsub(/[^a-zA-Z]t\(".*?",\s*"\d{5}"\)/,'') # 移除 t("找不到 CBETA 資料", "01004")
            if newline.match(/"(.*)"/)
                text = $1
                if text.match(/\p{Han}/)    # 有漢字
                    @log += line + "\n"
                end
            end
        }
    end

end

#####################
# 主程式
#####################

# 取得語系檔

$lang = IniFile.load('d:/Data/csharp/CBReader/CBReader/bin/Debug/Language/zh-TW.ini')

# 取得所有 cs 檔案

files = Dir.glob('CBReader/*.cs')

fout = File.new('check_language.txt','w')
files.each { |file|
    cs = CsFile.new(file)
    log = cs.analysic   # 分析檔案
    if log != ''
        fout.puts '=============================='
        fout.puts file
        fout.puts '=============================='
        fout.puts log
        fout.puts
    end
}
fout.close