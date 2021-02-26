using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sceneGenerator : MonoBehaviour {
    public GameObject TheGoomba;
    public GameObject TheMushroom;
    public GameObject ThePlant;
    public GameObject TheCoin;
    Camera mainCam;
    Quaternion mainCamOriginalRotaion;
    AudioSource audioSource;
    public AudioClip Coin;
    public AudioClip Damage;
    public AudioClip Fall;
    public AudioClip GrowShrink;
    public AudioClip Jump;
    public AudioClip Laugh;
    // Use this for initialization
    void Start () {
        audioSource = GetComponent<AudioSource>();
        Time.timeScale = 2;
        mainCam = Camera.main; // Grab a reference to the camera
        mainCam.orthographic = true;
        mainCam.orthographicSize = 15;
        mainCamOriginalRotaion = Camera.main.transform.rotation;
        //TERRAINA
        GameObject terrainA = GameObject.CreatePrimitive(PrimitiveType.Cube);
        Renderer terrainA_R = terrainA.GetComponent<Renderer>();
        terrainA.transform.position = new Vector3(-3.67f, -5f, 0);
        terrainA.transform.localScale = new Vector3(40f, 14f, 4f);
        terrainA_R.material.color = new Color(0.58f,0.29f,0.04f,0.85f);

        //TERRAINB
        GameObject terrainB = GameObject.CreatePrimitive(PrimitiveType.Cube);
        Renderer terrainB_R = terrainB.GetComponent<Renderer>();
        terrainB.transform.position = new Vector3(42.6f, -5f, 0);
        terrainB.transform.localScale = new Vector3(40f, 14f, 4f);
        terrainB_R.material.color = new Color(0.58f, 0.29f, 0.04f, 0.85f);

        //BRICKS1TO3
        float j = -5.71f;
        for (int i = 0; i < 3; i++)
        {
            GameObject brick = GameObject.CreatePrimitive(PrimitiveType.Cube);
            brick.transform.position = new Vector3(j, 7.5f, 0f);
            brick.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
            brick.GetComponent<Renderer>().material.color = new Color(0.58f, 0.29f, 0.04f, 0.85f);
            j += 1.66f;
        }
        //BRICKS4TO5
        j = -5.71f;
        for (int i = 0; i < 2; i++)
        {
            GameObject brick = GameObject.CreatePrimitive(PrimitiveType.Cube);
            brick.transform.position = new Vector3(j, 11.2f, 0f);
            brick.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
            brick.GetComponent<Renderer>().material.color = new Color(0.58f, 0.29f, 0.04f, 0.85f);
            j += 3.22f;
        }
 

        //CLOUD1
        GameObject cloud1 = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        cloud1.transform.position = new Vector3(-7.54f, 19.5f, 17.21f);
        cloud1.transform.localScale = new Vector3(3.91f, 5.33f, 1f);
        cloud1.transform.rotation *= Quaternion.Euler(0, 0, 90f);
        cloud1.GetComponent<Renderer>().material.color = Color.white;

        //CLOUD2
        GameObject cloud2 = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        cloud2.transform.position = new Vector3(41.96f, 15.5f, 17.21f);
        cloud2.transform.localScale = new Vector3(5.26f, 11.71f, 1f);
        cloud2.transform.rotation *= Quaternion.Euler(0, 0, 90f);
        cloud2.GetComponent<Renderer>().material.color = Color.white;

        //BACKGROUND
        GameObject background = GameObject.CreatePrimitive(PrimitiveType.Plane);
        background.transform.position = new Vector3(413.7f, 10.3f, 194.1f);
        background.transform.localScale = new Vector3(500f, 1f, 200f);
        background.transform.rotation *= Quaternion.Euler(-90f, 0, 0);
        background.GetComponent<Renderer>().material.color = new Color(0.38f, 0.52f, 0.97f, 0.85f);

        //MUSHROOMS
        TheMushroom.GetComponent<Renderer>().material.color = new Color(0.92f, 0.1f, 0.14f, 0.85f);
        TheMushroom.transform.Find("Base").GetComponent<Renderer>().material.color = new Color(0.32f, 0.31f, 0.3f, 0.3f);
        TheMushroom.transform.Find("Spot1").GetComponent<Renderer>().material.color = Color.white;
        TheMushroom.transform.Find("Spot2").GetComponent<Renderer>().material.color = Color.white;
        TheMushroom.transform.Find("Spot3").GetComponent<Renderer>().material.color = Color.white;
        TheMushroom.transform.Find("eye1").GetComponent<Renderer>().material.color = Color.black;
        TheMushroom.transform.Find("eye2").GetComponent<Renderer>().material.color = Color.black;

        //COINS
        CreateCoin(-5.6f, 13.3f, 0f);
        CreateCoin(-2.44f, 13.3f, 0f);
        CreateCoin(26.22f, 8.32f, 0f);
        CreateCoin(30.64f, 8.32f, 0f);
        CreateCoin(28.31f, 12.26f, 0f);
        TheCoin.GetComponent<Renderer>().material.color = Color.yellow;
        TheCoin.transform.Find("Detail").GetComponent<Renderer>().material.color = Color.yellow;
        //GOOMBAS
        TheGoomba.GetComponent<Renderer>().material.color = new Color(0.29f, 0.12f, 0.06f, 1f);
        TheGoomba.transform.Find("Body").GetComponent<Renderer>().material.color = new Color(0.32f, 0.31f, 0.3f, 0.3f);
        TheGoomba.transform.Find("Leg1").GetComponent<Renderer>().material.color = Color.black;
        TheGoomba.transform.Find("Leg2").GetComponent<Renderer>().material.color = Color.black; 
        TheGoomba.transform.Find("Eye1").GetComponent<Renderer>().material.color = Color.black; 
        TheGoomba.transform.Find("Eye2").GetComponent<Renderer>().material.color = Color.black;
        TheGoomba.transform.Find("Eyebrow1").GetComponent<Renderer>().material.color = Color.black;
        TheGoomba.transform.Find("Eyebrow2").GetComponent<Renderer>().material.color = Color.black;

        //PIPES
        CreatePipe(6.16f,3.4f,0f);
        CreatePipe(38.75f, 3.6f, 0f);

        //PLANTS
        ThePlant.GetComponent<Renderer>().material.color = Color.green;
        ThePlant.transform.Find("Head").GetComponent<Renderer>().material.color = new Color(0.92f, 0.1f, 0.14f, 0.85f);
        ThePlant.transform.Find("Lip1").GetComponent<Renderer>().material.color = Color.white;
        ThePlant.transform.Find("Lip2").GetComponent<Renderer>().material.color = Color.white;
        ThePlant.transform.Find("Leaf").GetComponent<Renderer>().material.color = Color.green;
        CreatePlant(38.72f, 7.3f, 0f);


        //ANIMATIONSGOOMBA
        Animation anim = TheGoomba.GetComponent<Animation>();
        // define animation curve
        Keyframe[] keysXG;
        keysXG = new Keyframe[13];
        keysXG[0] = new Keyframe(1, -14f);
        keysXG[1] = new Keyframe(5f, -4f);
        keysXG[2] = new Keyframe(22f, -4f);
        //SCENE2
        keysXG[3] = new Keyframe(26f, 2.5f);
        keysXG[4] = new Keyframe(28f, 6f);
        keysXG[5] = new Keyframe(31f, 6f);
        keysXG[6] = new Keyframe(34f, 10f);
        //SCENE3
        keysXG[7] = new Keyframe(45f, 10f);
        keysXG[8] = new Keyframe(48f, 15f);
        keysXG[9] = new Keyframe(50f, 15f);
        keysXG[10] = new Keyframe(52f, 25f);
        keysXG[11] = new Keyframe(57f, 25f);
        keysXG[12] = new Keyframe(58f, 19.41f);
        AnimationCurve curveXG = new AnimationCurve(keysXG);
        Keyframe[] keysYG;
        keysYG = new Keyframe[19];
        keysYG[0] = new Keyframe(8f, 3.567f);
        keysYG[1] = new Keyframe(9f, 6f);
        keysYG[2] = new Keyframe(10f, 3.567f);
        keysYG[3] = new Keyframe(19f, 3.567f);
        keysYG[4] = new Keyframe(20f, 4f);
        //SCENE2
        keysYG[5] = new Keyframe(26f, 4f);
        keysYG[6] = new Keyframe(27f, 10f);
        keysYG[7] = new Keyframe(28f, 8.2f);
        keysYG[8] = new Keyframe(31f, 8.2f);
        keysYG[9] = new Keyframe(32f, 14f);
        keysYG[10] = new Keyframe(34f, 4f);
        keysYG[11] = new Keyframe(35f, 3.567f);
        //SCENE3
        keysYG[12] = new Keyframe(50f, 3.567f);
        keysYG[13] = new Keyframe(51f, 8f);
        keysYG[14] = new Keyframe(52f, 3.567f);
        keysYG[15] = new Keyframe(57f, 3.567f);
        keysYG[16] = new Keyframe(58f, 10f);
        keysYG[17] = new Keyframe(61f, 10f);
        keysYG[18] = new Keyframe(63f, -15);
        AnimationCurve curveYG = new AnimationCurve(keysYG);
        Keyframe[] keysScaleX;
        keysScaleX = new Keyframe[4];
        keysScaleX[0] = new Keyframe(19f, 1.52f);
        keysScaleX[1] = new Keyframe(20f, 1.89f);
        keysScaleX[2] = new Keyframe(34f, 1.89f);
        keysScaleX[3] = new Keyframe(35f, 1.52f);
        AnimationCurve curveScaleX = new AnimationCurve(keysScaleX);
        Keyframe[] keysScaleY;
        keysScaleY = new Keyframe[4];
        keysScaleY[0] = new Keyframe(19f, 0.84f);
        keysScaleY[1] = new Keyframe(20f, 1.04f);
        keysScaleY[2] = new Keyframe(34f, 1.04f);
        keysScaleY[3] = new Keyframe(35f, 0.84f);
        AnimationCurve curveScaleY = new AnimationCurve(keysScaleY);
        Keyframe[] keysScaleZ;
        keysScaleZ = new Keyframe[4];
        keysScaleZ[0] = new Keyframe(19f, 1.45f);
        keysScaleZ[1] = new Keyframe(20f, 1.8f);
        keysScaleZ[2] = new Keyframe(34f, 1.8f);
        keysScaleZ[3] = new Keyframe(35f, 1.45f);
        AnimationCurve curveScaleZ = new AnimationCurve(keysScaleZ);
        AnimationCurve rotateZ = AnimationCurve.EaseInOut(31f, 0.0f, 34f, -720f);
        AnimationClip animationClipG = new AnimationClip();
        // set animation clip to be legacy
        animationClipG.legacy = true;
        animationClipG.SetCurve("", typeof(Transform), "localPosition.x", curveXG);
        animationClipG.SetCurve("", typeof(Transform), "localPosition.y", curveYG);
        animationClipG.SetCurve("", typeof(Transform), "localScale.x", curveScaleX);
        animationClipG.SetCurve("", typeof(Transform), "localScale.y", curveScaleY);
        animationClipG.SetCurve("", typeof(Transform), "localScale.z", curveScaleZ);
        animationClipG.SetCurve("", typeof(Transform), "localEulerAngles.z", rotateZ);
        anim.AddClip(animationClipG, "test");
        anim.Play("test");

        //ANIMATIONSMUSHROOM
        Animation anim2 = TheMushroom.GetComponent<Animation>();
        // define animation curve
        Keyframe[] keysXM;
        keysXM = new Keyframe[3];
        keysXM[0] = new Keyframe(12, -4.06f);
        keysXM[1] = new Keyframe(16 ,4f);
        keysXM[2] = new Keyframe(20, -4f);
        AnimationCurve curveXM = new AnimationCurve(keysXM);
        Keyframe[] keysYM;
        keysYM = new Keyframe[4];
        keysYM[0] = new Keyframe(9f, 7.9f);
        keysYM[1] = new Keyframe(10f, 9.5f);
        keysYM[2] = new Keyframe(13.5f, 9.5f);
        keysYM[3] = new Keyframe(15f, 3f);
        AnimationCurve curveYM = new AnimationCurve(keysYM);
        Keyframe[] keysScaleXM;
        keysScaleXM = new Keyframe[2];
        keysScaleXM[0] = new Keyframe(19f, 1.5f);
        keysScaleXM[1] = new Keyframe(20f, 0f);
        AnimationCurve curveScaleXM = new AnimationCurve(keysScaleXM);
        Keyframe[] keysScaleYM;
        keysScaleYM = new Keyframe[2];
        keysScaleYM[0] = new Keyframe(19f, 1.5f);
        keysScaleYM[1] = new Keyframe(20f, 0f);
        AnimationCurve curveScaleYM = new AnimationCurve(keysScaleYM);
        AnimationClip animationClipM = new AnimationClip();
        // set animation clip to be legacy
        animationClipM.legacy = true;
        animationClipM.SetCurve("", typeof(Transform), "localPosition.x", curveXM);
        animationClipM.SetCurve("", typeof(Transform), "localPosition.y", curveYM);
        animationClipM.SetCurve("", typeof(Transform), "localScale.x", curveScaleXM);
        animationClipM.SetCurve("", typeof(Transform), "localScale.y", curveScaleYM);
        anim2.AddClip(animationClipM, "test");
        anim2.Play("test");

        //ANIMATIONPLANT
        Animation anim3 = ThePlant.GetComponent<Animation>();
        Keyframe[] keysYP;
        keysYP = new Keyframe[4];
        keysYP[0] = new Keyframe(31f, 2.95f);
        keysYP[1] = new Keyframe(32f, 7.3f);
        keysYP[2] = new Keyframe(40f, 7.3f);
        keysYP[3] = new Keyframe(43f, 2.95f);
        AnimationCurve curveYP = new AnimationCurve(keysYP);
        AnimationCurve curveXP = AnimationCurve.Constant(0.0f, 200f, 6.22f);
        AnimationClip animationClipP = new AnimationClip();
        animationClipP.legacy = true;
        animationClipP.SetCurve("", typeof(Transform), "localPosition.y", curveYP);
        animationClipP.SetCurve("", typeof(Transform), "localPosition.x", curveXP);
        anim3.AddClip(animationClipP, "test");
        anim3.Play("test");

        //ANIMATIONCOIN
        Animation anim4 = TheCoin.GetComponent<Animation>();
        Keyframe[] keysSCX;
        keysSCX = new Keyframe[2];
        keysSCX[0] = new Keyframe(58f, 0.7f);
        keysSCX[1] = new Keyframe(59f, 0f);

        AnimationCurve curveSCX = new AnimationCurve(keysSCX);
        Keyframe[] keysSCY;
        keysSCY = new Keyframe[2];
        keysSCY[0] = new Keyframe(58f, 0.1f);
        keysSCY[1] = new Keyframe(59f, 0f);

        AnimationCurve curveSCY = new AnimationCurve(keysSCY);
        AnimationClip animationClipC = new AnimationClip();
        animationClipC.legacy = true;
        animationClipC.SetCurve("", typeof(Transform), "localScale.x", curveSCX);
        animationClipC.SetCurve("", typeof(Transform), "localScale.y", curveSCY);
        anim4.AddClip(animationClipC, "test");
        anim4.Play("test");

        //CAMERA CHANGES
        StartCoroutine(cameraChange1(5));
        StartCoroutine(cameraChange2(14));
        StartCoroutine(cameraChange3(22));
        StartCoroutine(cameraChange4(45));
        StartCoroutine(cameraChange5(53));
        StartCoroutine(cameraChange7(56));
        StartCoroutine(cameraChange6(59));
        StartCoroutine(Sounds());
    }
    IEnumerator Sounds()
    {
        yield return new WaitForSeconds(8f);
        audioSource.Play(0);

        yield return new WaitForSeconds(11f);
        audioSource.clip = GrowShrink;
        audioSource.Play(0);

        yield return new WaitForSeconds(7f);
        audioSource.clip = Jump;
        audioSource.Play(0);

        yield return new WaitForSeconds(4.5f);
        audioSource.clip = Damage;
        audioSource.Play(0);

        yield return new WaitForSeconds(3.5f);
        audioSource.clip = GrowShrink;
        audioSource.Play(0);

        yield return new WaitForSeconds(4f);
        audioSource.clip = Laugh;
        audioSource.Play(0);

        yield return new WaitForSeconds(12f);
        audioSource.clip = Jump;
        audioSource.Play(0);

        yield return new WaitForSeconds(7f);
        audioSource.clip = Jump;
        audioSource.Play(0);

        yield return new WaitForSeconds(1f);
        audioSource.clip = Coin;
        audioSource.Play(0);

        yield return new WaitForSeconds(3f);
        audioSource.clip = Fall;
        audioSource.Play(0);
    }
    IEnumerator cameraChange1(int secs)
    {
        yield return new WaitForSeconds(secs);
        mainCam.orthographic = false;
        SetObliqueness(0f, 0.2f);
        mainCam.transform.position = new Vector3(-4.07f,2.96f,-3.67f);
        mainCam.transform.rotation *= Quaternion.Euler(-35.105f, 0 ,0);
    }

    IEnumerator cameraChange2(int secs)
    {
        yield return new WaitForSeconds(secs);
        mainCam.transform.rotation = mainCamOriginalRotaion;
        SetObliqueness(0f, 0f);
        mainCam.transform.position = new Vector3(-7.49f, 5.71f, -8.05f);
        mainCam.transform.rotation *= Quaternion.Euler(0f, 29.94f, 0);
    }
    IEnumerator cameraChange3(int secs)
    {
        yield return new WaitForSeconds(secs);
        mainCam.transform.rotation = mainCamOriginalRotaion;
        mainCam.transform.position = new Vector3(8.7f, 4.58f, -11.93f);
        mainCam.transform.rotation *= Quaternion.Euler(-10.6f, 0f, 0);
    }
    IEnumerator cameraChange4(int secs)
    {
        yield return new WaitForSeconds(secs);
        mainCam.transform.rotation = mainCamOriginalRotaion;
        mainCam.transform.position = new Vector3(14.7f, 5.28f, -8.78f);
        mainCam.transform.rotation *= Quaternion.Euler(0f, 35.53f, 0);
    }
    IEnumerator cameraChange5(int secs)
    {
        yield return new WaitForSeconds(secs);
        mainCam.transform.rotation = mainCamOriginalRotaion;
        mainCam.transform.position = new Vector3(18.11f, 11.25f, -1.3f);
        mainCam.transform.rotation *= Quaternion.Euler(38.2f, 44.82f, 3.76f);
    }
    IEnumerator cameraChange6(int secs)
    {
        yield return new WaitForSeconds(secs);
        mainCam.orthographic = false; 
        mainCam.transform.rotation = mainCamOriginalRotaion;
        mainCam.transform.position = new Vector3(19.49f, -3.2f, -0.05f);
        mainCam.transform.rotation *= Quaternion.Euler(-90f, 0f, 0f);
    }

    IEnumerator cameraChange7(int secs)
    {
        yield return new WaitForSeconds(secs);
        mainCam.transform.rotation = mainCamOriginalRotaion;
        mainCam.transform.position = new Vector3(12.52f, 4.71f, -27.13f);
        mainCam.orthographic = true;
        mainCam.orthographicSize = 15;

    }

    void SetObliqueness(float horizObl, float vertObl)
    {
        Matrix4x4 mat = Camera.main.projectionMatrix;
        mat[0, 2] = horizObl;
        mat[1, 2] = vertObl;
        Camera.main.projectionMatrix = mat;
    }

    public void CreateMushroom(float i, float j, float k)
    {
        GameObject head = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        GameObject mushroom = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        GameObject spot1 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        GameObject spot2 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        GameObject spot3 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        GameObject eye1 = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        GameObject eye2 = GameObject.CreatePrimitive(PrimitiveType.Capsule);

        head.transform.parent = mushroom.transform;
        spot1.transform.parent = mushroom.transform;
        spot2.transform.parent = mushroom.transform;
        spot3.transform.parent = mushroom.transform;
        eye1.transform.parent = mushroom.transform;
        eye2.transform.parent = mushroom.transform;

        head.transform.localPosition = new Vector3(0f, -0.401f, 0f);
        head.transform.localScale = new Vector3(0.65f, 0.3f, 0.6f);
        head.GetComponent<Renderer>().material.color = new Color(0.32f, 0.31f, 0.3f, 0.3f);

        spot1.transform.localPosition = new Vector3(0.011f, 0.211f, -0.193f);
        spot1.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        spot1.GetComponent<Renderer>().material.color = Color.white;

        spot2.transform.localPosition = new Vector3(0.178f, 0.013f, -0.218f);
        spot2.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        spot2.GetComponent<Renderer>().material.color = Color.white;

        spot3.transform.localPosition = new Vector3(-0.177f, 0f, -0.226f);
        spot3.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        spot3.GetComponent<Renderer>().material.color = Color.white;

        eye1.transform.localPosition = new Vector3(-0.106f, -0.485f, -0.279f);
        eye1.transform.localScale = new Vector3(0.06f, 0.06f, 0.06f);
        eye1.GetComponent<Renderer>().material.color = Color.black;

        eye2.transform.localPosition = new Vector3(0.102f, -0.485f, -0.279f);
        eye2.transform.localScale = new Vector3(0.06f, 0.06f, 0.06f);
        eye2.GetComponent<Renderer>().material.color = Color.black;

        mushroom.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        mushroom.transform.position = new Vector3(i, j, k);
        mushroom.GetComponent<Renderer>().material.color = new Color(0.92f, 0.1f, 0.14f, 0.85f);

    }

    public void CreateCoin(float i, float j, float k)
    {
        GameObject detail = GameObject.CreatePrimitive(PrimitiveType.Cube);
        GameObject coin = GameObject.CreatePrimitive(PrimitiveType.Cylinder);

        detail.transform.parent = coin.transform;

        detail.transform.localPosition = new Vector3(0f, -1.74f, 0f);
        detail.transform.localScale = new Vector3(0.17f, 1f, 0.47f);
        detail.GetComponent<Renderer>().material.color = Color.yellow;

        coin.transform.localScale = new Vector3(0.7f, 0.1f, 1f);
        coin.transform.rotation *= Quaternion.Euler(90f, 0, 0);
        coin.transform.position = new Vector3(i, j, k);
        coin.GetComponent<Renderer>().material.color = Color.yellow;
    }

    public GameObject CreateGoomba(float i, float j, float k)
    {
        GameObject head = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        GameObject body = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        GameObject leg1 = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        GameObject leg2 = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        GameObject eyebrow1 = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        GameObject eyebrow2 = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        GameObject eye1 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        GameObject eye2 = GameObject.CreatePrimitive(PrimitiveType.Sphere);

        body.transform.parent = head.transform;
        leg1.transform.parent = head.transform;
        leg2.transform.parent = head.transform;
        eyebrow1.transform.parent = head.transform;
        eyebrow2.transform.parent = head.transform;
        eye1.transform.parent = head.transform;
        eye2.transform.parent = head.transform;

        //body
        body.transform.localPosition = new Vector3(0f, -1.097f, 0f);
        body.transform.localScale = new Vector3(1f, 1.68f, 1f);
        body.GetComponent<Renderer>().material.color = new Color(0.32f, 0.31f, 0.3f, 0.3f);

        //leg1
        leg1.transform.localPosition = new Vector3(-0.462f, -1.336f, 0f);
        leg1.transform.localScale = new Vector3(0.61f, 0.61f, 0.61f);
        leg1.GetComponent<Renderer>().material.color = Color.black;

        //leg2
        leg2.transform.localPosition = new Vector3(0.54f, -1.336f, 0f);
        leg2.transform.localScale = new Vector3(0.61f, 0.61f, 0.61f);
        leg2.GetComponent<Renderer>().material.color = Color.black;

        //eyebrow1
        eyebrow1.transform.localPosition = new Vector3(-0.322f, 0.58f, -0.472f);
        eyebrow1.transform.localScale = new Vector3(0.1f, 0.3f, 0.1f);
        eyebrow1.transform.rotation *= Quaternion.Euler(0, 0, 31.61f);
        eyebrow1.GetComponent<Renderer>().material.color = Color.black;

        //eyebrow2
        eyebrow2.transform.localPosition = new Vector3(0.365f, 0.597f, -0.472f);
        eyebrow2.transform.localScale = new Vector3(0.1f, 0.3f, 0.1f);
        eyebrow2.transform.rotation *= Quaternion.Euler(0, 0, -31.61f);
        eyebrow2.GetComponent<Renderer>().material.color = Color.black;

        //eye1
        eye1.transform.localPosition = new Vector3(-0.198f, 0.08f, -0.487f);
        eye1.transform.localScale = new Vector3(0.1f, 0.2f, 0.1f);
        eye1.GetComponent<Renderer>().material.color = Color.black;

        //eye2
        eye2.transform.localPosition = new Vector3(0.218f, 0.08f, -0.487f);
        eye2.transform.localScale = new Vector3(0.1f, 0.2f, 0.1f);
        eye2.GetComponent<Renderer>().material.color = Color.black;

        //head
        head.transform.position = new Vector3(i, j, k);
        head.transform.localScale = new Vector3(1.52f, 0.84f, 1.45f);
        head.GetComponent<Renderer>().material.color = new Color(0.29f, 0.12f, 0.06f, 1f);

        return head;
    }

    public void CreatePipe(float i, float j, float k)
    {
        GameObject top = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        GameObject body = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        GameObject hole = GameObject.CreatePrimitive(PrimitiveType.Cylinder);

        top.transform.parent = body.transform;
        hole.transform.parent = body.transform;

        top.transform.localPosition = new Vector3(0f, 1.41f, 0f);
        top.transform.localScale = new Vector3(1.2f, 0.4f, 1.2f);
        top.GetComponent<Renderer>().material.color = new Color(0.26f, 0.69f, 0.27f, 0.3f);

        hole.transform.localPosition = new Vector3(0f, 1.014f, 0f);
        hole.transform.localScale = new Vector3(0.799f, 0.799f, 0.799f);
        hole.GetComponent<Renderer>().material.color = Color.black;

        body.transform.localScale = new Vector3(3f, 1.5f, 3f);
        body.transform.position = new Vector3(i, j, k);
        body.GetComponent<Renderer>().material.color = new Color(0.26f, 0.69f, 0.27f, 0.3f);
    }

    public void CreatePlant(float i, float j, float k)
    {
        GameObject head = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        GameObject stem = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        GameObject lip1 = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        GameObject lip2 = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        GameObject leaf = GameObject.CreatePrimitive(PrimitiveType.Capsule);

        head.transform.parent = stem.transform;
        lip1.transform.parent = stem.transform;
        lip2.transform.parent = stem.transform;
        leaf.transform.parent = stem.transform;

        head.transform.localPosition = new Vector3(0f, 1.77f, 0f);
        head.transform.localScale = new Vector3(2.93f, 1.7f, 2.93f);
        head.GetComponent<Renderer>().material.color = new Color(0.92f, 0.1f, 0.14f, 0.85f);

        lip1.transform.localPosition = new Vector3(-0.82f, 2.949f, 0f);
        lip1.transform.localScale = new Vector3(0.51f, 1f, 1f);
        lip1.transform.rotation *= Quaternion.Euler(0, 0, 58.61f);
        lip1.GetComponent<Renderer>().material.color = Color.white;

        lip2.transform.localPosition = new Vector3(0.77f, 2.907f, 0f);
        lip2.transform.localScale = new Vector3(0.531f, 1.05f, 0.99f);
        lip2.transform.rotation *= Quaternion.Euler(0, 0, -58.61f);
        lip2.GetComponent<Renderer>().material.color = Color.white;

        leaf.transform.localPosition = new Vector3(-1.11f, 0, 0f);
        leaf.transform.localScale = new Vector3(0.56f, 1.21f, 0.1f);
        leaf.transform.rotation *= Quaternion.Euler(0, 0, 90f);
        leaf.GetComponent<Renderer>().material.color = Color.green;

        stem.transform.localScale = new Vector3(0.6f, 1f, 0.6f);
        stem.transform.position = new Vector3(i, j, k);
        stem.GetComponent<Renderer>().material.color = Color.green;
    }



    // Update is called once per frame
    void Update () {
	}
}
