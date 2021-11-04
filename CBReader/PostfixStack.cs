using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monster
{
	/*
	###################################
	# 練習計算機運算
	# 
	# 原則
	# 
	#  如果是數字, 如果有運算符號, 且層數都一樣, 就運算, 結果推入 query stack
	#  如果是數字, 如果有運算符號, 如果層數不一樣, 推入 query stack
	#  如果是數字, 沒有運算符號, 推入 query stack
	# 
	#  如果是運算符號, 推入 op stack , 且記錄目前層數
	#  
	#  如果是左括號, 目前層數 + 1
	#  如果是右括號, 層數 - 1 , 並且運算
	###################################
	*/

	public class CPostfixStack
	{
		char[] OpStack = new char[100];
		int[] LevelStack = new int[100];
		int Level = 0;
		int OpStackPoint = 0;

		int QueryStackSize = 0;     // query stack 的大小, 也就是有幾個, 因為若 pop 出來, 暫時不會去 delete 它.
		int QueryStackPoint = 0;    // 目前可以使用到的指標

		// ???? 超過 100 個怎麼辦?
		//CInt2List[] QueryStack = new CInt2List[100];
		public List<CInt2List> QueryStack = new List<CInt2List>();

		// 初值化
		public void Initial()
		{
			Level = 0;
			OpStackPoint = 0;
			QueryStackPoint = 0;
		}

		// 傳入一詞的查詢結果
		public void PushOp(string sOp)
		{
			if(sOp == "(") {
				// 如果是左括號, 目前層數 + 1
				Level++;
			} else if(sOp == ")") {
				// 如果是右括號, 層數 - 1 , 並且運算
				Level--;
				Run();
			} else {
				PushOpStack(sOp);
			}
		}

		public void PushOpStack(string sOp)
		{
			// 如果是運算符號, 推入 op stack , 且記錄目前層數
			OpStack[OpStackPoint] = sOp[0];
			LevelStack[OpStackPoint] = Level;
			OpStackPoint++;
		}

		// 進行分析
		public void Run()
		{
			if(OpStackPoint <= 0) { return; }                       // 沒有任何運算符號, 所以離開
			if(QueryStackPoint < 2) { return; }                     // 有問題, 不可能小於2 
			if(Level != LevelStack[OpStackPoint-1]) { return; }     // 層級不對, 不能運算

			// 取出運算符號

			OpStackPoint--;
			char cNowOp = OpStack[OpStackPoint];

			switch(cNowOp) {
				case '&':
					QueryStackPoint--;
					QueryStack[QueryStackPoint-1].AndIt(QueryStack[QueryStackPoint]);
					break;
				case ',':
					QueryStackPoint--;
					QueryStack[QueryStackPoint-1].OrIt(QueryStack[QueryStackPoint]);
					break;
				case '+':
					QueryStackPoint--;
					QueryStack[QueryStackPoint-1].NearIt(QueryStack[QueryStackPoint]);
					break;
				case '*':
					QueryStackPoint--;
					QueryStack[QueryStackPoint-1].BeforeIt(QueryStack[QueryStackPoint]);
					break;
				case '-':
					QueryStackPoint--;
					QueryStack[QueryStackPoint-1].ExcludeIt(QueryStack[QueryStackPoint]);
					break;
			}
		}

		// 傳入一詞的查詢結果
		public void PushQuery(CInt2List FoundPos, string sSearchString)
		{
			//  如果是數字, 如果有運算符號, 且層數都一樣, 就運算, 結果推入 query stack
			//  如果是數字, 如果有運算符號, 如果層數不一樣, 推入 query stack
			//  如果是數字, 沒有運算符號, 推入 query stack

			// 先檢查有沒有空間可以用

			if(QueryStackSize == QueryStackPoint)   // 空間不夠, 要 creat 一個新的
			{
				QueryStack.Add(new CInt2List());
				QueryStackSize++;
			}

			QueryStack[QueryStackPoint].Copy(FoundPos);
			QueryStack[QueryStackPoint].SearchString = sSearchString;
			QueryStackPoint++;
			Run();
		}

		// 傳回資料的筆數, 不是傳回結果, 若失敗傳回 -1
		public int GetResult()
		{
			// 檢查的標準如下:
			//
			// 1.運算符號堆疊 op stack 必須為 0
			// 2.運算堆疊 query stack 只有一組
			// 3.層數必須為 0

			
			if(OpStackPoint != 0) { return -1; }	// 1.
			if(QueryStackPoint != 1) { return -1; }	// 2.
			if(Level != 0) { return -1; }			// 3.

			// 傳回標準的結果
			return (QueryStack[0].Int2s.Count);
		}
	}
}
