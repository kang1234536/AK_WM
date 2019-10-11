using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1006_윈폼시험다시
{
    class Drink
    {
        public string Name { get; private set; }
        private int price;
        public int Count { get; private set; }
        public int Selcount { get; private set; }

        public int Price
        {
            get { return price; }
            set
            {
                if (value < 0)
                {
                    throw new Exception("가격은 0이상 필요함");
                }
                else
                    price = value;
            }
        }

        public Drink(string n, int p, int c)
        {
            Name = n;
            Price = p;
            Count = c;
        }
        public int GetSal()
        {
            return Price * Selcount;
        }

        public void SelDrink()
        {
            Count--;
            Selcount++;
        }

        public override string ToString()
        {
            return string.Format("[{0}/{1}원] 판매 {2}개 , 재고 {3}개", Name, Price, Selcount, Count);
        }
    }
}
