public static class Score {
    private static int score;

    public static int Points {
        get {
            return (score);
        }
        set {
            score = value;
            UI.UpdateScore(score);
        }
    }
}
