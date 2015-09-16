using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace QuizTool
{
    class GetQuizFile
    {
        private static List<QuizQuestion> _theQuestions = new List<QuizQuestion>();
        public static List<QuizQuestion> TheQuestions
        {
            get { return _theQuestions; }
        }
        public static string Title;
        public static void GetQuiz()
        {
            //Finds the file, and processes questions and answers.
            string line;
            StringBuilder stringBuilder = new StringBuilder();
            try
            {
                using (StringReader theReader = new StringReader(Form1.QuizText))
                {
                    while (true)
                    {
                        line = theReader.ReadLine();
                        //if the line is null, break.
                        if(line == null) { break; }
                        //If the line is empty, continue.
                        if (line == "") { continue; }
                        if (line[0] == 'T' || line[0] == 't')
                        {
                            //If the line starts with T, get the Title of the Quiz.
                            string[] parts = line.Split('"');
                            Title = parts[1];

                        }
                        //If the line does not start with Q, continue.
                        if (line[0] != 'Q' && line[0] != 'q')
                        {
                            //Ignore this line.
                            continue;
                        }
                        //Get elements for the Quiz Question in Line.
                        string[] elements = GetElements(line, stringBuilder);
                        QuizQuestion question = new QuizQuestion(elements);

                        _theQuestions.Add(question);


                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
        }
        private static string[] GetElements(string line, StringBuilder builder)
        {
            //[0] = Question.
            //[1],[2],[3],...,[n] = Options.
            //[stringArray.length] = Answer.

            //Set writing to false until condition is fulfilled.
            bool startWrite = false;
            //Create the list to hold elements.
            List<string> elements = new List<string>();
            //Find Question.
            foreach (char character in line)
            {
                //If the builder contains text, save the result and clear the builder.
                if (builder.Length > 0 && !startWrite)
                {
                    string elementToAdd = builder.ToString().Substring(0, builder.Length - 1);
                    elements.Add(elementToAdd);
                    builder.Clear();
                }
                if (startWrite)
                {
                    builder.Append(character);
                }
                //Start writing if the character is ".
                if (character == '"') { startWrite = !startWrite; }
            }
            //Return the list of elements of first quizquestion.
            //If the builder contains text, save the result and clear the builder.
            if (builder.Length > 0 && !startWrite)
            {
                string elementToAdd = builder.ToString().Substring(0, builder.Length - 1);
                elements.Add(elementToAdd);
                builder.Clear();
            }
            return elements.ToArray();

        }
    }

    class QuizQuestion
    {
        public string Question;
        public string[] Options;
        public string Answer;

        public QuizQuestion(string[] elements)
        {
            List<string> optionList = new List<string>();
            for (int i = 0; i < elements.Length; i++)
            {
                //Set the Question = elements[0];
                if (i == 0) { Question = elements[0]; continue; }
                //Set the Answer = elements[elements.Length-1];
                if (i == elements.Length - 1) { Answer = elements[i]; continue; }

                //Set the Options = elements[i]
                optionList.Add(elements[i]);
            }
            Options = optionList.ToArray();
        }
    }
}
