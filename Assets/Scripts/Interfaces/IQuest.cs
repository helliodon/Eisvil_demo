using UnityEngine;

public interface IQuest
{int Progress { get; }
    void UpdateProgress(int value);
}
