using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    //tracks which question the player is on
    int questionCounter = 0;
    //array of all the questions we're going to ask
    public string[] questions;

    //int[] highScore;
    //bool[] puzzleSolved;
    //float[] temperatures;

    //arrays of the answers the princesses can give
    public string[] belleAnswers;
    public string[] arielAnswers;
    public string[] cindAnswers;
    public string[] mulanAnswers;
    
    //reference to the text component we're drawing our questions to
    public TMP_Text questionText;

    //references to the text components we're drawing our answers to
    public TMP_Text belleText;
    public TMP_Text arielText;
    public TMP_Text cindText;
    public TMP_Text mulanText;

    //scores for how much of each princess we are
    int belleScore;
    int arielScore;
    int cindScore;
    int mulanScore;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //questionText.text = questionOne;

        //set the first question
        questionText.text = questions[0];

        //set the first answers
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

    //calculate results when the player answers a question
    //takes one parameter: an int representing which princess button we clicked
    public void AnsweredQuestion(int princessClicked)
    {
        //depending on the princess we clicked on
        //increase the coresponding (what is spelling??) princess's score
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
        
        //if we haven't reached the last question
        if (questionCounter < questions.Length-1)
        {
            //go to the next question
            //update the text accordingly
            questionCounter++;
            questionText.text = questions[questionCounter];
            belleText.text = belleAnswers[questionCounter];
            arielText.text = arielAnswers[questionCounter];
            cindText.text = cindAnswers[questionCounter];
            mulanText.text = mulanAnswers[questionCounter];
        }
        else
        {
            //other, find out which princess we are
            CalculatePrincess();
        }

        
    }

    //determines which princess we are
    void CalculatePrincess()
    {
        //if the score in any given category is 2
        //you are that princess
        //otherwise you are not a princess
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
