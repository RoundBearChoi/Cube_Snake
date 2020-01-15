using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RBSnake
{
    public class CameraManager : Singleton<CameraManager>
    {
        private CameraControl cameraControl;

        public CameraControl CAMERA_CONTROL
        {
            get
            {
                if (cameraControl == null)
                {
                    cameraControl = FindObjectOfType<CameraControl>();
                }
                return cameraControl;
            }
        }
    }
}

