using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScoreCalculator_8_1_x
{
    public partial class frmScoreCalculator_8_1_x : Form
    {
        public frmScoreCalculator_8_1_x()
        {
            InitializeComponent();
        }

        /*
       Drew Watson
       Friedman
       Component based
       Spring 18
       Lab 4
       8.1x
        */

        //Class variables
        int scoreTotal = 0;
        int scoreCount = 0;

        //Array
        int[] myData = new int[20];

        //List
        List<int> scores = new List<int>();


        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            /*
            Got tired of accidentally entering a letter and VS freezing
            decided to put an exception handler in.
            */
            try
            {
                //arrayCalculation();
                listCalculation();
            }

            //Catches format error if entry is not a valid number
            catch (FormatException)
            {
                MessageBox.Show("Invalid Number Format, Please try again.");
            }
        }

        //Clears the myData in the array
        private void btnClearScore_Click(object sender, EventArgs e)
        {
            clearScores();
        }

        //Calculates the values in an array
        private void arrayCalculation()
        {
            int score = 0;
            int average = 0;

            //Gets the myData from the txtbox and converts them
            score = Convert.ToInt32(txtScore.Text);

            //Adds each element from score into the array and then increments
            myData[scoreCount] = score;
            scoreCount++;

            //Adds the myData together
            scoreTotal = scoreTotal + score;

            //Calculates the average score
            average = scoreTotal / scoreCount;

            //Displays the myData, score count and average and shifts the focus
            txtScoreTotal.Text = Convert.ToString(scoreTotal);
            txtScoreCount.Text = Convert.ToString(scoreCount);
            txtAverage.Text = Convert.ToString(average);

            txtScore.Focus();
        }

        //Calculates the values in a list
        private void listCalculation()
        {
            int score = 0;
            int average = 0;
            int count = 0;

            //Converts scores and adds them to list
            score = Convert.ToInt32(txtScore.Text);
            scores.Add(score);

            //Gets the elements in list and puts them in count
            count = scores.Count;

            //Calculates score total 
            scoreTotal = scoreTotal + score;

            //Calculates average scores, could have just used the count variable here but didnt for some reason 
            average = scoreTotal / scores.Count;

            //Displays the results and changes focus
            txtScoreTotal.Text = Convert.ToString(scoreTotal);
            txtScoreCount.Text = Convert.ToString(count);
            txtAverage.Text = Convert.ToString(average);

            txtScore.Focus();
        }
    
        //Clears the data structures and controls
        private void clearScores()
        {
            int[] cleared = new int[20];

            //Just copy a new blank array into the old one and clear the count and total 
            Array.Copy(cleared, myData, cleared.Length);

            //Clears the list
            scores.Clear();

            scoreTotal = 0;
            scoreCount = 0;

            //Clear the txt boxes
            txtScoreTotal.Text = "";
            txtScoreCount.Text = "";
            txtAverage.Text = "";
            txtScore.Text = "";

            //Shifts the focus
            txtScore.Focus();
        }

        //Displays the myData array that is sorted
        private void btnDisplaymyData_Click(object sender, EventArgs e)
        {
            //displayArray();
            displayList();
        }

       
        //Displays data
        private void displayArray()
        {
            string numberString = sortArray();

             /*
            Prints myData; essentially it concats the myData with a string
            and sends them to a message box    
            */
            for (int i = 0; i < myData.Length; i++)
            {
                //Will not print out myData that are null or zero
                if (myData[i] != 0)
                {
                    numberString += myData[i] + "\n";
                }
            }

            MessageBox.Show(numberString, "myData");
            txtScore.Focus();
        }

        //Sorts data
        private string sortArray()
        {
            /*
            LOL BUBLE SORT FOR NOW; compares one element at a time 
            Time Complexity: O(n^2)
            */
            string numberString = "";

            int j = 0, k = 0, temp = 0;

            for (k = j + 1; k < myData.Length; k++)
            {
                for (j = 0; j < myData.Length - 1; j++)
                {
                    if (myData[j] > myData[k])
                    {
                        temp = myData[k];
                        myData[k] = myData[j];
                        myData[j] = temp;
                    }
                }
            }

            return numberString;
        }

        //Sorts list
        private void sortList()
        {
            scores.Sort();
        }

        //Displayes the sorted scores
        private void displayList()
        {
            string numberString = "";
            int listCount = 0;

            //Sorts the list
            sortList();

            //Adds elements to a string for printing
            for (int i = 0; i < scores.Count; i++)
            {
                //Will not display any null or zero scores
                if (scores[i] != 0)
                {
                    numberString += scores[i] + "\n";
                }
            }

            //Count of elements in list
            listCount = scores.Count();

            MessageBox.Show(numberString+"\n\n"+"Score count: "+listCount, "Scores");
            txtScore.Focus();
        }
    }
}
