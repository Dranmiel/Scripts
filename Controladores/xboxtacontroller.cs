/*

GameVersion 0.0.1v

HUD Controller for the project SteamDrafters
Script pure and commented for undestading pourposes

Controlador e HUD provisório para o projeto SteamDrafters
Script puro com comentários

pt-br|english

*/
using System;
using UnityEngine;
using System.Collections;

public class xboxtacontroller : MonoBehaviour
{
    public enum ControllerProfile { PC , Controller };
    bool isControllerConnected = false;
    public string Controller = "";
    public string PC_Move, PC_Rotate, PC_Item1, PC_Item2, PC_Item3, PC_Inv, PC_Pause, PC_Attackuse, PC_Aim;
    public string Xbox_Move, Xbox_Rotate, Xbox_Item1, Xbox_Item2, Xbox_Item3, Xbox_Inv, Xbox_Pause, Xbox_Attackuse, Xbox_Aim;
    public ControllerProfile cProfile;
    string ControlScheme;
    public KeyCode pcItem1, pcItem2, pcItem3, pcInv, pcPause, pcAttackUse, pcAim, xinv, xPause;
    private KeyCode orig_pcItem1, orig_pcItem2, orig_pcItem3, orig_pcInv, orig_pcPause, orig_xInv, orig_xPause;
    bool ShowPopup = false;
    KeyCode PreviousKey;

