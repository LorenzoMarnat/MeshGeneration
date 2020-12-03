using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pacman : MonoBehaviour
{
    public int meridiens;
    public int meridiensTronc;
    public int paralleles;
    public float rayon;

    public Material mat;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.AddComponent<MeshFilter>();          // Creation d'un composant MeshFilter qui peut ensuite être visualisé
        gameObject.AddComponent<MeshRenderer>();

        int meridiensF = meridiens - meridiensTronc;
        Vector3[] vertices = new Vector3[((meridiensF + 1) * (paralleles + 1)) + 1 ];
        int[] triangles = new int[(6 * paralleles * meridiensF)+ (6*paralleles)];

        int k = 0;

        // Vertices de la sphere
        for (int i = 0; i <= paralleles; i++)
        {
            float phi = -Mathf.PI / 2 + (i * Mathf.PI / paralleles);

            for (int j = 0; j <= meridiensF; j++)
            {
                float teta = j * 2 * Mathf.PI / meridiens;
                vertices[k++] = new Vector3(rayon * Mathf.Cos(teta) * Mathf.Cos(phi), rayon * Mathf.Sin(teta) * Mathf.Cos(phi), rayon * Mathf.Sin(phi));
            }
        }

        // Point central
        vertices[k++] = new Vector3(0, 0, 0);

        // Triangles spheres
        k = 0;
        for (int j = 0; j < paralleles; j++)
        {
            int paraHaut = j * (meridiensF + 1);
            int paraBas = (j + 1) * (meridiensF + 1);
            for (int i = 0; i < meridiensF; i++)
            {
                triangles[k++] = paraHaut + i;
                triangles[k++] = paraBas + i + 1;
                triangles[k++] = paraBas + i;
                triangles[k++] = paraHaut + i;
                triangles[k++] = paraHaut + i + 1;
                triangles[k++] = paraBas + i + 1;
            }
        }

        // Remplissage troncature
        for(int i = 0;i<paralleles;i++)
        {
            triangles[k++] = (i*(meridiensF+1))+meridiensF+1;
            triangles[k++] = ((meridiensF + 1) * (paralleles + 1));
            triangles[k++] = (i*(meridiensF+1));

            triangles[k++] = (i * (meridiensF + 1)) + meridiensF; 
            triangles[k++] = ((meridiensF + 1) * (paralleles + 1));
            triangles[k++] = ((i * (meridiensF + 1)) + meridiensF + 1) + meridiensF;
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
