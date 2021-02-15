using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirİşlemOyunu
{
    class Program
    {
        public static int hedef;
        static void Main(string[] args)
        {
            int[] rsayi = new int[6];

            Random rand = new Random();

            while (true)
            {
                Console.WriteLine("Sayılar random üretilsin mi ?:(E-H) ");
                string secim;
                secim = Console.ReadLine();
                if(secim =="E"||secim =="e")
                {
                    for (int i = 0; i < 5; i++)
                    {
                        rsayi[i] = rand.Next(1, 10);
                    }
                    rsayi[5] = rand.Next(1, 10) * 10;
                    List<int> list = new List<int>(rsayi);
                    Console.WriteLine("Tüm Sayılar: " + rsayi[0] + "," + rsayi[1] + "," + rsayi[2] + "," + rsayi[3] + "," + rsayi[4] + "," + rsayi[5] + "\n");
                    Random rastgele2 = new Random();
                    hedef = rastgele2.Next(100, 999);
                    Console.WriteLine("Bulunacak Hedef Sayı: " + hedef);
                    
                    Permutation_Sort(list,3);
                    Console.ReadLine();
                    break;
                }
                if (secim == "H" || secim == "h")
                {
                    for (int i = 0; i < 6; i++)
                    {
                        Console.Write("Lütfen {0}. sayıyı giriniz:", i + 1);
                        rsayi[i] = Convert.ToInt32(Console.ReadLine());

                    }
                    hedef = rand.Next(100, 999);
                    Console.WriteLine("Bulunacak Hedef Sayı: " + hedef);
                    List<int> list = new List<int>(rsayi);
                    Permutation_Sort(list,3);
                    Console.ReadLine();
                    break;
                }
                else
                {
                    Console.WriteLine("Yanlış secim yaptınız!!!");
                }

                
                Console.WriteLine("ÇÖZÜMLER...");
               
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();
            }
            

        }

        static void Permutation_Sort(List<int> list,int delay)
        {
      
            
            int yinele = 0;
            while (!IsSorted(list))
            {
                if (delay != 0)
                {
                    System.Threading.Thread.Sleep(Math.Abs(delay));
                }
                list = Remap(list);
                operations(list);
                yinele++;
            }
            Console.WriteLine();
            Console.WriteLine(" Permutation completed after {0} iterations.", yinele);
            
        }


        static bool IsSorted(List<int> list)
        {
            for (int i = 0; i < list.Count - 1; i++)
            {
                if (list[i] > list[i + 1])
                {
                    return false;
                }
            }

            return true;
        }
        static List<int> Remap(List<int> list)
        {
            int temp;
            List<int> newList = new List<int>();
            Random r = new Random();

            while (list.Count > 0)
            {
                temp = (int)r.Next(list.Count);
                newList.Add(list[temp]);
                list.RemoveAt(temp);
            }
            return newList;

        }
        static void operations(List<int> list)
        {
            float sonuc1, sonuc2, sonuc3, sonuc4, sonuc5;
            string islem1, islem2, islem3, islem4, islem5;
            //1. Islem
            for (int i = 0; i < 4; i++)
            {
                
                float sonuc = 0;
                switch (i)
                {
                    case 0:
                        sonuc = list[0] + list[1];
                        islem1 = "+";
                        break;
                    case 1:
                        sonuc = list[0] - list[1];
                        islem1 = "-";
                        break;
                    case 2:
                        sonuc = list[0] * list[1];
                        islem1 = "*";
                        break;
                    case 3:
                        sonuc = list[0] / list[1];
                        islem1 = "/";
                        break;
                    default:
                        islem1 = null;
                        break;
                }
                sonuc1 = sonuc;
                if (sonuc == hedef)
                {
                    Console.WriteLine("*******************");
                    Console.WriteLine(list[0] + islem1 + list[1] + "=" + sonuc + "\n\n");
                    break;
                   
                }
                //2.İşlem
                for (int j = 0; j < 4; j++)
                {
                    
                    sonuc = sonuc1;
                    switch (j)
                    {
                        case 0:
                            sonuc += list[2];
                            islem2 = "+";
                            break;
                        case 1:
                            sonuc -= list[2];
                            islem2 = "-";
                            break;
                        case 2:
                            sonuc *= list[2];
                            islem2 = "*";
                            break;
                        case 3:
                            sonuc /= list[2];
                            islem2 = "/";
                            break;
                        default:
                            islem2 = null;
                            break;
                    }
                    sonuc2 = sonuc;
                    if (sonuc == hedef)
                    { 
                        Console.WriteLine("*******************");
                      
                        Console.WriteLine(list[0] + islem1 + list[1] + " = " + sonuc1 + "\n"
                                         + sonuc1 + islem2 + list[2] + " = " + sonuc + "\n\n");
                        break;
                    }


                    // 3. Islem
                    for (int k = 0; k < 4; k++)
                    {
                        
                        sonuc = sonuc2;
                        switch (k)
                        {
                            case 0:
                                sonuc += list[3];
                                islem3 = "+";
                                break;
                            case 1:
                                sonuc -= list[3];
                                islem3 = "-";
                                break;
                            case 2:
                                sonuc *= list[3];
                                islem3 = "*";
                                break;
                            case 3:
                                sonuc /= list[3];
                                islem3 = "/";
                                break;
                            default:
                                islem3 = null;
                                break;
                        }
                        sonuc3 = sonuc;
                        if (sonuc == hedef)
                        {
                            Console.WriteLine("*******************");
                            Console.WriteLine(list[0] + islem1 + list[1] + " = " + sonuc1 + "\n"
                                             + sonuc1 + islem2 + list[2] + " = " + sonuc2 + "\n"
                                             + sonuc2 + islem3 + list[3] + " = " + sonuc + "\n\n");
                            break;
                        }
                        // 4. Islem
                        for (int l = 0; l < 4; l++)
                        {
                            
                            sonuc = sonuc3;
                            switch (l)
                            {
                                case 0:
                                    sonuc += list[4];
                                    islem4 = "+";
                                    break;
                                case 1:
                                    sonuc -= list[4];
                                    islem4 = "-";
                                    break;
                                case 2:
                                    sonuc *= list[4];
                                    islem4 = "*";
                                    break;
                                case 3:
                                    sonuc /= list[4];
                                    islem4 = "/";
                                    break;
                                default:
                                    islem4 = null;
                                    break;
                            }
                            sonuc4 = sonuc;
                            if (sonuc == hedef)
                            {
                                Console.WriteLine("*******************");
                                Console.WriteLine(list[0] + islem1 + list[1] + " = " + sonuc1 + "\n"
                                                 + sonuc1 + islem2 + list[2] + " = " + sonuc2 + "\n"
                                                 + sonuc2 + islem3 + list[3] + " = " + sonuc3 + "\n"
                                                 + sonuc3 + islem4 + list[4] + " = " + sonuc + "\n\n");
                                break;
                            }
                            //5. Islem
                            for (int m = 0; m < 4; m++)
                            {
                             
                                sonuc = sonuc4;
                                switch (m)
                                {
                                    case 0:
                                        sonuc += list[5];
                                        islem5 = "+";
                                        break;
                                    case 1:
                                        sonuc -= list[5];
                                        islem5 = "-";
                                        break;
                                    case 2:
                                        sonuc *= list[5];
                                        islem5 = "*";
                                        break;
                                    case 3:
                                        sonuc /= list[5];
                                        islem5 = "/";
                                        break;
                                    default:
                                        islem5 = null;
                                        break;
                                }
                                sonuc5 = sonuc;
                                if (sonuc == hedef)
                                {
                                    Console.WriteLine("*******************");
                                    Console.WriteLine(list[0] + islem1 + list[1] + " = " + sonuc1 + "\n"
                                                     + sonuc1 + islem2 + list[2] + " = " + sonuc2 + "\n"
                                                     + sonuc2 + islem3 + list[3] + " = " + sonuc3 + "\n"
                                                     + sonuc3 + islem4 + list[4] + " = " + sonuc4 + "\n"
                                                     + sonuc4 + islem5 + list[5] + " = " + sonuc + "\n\n");
                                    break;
                                }
                            }
                        }
                    }
                }
            }
           
        }
    }
}