    void setDefaultvalues() // Esquema dos controles | Control scheme
    {
        ControlScheme = "Scheme A";
        if (!isControllerConnected)
        {
            PC_Move = "WASD";
            PC_Rotate = "Mouse";
            PC_Item1 = "1";
            PC_Item2 = "2";
            PC_Item3 = "3";
            PC_Inv = "I";
            PC_Pause = "Escape";
            PC_Attackuse = "Left Mouse Button";
            PC_Aim = "Right Mouse Button";

            pcItem1 = KeyCode.Alpha1;
            pcItem2 = KeyCode.Alpha2;
            pcItem3 = KeyCode.Alpha3;
            pcInv = KeyCode.I;
            pcPause = KeyCode.Escape;
            pcAttackUse = KeyCode.Mouse0;
            pcAim = KeyCode.Mouse1;

            orig_pcItem1 = pcItem1;
            orig_pcItem2 = pcItem2;
            orig_pcItem3 = pcItem3;
            orig_pcInv = pcInv;
            orig_pcPause = pcPause;

        }
        else
        {
            PC_Move = "WASD";
            PC_Rotate = "Mouse";
            PC_Item1 = "1";
            PC_Item2 = "2";
            PC_Item3 = "3";
            PC_Inv = "I";
            PC_Pause = "Escape";
            PC_Attackuse = "Left Mouse Button";
            PC_Aim = "Right Mouse Button";
            Xbox_Move = "Left Thumbstick";
            Xbox_Rotate = "Right Thumbstick";
            Xbox_Item1 = "D-Pad UP";
            Xbox_Item2 = "D-Pad Down";
            Xbox_Item3 = "D-Pad Left";
            Xbox_Inv = "A Button";
            Xbox_Pause = "Start Button";
            Xbox_Attackuse = "Right Trigger";
            Xbox_Aim = "Left Trigger";

            pcItem1 = KeyCode.Alpha1;
            pcItem2 = KeyCode.Alpha2;
            pcItem3 = KeyCode.Alpha3;
            pcInv = KeyCode.I;
            pcPause = KeyCode.Escape;
            pcAttackUse = KeyCode.Mouse0;
            pcAim = KeyCode.Mouse1;
            xinv = KeyCode.I;
            xPause = KeyCode.Escape;

            orig_pcItem1 = pcItem1;
            orig_pcItem2 = pcItem2;
            orig_pcItem3 = pcItem3;
            orig_pcInv = pcInv;
            orig_pcPause = pcPause;
            orig_xInv = xinv;
            orig_xPause = xPause;
        }
    }
    void DetectController() // Função para checar se existe um "gamepad" conectado | "is gamepad connected?" function
    {
        try
        {
            if (Input.GetJoystickNames()[0] != null)
            {
                isControllerConnected = true;
                IdentifyController();
                cProfile = ControllerProfile.Controller;
            }
            else
            {
                cProfile = ControllerProfile.PC;
            }
        }
        catch
        {
            isControllerConnected = false;
        }
    }
    void IdentifyController() // Função Identificadora do "gamepad" | gamepad identifier funtion 
    {
        Controller = Input.GetJoystickNames()[0];
    }
    void SwitchProfile(ControllerProfile Switcher) // Função que troca o profile do controlador de PC para controle(xbox - mapeado,ps4 - não mapeado,..) | Profile switcher function from pc to controller (xbox - mapped,ps4 - un-mapped,..)
    {
        cProfile = Switcher;
    }
    void setNewKey(KeyCode KeyToSet, KeyCode SetTo) // Função de case switch de keys para ciclamento entre controles | Case switch function for key cycling
    {
        switch (KeyToSet)
        {
            case KeyCode.Alpha1:
                pcItem1 = SetTo;
                PC_Item1 = SetString(pcItem2.ToString());
                break;
            case KeyCode.Alpha2:
                pcItem2 = SetTo;
                PC_Item2 = SetString(pcItem2.ToString());
                break;
            case KeyCode.Alpha3:
                pcItem3 = SetTo;
                PC_Item3 = SetString(pcItem3.ToString());
                break;
            case KeyCode.I:
                pcInv = SetTo;
                PC_Inv = SetString(pcInv.ToString());
                break;
            case KeyCode.Escape:
                pcPause = SetTo;
                PC_Pause = SetString(pcPause.ToString());
                break;
            case KeyCode.Joystick1Button1:
                xinv = SetTo;
                Xbox_Inv = SetString(xinv.ToString());
                break;
            case KeyCode.Joystick1Button6:
                xPause = SetTo;
                Xbox_Pause = SetString(xPause.ToString());
                break;
        }
    }
    string SetString(string SetTo)// case switch para variáves string | String variables case switcher function
    {
        switch (SetTo)
        {
            case "Alpha1":
                SetTo = "1";
                break;
            case "Alpha2":
                SetTo = "2";
                break;
            case "Alpha3":
                SetTo = "3";
                break;
            case "Return":
                SetTo = "Enter";
                break;
            case "Escape":
                SetTo = "Escape";
                break;
            case "I":
                SetTo = "I";
                break;
            case "JoystickButton6":
                SetTo = "Start Button";
                break;
            case "JoystickButton1":
                SetTo = "A Button";
                break;
        }
        return SetTo;
    }

