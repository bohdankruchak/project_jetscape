using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace test
{
    abstract class Interpreter
    {
        //public Interpreter(string s1) { }
        public virtual int GetResult();
    }
    class MathTemplate
    {
        // Генератор стрічки відповідно до заданого ключа
        private static string GenerateString(Interpreter key, char sign)
        {
            Random rand = new Random();
            string output = "";
            int first_nmb = 0;
            int second_nmb = 0;
            int result = key.GetResult();

            switch (sign)
            {
                case '+':
                    {
                        first_nmb = rand.Next(0, result);
                        second_nmb = result - first_nmb;

                        output = first_nmb.ToString() + " + " + second_nmb.ToString();
                        break;
                    }
                case '-':
                    {
                        first_nmb = rand.Next(result, result + 20);
                        second_nmb = first_nmb - result;

                        output = first_nmb.ToString() + " - " + second_nmb.ToString();
                        break;
                    }
                case '/':
                    {
                        second_nmb = rand.Next(1, 10);
                        first_nmb = second_nmb * result;

                        output = first_nmb.ToString() + " / " + second_nmb.ToString();
                        break;
                    }
                case '*':
                    {
                        first_nmb = GetRandomDivisor(result);
                        second_nmb = first_nmb / result;
                        output = first_nmb.ToString() + " * " + second_nmb.ToString();
                        break;
                    }
            }

            return output;
        }

        // Генератор стрічки виконання дій у стовпчик
        private static string GenerateColomnString(Interpreter key, char sign)
        {
            Random rand = new Random();
            string output = "";
            int first_nmb = 0;
            int second_nmb = 0;
            int result = key.GetResult();

            switch (sign)
            {
                case '+':
                    {
                        first_nmb = rand.Next(0, result);
                        second_nmb = result - first_nmb;

                        output = first_nmb.ToString() + "\n + " + second_nmb.ToString();
                        break;
                    }
                case '-':
                    {
                        first_nmb = rand.Next(result, result + 20);
                        second_nmb = first_nmb - result;

                        output = first_nmb.ToString() + "\n - " + second_nmb.ToString();
                        break;
                    }
                case '*':
                    {


                        first_nmb = GetRandomDivisor(result);
                        second_nmb = first_nmb / result;
                        output = first_nmb.ToString() + "\n * " + second_nmb.ToString();
                        break;
                    }
            }

            return output;
        }

        // Генератор стрічки з рядом чисел
        private static string GenerateNumberSeriesString(Interpreter key, int distance)
        {
            const int numbers_in_string = 4;
            Random rand = new Random();
            int startNumber = 0;
            List<int> potential_numbers = new List<int>();
            string output = "";

            for (int i = 0; i < 1000 - (numbers_in_string * distance); i++ )
            {
                potential_numbers.Add(i);
            }
            int index = rand.Next();
            startNumber = potential_numbers[index];

            output = String.Format("{0},{1},{2},{3}", startNumber, startNumber + distance, 
                startNumber + (distance * 2), startNumber + (distance*3));
            return output;
        }

        // Генератор стрічки з кутовими значеннями
        private static string GenerateAnglesString(Interpreter key)
        {
            List<int> angles = new List<int>();
            Random rand = new Random();
            int final_angle = 0;

            switch(key.GetResult())
            {
                //Випадок розгорнутого кута
                case 0:
                    {
                        final_angle = 180;
                        return final_angle.ToString();
                    }

                //Випадок прямого кута
                case 1:
                    {
                        final_angle = 90;
                        return final_angle.ToString();
                    }

                //Випадок гострого кута
                case 2:
                    {
                        final_angle = rand.Next(1, 89);
                        return final_angle.ToString();
                    }

                //Випадок тупого кута
                case 3:
                    {
                        final_angle = rand.Next(91, 179);
                        return final_angle.ToString();
                    }
            }
            return "";
        }

        // Генератор стрічки з координатами
        private static string GenerateQuadrantString(Interpreter key)
        {
            Random rand = new Random();
            int quadrant = key.GetResult();
            int first_coordinate = 0, second_coordinate = 0;
            string output = "";

            switch(quadrant)
            {
                case 1:
                    {
                        first_coordinate = rand.Next(0, 999);
                        second_coordinate = rand.Next(0, 999);
                        break;
                    }
                case 2:
                    {
                        first_coordinate = rand.Next(0, 999);
                        second_coordinate = rand.Next(-999, 0);
                        break;
                    }
                case 3:
                    {
                        first_coordinate = rand.Next(-999, 0);
                        second_coordinate = rand.Next(-999, 0);
                        break;
                    }
                case 4:
                    {
                        first_coordinate = rand.Next(-999, 0);
                        second_coordinate = rand.Next(0, 999);
                        break;
                    }
            }

            output = first_coordinate.ToString() + "," + second_coordinate.ToString();
            return output;
        }

        // Генератор стрічки з іменем фігури
        private static string GenerateShapeNameString(Interpreter key)
        {
            int sides = key.GetResult();
            Random rand = new Random();
            string output = "";

            List<string> _3Sides = new List<string>() 
            { 
                "right", "triangle", "isoscales", "equilateral"
            };
            List<string> _4Sides = new List<string>()
            { 
                "parallelogram", "rhombus", "square", "rectangle", "trapezoid"
            };
            List<string> MoreSides = new List<string>()
            { 
                "hexagon", "pentagon", "octagon"
            };

            switch (sides)
            {
                // Ідентифікатор трикутника
                case 3:
                    {
                        int index = rand.Next(_3Sides.Count);
                        output = _3Sides[index];
                        break;
                    }
                // Ідентифікатор чотирикутника
                case 4:
                    {
                        int index = rand.Next(_4Sides.Count);
                        output = _4Sides[index];
                        break;
                    }
                // Ідентифікатор багатокутника
                case 5:
                    {
                        int index = rand.Next(MoreSides.Count);
                        output = MoreSides[index];
                        break;
                    }
            }

            return output;
        }

        public static string MathFact_Jr(string input, char sign)
        {
            jr_key_interpr key = new jr_key_interpr(input);

            return GenerateString(key, sign);
        }

        public static string MathFact_Basic(string input, char sign)
        {
            basic_key_interpr key = new basic_key_interpr(input);

            return GenerateString(key, sign);
        }

        public static string MathFact_Advanced(string input, char sign)
        {
            advanced_key_interpr key = new advanced_key_interpr(input);
            return GenerateString(key, sign);
        }

        public static string MathFact_Mixed(string input)
        {
            advanced_key_interpr key = new advanced_key_interpr(input);

            // Випадково вибираємо знак операції над числами
            Random rand = new Random();
            char[] arr_chars = { '+', '-', '*', '/'};
            List<char> potential_signs = new List<char>(arr_chars);
            int index = rand.Next(potential_signs.Count);
            char sign = potential_signs[index];

            return GenerateString(key, sign);
        }

        public static string PlaceValue_Counting(string input)
        {
            advanced_key_interpr key = new advanced_key_interpr(input);

            return key.GetResult().ToString();
        }

        public static string PlaceValue_PlaceValue(string input)
        {
            place_depend_key_interpr key = new place_depend_key_interpr(input);

            return key.GetResult().ToString();
        }

        public static string PlaceValue_Rounding(string input)
        {
            rounding_interpr key = new rounding_interpr(input);

            return key.GetResult().ToString();
        }

        public static string AdvancedMath_Regrouping(string input, char sign)
        {
            regrouping_interpr key = new regrouping_interpr(input);

            return GenerateColomnString(key, sign);
        }

        public static string AdvancedMath_NumbAndOps_Even_Odd(string input)
        {
            even_odd_interpr key = new even_odd_interpr(input);

            return key.GetResult().ToString();
        }

        public static string AdvancedMath_NumbAndOps_NumbPatterns(string input)
        {
            num_pattern_interpr key = new num_pattern_interpr(input);

            return GenerateNumberSeriesString(key, key.GetResult());
        }

        public static string AdvancedMath_NumbAndOps_PrimeOrComposite(string input)
        {
            prime_composite_interpr key = new prime_composite_interpr(input);

            return key.GetResult().ToString();
        }

        public static string AdvancedMath_NumbAndOps_GeomAndMeasur(string input)
        {
            geom_measurement_interpr key = new geom_measurement_interpr(input);

            return GenerateAnglesString(key);
        }

        public static string AdvancedMath_NumbAndOps_Quadrants(string input)
        {
            qudrant_interpr key = new qudrant_interpr(input);

            return GenerateQuadrantString(key);
        }

        public static string AdvancedMath_NumbAndOps_Shapes_Names(string input)
        {
            shape_name_interpr key = new shape_name_interpr(input);

            return GenerateShapeNameString(key);
        }

        private static int GetRandomDivisor(int number)
        {
            List<int> dividers = new List<int>();
            Random rand = new Random();

            for (int i = 1; i < number / 2; i++)
            {
                if (number % i == 0) dividers.Add(i);
            }

            int index = rand.Next(dividers.Count);
            int divider = dividers[index];
            return divider;
        }
    }

    //Клас для інтерпретації ключа типу jr
    class jr_key_interpr: Interpreter
    {
        int first_nmb;
        int second_nmb;
        Random rand = new Random();

        string rulls = "Key data:/n 2 or 3";
        public jr_key_interpr(string s1)
        {
            string[] arr = s1.Split(' ');
            first_nmb = int.Parse(arr[0]);
            second_nmb = int.Parse(arr[2]);
        }

        public override int GetResult()
        {
            return rand.Next(first_nmb, second_nmb);
        }
    }

    //Клас для інтерпретації ключа типу basic
    class basic_key_interpr: Interpreter
    {
        int result = 0;
        Random rand = new Random();

        string rulls = "Key data:/n 2 or 3";
        public basic_key_interpr(string s1)
        {
            result = int.Parse(s1);
        }

        public override int GetResult()
        {
            return result;
        }
    }

    //Клас для інтерпретації ключа типу advanced
    class advanced_key_interpr: Interpreter
    {
        int result = 0;
        Random rand = new Random();
        List<int> potential_numbers = new List<int>();
        bool isSingleNum = false;

        public advanced_key_interpr(string s1)
        {
            if(s1.Contains('-'))
            {
                string[] str_limits_numbers = s1.Split('-');
                int first_number = int.Parse(str_limits_numbers[0]);
                int last_number = int.Parse(str_limits_numbers[1]);
                for (int i = first_number; i <= last_number; i++)
                    potential_numbers.Add(i);
            }
            else if (s1.Contains(','))
            {
                string[] str_numbers = s1.Split(',');
                for (int i = 0; i < str_numbers.Length; i++ )
                    potential_numbers.Add(int.Parse(str_numbers[i]));
            }
            else
            {
                isSingleNum = true;
                result = int.Parse(s1);
            }
        }

        public override int GetResult()
        {
            if (!isSingleNum)
            {
                int index = rand.Next(potential_numbers.Count);
                result = potential_numbers[index];
            }
            return result;
        }
    }

    //Клас для інтерпретації ключа типу placeValue
    class place_depend_key_interpr: Interpreter
    {
        int number = 0;
        int result = 0;
        List<int> potential_numbers = new List<int>();
        Random rand = new Random();
        bool isOnes = false;
        bool isTens = false;
        bool isHundreds = false;

        string rulls = "Key data:/n 2 or 3";

        private static bool isNumberInOnes(int final_number, int peace_number)
        {
            string str_final_number = final_number.ToString();

            if (final_number < 10 && final_number == peace_number) return true;
            else if (final_number < 100 && str_final_number[1].ToString() == peace_number.ToString()) return true;
            else if (final_number < 1000 && str_final_number[2].ToString() == peace_number.ToString()) return true;
            else return false;
        }

        private static bool isNumberInTens(int final_number, int peace_number)
        {
            string str_final_number = final_number.ToString();

            if (final_number > 10 && final_number < 100 && str_final_number[0].ToString() == peace_number.ToString()) return true;
            else if (final_number < 1000 && str_final_number[1].ToString() == peace_number.ToString()) return true;
            else return false;
        }

        private static bool isNumberInHundreds(int final_number, int peace_number)
        {
            string str_final_number = final_number.ToString();

            if (final_number > 100 && final_number < 1000 && str_final_number[0].ToString() == peace_number.ToString()) return true;
            else return false;
        }

        public place_depend_key_interpr(string s1)
        {
            if(!(s1.Contains("Not") || s1.Contains("not") || s1.Contains("NOT")))
            {
                string[] all_words = s1.Split(' ');
                number = int.Parse(all_words[0]);

                for(int i = 1; i < all_words.Length; i++)
                {
                    if (all_words[i] == "ones") isOnes = true;
                    else if (all_words[i] == "tens") isTens = true;
                    else if (all_words[i] == "hundreds") isHundreds = true;
                }

                for(int i = 0; i < 1000; i++)
                {
                    if(isOnes && isNumberInOnes(i, number))
                        potential_numbers.Add(i);
                    else if(isTens && isNumberInTens(i, number))
                        potential_numbers.Add(i);
                    else if (isHundreds && isNumberInHundreds(i, number))
                        potential_numbers.Add(i);
                }
            }
            else
            {
                for(int i = 0; i < 1000; i++)
                {
                    if(!i.ToString().Contains(number.ToString()))
                    {
                        potential_numbers.Add(i);
                    }
                }
            }
        }

        public override int GetResult()
        {
            int index = rand.Next(potential_numbers.Count);
            result = potential_numbers[index];
            return result;
        }
    }

    //Клас для інтерпретації ключа типу rounding
    class rounding_interpr: Interpreter
    {
        int result = 0;
        Random rand = new Random();
        List<int> potential_numbers = new List<int>();
        public rounding_interpr(string s1)
        {
            int input_number = 0;
            string[] all_words = s1.Split(' ');
            input_number = int.Parse(all_words[all_words.Count() - 1]);

            if(input_number < 100)
            {
                for (int i = input_number - 5; i < input_number + 5; i++)
                    potential_numbers.Add(i);
            }else if(input_number < 1000)
            {
                for (int i = input_number - 50; i < input_number + 50; i++)
                    potential_numbers.Add(i);
            }
        }

        public override int GetResult()
        {
            int index = rand.Next(potential_numbers.Count);
            result = potential_numbers[index];
            return result;
        }
    }

    //Клас для інтерпретації ключа типу regrouping
    class regrouping_interpr: Interpreter
    {
        int result = 0;
        Random rand = new Random();
        List<int> potential_numbers = new List<int>();
        public regrouping_interpr(string s1)
        {
            int input_number = 0;
            string[] all_words = s1.Split(' ');
            input_number = int.Parse(all_words[all_words.Count() - 1]);

            if(input_number < 100)
            {
                for (int i = input_number - 5; i < input_number + 5; i++)
                    potential_numbers.Add(i);
            }else if(input_number < 1000)
            {
                for (int i = input_number - 50; i < input_number + 50; i++)
                    potential_numbers.Add(i);
            }
        }

        public override int GetResult()
        {
            int index = rand.Next(potential_numbers.Count);
            result = potential_numbers[index];
            return result;
        }
    }

    //Клас для інтерпретації ключа типу even or odd numbers
    class even_odd_interpr: Interpreter
    {
        int result = 0;
        Random rand = new Random();
        List<int> potential_numbers = new List<int>();

        public bool IsPrime(int num)
        {

            bool _isPrime = true;

            if (num % 2 == 0) return false;

            for (int i = 3; i <= Convert.ToInt32(Math.Sqrt(num)); i = i + 2)
            {

                if (num % i == 0)
                {

                    _isPrime = false;

                    break;

                }

            }

            return _isPrime;

        }

        public even_odd_interpr(string s1)
        {
            for (int i = 0; i < 1000; i++)
            {
                if (s1.ToLower() == "even")
                {
                    if (IsPrime(i))
                        potential_numbers.Add(i);
                }else if(s1.ToLower() == "odd")
                {
                    if (!IsPrime(i))
                        potential_numbers.Add(i);
                }
            }
        }

        public override int GetResult()
        {
            int index = rand.Next(potential_numbers.Count);
            result = potential_numbers[index];
            return result;
        }
    }

    //Клас для інтерпретації ключа типу number pattern
    class num_pattern_interpr : Interpreter
    {
        int result = 0;
        List<int> potential_numbers = new List<int>();

        public num_pattern_interpr(string s1)
        {
            int input_number = 0;
            string[] all_words = s1.Split(' ');
            input_number = int.Parse(all_words[all_words.Count() - 1]);

            if(all_words[0].ToLower() == "add")
                result = input_number;
        }
        public override int GetResult()
        {
            return result;
        }
    }

    //Клас для інтерпретації ключа типу prime or composite
    class prime_composite_interpr : Interpreter
    {
        int result = 0;
        Random rand = new Random();
        List<int> potential_numbers = new List<int>();

        public bool IsPrime(int num)
        {

            bool _isPrime = true;

            if (num % 2 == 0) return false;

            for (int i = 3; i <= Convert.ToInt32(Math.Sqrt(num)); i = i + 2)
            {

                if (num % i == 0)
                {

                    _isPrime = false;

                    break;

                }

            }

            return _isPrime;

        }

        public prime_composite_interpr(string s1)
        {
            for(int i = 0; i < 1000; i++)
            {
                if (s1.ToLower() == "prime" && IsPrime(i))
                    potential_numbers.Add(i);
                else if (s1.ToLower() == "composite" && !IsPrime(i))
                    potential_numbers.Add(i);
            }
        }

        public override int GetResult()
        {
            int index = rand.Next(potential_numbers.Count);
            result = potential_numbers[index];
            return result;
        }
    }

    //Клас для інтерпретації ключа типу geometry and measurement
    class geom_measurement_interpr : Interpreter
    {
        int result = 0;
        List<int> potential_numbers = new List<int>();

        public geom_measurement_interpr(string s1)
        {
            char first_letter = (s1.ToLower())[0];

            switch(first_letter)
            {
                case 's': result = 0; break;
                case 'r': result = 1; break;
                case 'a': result = 2; break;
                case 'o': result = 3; break;
            }
        }
        public override int GetResult()
        {
            return result;
        }
    }

    //Клас для інтерпретації ключа типу quadrant
    class qudrant_interpr : Interpreter
    {
        int quadrant = 0;
        List<int> potential_numbers = new List<int>();

        public qudrant_interpr(string s1)
        {
            quadrant = int.Parse((s1.Split(' '))[1]);
        }
        public override int GetResult()
        {
            return quadrant;
        }
    }

    //Клас для інтерпретації ключа типу shape name
    class shape_name_interpr : Interpreter
    {
        int result = 0;

        public shape_name_interpr(string s1)
        {
            string input_str = s1.ToLower();

            if (input_str.Contains("more"))
                result = 5;// Ідентифікатор багатокутника
            else if (input_str.Contains("4"))
                result = 4;// Ідентифікатор чотирикутника
            else if (input_str.Contains("4"))
                result = 3;// Ідентифікатор трикутника
        }

        public override int GetResult()
        {
            return result;
        }
    }
}
