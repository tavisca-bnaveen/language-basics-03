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

        public static int[] SelectMeals(int[] protein, int[] carbs, int[] fat, string[] dietPlans)
        {
            int i,j,k;
            
            int min = int.MaxValue;
            int max = int.MinValue;
            for (i=0;i<protein.Length;i++)
            {
                if (protein[i] > max)
                    max = protein[i];
                if (protein[i] < min)
                    min = protein[i];
            }
            List<int> maxprotein = new List<int>();
            List<int> minprotein = new List<int>();
            for (i = 0; i < protein.Length; i++)
            {
            if(protein[i]==min)
                {
                    minprotein.Add(i);
                }
            else if(protein[i]==max)
                {
                    maxprotein.Add(i);
                }
            }
            min = int.MaxValue;
            max = int.MinValue;
            for (i = 0; i < carbs.Length; i++)
            {
                if (carbs[i] > max)
                    max = carbs[i];
                if (carbs[i] < min)
                    min = carbs[i];
            }
            List<int> maxcarbs = new List<int>();
            List<int> mincarbs = new List<int>();
            for (i = 0; i < carbs.Length; i++)
            {
                if (carbs[i] == min)
                {
                    mincarbs.Add(i);
                }
                else if (carbs[i] == max)
                {
                    maxcarbs.Add(i);
                }
            }
            min = int.MaxValue;
            max = int.MinValue;
            for (i = 0; i < fat.Length; i++)
            {
                if (fat[i] > max)
                    max = fat[i];
                if (fat[i] < min)
                    min = fat[i];
            }
            List<int> maxfat = new List<int>();
            List<int> minfat = new List<int>();
            for (i = 0; i < fat.Length; i++)
            {
                if (fat[i] == min)
                {
                    minfat.Add(i);
                }
                else if (fat[i] == max)
                {
                    maxfat.Add(i);
                }
            }
            int c = 0;
            max = int.MinValue;
            min = int.MaxValue;
            List<int> cal = new List<int>();
            for (i = 0; i < fat.Length; i++)
            {
                c = (fat[i] * 9) + (protein[i] * 5) + (carbs[i] * 5);
                cal.Add(c);
                if (c > max)
                    max = c;
                if (c < min)
                    min = c;

            }
            List<int> maxcal = new List<int>();
            List<int> mincal = new List<int>();
            for (i = 0; i < cal.Count; i++)
            {
                if (cal[i] == min)
                {
                    mincal.Add(i);
                }
                else if (cal[i] == max)
                {
                    maxcal.Add(i);
                }
            }
            int[] answer = new int[dietPlans.Length];
            for (i=0;i< dietPlans.Length;i++)
            {
                List<int> output;
                if (dietPlans[i].Length == 0)
                {
                    answer[i] = 0;
                    continue;
                }

                switch (dietPlans[i][0])
                {
                    case 'C':
                        output = maxcarbs.ToList();
                        break;
                    case 'c':
                        output = mincarbs.ToList();
                        break;
                    case 'P':
                        output = maxprotein.ToList();
                        break;
                    case 'p':
                        output = minprotein.ToList();
                        break;
                    case 'F':
                        output = maxfat.ToList();
                        break;
                    case 'f':
                        output = minfat.ToList();
                        break;
                    case 'T':
                        output = maxcal.ToList();
                        break;
                    case 't':
                        output = mincal.ToList();
                        break;
                    default:
                        output = mincal.ToList();
                        break;
                }
                if (output.Count==1 || dietPlans[i].Length==1)
                {
                    answer[i] = output[0];
                    continue;
                }
                k = i;
                for (j=1;j< dietPlans[k].Length;j++)
                {
                    List<int> sample = new List<int>();
                    switch (dietPlans[k][j])
                    { 
                        case 'C':
                            max = int.MinValue;
                            for (i = 0; i < output.Count; i++)
                                {
                                if (carbs[output[i]] > max)
                                    max = carbs[output[i]];
                                }
                            for (i = 0; i < output.Count; i++)
                            {
                                if (carbs[output[i]] == max)
                                    sample.Add(output[i]);
                            }
                            output = sample.ToList();
                            break;
                        case 'c':
                            min = int.MaxValue;
                            for (i = 0; i < output.Count; i++)
                            {
                                if (carbs[output[i]] <min)
                                    min = carbs[output[i]];
                            }
                            for (i = 0; i < output.Count; i++)
                            {
                                if (carbs[output[i]] == min)
                                    sample.Add(output[i]);
                            }
                            output = sample.ToList();
                          
                            break;
                        case 'P':
                            max = int.MinValue;
                            for (i = 0; i < output.Count; i++)
                            {
                                if (protein[output[i]] > max)
                                    max = protein[output[i]];
                            }
                            for (i = 0; i < output.Count; i++)
                            {
                                if (protein[output[i]] == max)
                                    sample.Add(output[i]);
                            }
                            output = sample.ToList();
                            break;
                        case 'p':
                            min = int.MaxValue;
                            for (i = 0; i < output.Count; i++)
                            {
                                if (protein[output[i]] < min)
                                    min = protein[output[i]];
                            }
                            for (i = 0; i < output.Count; i++)
                            {
                                if (protein[output[i]] == min)
                                    sample.Add(output[i]);
                            }
                            output = sample.ToList();
                            break;
                        case 'F':
                            
                            max = int.MinValue;
                            for (i = 0; i < output.Count; i++)
                            {
                                
                                if (fat[output[i]] > max)
                                    max = fat[output[i]];
                            }
                            for (i = 0; i < output.Count; i++)
                            {
                                if (fat[output[i]] == max)
                                    sample.Add(output[i]);
                            }
                            output = sample.ToList();
                           
                            break;
                        case 'f':
                            min = int.MaxValue;
                            for (i = 0; i < output.Count; i++)
                            {
                                if (fat[output[i]] < min)
                                    min = fat[output[i]];
                            }
                            for (i = 0; i < output.Count; i++)
                            {
                                if (fat[output[i]] == min)
                                    sample.Add(output[i]);
                            }
                            output = sample.ToList();
                            break;
                        case 'T':
                            max = int.MinValue;
                            for (i = 0; i < output.Count; i++)
                            {
                                if (cal[output[i]] > max)
                                    max = cal[output[i]];
                            }
                            for (i = 0; i < output.Count; i++)
                            {
                                if (cal[output[i]] == max)
                                    sample.Add(output[i]);
                            }
                            output = sample.ToList();
                            break;
                        case 't':
                            min = int.MaxValue;
                            for (i = 0; i < output.Count; i++)
                            {
                                if (cal[output[i]] < min)
                                    min = cal[output[i]];
                            }
                            for (i = 0; i < output.Count; i++)
                            {
                                if (cal[output[i]] == min)
                                    sample.Add(output[i]);
                            }
                            output = sample.ToList();
                            
                            break;
                        default:
                            
                            break;
                    }
                    if (output.Count == 1)
                    {
                        answer[k] = output[0];
                        break;
                    }
                  if(j==dietPlans[k].Length - 1)
                    {
                        answer[k] = output[0];
                        break;
                    }
                }
                i = k;
                
            }
            return answer;
            
        }
    }
}
