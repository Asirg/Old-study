/*
 * Клас для зберігання інформації про пробне ЗНО
 */
namespace SofiaSpack.Code
{
    class TrialTest
    {
        public string ID { get; set; }

        public string[] QuestionsText { get; set; }
        public int[] QuestionSize { get; set; }
        public int[] QuestionsAnswer { get; set; }

        public string[] WritingQuestionsText { get; set; }
        public string[] WritingQuestionsAnswer { get; set; }
    }
}
