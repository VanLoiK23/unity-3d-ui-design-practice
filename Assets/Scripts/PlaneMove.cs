using UnityEngine;

public class PlaneMove : MonoBehaviour
{
    public float speed = 10f;       
    public float takeOffZ = 12f;    
    public float climbRate = 0.04f; 
    public float maxHeight = 4.5f;   

    void Update()
    {
        // Cho máy bay tiến về phía trước dọc theo trục Z
        transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.World);

        // Khi vượt qua mốc chạy đà
        if (transform.position.z > takeOffZ)
        {
            Vector3 pos = transform.position;

            // Đang lấy độ cao
            if (pos.y < maxHeight)
            {
                float distance = transform.position.z - takeOffZ;
                pos.y = (distance * distance) * climbRate;

                if (pos.y > maxHeight)
                {
                    pos.y = maxHeight;
                }
                transform.position = pos;

                Quaternion climbRotation = Quaternion.Euler(15f, 180f, 0f);
                transform.rotation = Quaternion.Lerp(transform.rotation, climbRotation, Time.deltaTime * 2f);
            }
            // Đã đạt độ cao tối đa -> Giữ nguyên độ cao và bay thẳng
            else
            {
                pos.y = maxHeight;
                transform.position = pos;

                Quaternion levelRotation = Quaternion.Euler(0f, 180f, 0f);
                transform.rotation = Quaternion.Lerp(transform.rotation, levelRotation, Time.deltaTime * 3f);
            }
        }
    }
}