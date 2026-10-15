using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    int questionCounter = 0;
    public string[] questions;

    //int[] highScore;
    //bool[] puzzleSolved;
    //float[] temperatures;

    public string[] belleAnswers;
    public string[] arielAnswers;
    public string[] cindAnswers;
    public string[] mulanAnswers;
    
    public TMP_Text questionText;

    public TMP_Text belleText;
    public TMP_Text arielText;
    public TMP_Text cindText;
    public TMP_Text mulanText;

    int belleScore;
    int arielScore;
    int cindScore;
    int mulanScore;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //questionText.text = questionOne;
        questionText.text = questions[0];

        belleText.text = belleAnswers[0];
        arielText.text = arielAnswers[0];
        cindText.text = cindAnswers[0];
        mulanText.text = mulanAnswers[0];
    }

    // Update is called once per frame
    void Update()
    {
        /*if (questionCounter == 0)
        {
            questionText.text = questions[0];
        } else if (questionCounter == 1)
        {
            questionText.text = questions[1];
        }*/
    }

    public void AnsweredQuestion(int princessClicked)
    {
        if (princessClicked == 0)
        {
            belleScore++;
        } else if (princessClicked == 1)
        {
            arielScore++;
        } else if (princessClicked == 2)
        {
            cindScore++;
        } else if (princessClicked == 3)
        {
            mulanScore++;
        }
        
        if (questionCounter < questions.Length-1)
        {
            questionCounter++;
            questionText.text = questions[questionCounter];
            belleText.text = belleAnswers[questionCounter];
            arielText.text = arielAnswers[questionCounter];
            cindText.text = cindAnswers[questionCounter];
            mulanText.text = mulanAnswers[questionCounter];
        }
        else
        {
            CalculatePrincess();
        }

        
    }

    void CalculatePrincess()
    {
        if (belleScore == 2)
        {
            questionText.text = "You are Belle!";
        } else if (arielScore == 2)
        {
            questionText.text = "You are Ariel!";
        } else if (cindScore == 2)
        {
            questionText.text = "You are Cinderella!";
        } else if (mulanScore == 2)
        {
            questionText.text = "You are Mulan!";
        }
        else
        {
            questionText.text = "You are NOT a princess!";
        }
    }
}
