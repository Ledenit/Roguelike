#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Content;
#endregion

namespace Roguelike
{
    public class GameMouseControl
    {
        public bool dragging, rightDrag;
        public Vector2 newMousePosition, oldMousePosition, firstMousePosition, newMouseAdjPosition,
            systemCursorPosition, csreenLoc;

        public MouseState newMouse, oldMouse, firstMouse;

        public GameMouseControl()
        {
            dragging = false;

            newMouse = Mouse.GetState();
            oldMouse = newMouse;
            firstMouse = newMouse;

            newMousePosition = new Vector2(newMouse.Position.X, newMouse.Position.Y);
            oldMousePosition = new Vector2(newMouse.Position.X, newMouse.Position.Y);
            firstMousePosition = new Vector2(newMouse.Position.X, newMouse.Position.Y);

            GetMouseAndAdjust();
        }

        public void Update()
        {
            GetMouseAndAdjust();

            if (newMouse.LeftButton == ButtonState.Pressed
                && oldMouse.LeftButton == ButtonState.Released)
            {
                firstMouse = newMouse;
                firstMousePosition = newMousePosition = GetScreenPosition(firstMouse);
            }
        }

        public void UpdateOld()
        {
            oldMouse = newMouse;
            oldMousePosition = GetScreenPosition(oldMouse);
        }

        public virtual float GetDistanceFromClick()
        {
            return Global.GetDistance(newMousePosition, firstMousePosition);
        }

        public virtual void GetMouseAndAdjust()
        {
            newMouse = Mouse.GetState();
            newMousePosition = GetScreenPosition(newMouse);
        }

        public int GetMouseWheelChange()
        {
            return newMouse.ScrollWheelValue - oldMouse.ScrollWheelValue;
        }

        public Vector2 GetScreenPosition(MouseState Mouse)
        {
            Vector2 tempVector = new Vector2(Mouse.Position.X, Mouse.Position.Y);
            return tempVector;
        }

        public virtual bool LeftClick()
        {
            return (newMouse.LeftButton == ButtonState.Pressed
                && oldMouse.LeftButton != ButtonState.Pressed
                && newMouse.Position.X >= 0
                && newMouse.Position.X <= Global.screenWidth
                && newMouse.Position.Y >= 0
                && newMouse.Position.Y <= Global.screenHeight);
        }

        public virtual bool LeftClickHold()
        {
            bool holding = false;
            if (newMouse.LeftButton == ButtonState.Pressed
                && oldMouse.LeftButton != ButtonState.Pressed
                && newMouse.Position.X >= 0
                && newMouse.Position.X <= Global.screenWidth
                && newMouse.Position.Y >= 0
                && newMouse.Position.Y <= Global.screenHeight)
            {
                holding = true;
                if (Math.Abs(newMouse.Position.X - firstMouse.Position.X) > 8
                  || Math.Abs(newMouse.Position.Y - firstMouse.Position.Y) > 8)
                    dragging = true;
            }

            return holding;
        }

        public virtual bool LeftClickRelease()
        {
            if (newMouse.LeftButton == ButtonState.Released 
                && oldMouse.LeftButton == ButtonState.Pressed)
            {
                dragging = false;
                return true;
            }
            return false;
        }

        public virtual bool RightClick()
        {
            return (newMouse.RightButton == ButtonState.Pressed
                && oldMouse.RightButton != ButtonState.Pressed
                && newMouse.Position.X >= 0
                && newMouse.Position.X <= Global.screenWidth
                && newMouse.Position.Y >= 0
                && newMouse.Position.Y <= Global.screenHeight);
        }

        public virtual bool RightClickHold()
        {
            bool holding = false;
            if (newMouse.RightButton == ButtonState.Pressed
                && oldMouse.RightButton != ButtonState.Pressed
                && newMouse.Position.X >= 0
                && newMouse.Position.X <= Global.screenWidth
                && newMouse.Position.Y >= 0
                && newMouse.Position.Y <= Global.screenHeight)
            {
                holding = true;
                if (Math.Abs(newMouse.Position.X - firstMouse.Position.X) > 8
                  || Math.Abs(newMouse.Position.Y - firstMouse.Position.Y) > 8)
                    dragging = true;
            }

            return holding;
        }

        public virtual bool RightClickRelease()
        {
            if (newMouse.RightButton == ButtonState.Released
                && oldMouse.RightButton == ButtonState.Pressed)
            {
                dragging = false;
                return true;
            }
            return false;
        }

        public void SetFirst()
        { }
    }
}
