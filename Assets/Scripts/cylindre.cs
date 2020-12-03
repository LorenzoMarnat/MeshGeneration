using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cylindre : MonoBehaviour
{

    public int meridiens;
    public int rayon;
    public int hauteur;

    public Material mat;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.AddComponent<MeshFilter>();          // Creation d'un composant MeshFilter qui peut ensuite être visualisé
        gameObject.AddComponent<MeshRenderer>();

        Vector3[] vertices = new Vector3[(meridiens+1)*2];
        int[] triangles = new int[(meridiens*6)+(meridiens*6)];

        // Centre face basse
        vertices[0] = new Vector3(0, 0, 0);

        // Centre face haute
        vertices[meridiens + 1] = new Vector3(0, hauteur, 0);

        // Vertices faces haute et basse
        for (int i = 1; i <= meridiens; i++)
        {
            // Basse
            vertices[i] = new Vector3(rayon * Mathf.Sin((2 * Mathf.PI * i) / meridiens),0, rayon * Mathf.Cos((2 * Mathf.PI * i) / meridiens));

            // Haute
            vertices[i + meridiens + 1] = new Vector3(rayon * Mathf.Sin((2 * Mathf.PI * i) / meridiens), hauteur, rayon * Mathf.Cos((2 * Mathf.PI * i) / meridiens));
        }

        int k = 0;

        // Triangles faces haute et basse
        for(int j = 1; j <= meridiens;j++)
        {
            // Basse
            triangles[k] = 0;
            triangles[k+1] = (j % meridiens) + 1;
            triangles[k + 2] = j;

            // Haute
            triangles[k+3] = (meridiens + 1);
            triangles[k + 4] = (meridiens + 1) + j;
            triangles[k + 5] = (meridiens + 1) + (j % meridiens) + 1;

            k += 6;
        }

        // Triangles faces cotés
        for (int i = 1; i <= meridiens; i++)
        {
            triangles[k] = i;
            triangles[k + 1] = (meridiens + 1) + (i % meridiens) + 1; 
            triangles[k + 2] = (meridiens + 1) + i;
            triangles[k + 3] = i;
            triangles[k + 4] = (i % meridiens) + 1;
            triangles[k + 5] = (meridiens + 1) + (i % meridiens) + 1;
            k += 6;
        }

        Mesh msh = new Mesh();                          // Création et remplissage du Mesh

        msh.vertices = vertices;
        msh.triangles = triangles;

        gameObject.GetComponent<MeshFilter>().mesh = msh;           // Remplissage du Mesh et ajout du matériel
        gameObject.GetComponent<MeshRenderer>().material = mat;

    }

    // Update is called once per frame
    void Update()
    {

    }
}
