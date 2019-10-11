using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1006_윈폼시험다시
{
    class Machine
    {
        List<Drink> drinklist = new List<Drink>();
        public int SelCount { get; private set; }
        public int SelMoney { get; private set; }
        public int Money { get; private set; }

        public Machine()
        {
            SelCount = 0;
            SelMoney = 0;
            Money = 0;
            InitDrinkSetting();
        }

        public void InitDrinkSetting()
        {
            try
            {
                drinklist.Add(new Drink("콜라", 800, 50));
                drinklist.Add(new Drink("사이다", 700, 50));
                drinklist.Add(new Drink("밀키스", 600, 50));
                drinklist.Add(new Drink("웰치스", 1200, 50));
                drinklist.Add(new Drink("마운틴듀", 1400, 50));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public string[] PrintAll()
        {
            string[] items = new string[5];
            for (int i = 0; i < drinklist.Count; i++)
            {
                Drink d = drinklist[i];
                string str = string.Format("{0}({1})", d.Name, d.Price);
                items[i] = str;
            }
            return items;

        }

        public void InputMoney(int value)
        {
            if (value <= 0)
                throw new Exception("0보다 큰 금액을 투입");

            Money += value;
        }

        public void SelectDrink(string name)
        {
            foreach (Drink d in drinklist)
            {
                if (d.Name.Equals(name))
                {
                    if (d.Count <= 0)
                        throw new Exception("재고가 없다");

                    if (d.Price > Money)
                        throw new Exception("금액이 모자라다");

                    d.SelDrink();
                    SelDrink(d.Price);
                }
            }
        }
        public void SelDrink(int price)
        {
            SelCount++;
            SelMoney += price;
            Money -= price;
        }

        public void GetMoney()
        {
            Money = 0;
        }

        public void Getlist(ListView listview)
        {
            foreach (Drink d in drinklist)
            {
                string[] items = { d.Name, string.Format("{0}", d.Price), string.Format("{0}", d.Count) };
                ListViewItem a = new ListViewItem(items);
                listview.Items.Add(a);
            }
        }

        public Drink Drinkinfo(string name)
        {
            foreach (Drink d in drinklist)
            {
                if (d.Name.Equals(name))
                {
                    return d;
                }
            }
            throw new Exception("없음");
        }
    }
}
