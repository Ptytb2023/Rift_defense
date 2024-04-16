public class ClassicViewV2 : BaseBeatleView
{
    private ClassicBeatleV2 ClassicBeatle;

    protected override void Awake()
    {
        base.Awake();
        ClassicBeatle = new ClassicBeatleV2(this);

    }

    public override void OnSpawn()
    {
        base.OnSpawn();
        Enabel = true;
        ClassicBeatle.SetActive(true);
    }

    public override void OnDespawn()
    {
        base.OnDespawn();
        Enabel = false;

        ClassicBeatle.SetActive(false);
    }


}