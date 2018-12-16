#include  <iostream> 
#include  <string.h> 
#include  <stdio.h> 
#include  <stdlib.h> 
#include <conio.h> 
using namespace std;



char matrizPrincipal[8][8];
int fila = 0;
int  columna = 0;
static string alfabeto = "ABCDEFGHIJKLMN�OPQRSTUVWXYZ";


//---------------------------------------------------------------------------------------
bool buscarEnMatriz(char matriz[8][8], char valor)
{
	for (int i = 0; i<8; i++)
		for (int j = 0; j < 8; j++)
		{
			if (matriz[i][j] == valor)
				return true;
		}
	return false;
}

//---------------------------------------------------------------------------------------
void crearMatriz(string clave)
{
	for (int i = 0; i < clave.length(); i++)
	{
		char letra = clave[i];
		bool encontrado = buscarEnMatriz(matrizPrincipal, letra);

		if (!encontrado) {
			matrizPrincipal[fila][columna] = (char)letra;
			columna++;
			if (columna > 7)
			{
				columna = 0;
				fila++;
			}
		}
	}
}

//---------------------------------------------------------------------------------------
string cifrarDiagrama(char c1, char c2)
{
	int par1[2];
	int par2[2];
	string cad = "";

	for (size_t i = 0; i < 8; i++)
	{
		for (size_t j = 0; j < 8; j++)
		{
			if (matrizPrincipal[i][j] == c1)
			{
				par1[0] = i;
				par1[1] = j;
			}
			if (matrizPrincipal[i][j] == c2)
			{
				par2[0] = i;
				par2[1] = j;
			}
		}
	}
	int x1 = par1[0], x2 = par2[0];
	int y1 = par1[1], y2 = par2[1];
	if (par1[0] == par2[0])
	{
		y1++;
		y2++;
		if (y1 >= 8)
			y1 = 0;
		if (y2 >= 8)
			y2 = 0;

		c2 = matrizPrincipal[x2][y2];
		c1 = matrizPrincipal[x1][y1];
	}
	else if (par1[1] == par2[1])
	{
		x1++;
		x2++;
		if (x1 >= 8)
			x1 = 0;
		if (x2 >= 8)
			x2 = 0;

		c2 = matrizPrincipal[x2][y2];
		c1 = matrizPrincipal[x1][y1];
	}
	else
	{
		c2 = matrizPrincipal[par2[0]][par1[1]];
		c1 = matrizPrincipal[par1[0]][par2[1]];
	}
	cad += c1;
	cad += c2;

	return cad;
}

//---------------------------------------------------------------------------------------
string cifrado = "";
string cifrar(string clave, string txt)
{
	//txt = sinEspacios(txt);
	crearMatriz(clave);
	crearMatriz(alfabeto);
	cifrado = "";

	for (size_t i = 0; i < txt.length(); i = i + 2)
	{
		cifrado += cifrarDiagrama(txt[i], txt[i + 1]);
	}
	return cifrado;
}


//---------------------------------------------------------------------------------------
string descifrarMatriz(char c1, char c2)
{
	int par1[2];
	int par2[2];
	string cad = "";

	for (size_t i = 0; i < 8; i++)
	{
		for (size_t j = 0; j < 8; j++)
		{
			if (matrizPrincipal[i][j] == c1)
			{
				par1[0] = i;
				par1[1] = j;
			}
			if (matrizPrincipal[i][j] == c2)
			{
				par2[0] = i;
				par2[1] = j;
			}
		}
	}
	int x1 = par1[0], x2 = par2[0];
	int y1 = par1[1], y2 = par2[1];
	if (par1[0] == par2[0])
	{
		y1--;
		y2--;
		if (y1 < 0)
			y1 = 7;
		if (y2 < 0)
			y2 = 7;

		c2 = matrizPrincipal[x2][y2];
		c1 = matrizPrincipal[x1][y1];
	}
	else if (par1[1] == par2[1])
	{
		x1--;
		x2--;
		if (x1 < 0) x1 = 7;
		if (x2 < 0) x2 = 7;

		c2 = matrizPrincipal[x2][y2];
		c1 = matrizPrincipal[x1][y1];
	}
	else
	{
		c2 = matrizPrincipal[par2[0]][par1[1]];
		c1 = matrizPrincipal[par1[0]][par2[1]];

	}
	cad += c1;
	cad += c2;

	return cad;
}

//---------------------------------------------------------------------------------------
string descifrar(string clave, string txt)
{
//	txt = sinEspacios(txt);
	crearMatriz(txt);
	crearMatriz(alfabeto);

	cifrado = "";
	for (size_t i = 0; i <txt.length(); i += 2)
	{
		cifrado += descifrarMatriz(txt[i], txt[i + 1]);

	}
	return cifrado;
}

string acompletar(string text)
{
	if (text.length() % 2 == 1)
		text = text + "X";
	return text;
}


//�h�la MUNDo!
/*SI LA CLAVE ES MAS GRANDE QUE EL TEXTO A CIFRAR
miniculas y mayusculas, letras acentuadas, caracateres, espacios
*/
