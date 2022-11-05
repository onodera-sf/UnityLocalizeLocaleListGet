using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

public class DropDownEvent : MonoBehaviour
{
	// 最初のフレームアップデートの前に開始が呼び出されます
	async void Start()
  {
		// Localization の初期化が完了するまで待機します
		await LocalizationSettings.InitializationOperation.Task;

		// 処理対象の Dropdown コンポーネントを取得します
		var dropdownLocale = GetComponent<Dropdown>();
		dropdownLocale.options.Clear();

		// LocalizationSettings.AvailableLocales.Locales からロケール一覧を取得してオプションを追加します
		foreach (var locale in LocalizationSettings.AvailableLocales.Locales)
		{
			dropdownLocale.options.Add(new Dropdown.OptionData(locale.name));
		}

		// 初期選択されているロケールのインデックスを取得して選択します
		dropdownLocale.value = LocalizationSettings.AvailableLocales.Locales.IndexOf(LocalizationSettings.SelectedLocale);

		// ドロップダウンのアイテムが選択されたときにロケールを変更します
		dropdownLocale.onValueChanged.AddListener((index) =>
		{
			LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[index];
		});
	}
}
