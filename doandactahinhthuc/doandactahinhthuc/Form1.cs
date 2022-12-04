using Microsoft.CSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.CodeDom;
using System.IO;

namespace doandactahinhthuc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Input_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e) // code của the magic button
        {

            string huycute = Input.Text;
            int check = 0;

            //--------------------------------------------------------------------------------- lay path cua nguoi dung va copy
            string startupPath = System.IO.Directory.GetCurrentDirectory();
            string fixPath = "";
            int counttheslack = 0;
            for (int i = startupPath.Length - 1; i >= 0; i--)
            {
                if (startupPath[i] == '\\')
                {
                    counttheslack++;
                    if (counttheslack <= 3)
                    {
                        continue;
                    }
                }

                if (counttheslack >= 3)
                    fixPath += startupPath[i];
            }
            fixPath = Reverse(fixPath);
            string runcppmagic = "g++ " + fixPath + "\\" + "testcode.cpp -o " + fixPath + "\\" + "huycute.exe" + "\r\n" + fixPath + "\\" + "huycute.exe" + "\r\n";
            textBox1.Text = runcppmagic;
            string copytext = textBox1.Text;
            System.Windows.Forms.Clipboard.SetText(copytext);
            frameworkbox.Text = fixPath;
            //-----------------------------------------------------------------------------------


            //----------------------------------------------------------------------------------- check loai bai tap
            for (int i = 0; i < huycute.Length; i++)
            {
                if (huycute[i] == 'H')
                {
                    if (huycute[i + 1] == 'a')
                    {
                        if (huycute[i + 2] == 'm')
                        {
                            if (huycute[i + 4] == '(')
                            {
                                check = 1;
                                break;
                            }
                        }
                    }
                }
                if (i == 10)
                    break;
            }
            //-----------------------------------------------------------------------------------



            if (check == 1)
                Output.Text = UltimateConvertType2(huycute);

            if (check == 0)
                Output.Text = UltimateConvertType1(huycute);
        }




        static String UltimateConvertType1(string input)
        {
            int firstbracketopen = 0; // dia diem cua dau ngoac dau tien 
            int firstbracketclose = 0;

            int startpreword = 0;
            string beforepreword = "";
            string thewholething = "";
            string theprecontent = "";
            int startpostword = 0;
            string postword = "";
            string thekq = "";
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    firstbracketopen = i;

                }
                if (input[i] == ')')
                {
                    firstbracketclose = i;
                    break;
                }

            }



            //------------------------------------------ extract precontent
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == 'p')
                {
                    if (input[i + 1] == 'r')
                    {
                        if (input[i + 2] == 'e')
                        {
                            startpreword = i;
                        }
                    }
                }
            }
            for (int i = startpreword + 3; i < input.Length; i++)
            {
                if (input[i] == 'p')
                {
                    if (input[i + 1] == 'o')
                    {
                        if (input[i + 2] == 's')
                        {
                            if (input[i + 3] == 't')
                            {
                                startpostword = i;
                                break;
                            }
                        }
                    }
                }
            }
            for (int i = startpreword + 3; i < startpostword; i++)
            {
                theprecontent += input[i];
            }
            theprecontent = theprecontent.Trim(); // lam sach cac dau xuong dong hay space ngu
            //------------------------------------------ 




            //------------------------------------------ phan tich precontent
            string precontentfix = "";
            int pass = 0;
            for (int i = 0; i < theprecontent.Length; i++)
            {
                if (pass % 2 != 0)
                {
                    if (theprecontent[i] == '=' || theprecontent[i] == '&' || theprecontent[i] == '|')
                    {
                        pass++;
                        continue;
                    }
                }

                if (theprecontent[i] == '>' && (pass % 2 == 0))
                {
                    if (theprecontent[i + 1] == '=')
                    {
                        precontentfix += '<';
                        pass++;
                        continue;
                    }

                    if (theprecontent[i + 1] != '=')
                    {
                        precontentfix += "<=";

                        continue;
                    }

                }

                if (theprecontent[i] == '<' && (pass % 2 == 0))
                {
                    if (theprecontent[i + 1] == '=')
                    {
                        precontentfix += '>';
                        pass++;
                        continue;
                    }

                    if (theprecontent[i + 1] != '=')
                    {
                        precontentfix += ">=";

                        continue;
                    }

                }
                if (theprecontent[i] == '=' && (pass % 2 == 0))
                {
                    if (theprecontent[i + 1] == '=')
                    {
                        precontentfix += "!=";
                        pass++;
                        continue;
                    }

                    if (theprecontent[i + 1] != '=')
                    {
                        precontentfix += "!=";

                        continue;
                    }

                }
                if (theprecontent[i] == '!' && (pass % 2 == 0))
                {
                    if (theprecontent[i + 1] == '=')
                    {
                        precontentfix += "==";
                        pass++;
                        continue;
                    }

                    if (theprecontent[i + 1] != '=')
                    {
                        precontentfix += "==";

                        continue;
                    }

                }
                if (theprecontent[i] == '&' && (pass % 2 == 0))
                {
                    if (theprecontent[i + 1] == '&')
                    {
                        precontentfix += "||";
                        pass++;
                        continue;
                    }

                    if (theprecontent[i + 1] != '&')
                    {
                        precontentfix += "||";

                        continue;
                    }

                }
                if (theprecontent[i] == '|' && (pass % 2 == 0))
                {
                    if (theprecontent[i + 1] == '|')
                    {
                        precontentfix += "&&";
                        pass++;
                        continue;
                    }

                    if (theprecontent[i + 1] != '|')
                    {
                        precontentfix += "&&";

                        continue;
                    }

                }
                precontentfix += theprecontent[i];
            }
            //------------------------------------------



            //------------------------------------------
            string TheClassName = "";// name cua class
            for (int i = 0; i < firstbracketopen; i++)
                TheClassName += input[i];
            TheClassName = TheClassName.Trim();
            //------------------------------------------


            //----------------------------------------- phan mo dau cua code
            thewholething += "#include <iostream>" + "\r\n" + "using namespace std;" + "\r\n" + "\r\n" + "class c" + TheClassName + "\r\n" + "{" + "\r\n" + "\r\n" + "private:" + "\r\n" + "\r\n";
            //----------------------------------------- 


            //----------------------------------------- phan tich cac bien cua de bai
            thewholething += TheFirstBracker(firstbracketopen, firstbracketclose, input, 1);
            //-----------------------------------------


            //----------------------------------------- khai bao phan ket qua
            for (int j = firstbracketclose + 1; j < input.Length; j++)
            {
                if (input[j] == 'p')
                {
                    if (input[j + 1] == 'r')
                    {
                        if (input[j + 2] == 'e')
                            startpreword = j;
                        break;
                    }
                }
            }
            for (int i = firstbracketclose + 1; i < startpreword; i++)
                beforepreword += input[i];

            thekq = Convertintotype(beforepreword.Trim(), 2); // lay bien ket qua
            thewholething += Convertintotype(beforepreword.Trim(), 1) + "\r\n" + "\r\n";
            //------------------------------------------


            //------------------------------------------ dong ngoac va viet cac ham
            thewholething += "public: " + "\r\n" + "\r\n" + "    void Nhap();" + "\r\n" + "    " + Convertintotype(beforepreword, 3) + " " + TheClassName + "();" + "\r\n" + "    void Xuat(" + Convertintotype(beforepreword, 3) + thekq + ");" + "\r\n" + "\r\n" + "};" + "\r\n";
            //------------------------------------------



            //------------------------------------------ ham nhap
            thewholething += "\r\n" + "void c" + TheClassName + "::Nhap()" + "\r\n" + "{" + "\r\n";
            if (string.IsNullOrEmpty(theprecontent) == false)
            {
                thewholething += "    do" + "\r\n" + "    {" + "\r\n";
                thewholething += TheFirstBracker(firstbracketopen, firstbracketclose, input, 2);
                thewholething += "    } while (" + precontentfix + ");" + "\r\n";
                thewholething += "}" + "\r\n";
            }
            if (string.IsNullOrEmpty(theprecontent) == true)
            {
                thewholething += "\r\n";
                thewholething += TheFirstBracker(firstbracketopen, firstbracketclose, input, 0);
                thewholething += "}" + "\r\n";
            }
            //------------------------------------------ 

            thewholething += "\r\n";

            //------------------------------------------ ham chinh
            thewholething += Convertintotype(beforepreword.Trim(), 3) + "c" + TheClassName + "::" + TheClassName + "()" + "\r\n" + "{" + "\r\n";
            //------------------------------------------ 





            //------------------------------------------ the post content
            for (int i = startpostword + 4; i < input.Length; i++)
            {
                postword += input[i];
            }
            postword = postword.Trim();
            thewholething += TheMainFunction(postword);
            thewholething += "    return " + thekq + ";" + "\r\n" + "}" + "\r\n" + "\r\n";
            //------------------------------------------


            //------------------------------------------ the cout content
            thewholething += "void c" + TheClassName + "::Xuat" + "(" + Convertintotype(beforepreword, 3) + " " + Convertintotype(beforepreword, 2) + ")" + "\r\n" + "{" + "\r\n";
            thewholething += "    cout << \" ket qua la: \" ;" + "\r\n";
            thewholething += "    cout << " + thekq + ";" + "\r\n";
            thewholething += "}" + "\r\n" + "\r\n";
            //------------------------------------------ 


            //------------------------------------------ the main content
            thewholething += "int main()" + "\r\n";
            thewholething += "{" + "\r\n";
            thewholething += "    c" + TheClassName + " a " + ";" + "\r\n";
            thewholething += "    a.Nhap();" + "\r\n";
            thewholething += "    " + Convertintotype(beforepreword, 3) + " " + Convertintotype(beforepreword, 2) + " = a." + TheClassName + "();" + "\r\n";
            thewholething += "    a.Xuat(" + thekq + ");" + "\r\n";
            thewholething += "    return 0;" + "\r\n";
            thewholething += "}";
            //------------------------------------------ 



            //------------------------------------------------------------------------
            return thewholething;
        }

        static String TheFirstBracker(int bracketdesopen, int bracketdesclose, string input, int type) // muc tieu cua ham nay la di phan tich dieu kien cua cac bien trong dau ngoac dau tien
        {
            string firstbracketresult = "";
            string TheCovertText = ""; // cac text mang di convert vidu a:R mang di qua ham khac

            for (int i = bracketdesopen + 1; i < bracketdesclose; i++)
            {
                if (input[i] != ',') // phan tich cac dau phay
                    TheCovertText += input[i];
                if (type == 0)
                {

                    if (input[i] == ',')
                    {

                        firstbracketresult += Convertintotype(TheCovertText, 0);
                        firstbracketresult += "\r\n";
                        TheCovertText = "";
                    }
                    if (i == bracketdesclose - 1) // neu ko con dau phay thi mac dinh lay o vi tri dau ngoac dong
                    {
                        firstbracketresult += Convertintotype(TheCovertText, 0);
                        firstbracketresult += "\r\n";
                    }
                }
                if (type == 1)
                {

                    if (input[i] == ',')
                    {

                        firstbracketresult += Convertintotype(TheCovertText, 1);
                        firstbracketresult += "\r\n";
                        TheCovertText = "";
                    }
                    if (i == bracketdesclose - 1) // neu ko con dau phay thi mac dinh lay o vi tri dau ngoac dong
                    {
                        firstbracketresult += Convertintotype(TheCovertText, 1);
                        firstbracketresult += "\r\n";
                    }
                }
                if (type == 2)
                {

                    if (input[i] == ',')
                    {

                        firstbracketresult += Convertintotype(TheCovertText, 5);
                        firstbracketresult += "\r\n";
                        TheCovertText = "";
                    }
                    if (i == bracketdesclose - 1) // neu ko con dau phay thi mac dinh lay o vi tri dau ngoac dong
                    {
                        firstbracketresult += Convertintotype(TheCovertText, 5);
                        firstbracketresult += "\r\n";
                    }
                }
            }

            return firstbracketresult;
        }
        static String Convertintotype(string input, int type) // muc tieu cua ham nay la di convert kieu du lieu vd: a:R -> float a; con cac kieu bien khac - can bo sung
        {
            //type la input type, neu bang 0 thi no se co phan cin neu la 1 thi ko co
            string output = "";         // bien ouput
            string theoutputa = "";    // phan truoc dau :
            string theoutputb = "";   // phan sau dau :
            string theoutputc = "";  // phan input tong cua a vs b
            string theoutputd = ""; // phan cin


            //---------------------------- cac loai kieu char
            char r = 'R';
            char n = 'N';
            char z = 'Z';
            char q = 'Q';
            char b = 'B';
            string charr = "char";
            string charrr = "char*";
            string nplus = "N+";
            string rr = "R*";
            //----------------------------


            for (int i = 0; i < input.Length; i++) //phan tich dau :
            {
                if (input[i] == ':')
                {

                    for (int j = 0; j < i; j++)
                        theoutputa += input[j];
                    for (int k = i + 1; k < input.Length; k++)
                        theoutputb += input[k];
                }
            }
            theoutputa = theoutputa.Trim();
            theoutputb = theoutputb.Trim();
            //phan tich cac kieu bien
            if (theoutputb == r.ToString())
                theoutputc = "double";
            if (theoutputb == n.ToString())
                theoutputc = "int";
            if (theoutputb == z.ToString())
                theoutputc = "int";
            if (theoutputb == q.ToString())
                theoutputc = "float";
            if (theoutputb == b.ToString())
                theoutputc = "bool";
            if (theoutputb == charr.ToString())
                theoutputc = "string";
            if (theoutputb == charrr.ToString())
                theoutputc = "string";
            if (theoutputb == rr.ToString())
                theoutputc = "double";
            if (type == 0)
            {
                theoutputd = "    cout << \" nhap so " + theoutputa + ": \"; " + "\r\n" + "    cin >> " + theoutputa + ";"; // khai bao bien
                output = theoutputd + "\r\n";
            }
            if (type == 1)
            {
                output = "    " + theoutputc + " " + theoutputa + ";";
            }
            if (type == 2)
            {
                output = theoutputa;
            }
            if (type == 3)
            {
                output = theoutputc + " ";
            }
            if (type == 4)
            {
                output = "    vector<" + theoutputc + "> " + theoutputa + ";";
            }
            if (type == 5)
            {
                theoutputd = "        cout << \" nhap so " + theoutputa + ": \"; " + "\r\n" + "        cin >> " + theoutputa + ";"; // khai bao bien
                output = theoutputd + "\r\n";
            }
            return output;
        }
        static String TheMainFunction(string input)
        {

            //---------------------------------------------------------- biến
            string output = "";
            string theinputa = "";
            int count = 0;// count so | se tien hon
            int counttheif = 0; // xac dinh so dau ||
            int theApostropheDes = 0;//xac dinh dau moc cua dau "
            //----------------------------------------------------------


            //----------------------------------------------- ham hoi phuc tap, chu yeu de phan tich cac dau
            for (int i = 0; i < input.Length; i++)
            {
                if (count == 0)
                    theinputa += input[i];
                if (input[i] == '|')
                {
                    if (counttheif == 0)
                    {
                        if (count == 0)
                        {
                            theinputa = ""; // neu co dau | se reset de su dung cho ham lap phia sau
                            for (int j = 0; j < i; j++)
                            {
                                theinputa += input[j];
                            }
                        }
                        count++;
                    }


                    if (counttheif > 0)
                    {

                        if (count == 0)
                        {
                            theinputa = ""; // neu co dau | se reset de su dung cho ham lap phia sau
                            for (int j = theApostropheDes + 1; j < i; j++)
                            {
                                theinputa += input[j];
                            }
                        }
                        count++;

                    }

                    if (count == 2)
                    {
                        counttheif++;
                        theApostropheDes = i;
                        output += DetermineTheFunction(theinputa.Trim());
                        theinputa = "";
                        count = 0;
                    }
                }
                if (i == input.Length - 1)
                {
                    theinputa = theinputa.Trim();
                    output += DetermineTheFunction(theinputa);
                }

            }
            return output;
        }
        static String DetermineTheFunction(string input)
        {

            //----------------------------------------------------------- các biến
            string output = ""; // output
            string theoutputa = ""; //output của biến trc dấu
            string theoutputb = ""; //output của biến sau dấu  
            int countthebracket = 0;
            int type = 0; // xac dinh type
            //----------------------------------------------------------- 


            //xác định type
            //----------------------------------------------------------------
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(' && countthebracket == 0)
                {
                    countthebracket++;
                }
                if (countthebracket == 1 && input[i + 1] == '(')
                {
                    type = 1;
                    break;
                }
                if (countthebracket == 1 && input[i + 1] == ')')
                {
                    type = 2;
                    break;
                }
            }
            //----------------------------------------------------------------


            //type 2 tức là chỉ có một phép so sánh
            //----------------------------------------------------------------
            if (type == 2) // vidu (x=b/a);
            {
                for (int i = 0; i < input.Length; i++)
                {
                    if (input[i] == '=')
                    {
                        for (int j = 1; j < i; j++)
                            theoutputa += input[j];
                        theoutputa = theoutputa.Trim();

                        for (int k = i + 1; k < input.Length - 1; k++)
                            theoutputb += input[k];
                        theoutputb = theoutputb.Trim();

                        break;
                    }

                }
                output = "    " + theoutputa + " = " + theoutputb + ";" + "\r\n";
            }
            //----------------------------------------------------------------


            //type 1 là loại có 2 so sánh
            //----------------------------------------------------------------
            if (type == 1) // vidu ((c=a)&&(a>=b))
            {
                int passtheand = 0;// dem so dau &
                int passthebracket = 0;//dem so dau ngoac
                for (int i = 0; i < input.Length; i++)
                {


                    if (input[i] == '&')
                        passtheand++;
                    if (passtheand == 2)
                    {
                        for (int j = i + 1; j < input.Length; j++)
                            theoutputa += input[j];
                        break;
                    }
                }

                //xet truong hop co dau = -> ==
                theoutputa = theoutputa.Trim();
                theoutputb = "";
                for (int i = 0; i < theoutputa.Length; i++)
                {
                    theoutputb += theoutputa[i];
                    if (theoutputa[i] == '=')
                    {
                        if ((theoutputa[i - 1] != '>') && (theoutputa[i - 1] != '<') && (theoutputa[i - 1] != '!'))
                        {
                            theoutputb += "=";
                        }
                    }
                }

                output += "    if (" + theoutputb + "\r\n";
                //------------------------------------------------------------------------------------- done part 1; 

                theoutputa = ""; //reset bien
                int passtrue = 0;
                int passfalse = 0;

                for (int i = 0; i < input.Length; i++)
                {
                    if (input[i] == '(')
                        passthebracket++;
                    if (passthebracket == 2)
                    {
                        for (int j = i + 1; j < input.Length; j++)
                        {

                            //------------------------------ dung de thay the vi khi de  FALSE hay TRUE thi code ko chay duoc
                            if (passtrue > 0 && passtrue <= 3)
                            {
                                passtrue++;
                                continue;
                            }

                            if (passfalse > 0 && passfalse <= 4)
                            {
                                passfalse++;
                                continue;
                            }

                            if (input[j] == 'T')
                            {
                                if (input[j + 1] == 'R')
                                {
                                    if (input[j + 2] == 'U')
                                    {
                                        if (input[j + 3] == 'E')
                                        {
                                            theoutputa += "true";
                                            passtrue++;
                                            continue;
                                        }
                                    }
                                }
                            }

                            if (input[j] == 'F')
                            {
                                if (input[j + 1] == 'A')
                                {
                                    if (input[j + 2] == 'L')
                                    {
                                        if (input[j + 3] == 'S')
                                        {
                                            if (input[j + 4] == 'E')
                                            {
                                                theoutputa += "false";
                                                passfalse++;
                                                continue;
                                            }
                                        }
                                    }
                                }
                            }
                            //------------------------------ 

                            if (input[j] != ')')
                                theoutputa += input[j];
                            if (input[j] == ')') // toi dau ) thi ngung
                                break;
                        }
                        break;
                    }

                }
                output += "        " + theoutputa + ";" + "\r\n";


                //------------------------------------------------------------------------------------- done part 2;
            }
            return output;
        }
        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }



        static String UltimateConvertType2(string input)
        {



            int firstbracketopen = 0; // dia diem cua dau ngoac dau tien 
            int firstbracketclose = 0;
            int startpreword = 0;
            string beforepreword = "";
            string thewholething = "";
            string theprecontent = "";
            int startpostword = 0;
            string postword = "";
            string thekq = "";





            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    firstbracketopen = i;

                }
                if (input[i] == ')')
                {
                    firstbracketclose = i;
                    break;
                }
            }

            //------------------------------------------ extract precontent
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == 'p')
                {
                    if (input[i + 1] == 'r')
                    {
                        if (input[i + 2] == 'e')
                        {
                            startpreword = i;
                        }
                    }
                }
            }
            for (int i = startpreword + 3; i < input.Length; i++)
            {
                if (input[i] == 'p')
                {
                    if (input[i + 1] == 'o')
                    {
                        if (input[i + 2] == 's')
                        {
                            if (input[i + 3] == 't')
                            {
                                startpostword = i;
                                break;
                            }
                        }
                    }
                }
            }
            for (int i = startpreword + 3; i < startpostword; i++)
            {
                theprecontent += input[i];
            }
            theprecontent = theprecontent.Trim(); // lam sach cac dau xuong dong hay space ngu

            //------------------------------------------ phan tich precontent
            string precontentfix = "";
            int pass = 0;
            for (int i = 0; i < theprecontent.Length; i++)
            {
                if (pass % 2 != 0)
                {
                    if (theprecontent[i] == '=' || theprecontent[i] == '&' || theprecontent[i] == '|')
                    {
                        pass++;
                        continue;
                    }
                }

                if (theprecontent[i] == '>' && (pass % 2 == 0))
                {
                    if (theprecontent[i + 1] == '=')
                    {
                        precontentfix += '<';
                        pass++;
                        continue;
                    }

                    if (theprecontent[i + 1] != '=')
                    {
                        precontentfix += "<=";

                        continue;
                    }

                }

                if (theprecontent[i] == '<' && (pass % 2 == 0))
                {
                    if (theprecontent[i + 1] == '=')
                    {
                        precontentfix += '>';
                        pass++;
                        continue;
                    }

                    if (theprecontent[i + 1] != '=')
                    {
                        precontentfix += ">=";

                        continue;
                    }

                }
                if (theprecontent[i] == '=' && (pass % 2 == 0))
                {
                    if (theprecontent[i + 1] == '=')
                    {
                        precontentfix += "!=";
                        pass++;
                        continue;
                    }

                    if (theprecontent[i + 1] != '=')
                    {
                        precontentfix += "!=";

                        continue;
                    }

                }
                if (theprecontent[i] == '!' && (pass % 2 == 0))
                {
                    if (theprecontent[i + 1] == '=')
                    {
                        precontentfix += "==";
                        pass++;
                        continue;
                    }

                    if (theprecontent[i + 1] != '=')
                    {
                        precontentfix += "==";

                        continue;
                    }

                }
                if (theprecontent[i] == '&' && (pass % 2 == 0))
                {
                    if (theprecontent[i + 1] == '&')
                    {
                        precontentfix += "||";
                        pass++;
                        continue;
                    }

                    if (theprecontent[i + 1] != '&')
                    {
                        precontentfix += "||";

                        continue;
                    }

                }
                if (theprecontent[i] == '|' && (pass % 2 == 0))
                {
                    if (theprecontent[i + 1] == '|')
                    {
                        precontentfix += "&&";
                        pass++;
                        continue;
                    }

                    if (theprecontent[i + 1] != '|')
                    {
                        precontentfix += "&&";

                        continue;
                    }

                }
                precontentfix += theprecontent[i];
            }
            //------------------------------------------


            //------------------------------------------
            string TheClassName = "";// name cua class
            for (int i = 0; i < firstbracketopen; i++)
                TheClassName += input[i];
            TheClassName = TheClassName.Trim();
            //------------------------------------------


            //----------------------------------------- phan mo dau cua code
            thewholething += "#include <iostream>" + "\r\n" + "#include <vector>" + "\r\n" + "using namespace std;" + "\r\n" + "\r\n" + "class c" + TheClassName + "\r\n" + "{" + "\r\n" + "\r\n" + "private:" + "\r\n" + "\r\n";
            //----------------------------------------- 


            //----------------------------------------- phan tich cac bien cua de bai
            thewholething += TheFirstBracker2(firstbracketopen, firstbracketclose, input, 1);
            string ClassName = TheFirstBracker2(firstbracketopen, firstbracketclose, input, 2);
            //-----------------------------------------

            //----------------------------------------- khai bao phan ket qua
            for (int j = firstbracketclose + 1; j < input.Length; j++)
            {
                if (input[j] == 'p')
                {
                    if (input[j + 1] == 'r')
                    {
                        if (input[j + 2] == 'e')
                            startpreword = j;
                        break;
                    }
                }
            }
            for (int i = firstbracketclose + 1; i < startpreword; i++)
                beforepreword += input[i];

            thekq = Convertintotype(beforepreword.Trim(), 2); // lay bien ket qua
            thewholething += Convertintotype(beforepreword.Trim(), 1) + "\r\n" + "\r\n";
            //------------------------------------------

            //------------------------------------------ dong ngoac va viet cac ham
            thewholething += "public: " + "\r\n" + "\r\n" + "    void Nhap(int num);" + "\r\n" + "    " + Convertintotype(beforepreword, 3) + "Xuly" + "(int num);" + "\r\n" + "    void Xuat(" + Convertintotype(beforepreword, 3) + thekq + ");" + "\r\n" + "\r\n" + "};" + "\r\n" + "\r\n";
            //------------------------------------------

            //------------------------------------------ ham nhap
            thewholething += "void c" + TheClassName + "::Nhap(int num)" + "\r\n" + "{" + "\r\n";
            if (string.IsNullOrEmpty(theprecontent) == false)
            {
                thewholething += "                                          If teacher has some pre-condition in type 2, I didnt expect it since I dont know how it work!";
            }
            if (string.IsNullOrEmpty(theprecontent) == true)
            {
                thewholething += "    int number;" + "\r\n";
                thewholething += "    " + ClassName + ".push_back(0);" + "\r\n"; // day la 1 ham doi pho vi co cho range vuot qua vector, neu de bai khong thoa, hay xoa dong nay
                thewholething += "    for (int i=0;i<num;i++)" + "\r\n" + "    {" + "\r\n";
                thewholething += "        cin >> number;" + "\r\n";
                thewholething += "        " + ClassName + ".push_back(number);" + "\r\n";
                thewholething += "    }" + "\r\n";
                thewholething += "    cout << \"Ban da hoan tat viec nhap !\";" + "\r\n";
                thewholething += "    cout << endl;" + "\r\n";
                thewholething += "}" + "\r\n" + "\r\n";
            }
            //------------------------------------------ 

            //------------------------------------------ ham chinh
            thewholething += Convertintotype(beforepreword.Trim(), 3) + "c" + TheClassName + "::" + "Xuly" + "(int n)" + "\r\n" + "{" + "\r\n";
            //------------------------------------------ 

            //------------------------------------------ the post content
            for (int i = startpostword + 4; i < input.Length; i++)
            {
                postword += input[i];
            }
            postword = postword.Trim();
            thewholething += TheMainFunction2(postword, ClassName);
            //------------------------------------------

            //------------------------------------------ xuat
            thewholething += "void c" + TheClassName + "::Xuat(bool x)" + "\r\n" + "{" + "\r\n";
            thewholething += "    if (x==1)" + "\r\n";
            thewholething += "        cout << \"Ket qua la: True\" ;" + "\r\n";
            thewholething += "    if (x==0)" + "\r\n";
            thewholething += "        cout << \"Ket qua la: False\" ;" + "\r\n";
            thewholething += "}" + "\r\n" + "\r\n";
            //------------------------------------------

            //------------------------------------------ main
            thewholething += "int main()" + "\r\n" + "{" + "\r\n";
            thewholething += "    c" + TheClassName + " a;" + "\r\n" + "\r\n";

            thewholething += "    int num;" + "\r\n";
            thewholething += "    cout << \"Nhap so phan tu: \";" + "\r\n";
            thewholething += "    cin >> num;" + "\r\n" + "\r\n";

            thewholething += "    " + ClassName + ".Nhap(num);" + "\r\n";
            thewholething += "    bool x = " + ClassName + ".Xuly(num);" + "\r\n";
            thewholething += "    " + ClassName + ".Xuat(x);" + "\r\n";
            thewholething += "    return 0;" + "\r\n";
            thewholething += "}" + "\r\n";
            //------------------------------------------

            return thewholething;
        }

        static String TheFirstBracker2(int bracketdesopen, int bracketdesclose, string input, int type) // muc tieu cua ham nay la di phan tich dieu kien cua cac bien trong dau ngoac dau tien
        {



            string firstbracketresult = "";
            string TheCovertText = ""; // cac text mang di convert vidu a:R mang di qua ham khac





            for (int i = bracketdesopen + 1; i < bracketdesclose; i++)
            {
                if (input[i] != ',') // phan tich cac dau phay
                    TheCovertText += input[i];
                if (type == 0)
                {

                    if (input[i] == ',')
                    {

                        firstbracketresult += Convertintotype(TheCovertText, 0);
                        firstbracketresult += "\r\n";
                        TheCovertText = "";
                    }
                    if (i == bracketdesclose - 1) // neu ko con dau phay thi mac dinh lay o vi tri dau ngoac dong
                    {

                    }
                }
                if (type == 1)
                {

                    if (input[i] == ',')
                    {

                        firstbracketresult += Convertintotype(TheCovertText, 4);
                        firstbracketresult += "\r\n";
                        TheCovertText = "";
                    }
                    if (i == bracketdesclose - 1) // neu ko con dau phay thi mac dinh lay o vi tri dau ngoac dong
                    {

                    }
                }
                if (type == 2)
                {

                    if (input[i] == ',')
                    {

                        firstbracketresult += Convertintotype(TheCovertText, 2);

                        TheCovertText = "";
                    }
                    if (i == bracketdesclose - 1) // neu ko con dau phay thi mac dinh lay o vi tri dau ngoac dong
                    {

                    }
                }
            }

            return firstbracketresult;
        }
        static String TheMainFunction2(string input, string variable)
        {



            string output = "";
            int markthebracket = 0;// setting {
            int markthefirstbracket = 0; // danh dau dau ( dau tien
            int countthedot = 0;
            int type = 0;// xac dinh loai phan tich ( type =1 -> phan tich 1 dau , type =2 -> phan tich 2 dau )
            string theconditiontext = "";





            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    markthefirstbracket = i;
                    break;
                }
            }

            //tu dong nay, co tac dung la xac dinh so cac phan tu dien kien ( vd TT -> menh de -> type 1 ; TT + TT -> menh de -> type 2 ) bang cach phan tich so dau "."
            for (int i = markthefirstbracket + 1; i < input.Length; i++)
            {
                if (markthebracket == 0)
                {
                    if (input[i] == '{')
                    {
                        markthebracket = 1;
                    }
                    if (input[i] == '.')
                    {
                        countthedot++;
                    }
                }
                if (markthebracket == 1)
                {
                    if (input[i] == '}')
                    {
                        markthebracket = 0;
                    }

                }

            }

            //phan loai
            if (countthedot == 1)
            {
                type = 1;
            }
            if (countthedot > 1)
            {
                type = 2;
            }

            // loai 1
            if (type == 1)
            {
                for (int i = markthefirstbracket + 1; i < input.Length; i++)
                {
                    theconditiontext += input[i];
                }
                theconditiontext = theconditiontext.Trim();
                output += TheMainFunction2Type1(theconditiontext, variable);
            }

            // loai 2
            if (type == 2)
            {
                for (int i = markthefirstbracket + 1; i < input.Length; i++)
                {
                    theconditiontext += input[i];
                }
                theconditiontext = theconditiontext.Trim();
                output += TheMainFunction2Type2(theconditiontext, variable);
            }


            return output;
        }
        static String TheMainFunction2Type1(string input, string variable)
        {



            input = input.Trim();
            string output = "";
            string thebegin = "";
            string theend = "";
            int marktheend = 0;  // tinh dau }
            string SuckType = "";//  TT or VM
            int SuckX = 0; //cac dau nhu =, >=,... type 0 =, type 1 >, type 2<, type 3>=, type 4<=
            int markthebracket1 = 0; //mark the bracket with (
            int markthebracket2 = 0; //mark the bracket with )
            int numofbracket = 0;
            int markthebracket3 = 0; //mark the bracket with ( second
            int markthebracket4 = 0; //mark the bracket with ) second
            string therangea = "";
            string therangeb = "";
            string thesubrangea = "";
            string thesubrangeb = "";
            string varietyletter = "";





            //[
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '}')
                {
                    marktheend = i;
                    break;
                }

            }

            //TT or VM
            for (int i = 0; i < 2; i++)
            {
                SuckType += input[i];
            }

            //xac dinh bien trong range
            for (int i = 2; i < input.Length; i++)
            {
                if (input[i] == 'T')
                {
                    if (input[i + 1] == 'H')
                    {
                        for (int j = 2; j < i; j++)
                        {
                            varietyletter += input[j];
                        }
                        break;
                    }
                }
            }
            varietyletter = varietyletter.Trim();

            //determine the function ( SUck x)
            for (int i = marktheend; i < input.Length; i++)
            {
                if (input[i] == '=')
                {
                    SuckX = 0;
                    break;
                }
                if (input[i] == '>')
                {
                    if (input[i + 1] == '=')
                    {
                        SuckX = 3;
                        break;
                    }
                    else
                    {
                        SuckX = 1;
                        break;
                    }
                }
                if (input[i] == '<')
                {
                    if (input[i + 1] == '=')
                    {
                        SuckX = 4;
                        break;
                    }
                    else
                    {
                        SuckX = 2;
                        break;
                    }
                }
            }

            //determine the range in main function
            for (int i = marktheend + 1; i < input.Length; i++)
            {
                if (numofbracket < 2)
                {
                    if (input[i] == '(')
                    {
                        numofbracket++;
                        markthebracket1 = i;

                    }
                    if (input[i] == ')')
                    {
                        numofbracket++;
                        markthebracket2 = i;
                        continue;

                    }
                }



                if (numofbracket >= 2)
                {
                    if (input[i] == '(')
                    {
                        numofbracket++;
                        markthebracket3 = i;

                    }
                    if (input[i] == ')')
                    {
                        numofbracket++;
                        markthebracket4 = i;
                        break;
                    }
                }
            }

            //determine range a and b
            for (int i = markthebracket1 + 1; i < markthebracket2; i++)
            {
                therangea += input[i];
            } //range a
            for (int i = markthebracket3 + 1; i < markthebracket4; i++)
            {
                therangeb += input[i];
            } // range b

            //determine virable for range a and b
            for (int i = marktheend; i < input.Length; i++)
            {
                if (input[i] == '.')
                {
                    for (int j = i + 1; j < markthebracket1; j++)
                    {
                        thesubrangea += input[j];
                    }

                }

                if (input[i] == '=')
                {
                    for (int j = i + 1; j < markthebracket3; j++)
                    {
                        thesubrangeb += input[j];
                    }
                    break;
                }
                if (input[i] == '>')
                {
                    if (input[i + 1] == '=')
                    {
                        for (int j = i + 2; j < markthebracket3; j++)
                        {
                            thesubrangeb += input[j];
                        }
                        break;
                    }
                    else
                    {
                        for (int j = i + 1; j < markthebracket3; j++)
                        {
                            thesubrangeb += input[j];
                        }
                        break;
                    }
                }
                if (input[i] == '<')
                {
                    if (input[i + 1] == '=')
                    {
                        for (int j = i + 2; j < markthebracket3; j++)
                        {
                            thesubrangeb += input[j];
                        }
                        break;
                    }
                    else
                    {
                        for (int j = i + 1; j < markthebracket3; j++)
                        {
                            thesubrangeb += input[j];
                        }
                        break;
                    }
                }

            }
            thesubrangea = thesubrangea.Trim();
            thesubrangeb = thesubrangeb.Trim();

            //extract the begin
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '{')
                {
                    for (int j = i + 1; j < input.Length; j++)
                    {
                        if (input[j] == '.')
                        {
                            for (int k = i + 1; k < j; k++)
                            {
                                thebegin += input[k];
                            }
                            break;
                        }
                    }
                    break;
                }
            }

            //extract the endpoint
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '{')
                {
                    for (int j = i + 1; j < input.Length; j++)
                    {
                        if (input[j] == '.')
                        {
                            for (int k = j + 2; k < marktheend; k++)
                            {
                                theend += input[k];
                            }
                            break;
                        }
                    }
                    break;
                }
            }
            output += "    for (int " + varietyletter + "=" + thebegin + ";" + varietyletter + "<=" + theend + ";" + varietyletter + "++)" + "\r\n";
            output += "    {" + "\r\n";

            if (SuckType == "VM")
            {
                output += "        if (" + thesubrangea + "[" + therangea + "]" + ReverseFuction(SuckX) + thesubrangeb + "[" + therangeb + "])" + "\r\n";
                output += "        {" + "\r\n";
                output += "            return 0;" + "\r\n";
                output += "        }" + "\r\n";
                output += "    }" + "\r\n";
                output += "    return 1;" + "\r\n";
                output += "}" + "\r\n" + "\r\n";
            }

            if (SuckType == "TT")
            {
                output += "        if (" + thesubrangea + "[" + therangea + "]" + NahFunction(SuckX) + thesubrangeb + "[" + therangeb + "])" + "\r\n";
                output += "        {" + "\r\n";
                output += "            return 1;" + "\r\n";
                output += "        }" + "\r\n";
                output += "    }" + "\r\n";
                output += "    return 0;" + "\r\n";
                output += "}" + "\r\n" + "\r\n";
            }

            return output;
        } // VM i TH {1..n-1}.a(i) <= a(i+1)
        static String TheMainFunction2Type2(string input, string variable) // TT i TH {1..n-1}. TT j TH {i+1..n}.a(i) <= a(j))
        {



            string output = "";
            string SuckType1 = "";
            string SuckType2 = "";
            string Variable1 = "";
            string Variable2 = "";
            string VariablerangeHead1 = "";
            string VariablerangeHead2 = "";
            string VariablerangeTail1 = "";
            string VariablerangeTail2 = "";
            string questionrange1 = "";
            string questionrange2 = "";
            string FunnyFunction = "";
            int markthebracket = 0;
            int marknumberdot = 0;
            int markthedot1 = 0;
            int markthedot2 = 0;
            int markskip = 0;





            for (int i = 0; i < input.Length; i++)
            {
                if (markthebracket == 0)
                {
                    if (input[i] == '{')
                    {
                        markthebracket++;
                        continue;
                    }
                    if (marknumberdot == 0)
                    {
                        if (input[i] == '.')
                        {
                            markthedot1 = i;
                            marknumberdot++;
                            continue;
                        }
                    }
                    if (marknumberdot == 1)
                    {
                        if (input[i] == '.')
                        {
                            markthedot2 = i;
                            break;
                        }
                    }

                }


                if (markthebracket == 1)
                {
                    if (input[i] == '}')
                    {
                        markthebracket--;
                        continue;
                    }
                }


            } // xac dinh cac dot de phan ra cho de
            for (int i = 0; i < markthedot1; i++) // xac dinh loai bien 1
            {
                if (input[i] == 'T')
                {
                    SuckType1 = "TT";
                    break;
                }
                if (input[i] == 'V')
                {
                    SuckType1 = "VM";
                    break;
                }
            }

            for (int i = markthedot1 + 1; i < markthedot2; i++) // xac dinh loai bien 2
            {
                if (input[i] == 'T')
                {
                    SuckType2 = "TT";
                    break;
                }
                if (input[i] == 'V')
                {
                    SuckType2 = "VM";
                    break;
                }
            }
            for (int i = 0; i < markthedot1; i++) // xac dinh bien 1
            {
                if (markskip == 0)
                {
                    if (input[i] == 'T')
                    {
                        if (input[i + 1] == 'T')
                        {
                            markskip++;
                            continue;
                        }
                    }

                    if (input[i] == 'V')
                    {
                        if (input[i + 1] == 'M')
                        {
                            markskip++;
                            continue;
                        }
                    }
                }
                if (markskip == 1)
                {
                    markskip++;
                    continue;
                }
                if (markskip == 2)
                {
                    if (input[i] == 'T')
                    {
                        if (input[i + 1] == 'H')
                        { break; }
                    }
                    Variable1 += input[i];

                }
            }//-------------------------------
            Variable1 = Variable1.Trim();

            markskip = 0;

            for (int i = markthedot1 + 1; i < markthedot2; i++) // xac dinh bien 2
            {
                if (markskip == 0)
                {
                    if (input[i] == 'T')
                    {
                        if (input[i + 1] == 'T')
                        {
                            markskip++;
                            continue;
                        }
                    }

                    if (input[i] == 'V')
                    {
                        if (input[i + 1] == 'M')
                        {
                            markskip++;
                            continue;
                        }
                    }
                }
                if (markskip == 1)
                {
                    markskip++;
                    continue;
                }
                if (markskip == 2)
                {
                    if (input[i] == 'T')
                    {
                        if (input[i + 1] == 'H')
                        { break; }
                    }
                    Variable2 += input[i];

                }
            }//--------------------
            Variable2 = Variable2.Trim();

            for (int i = 0; i < markthedot1; i++)//---------------------xac dinh dau bien 1
            {
                if (input[i] == '{')
                {
                    for (int j = i + 1; j < markthedot1; j++)
                    {
                        if (input[j] == '.')
                            break;
                        VariablerangeHead1 += input[j];

                    }
                    break;
                }
            }
            VariablerangeHead1 = VariablerangeHead1.Trim();

            for (int i = markthedot1 + 1; i < markthedot2; i++)//---------------------xac dinh dau bien 2
            {
                if (input[i] == '{')
                {
                    for (int j = i + 1; j < markthedot2; j++)
                    {
                        if (input[j] == '.')
                            break;
                        VariablerangeHead2 += input[j];

                    }
                    break;
                }
            }
            VariablerangeHead2 = VariablerangeHead2.Trim();

            for (int i = 0; i < markthedot1; i++)//---------------------xac dinh duoi bien 1
            {
                if (input[i] == '.')
                {
                    for (int j = i + 2; j < markthedot1; j++)
                    {
                        if (input[j] == '}')
                            break;
                        VariablerangeTail1 += input[j];

                    }
                    break;
                }
            }
            VariablerangeTail1 = VariablerangeTail1.Trim();

            for (int i = markthedot1 + 1; i < markthedot2; i++)//---------------------xac dinh duoi bien 2
            {
                if (input[i] == '.')
                {
                    for (int j = i + 2; j < markthedot2; j++)
                    {
                        if (input[j] == '}')
                            break;
                        VariablerangeTail2 += input[j];

                    }
                    break;
                }
            }
            VariablerangeTail2 = VariablerangeTail2.Trim();

            for (int i = markthedot2 + 1; i < input.Length; i++) // xac dinh bien function 1
            {
                if (input[i] == '(')
                {
                    for (int j = i + 1; j < input.Length; j++)
                    {
                        if (input[j] == ')')
                        {
                            break;
                        }
                        questionrange1 += input[j];
                    }
                    break;
                }
            }
            questionrange1 = questionrange1.Trim();

            for (int i = input.Length - 2; i > markthedot2; i--) // xac dinh bien function 1
            {
                if (input[i] == ')')
                {
                    for (int j = i - 1; j > markthedot2; j--)
                    {
                        if (input[j] == '(')
                        {
                            break;
                        }
                        questionrange2 += input[j];
                    }
                    break;
                }
            }
            questionrange2 = questionrange2.Trim();
            questionrange2 = Reverse(questionrange2);

            for (int i = markthedot2 + 1; i < input.Length; i++)
            {
                if (input[i] == '!')
                {
                    FunnyFunction = "!=";
                    break;
                }
                if (input[i] == '=')
                {
                    FunnyFunction = "=";
                    break;
                }
                if (input[i] == '>')
                {
                    if (input[i + 1] == '=')
                    {
                        FunnyFunction = ">=";
                        break;
                    }
                    FunnyFunction = ">";
                    break;
                }
                if (input[i] == '<')
                {
                    if (input[i + 1] == '=')
                    {
                        FunnyFunction = "<=";
                        break;
                    }
                    FunnyFunction = "<";
                    break;
                }
            } // xac dinh dau cua function

            output += "    for (int " + Variable1 + "=" + VariablerangeHead1 + ";" + Variable1 + "<=" + VariablerangeTail1 + ";" + Variable1 + "++)" + "\r\n";
            output += "    {" + "\r\n";
            output += "        for (int " + Variable2 + "=" + VariablerangeHead2 + ";" + Variable2 + "<=" + VariablerangeTail2 + ";" + Variable2 + "++)" + "\r\n";
            output += "        {" + "\r\n";


            //--------------------------------- xac dinh loai 

            // Loai 1: TT - TT 
            if (SuckType1 == "TT" && SuckType2 == "TT")
            {
                output += "            if (" + variable + "[" + questionrange1 + "]" + FunnyFunction + variable + "[" + questionrange2 + "])" + "\r\n";
                output += "                return 1;" + "\r\n";
                output += "        }" + "\r\n";
                output += "    }" + "\r\n";
                output += "    return 0;" + "\r\n";
                output += "}" + "\r\n" + "\r\n";
            }


            // Loai 2: TT - VM 
            if (SuckType1 == "TT" && SuckType2 == "VM")
            {
                output += "            if (" + variable + "[" + questionrange1 + "]" + ReverseFuction2(FunnyFunction) + variable + "[" + questionrange2 + "])" + "\r\n";
                output += "                break;" + "\r\n";
                output += "            if (" + questionrange2 + "==" + VariablerangeTail2 + ")" + "\r\n";
                output += "                return 1;" + "\r\n";
                output += "        }" + "\r\n";
                output += "    }" + "\r\n";
                output += "    return 0;" + "\r\n";
                output += "}" + "\r\n" + "\r\n";
            }


            // Loai 3: VM - TT 
            if (SuckType1 == "VM" && SuckType2 == "TT")
            {
                output += "            if (" + variable + "[" + questionrange1 + "]" + FunnyFunction + variable + "[" + questionrange2 + "])" + "\r\n";
                output += "                break;" + "\r\n";
                output += "            if (" + questionrange2 + "==" + VariablerangeTail2 + ")" + "\r\n";
                output += "                return 0;" + "\r\n";
                output += "        }" + "\r\n";
                output += "    }" + "\r\n";
                output += "    return 1;" + "\r\n";
                output += "}" + "\r\n" + "\r\n";
            }

            // Loai 4: VM - VM 
            if (SuckType1 == "VM" && SuckType2 == "VM")
            {
                output += "            if (" + variable + "[" + questionrange1 + "]" + ReverseFuction2(FunnyFunction) + variable + "[" + questionrange2 + "])" + "\r\n";
                output += "                return 0;" + "\r\n";
                output += "        }" + "\r\n";
                output += "    }" + "\r\n";
                output += "    return 1;" + "\r\n";
                output += "}" + "\r\n" + "\r\n";
            }


            return output;
        }
        static String ReverseFuction(int type)
        {
            string output = "";

            if (type == 0)
                output = "!=";
            if (type == 1)
                output = "<=";
            if (type == 2)
                output = ">=";
            if (type == 3)
                output = "<";
            if (type == 4)
                output = ">";


            return output;
        }
        static String ReverseFuction2(string input)
        {
            string output = "";

            if (input == "=")
                output = "!=";
            if (input == ">")
                output = "<=";
            if (input == "<")
                output = ">=";
            if (input == ">=")
                output = "<";
            if (input == "<=")
                output = ">";
            if (input == "!=")
                output = "==";

            return output;
        }
        static String NahFunction(int type)
        {
            string output = "";

            if (type == 0)
                output = "=";
            if (type == 1)
                output = ">";
            if (type == 2)
                output = "<";
            if (type == 3)
                output = ">=";
            if (type == 4)
                output = "<=";


            return output;
        }



        private void button1_Click_1(object sender, EventArgs e)
        {

            // Create a file to write to.
            string createText = Output.Text;
            File.WriteAllText(frameworkbox.Text + "\\" + "testcode.cpp", createText);



            // Open the file to read from.
            string readText = File.ReadAllText(frameworkbox.Text + "\\" + "testcode.cpp");

            string strCmdText = Output.Text;
            System.Diagnostics.Process.Start("CMD.exe", strCmdText);

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string message = "Do you want to create a new one ?, all of the unsaved one will be deleted.";
            string title = "Create new file";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                Output.Text = "";
                Input.Text = "";
                textBox1.Text = "";
            }
            else
            {
                // Do something  
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {

                ofd.Filter = "Text files (*.txt)|*.txt";
                ofd.Title = "Open text file";
                ofd.FileName = "Select a text file";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string text = File.ReadAllText(ofd.FileName);
                    Input.Text = text;
                }
            }

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string message = "Do you want to exit ?, all of the unsaved one will be deleted.";
            string title = "Close the program";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
            else
            {
                // Do something  
            }
        }

        private void saveInputToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Title = "Save text files";
            saveFileDialog1.CheckFileExists = true;
            saveFileDialog1.CheckPathExists = true;
            saveFileDialog1.DefaultExt = "txt";
            saveFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (var fileStream = saveFileDialog1.OpenFile())
                using (var sw = new StreamWriter(fileStream))
                    sw.WriteLine(Input.Text);
            }

        }

        private void saveCodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Title = "Save text files";
            saveFileDialog1.CheckFileExists = true;
            saveFileDialog1.CheckPathExists = true;
            saveFileDialog1.DefaultExt = "txt";
            saveFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (var fileStream = saveFileDialog1.OpenFile())
                using (var sw = new StreamWriter(fileStream))
                    sw.WriteLine(Output.Text);
            }
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            System.Windows.Forms.Clipboard.SetText(Output.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Clipboard.SetText(textBox1.Text);
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Sleep.Parent = pictureBox1;
            Sleep.BackColor = Color.Transparent;
            Sleep.FlatStyle = FlatStyle.Flat;
            label4.BackColor = Color.Transparent;
            label4.FlatStyle = FlatStyle.Flat;
            label4.Visible = false;

        }

        private void buttonhowtouse_Click(object sender, EventArgs e)
        {
            int checkmark = 0;
            if (label4.Visible == false && checkmark == 0)
            {
                label4.Visible = true;
                checkmark = 1;
            }
            if (label4.Visible == true && checkmark == 0)
            {
                label4.Visible = false;
                checkmark = 1;
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.MessageBox.Show("Made by: Trần Quốc Huy" + "\r\n" + "MSSV: 20520554" + "\r\n");
        }
    }

}
