using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace GameLogic
{
    internal class Step
    {
        private Point m_Start;
        private Point m_End;
        private bool m_IsEatStep;

        public Step()
        {
            m_IsEatStep = false;
        }

        public bool IsEatStep
        {
            get
            {
                return m_IsEatStep;
            }

            set
            {
                m_IsEatStep = value;
            }
        }

        public Point Start
        {
            get
            {
                return m_Start;
            }

            set
            {
                m_Start = value;
            }
        }

        public Point End
        {
            get
            {
                return m_End;
            }

            set
            {
                m_End = value;
            }
        }

        internal static bool IsValid(Step i_CurrentStep, List<Step> i_ListOfSteps)
        {
            bool isValid = true;
            Point startPoint = i_CurrentStep.Start;
            Point endPoint = i_CurrentStep.End;

            i_CurrentStep.SetStep(startPoint, endPoint);
            if (!i_CurrentStep.IsStepInList(i_ListOfSteps))
            {
                isValid = false;
            }

            return isValid;
        }

        internal bool IsStepInList(List<Step> i_ListOfSteps)
        {
            bool isStepInList = false;

            foreach (Step step in i_ListOfSteps)
            {
                if (m_Start == step.Start && m_End == step.End)
                {
                    isStepInList = true;
                }
            }

            return isStepInList;
        }

        internal void SetStep(Point i_Start, Point i_End)
        {
            m_Start.Y = i_Start.Y;
            m_Start.X = i_Start.X;
            m_End.Y = i_End.Y;
            m_End.X = i_End.X;
        }
    }
}
