using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Graphing3D._3DBehaviors.Frontend
{
    public static class Movement
    {
        public static void applyMovement()
        {
            if (Keyboard.IsKeyDown(Key.A)) // left
            {
                Screen.cam.position.x -= .03 * Math.Sin(Screen.cam.theta);
                Screen.cam.position.y += .03 * Math.Cos(Screen.cam.theta);
            }
            if (Keyboard.IsKeyDown(Key.D)) // right
            {
                Screen.cam.position.x += .03 * Math.Sin(Screen.cam.theta);
                Screen.cam.position.y -= .03 * Math.Cos(Screen.cam.theta);
            }
            if (Keyboard.IsKeyDown(Key.W)) // forward
            {
                Screen.cam.position.x += .03 * Math.Cos(Screen.cam.theta);
                Screen.cam.position.y += .03 * Math.Sin(Screen.cam.theta);
            }
            if (Keyboard.IsKeyDown(Key.S)) // backward
            {
                Screen.cam.position.x -= .03 * Math.Cos(Screen.cam.theta);
                Screen.cam.position.y -= .03 * Math.Sin(Screen.cam.theta);
            }
            if (Keyboard.IsKeyDown(Key.LeftShift)) // Down
            {
                Screen.cam.position.z -= 0.03;
            }
            if (Keyboard.IsKeyDown(Key.Space)) // Up
            {
                Screen.cam.position.z += 0.03;
            }
            if (Keyboard.IsKeyDown(Key.Up)) // look up
            {
                Screen.cam.phi -= .02;
            }
            if (Keyboard.IsKeyDown(Key.Right)) //look right
            {
                Screen.cam.theta -= .02;
            }
            if (Keyboard.IsKeyDown(Key.Left)) // look left
            {
                Screen.cam.theta += .02;
            }
            if (Keyboard.IsKeyDown(Key.Down)) // look down
            {
                Screen.cam.phi += .02;
            }
        }
    }
}
