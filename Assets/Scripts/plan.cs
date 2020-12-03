using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plan : MonoBehaviour
{
    public int nbLignes;
    public int nbColonnes;


    public Material mat;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.AddComponent<MeshFilter>();          // Creation d'un composant MeshFilter qui peut ensuite être visualisé
        gameObject.AddComponent<MeshRenderer>();

        Vector3[] vertices = new Vector3[nbLignes*nbColonnes*4];
        int[] triangles = new int[nbLignes * 3 * nbColonnes * 3];

        for (int i = 0; i < nbColonnes; i++)
        {
            for (int j = 0; j < nbLignes; j++)
            {
                vertices[(i+j*nbColonnes)*4] = new Vector3(i, j, 0);
                vertices[(i + j * nbColonnes) * 4 +1] = new Vector3(i, j+1, 0);
                vertices[(i + j * nbColonnes) * 4 + 2] = new Vector3(i+1, j, 0);
                vertices[(i + j * nbColonnes) * 4 + 3] = new Vector3(i+1, j+1, 0);

                triangles[(i + j * nbColonnes) * 6] = (i + j * nbColonnes) * 4;
                triangles[(i + j * nbColonnes) * 6 + 1] = (i + j * nbColonnes) * 4 + 1;
                triangles[(i + j * nbColonnes) * 6 + 2] = (i + j * nbColonnes) * 4 + 2;
                triangles[(i + j * nbColonnes) * 6 + 3] = (i + j * nbColonnes) * 4 + 2;
                triangles[(i + j * nbColonnes) * 6 + 4] = (i + j * nbColonnes) * 4 + 1;
                triangles[(i + j * nbColonnes) * 6 + 5] = (i + j * nbColonnes) * 4 + 3;

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
