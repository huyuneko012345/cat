using System;
using UnityEngine;

public class Dialog : MonoBehaviour
{
    public enum DialogResult
    {
        OK,
        Cancel,
    }
    public Action<DialogResult> FixDialog { get; set; }

    public void OnOk()
    {
        Debug.Log("OK");
        // Destroy(this.gameObject);
    }
    public void OnCancel(){
        this.FixDialog?.Invoke(DialogResult.Cancel);
        Destroy(this.gameObject);
        Debug.Log("cancel 完了");

    }

}
