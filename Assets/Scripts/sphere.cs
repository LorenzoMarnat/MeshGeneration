using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sphere : MonoBehaviour
{
    public int meridiens;
    public int paralleles;
    public float rayon;

    public Material mat;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.AddComponent<MeshFilter>();          // Creation d'un composant MeshFilter qui peut ensuite être visualisé
        gameObject.AddComponent<MeshRenderer>();

        Vector3[] vertices = new Vector3[(meridiens+1)*(paralleles+1)];
        int[] triangles = new int[6*paralleles*meridiens];

        int k = 0;

        for(int i =0; i<= paralleles;i++)
        {
            float phi = -Mathf.PI / 2 + (i * Mathf.PI / paralleles);
            for (int j = 0; j <= meridiens;j++)
            {
                float teta = j * 2 * Mathf.PI / meridiens;
                vertices[k++] = new Vector3(rayon * Mathf.Cos(teta) * Mathf.Cos(phi), rayon * Mathf.Sin(teta) * Mathf.Cos(phi), rayon * Mathf.Sin(phi));
            }
        }

        k = 0;
        for(int j = 0;j < paralleles;j++)
        {
            int paraHaut = j * (meridiens + 1);
            int paraBas = (j + 1) * (meridiens + 1);
            for(int i = 0;i<meridiens;i++)
            {
                triangles[k++] = paraHaut + i;
                triangles[k++] = paraBas + i + 1;
                triangles[k++] = paraBas + i;
                triangles[k++] = paraHaut + i;
                triangles[k++] = paraHaut + i + 1;
                triangles[k++] = paraBas + i + 1;
            }
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
