using System;
using System.Collections;
using System.Collections.Generic;

namespace practice_iterator
{
    //引数以下の３の倍数を列挙して返すクラス
    class Multiple:IEnumerable<int>//イテレーター継承。列挙可能であること示している
    {
        public int max;
        public Multiple(int max)//コンストラクター
        {
            this.max = max;
        }
        //イテレーター実装（IEnumerator型のGetEnumeratorメソッドを定義）
        public IEnumerator<int> GetEnumerator()
        {

            const int min= 1;
            for(int n = min; n<= max; n++)
            {
                int m = n % 3;
                if (m == 0)
                {
                    //毎回nを返した後は処理を止める
                    yield return n;
                }
          
            }
        
        }
        //列挙子（IEnumerator型）を返すメソッド
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            /*
            var list = new List<int> { 10, 20, 30 };
            foreach (var l in list)
            {
                Console.WriteLine(l);
                var n = l+10;
                Console.WriteLine(n);
            }*/
            //そもそもlistや配列などforeachを使用できるコレクションではないものについては、IEnumerableを
            //実装し、GetEnumeratorも実装している必要がある
            var list_2 = new Multiple(30);
           foreach (var n in list_2)
            {
                Console.WriteLine($"{n}は３の倍数です");
            }
        }
    }
}
