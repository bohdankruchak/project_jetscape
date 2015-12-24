using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test;

namespace test
{
    public static class GenereteNumbers
    {
        public static Workspace workspace = new Workspace();
        private static int key_count = workspace.keys.Count;
        private static string key_string = "";
        private static int first_num = workspace.op.active_range_first;
        private static int last_num = workspace.op.active_range_second;

        struct Range<T>
        {
            T first; T last;
        }

        static Random rand = new Random();

        public static T Get_Random_Element<T>(List<T> element_list)
        {
            int index = rand.Next(element_list.Count);
            return element_list[index];
        }


        public static void Generate_Number()
        {
            
            
            switch(workspace.op.game_mod)
            {
                case Workspace.options.g_mod.BASIC_EVEN_ODD:
                    {
                        Fill_key_BASIC_EVEN_ODD();
                        break;
                    }
                case Workspace.options.g_mod.BASIC_PRIM_COMP:
                    {
                        Fill_key_BASIC_PRIM_COMP();
                        break;
                    }
                case Workspace.options.g_mod.BASIC_MYST:
                    {
                        Fill_key_BASIC_MYST();
                        break;
                    }
                case Workspace.options.g_mod.ALGEBRA_SIMP:
                    {
                        Fill_key_BASIC_MYST();
                        break;
                    }
            }

        }

        private static void Fill_key_BASIC_EVEN_ODD()
        {
            workspace.keys[0].str = Get_Random_Element<string>(new List<string>() { "Even", "Odd" });
            workspace.keys[1].str = workspace.keys[0].str == "Odd" ? "Even" : "Odd";
        }

        private static void Fill_key_BASIC_PRIM_COMP()
        {
            workspace.keys[0].str = Get_Random_Element<string>(new List<string>() { "Prime", "Composite" });
            workspace.keys[1].str = workspace.keys[0].str == "Prime" ? "Composite" : "Prime";
        }

        private static void Fill_key_BASIC_MYST()
        {
            List<int> counters = new List<int>();

            for (int i = first_num; i <= last_num; i++)
                counters.Add(i);

            for (int i = 0; i < workspace.keys.Count; i++)
            {
                workspace.keys[i].str = "Add ";
                int current_counter = Get_Random_Element<int>(counters);
                workspace.keys[i].str += current_counter.ToString();
                counters.Remove(current_counter);

                if (counters.Count == 0) break;
            }
        }

        private static void Fill_key_ALGEBRA_SIMP()
        {
            switch (workspace.op.active_complexity)
            {
                case Workspace.options.complexity.JUNIOR:
                    {
                        Fill_key_ALGEBRA_SIMP_JUNIOR();
                        break;
                    }
                case Workspace.options.complexity.BASIC:
                    {
                        Fill_key_ALGEBRA_SIMP_BASIC();
                        break;
                    }
                case Workspace.options.complexity.ADVANCED:
                    {
                        Fill_key_ALGEBRA_SIMP_ADVANCED();
                        break;
                    }
            }
        }

        private static void Fill_key_ALGEBRA_SIMP_JUNIOR()
        {
            List<int> all_numbers = new List<int>();
            int first_or_number = 0;
            int second_or_number = 0;

            for (int i = first_num; i <= last_num; i++)
                all_numbers.Add(i);

            for (int i = 0; i < workspace.keys.Count; i++)
            {
                try
                {
                    first_or_number = rand.Next(first_num, last_num + 1);
                    all_numbers.Remove(first_or_number);

                    do
                    {
                        second_or_number = rand.Next(first_num, last_num + 1);
                    } while (first_or_number != second_or_number);

                    all_numbers.Remove(second_or_number);
                }
                catch { break; }

                workspace.keys[i].str = "";
                workspace.keys[i].str += first_or_number.ToString();
                workspace.keys[i].str += " or ";
                workspace.keys[i].str += second_or_number.ToString();

                if (all_numbers.Count == 0) break;
            }
        }

        private static void Fill_key_ALGEBRA_SIMP_BASIC()
        {
            List<int> all_numbers = new List<int>();

            for (int i = first_num; i <= last_num; i++)
                all_numbers.Add(i);

            for (int i = 0; i < workspace.keys.Count; i++)
            {
                int current_number = Get_Random_Element<int>(all_numbers);
                workspace.keys[i].str += current_number.ToString();
                all_numbers.Remove(current_number);

                if (all_numbers.Count == 0) break;
            }
        }

        private static void Fill_key_ALGEBRA_SIMP_ADVANCED()
        {
            List<int> all_numbers = new List<int>();

            for (int i = first_num; i <= last_num; i++)
                all_numbers.Add(i);

            //Випадковий вибір між ключем з одним числом, багатьма які розділені комою, і проміжком між числами
            int coma_or_hyphen = rand.Next(1,3);
            if (coma_or_hyphen == 1) Fill_key_ALGEBRA_COMA(ref all_numbers);
            else Fill_key_ALGEBRA_HYPHEN(ref all_numbers);
        }

        private static void Fill_key_ALGEBRA_COMA(ref List<int> all_numbers)
        {
            const int max_numbers_in_one_string = 5;

            for (int i = 0; i < workspace.keys.Count; i++)
            {
                int current_count_numbers_in_string = rand.Next(1, max_numbers_in_one_string);

                List<int> current_numbers_in_string = new List<int>();

                for (int j = 0; j < current_count_numbers_in_string; j++)
                {
                    int current_number = Get_Random_Element<int>(all_numbers);
                    workspace.keys[i].str += current_number.ToString();
                    all_numbers.Remove(current_number);
                    if (current_count_numbers_in_string != 1 && j != current_count_numbers_in_string - 1) workspace.keys[i].str += ",";
                }

                if (all_numbers.Count == 0) break;
            }
        }

        private static void Fill_key_ALGEBRA_HYPHEN(ref List<int> all_numbers)
        {

            for (int i = 0; i < workspace.keys.Count; i++)
            {
                

                if (all_numbers.Count == 0) break;
            }
        }

    }
}
