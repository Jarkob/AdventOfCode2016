using System;
namespace Day02
{
    public class KeypadElement
    {
        public KeypadElement()
        {

        }

        public KeypadElement(int Value)
        {
            this.Value = Value;
        }

        private KeypadElement up;
        public KeypadElement Up
        {
            get { return this.up; }
            set
            {
                this.up = value;

                if (value.Down == null)
                {
                    value.Down = this;
                }
            }
        }

        private KeypadElement right;
        public KeypadElement Right
        {
            get { return this.right; }
            set
            {
                this.right = value;

                if (value.Left == null)
                {
                    value.Left = this;
                }
            }
        }

        private KeypadElement down;
        public KeypadElement Down
        {
            get { return this.down; }
            set
            {
                this.down = value;

                if (value.Up == null)
                {
                    value.Up = this;
                }
            }
        }

        private KeypadElement left;
        public KeypadElement Left
        {
            get { return this.left; }
            set
            {
                this.left = value;

                if (value.Right == null)
                {
                    value.Right = this;
                }
            }
        }

        public int Value { get; set; }
    }
}
