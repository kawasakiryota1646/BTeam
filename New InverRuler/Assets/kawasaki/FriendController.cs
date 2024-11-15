using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendController : MonoBehaviour
{
    public GameObject explosionPrefab; // �����G�t�F�N�g�̃v���n�u���Q��

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("EnemyBullet"))
        {
            StartCoroutine(HandleExplosion()); // �R���[�`�����J�n
            Destroy(gameObject); // �����@�̂����ł�����
        }
    }

    private IEnumerator HandleExplosion()
    {
        GameObject explosion = Instantiate(explosionPrefab, transform.position, transform.rotation); // �����G�t�F�N�g���C���X�^���X��
        Debug.Log("Explosion instantiated"); // �f�o�b�O���O
        yield return new WaitForSeconds(0.5f); // 0.5�b�ҋ@
        Destroy(explosion); // �����G�t�F�N�g�����ł�����
        Debug.Log("Explosion destroyed"); // �f�o�b�O���O
    }
}







