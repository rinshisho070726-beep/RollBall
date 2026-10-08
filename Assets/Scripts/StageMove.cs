//ライブラリの宣言　-> これからこの機能を使うよ
using UnityEngine;
using UnityEngine.InputSystem;

public class StageMove : MonoBehaviour
{
    // 変数、関数
    // 変数 -> int,string 値を格納するための箱
    // データ型(int,string,InputAction) + 変数名(num,name)
    private InputAction moveInput;

    // 関数 -> 処理をまとめて実行するための箱


    // 目的(抽象的課題)：ステージを回転させること
    // 手段（具体的課題）：ActionMapを使用してプレイヤーの入力を受け取る
    //      受け取った入力を元にステージのRotationを変更する


    // Start -> シーンのロード時(ゲームの開始時)に自動的に実行される関数
    void Start()
    {
        moveInput = InputSystem.actions.FindAction("Move");
    }
    [SerializeField] private float rotateSpeed = 30f;
    [SerializeField] private float maxAngle = 20f;

    private float xAngle;
    private float zAngle;

    // Update -> マイフレーム毎(0.1～0.3秒刻み)に自動で実行される関数
    void Update()
    {
        Debug.Log(moveInput.ReadValue<Vector2>());
        // A += B -> A = A + B
        // this.transform.localPosition -> このコードがアタッチされているオブジェクトの位置情報
        // moveInput.ReadValue<Vector2> ->(X,Y,Z=0)
        this.transform.Rotate((Vector3)moveInput.ReadValue<Vector2>());

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        xAngle += vertical * rotateSpeed * Time.deltaTime;
        zAngle -= horizontal * rotateSpeed * Time.deltaTime;

        xAngle = Mathf.Clamp(xAngle, -maxAngle, maxAngle);
        zAngle = Mathf.Clamp(zAngle, -maxAngle, maxAngle);

        transform.rotation = Quaternion.Euler(xAngle, 0f, zAngle);
    }
}