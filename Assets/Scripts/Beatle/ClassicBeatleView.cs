public class ClassicBeatleView : BaseBeatleView
{
    private ClassicBeatle ClassicBeatle;

    protected override void Awake()
    {
        base.Awake();
        ClassicBeatle = new ClassicBeatle(this);

    }

    public override void OnSpawn()
    {
        base.OnSpawn();
        ClassicBeatle.SetActive(true);
    }

    public override void OnDespawn()
    {
        base.OnDespawn();

    }

    protected override void OnDead()
    {
        ClassicBeatle.SetActive(false);
        base.OnDead();
    }


}