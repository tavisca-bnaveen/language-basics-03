using System;
using System.Linq;
using System.Collections.Generic;
namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
    public static class Program
    {
        static void Main(string[] args)
        {
            Test(
                new[] { 3, 4 }, 
                new[] { 2, 8 }, 
                new[] { 5, 2 }, 
                new[] { "P", "p", "C", "c", "F", "f", "T", "t" }, 
                new[] { 1, 0, 1, 0, 0, 1, 1, 0 });
            Test(
                new[] { 3, 4, 1, 5 }, 
                new[] { 2, 8, 5, 1 }, 
                new[] { 5, 2, 4, 4 }, 
                new[] { "tFc", "tF", "Ftc" }, 
                new[] { 3, 2, 0 });
           Test(
                new[] { 18, 86, 76, 0, 34, 30, 95, 12, 21 }, 
                new[] { 26, 56, 3, 45, 88, 0, 10, 27, 53 }, 
                new[] { 93, 96, 13, 95, 98, 18, 59, 49, 86 }, 
                new[] { "f", "Pt", "PT", "fT", "Cp", "C", "t", "", "cCp", "ttp", "PCFt", "P", "pCt", "cP", "Pc" }, 
                new[] { 2, 6, 6, 2, 4, 4, 5, 0, 5, 5, 6, 6, 3, 5, 6 });
            Console.ReadKey(true);
        }

        private static void Test(int[] protein, int[] carbs, int[] fat, string[] dietPlans, int[] expected)
        {
            var result = SelectMeals(protein, carbs, fat, dietPlans).SequenceEqual(expected) ? "PASS" : "FAIL";
            Console.WriteLine($"Proteins = [{string.Join(", ", protein)}]");
            Console.WriteLine($"Carbs = [{string.Join(", ", carbs)}]");
            Console.WriteLine($"Fats = [{string.Join(", ", fat)}]");
            Console.WriteLine($"Diet plan = [{string.Join(", ", dietPlans)}]");
            Console.WriteLine(result);
        }
        public static List<int> MaxMeal(List<int> index, int[] meal)
        {
            int i;
            int max = int.MinValue;
            for (i = 0; i < index.Count; i++)
            {
                if (meal[index[i]] > max)
                    max = meal[index[i]];
            }
            List<int> maxnut = new List<int>();
            for (i = 0; i < index.Count; i++)
            {
                if (meal[index[i]] == max)
                    maxnut.Add(index[i]);
            }
            return maxnut;
        }
        public static List<int> MinMeal(List<int> index, int[] meal)
        {
            int min = int.MaxValue;
            int i;
            for (i = 0; i < index.Count; i++)
            {
                if (meal[index[i]] <min)
                    min = meal[index[i]];
            }
            List<int> minnut = new List<int>();
            for (i = 0; i < index.Count; i++)
            {
                if (meal[index[i]] == min)
                    minnut.Add(index[i]);
            }
            return minnut;
        }
        public static int[] calorie(int[] protein, int[] carbs, int[] fat)
        {
            int i;
            int[] a = new int[protein.Length];
            for (i = 0; i < fat.Length; i++)
            {
                int c = (fat[i] * 9) + (protein[i] * 5) + (carbs[i] * 5);
                a[i] = c;
            }
            return a;
        }
        public static int[] SelectMeals(int[] protein, int[] carbs, int[] fat, string[] dietPlans)
        {
            int i,j;
            int[] answer = new int[dietPlans.Length];
            for (i = 0; i < dietPlans.Length; i++)
            {
                
                if (dietPlans[i].Length == 0)
                {
                    answer[i] = 0;
                    continue;
                }
                List<int> output = Enumerable.Range(0, fat.Length).ToList();
                for (j = 0; j < dietPlans[i].Length; j++)
                { 
                   switch (dietPlans[i][j])
                   {
                    case 'C':
                        output = MaxMeal(output, carbs).ToList();
                        break;
                    case 'c':
                        output = MinMeal(output, carbs).ToList();
                        break;
                    case 'P':
                        output = MaxMeal(output, protein).ToList();
                        break;
                    case 'p':
                        output = MinMeal(output, protein).ToList();
                        break;
                    case 'F':
                        output = MaxMeal(output, fat).ToList();
                        break;
                    case 'f':
                        output = MinMeal(output, fat).ToList();
                        break;
                    case 'T':
                        output = MaxMeal(output, calorie(protein, carbs, fat)).ToList();
                        break;
                    case 't':
                        output = MinMeal(output, calorie(protein, carbs, fat)).ToList();
                        break;
                    default:
                        //output = mincal.ToList();
                        break;
                }
                if (output.Count == 1)
                {
                    answer[i] = output[0];
                        break;
                }
                    if (j == dietPlans[i].Length - 1)
                    {
                        answer[i] = output[0];
                        break;
                    }
                }
                   
                  
                }
                
                
            
            return answer;
            
        }
    }
}
