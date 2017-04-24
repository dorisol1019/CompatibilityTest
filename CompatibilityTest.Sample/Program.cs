using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Bot.Interactive;

namespace Bot.Interactive.Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            CompatibilityTest compatibilityTest = new CompatibilityTest("../../template.json");

            do
            {

                foreach (var beginningMessage in compatibilityTest.GetBeginningMessages())
                {
                    Console.WriteLine(beginningMessage);
                }
                Console.WriteLine("======== 診断開始 ==========");

                int id = 1;
                do
                {
                    var question = compatibilityTest.GetQuestion(id);
                    do
                    {
                        Console.WriteLine(question.Text);
                        for (int i = 0; i < question.AnswerOption.Length; i++)
                        {
                            Console.WriteLine($"[{i + 1}:{question.AnswerOption[i].Label}]");
                        }
                        Console.WriteLine("番号を入力し、Enterを押してくれ");
                        if (int.TryParse(Console.ReadLine(), out id) && 
                            0 < id && id < question.AnswerOption.Length + 1)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("不正な入力だ、選択し直してくれ");
                        }
                    } while (true);

                    Core.AnswerOption ans = question.AnswerOption[id - 1];

                    id = ans.NextId;

                    if (ans.Type == Core.AnswerActionType.Result) break;

                } while (true);

                Console.WriteLine("======== 診断終了 ==========");
                var resultMessages = compatibilityTest.GetResultMessages(id);

                foreach (var resultMessage in resultMessages)
                {
                    Console.WriteLine(resultMessage);
                }

                var replayQuestion = compatibilityTest.GetReplayQuestion();

                var answerOption = replayQuestion.AnswerOption;
                do
                {
                    Console.WriteLine(replayQuestion.Text);

                    for (int i = 0; i < answerOption.Length; i++)
                    {
                        Console.WriteLine($"[{i + 1}:{answerOption[i].Label}]");
                    }
                    Console.WriteLine("番号を入力し、Enterを押してくれ");
                    if (int.TryParse(Console.ReadLine(), out id)&&
                         0 < id && id < answerOption.Length + 1)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("不正な入力だ、選択し直してくれ");
                    }
                } while (true);

                Core.AnswerOption answer = replayQuestion.AnswerOption[id - 1];

                if (answer.Type == Core.AnswerActionType.End)
                {
                    foreach (var item in compatibilityTest.GetEndingMessages())
                    {
                        Console.WriteLine(item);
                    }
                    return;
                }

                foreach (var item in compatibilityTest.GetReplayMessages())
                {
                    Console.WriteLine(item);
                }

            } while (true);
        }
    }
}
