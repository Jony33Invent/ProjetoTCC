using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Pergunta
{
	[TextArea(3,10)]
	public string pergunta;
	public string resposta;
	public string[] alternativas;

}
