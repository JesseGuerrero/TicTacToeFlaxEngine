using System;
using System.Collections.Generic;
using FlaxEngine;
using FlaxEngine.Utilities;

namespace Game
{
    public class InputTicTac : Script
    {
        private TextRender[,] points= new TextRender[3, 3];
        private TextRender text;
        /// <inheritdoc/>
        public override void OnStart()
        {
            text = Actor.Scene.GetChild<TextRender>();
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                {
                    TextRender textClone = Scene.AddChild<TextRender>();
                    textClone.Material = text.Material;
                    textClone.Font = text.Font;
                    textClone.Position = text.Position;
                    textClone.Position = new Vector3(-60 + (i * 60), 215 - (j * 60), text.Position.Z);
                    points[i, j] = textClone;
                }

        }

        /// <inheritdoc/>
        public override void OnUpdate()
        {
            if (Input.Mouse.GetButtonDown(MouseButton.Left))
            {
                Debug.Log("X: " + Input.MousePosition.X + ", Y: " + Input.MousePosition.Y);
                markSquare(Input.MousePosition.X, Input.MousePosition.Y);
            }
                
        }

        private bool isX = true;
        public void markSquare(float mouseX, float mouseY)
        {
            int i = 0;
            int j = 0;
            if (Input.MousePosition.X < 430)
                i = 0;
            else if (Input.MousePosition.X < 650)
                i = 1;
            else if (Input.MousePosition.X < 867)
                i = 2;
            if (Input.MousePosition.Y < 159)
                j = 0;
            else if (Input.MousePosition.Y < 376)
                j = 1;
            else if (Input.MousePosition.Y < 569)
                j = 2;
            if (points[i, j].Text.Value == "")
            {
                points[i, j].Text = isX ? "X" : "O";
                isX = !isX;
            }
        }
    }
}
