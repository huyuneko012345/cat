using System;
using UnityEngine;
/// <summary>
///　ダイアログを制御する
/// </summary>
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
        // Destroy(this.gameObject);
    }
    public void OnCancel(){
        this.FixDialog?.Invoke(DialogResult.Cancel);
        Destroy(this.gameObject);
        

    }

}
