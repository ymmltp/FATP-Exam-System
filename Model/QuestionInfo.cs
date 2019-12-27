namespace Model
{
    public class QuestionInfo
    {
        public int QuestionIndex { get; set; }
        public string Question { get; set; }
        public string QuestionType { get; set; }
        public string S1 { get; set; }
        public string S2 { get; set; }
        public string S3 { get; set; }
        public string S4 { get; set; }
        public string[] Answer { get; set; }
        public string[] UserAnswer { get; set; }
        public bool FinalResult { get; set; }
    }
}
