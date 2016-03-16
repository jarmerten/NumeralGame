using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class RomanConversions
    {
        private List<string> RomanList = new List<string>();

        private List<char> NumeralList = new List<char>();

        private int remainder;

        private int romans2Add;

        private int decConvertTotal;

        public RomanConversions()
        {
        }

        public void ConvertFromRome(string UserInputRomanNumeral)
        {
            int lengthofuserinputedstring = this.NumeralList.Count<char>();
            for (int i = 1; i < lengthofuserinputedstring - 1; i++)
            {
                char firstcharinuserinputedstring = this.NumeralList.ElementAt<char>(i);
                char secondcharinuserinputedstring = this.NumeralList.ElementAt<char>(i + 1);
                char threecharinuserinputedstring = this.NumeralList.ElementAt<char>(i - 1);
                if (i != 1)
                {
                    if (firstcharinuserinputedstring == threecharinuserinputedstring)
                    {
                        this.decConvertTotal = this.decConvertTotal + this.RomeConverter(firstcharinuserinputedstring);
                    }
                    else if ((firstcharinuserinputedstring == threecharinuserinputedstring ? false : firstcharinuserinputedstring != secondcharinuserinputedstring))
                    {
                        if (this.RomeConverter(secondcharinuserinputedstring) <= this.RomeConverter(firstcharinuserinputedstring))
                        {
                            this.decConvertTotal = this.decConvertTotal + this.RomeConverter(firstcharinuserinputedstring);
                        }
                        else
                        {
                            this.decConvertTotal = this.decConvertTotal + (this.RomeConverter(secondcharinuserinputedstring) - this.RomeConverter(firstcharinuserinputedstring));
                            i++;
                        }
                    }
                }
                else if (firstcharinuserinputedstring == secondcharinuserinputedstring)
                {
                    this.decConvertTotal = this.decConvertTotal + this.RomeConverter(firstcharinuserinputedstring);
                }
                else if (i + 2 == lengthofuserinputedstring)
                {
                    this.decConvertTotal = this.decConvertTotal + this.RomeConverter(firstcharinuserinputedstring);
                }
                else if (firstcharinuserinputedstring != secondcharinuserinputedstring)
                {
                    if (this.RomeConverter(secondcharinuserinputedstring) <= this.RomeConverter(firstcharinuserinputedstring))
                    {
                        this.decConvertTotal = this.decConvertTotal + this.RomeConverter(firstcharinuserinputedstring);
                    }
                    else
                    {
                        this.decConvertTotal = this.decConvertTotal + (this.RomeConverter(secondcharinuserinputedstring) - this.RomeConverter(firstcharinuserinputedstring));
                        i++;
                    }
                }
            }
            Console.WriteLine(string.Concat(new object[] { "The Roman Numeral ", UserInputRomanNumeral, " is equal to a decimal value of ", this.decConvertTotal }));
            this.NumeralList.Clear();
            this.MainBuild();
        }

        public void ListConverter()
        {
            Console.WriteLine(string.Join("", this.RomanList));
            this.MainBuild();
        }

        public string ListCreator(string UserInputString)
        {
            int userinputedstringlength = UserInputString.Count<char>();
            string userinputedstringtoupper = UserInputString.ToUpper();
            this.NumeralList.Add('P');
            for (int i = 0; i <= userinputedstringlength - 1; i++)
            {
                this.NumeralList.Add(userinputedstringtoupper.ElementAt<char>(i));
            }
            this.NumeralList.Add('P');
            return userinputedstringtoupper;
        }

        public void MainBuild()
        {
            Console.WriteLine("Would you like to check a 1) Roman Numeral or 2) a regular Integer?");
            int userinputedgamechoice = int.Parse(Console.ReadLine());
            if (userinputedgamechoice == 2)
            {
                Console.WriteLine("Please input your Number.");
                int userinputednumber = int.Parse(Console.ReadLine());
                this.decConvertTotal = 0;
                this.SwitchtoStart(userinputednumber);
            }
            else if (userinputedgamechoice == 1)
            {
                Console.WriteLine("Please input your Roman Numeral.");
                string userinputedstring = Console.ReadLine();
                this.decConvertTotal = 0;
                this.ConvertFromRome(this.ListCreator(userinputedstring));
            }
        }

        public void RomanAssigner(int Num2Convert, int Divisor, int SecondaryDivisor, string Letter2Add, string SecondaryOpp)
        {
            if (Num2Convert < Divisor)
            {
                this.RomanList.Add(SecondaryOpp);
                this.RomanList.Add(Letter2Add);
                this.remainder = Num2Convert % SecondaryDivisor;
                this.SwitchtoStart(this.remainder);
            }
            else if (Num2Convert >= Divisor)
            {
                this.romans2Add = Num2Convert / Divisor;
                this.remainder = Num2Convert % Divisor;
                for (int i = 0; i < this.romans2Add; i++)
                {
                    this.RomanList.Add(Letter2Add);
                }
                this.SwitchtoStart(this.remainder);
            }
        }

        public int RomeConverter(char RomeDig)
        {
            int valueofnumeral;
            char romeDig = RomeDig;
            if (romeDig > 'D')
            {
                switch (romeDig)
                {
                    case 'I':
                        {
                            valueofnumeral = 1;
                            break;
                        }
                    case 'J':
                    case 'K':
                        {
                            valueofnumeral = 0;
                            return valueofnumeral;
                        }
                    case 'L':
                        {
                            valueofnumeral = 50;
                            break;
                        }
                    case 'M':
                        {
                            valueofnumeral = 1000;
                            break;
                        }
                    default:
                        {
                            if (romeDig == 'V')
                            {
                                valueofnumeral = 5;
                                break;
                            }
                            else if (romeDig == 'X')
                            {
                                valueofnumeral = 10;
                                break;
                            }
                            else
                            {
                                valueofnumeral = 0;
                                return valueofnumeral;
                            }
                        }
                }
            }
            else if (romeDig == 'C')
            {
                valueofnumeral = 100;
            }
            else
            {
                if (romeDig != 'D')
                {
                    valueofnumeral = 0;
                    return valueofnumeral;
                }
                valueofnumeral = 500;
            }
            return valueofnumeral;
        }

        public void SwitchtoStart(int Num2Convert)
        {
            if (Num2Convert >= 900)
            {
                this.RomanAssigner(Num2Convert, 1000, 900, "M", "C");
            }
            else if (Num2Convert >= 400)
            {
                this.RomanAssigner(Num2Convert, 500, 400, "D", "C");
            }
            else if (Num2Convert >= 90)
            {
                this.RomanAssigner(Num2Convert, 100, 90, "C", "X");
            }
            else if (Num2Convert >= 40)
            {
                this.RomanAssigner(Num2Convert, 50, 40, "L", "X");
            }
            else if (Num2Convert >= 9)
            {
                this.RomanAssigner(Num2Convert, 10, 9, "X", "I");
            }
            else if (Num2Convert >= 4)
            {
                this.RomanAssigner(Num2Convert, 5, 4, "V", "I");
            }
            else if (Num2Convert < 1)
            {
                this.ListConverter();
                this.RomanList.Clear();
            }
            else
            {
                this.RomanAssigner(Num2Convert, 1, 0, "I", "I");
            }
        }
    }
}