    void SwitchControlScheme(string Scheme)// Função de troca entre esquemas preset | Preset switcher function
    {
        switch (Scheme)
        {
            case "Scheme A":
                setDefaultvalues();
                break;
            case "Scheme B":
                if (!isControllerConnected)
                {
                    PC_Move = "WASD";
                    PC_Rotate = "Mouse";
                    PC_Item1 = "Numpad 1";
                    PC_Item2 = "Numpad 2";
                    PC_Item3 = "Numpad 3";
                    PC_Inv = "Numpad +";
                    PC_Pause = "Enter";
                    PC_Attackuse = "Right Mouse Button";
                    PC_Aim = "Left Mouse Button";

                    pcItem1 = KeyCode.Keypad1;
                    pcItem2 = KeyCode.Keypad2;
                    pcItem3 = KeyCode.Keypad3;
                    pcInv = KeyCode.KeypadPlus;
                    pcPause = KeyCode.Return;
                    pcAttackUse = KeyCode.Mouse1;
                    pcAim = KeyCode.Mouse0;
                }
                else
                {
                    PC_Move = "WASD";
                    PC_Rotate = "Mouse";
                    PC_Item1 = "Numpad 1";
                    PC_Item2 = "Numpad 2";
                    PC_Item3 = "Numpad 3";
                    PC_Inv = "Numpad +";
                    PC_Pause = "Enter";
                    PC_Attackuse = "Right Mouse Button";
                    PC_Aim = "Left Mouse Button";
                    Xbox_Move = "Left Thumbstick";
                    Xbox_Rotate = "Right Thumbstick";
                    Xbox_Item1 = "D-Pad UP";
                    Xbox_Item2 = "D-Pad Down";
                    Xbox_Item3 = "D-Pad Left";
                    Xbox_Inv = "B Button";
                    Xbox_Pause = "Back Button";
                    Xbox_Attackuse = "Right Trigger";
                    Xbox_Aim = "Left Trigger";

                    pcItem1 = KeyCode.Keypad1;
                    pcItem2 = KeyCode.Keypad2;
                    pcItem3 = KeyCode.Keypad3;
                    pcInv = KeyCode.KeypadPlus;
                    pcPause = KeyCode.Return;
                    pcAttackUse = KeyCode.Mouse1;
                    pcAim = KeyCode.Mouse0;
                    xinv = KeyCode.Joystick1Button1;
                    xPause = KeyCode.Joystick1Button6;
                }
                break;
        }
    }
    void Reset() // Função de reset do mapeamento, display e esquema dos controles para os valores default | Mapping, display and control scheme reset function to default values
    {
        setDefaultvalues();
        ShowPopup = false;
        PreviousKey = KeyCode.None;
    }
    void OnGUI() // Menu gráfico de mapeamento, customização e display dos controles | Mapping, customization and control display GUI
    {
        if (!ShowPopup)
        {
            GUI.BeginGroup(new Rect(Screen.width / 2 - 300, Screen.height / 2 - 300, 600, 400));
            GUI.Box(new Rect(0, 0, 600, 400), "Controls");
            GUI.Label(new Rect(205, 40, 20, 20), "PC");
            GUI.Label(new Rect(350, 40, 125, 20), "Xbox Controller");

            GUI.Label(new Rect(25, 75, 125, 20), "Movement: ");
            GUI.Button(new Rect(150, 75, 135, 20), PC_Move);
            GUI.Button(new Rect(325, 75, 135, 20), Xbox_Move);

            GUI.Label(new Rect(25, 100, 125, 20), "Rotation: ");
            GUI.Button(new Rect(150, 100, 135, 20), PC_Rotate);
            GUI.Button(new Rect(325, 100, 135, 20), Xbox_Rotate);
	/* 
	Menu com condições para customização para os controles:
	PC_Item1,PC_Item2,PC_Item3,PC_Inv,Xbox_Inv,PC_Pause,Xbox_Pause

	Case menu for the following control customization:
	PC_Item1,PC_Item2,PC_Item3,PC_Inv,Xbox_Inv,PC_Pause,Xbox_Pause
	*/
            GUI.Label(new Rect(25, 125, 125, 20), "Item 1:"); 
            if (GUI.Button(new Rect(150, 125, 135, 20), PC_Item1))
            {
                ShowPopup = true;
                PreviousKey = pcItem1;
            }
            GUI.Button(new Rect(325, 125, 135, 20), Xbox_Item1);

            GUI.Label(new Rect(25, 150, 125, 20), "Item 2: ");
            if (GUI.Button(new Rect(150, 150, 135, 20), PC_Item2))
            {
                ShowPopup = true;
                PreviousKey = pcItem2;
            }
            GUI.Button(new Rect(325, 150, 135, 20), Xbox_Item2);

            GUI.Label(new Rect(25, 175, 125, 20), "Item 3: ");
            if (GUI.Button(new Rect(150, 175, 135, 20), PC_Item3))
            {
                ShowPopup = true;
                PreviousKey = pcItem3;
            }
            GUI.Button(new Rect(325, 175, 135, 20), Xbox_Item3);

            GUI.Label(new Rect(25, 200, 125, 20), "Inventory: ");
            if (GUI.Button(new Rect(150, 200, 135, 20), PC_Inv))
            {
                ShowPopup = true;
                PreviousKey = pcInv;
            }
            if (GUI.Button(new Rect(325, 200, 135, 20), Xbox_Inv))
            {
                ShowPopup = true;
                PreviousKey = xinv;
            }

            GUI.Label(new Rect(25, 225, 125, 20), "Pause Game: ");
            if (GUI.Button(new Rect(150, 225, 135, 20), PC_Pause))
            {
                ShowPopup = true;
                PreviousKey = pcPause;
            }
            if (GUI.Button(new Rect(325, 225, 135, 20), Xbox_Pause))
            {
                ShowPopup = true;
                PreviousKey = xPause;
            }

            GUI.Label(new Rect(25, 250, 125, 20), "Attack/Use:");
            GUI.Button(new Rect(150, 250, 135, 20), PC_Attackuse);
            GUI.Button(new Rect(325, 250, 135, 20), Xbox_Attackuse);

            GUI.Label(new Rect(25, 275, 125, 20), "Aim: ");
            GUI.Button(new Rect(150, 275, 135, 20), PC_Aim);
            GUI.Button(new Rect(325, 275, 135, 20), Xbox_Aim);

            GUI.Label(new Rect(450, 345, 125, 20), "Current Controls: ");
            if (GUI.Button(new Rect(425, 370, 135, 20), cProfile.ToString()))// Switcher e display atual do profile dos controles | Actual control profile and display switcher
            {
                if (cProfile == ControllerProfile.Controller)
                {
                    SwitchProfile(ControllerProfile.PC);
                }
                else
                {
                    SwitchProfile(ControllerProfile.Controller);
                }
            }
            GUI.Label(new Rect(15, 345, 125, 20), "Current Control Scheme");
            if (GUI.Button(new Rect(25, 370, 135, 20), ControlScheme))// Switcher e display do preset do esquema de controles | Actual control preset and scheme switcher
            {
                if (ControlScheme == "Scheme A")
                {
                    SwitchControlScheme("Scheme B");
                    ControlScheme = "Scheme B";
                }
                else
                {
                    SwitchControlScheme("Scheme A");
                    ControlScheme = "Scheme A";
                }
            }
            if (GUI.Button(new Rect(230, 370, 135, 20), "Reset Controls")) // Reset do mapeamento e esquema para os valores default | Control mapping and scheme default reset switcher 
            {
                Reset();
            }
            GUI.EndGroup();
        }
        else // Menu condicional final para troca de controles | Final case control switcher
        {
            GUI.BeginGroup(new Rect(Screen.width / 2 - 300, Screen.height / 2 - 300, 600, 400));
            GUI.Box(new Rect(0, 0, 600, 400), "Pick A Control to Switch");
            if (GUI.Button(new Rect(150, 125, 135, 20), "1"))
            {
                setNewKey(PreviousKey, orig_pcItem1);
                ShowPopup = false;
            }
            if (GUI.Button(new Rect(150, 150, 135, 20), "2"))
            {
                setNewKey(PreviousKey, orig_pcItem2);
                ShowPopup = false;
            }
            if (GUI.Button(new Rect(150, 175, 135, 20), "3"))
            {
                setNewKey(PreviousKey, orig_pcItem3);
                ShowPopup = false;
            }
            if (GUI.Button(new Rect(150, 200, 135, 20), "I"))
            {
                setNewKey(PreviousKey, orig_pcInv);
                ShowPopup = false;
            }
            if (GUI.Button(new Rect(150, 225, 135, 20), "Escape"))
            {
                setNewKey(PreviousKey, orig_pcPause);
                ShowPopup = false;
            }
            if (GUI.Button(new Rect(150, 250, 135, 20), "A Button"))
            {
                setNewKey(PreviousKey, orig_xInv);
                ShowPopup = false;
            }
            if (GUI.Button(new Rect(150, 275, 135, 20), "Start Button"))
            {
                setNewKey(PreviousKey, orig_xPause);
                ShowPopup = false;
            }
            GUI.EndGroup();
        }
    }
}
