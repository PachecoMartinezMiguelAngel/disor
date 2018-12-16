#include "GUI.h"

using namespace System;
using namespace System::Windows::Forms;


[STAThread]
void Main()
{
	Application::EnableVisualStyles();
	Application::SetCompatibleTextRenderingDefault(false);

	PlayFair_GUI::MyForm form;
	Application::Run(%form);
}
