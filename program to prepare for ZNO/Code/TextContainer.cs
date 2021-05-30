

/**
 *  Клас для зберігання інформації про деякий розділ.
 */
namespace SofiaSpack.Code
{
    public class TextContainer
    {
        public string ID { get; set; }
        public string[] Header { get; set; }

        public string[] QuestionsText { get; set; }
        public int[] QuestionSize { get; set; }
        public int[] QuestionsAnswer { get; set; }

    }
}
