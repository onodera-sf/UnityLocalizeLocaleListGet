using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

public class DropDownEvent : MonoBehaviour
{
	// �ŏ��̃t���[���A�b�v�f�[�g�̑O�ɊJ�n���Ăяo����܂�
	async void Start()
  {
		// Localization �̏���������������܂őҋ@���܂�
		await LocalizationSettings.InitializationOperation.Task;

		// �����Ώۂ� Dropdown �R���|�[�l���g���擾���܂�
		var dropdownLocale = GetComponent<Dropdown>();
		dropdownLocale.options.Clear();

		// LocalizationSettings.AvailableLocales.Locales ���烍�P�[���ꗗ���擾���ăI�v�V������ǉ����܂�
		foreach (var locale in LocalizationSettings.AvailableLocales.Locales)
		{
			dropdownLocale.options.Add(new Dropdown.OptionData(locale.name));
		}

		// �����I������Ă��郍�P�[���̃C���f�b�N�X���擾���đI�����܂�
		dropdownLocale.value = LocalizationSettings.AvailableLocales.Locales.IndexOf(LocalizationSettings.SelectedLocale);

		// �h���b�v�_�E���̃A�C�e�����I�����ꂽ�Ƃ��Ƀ��P�[����ύX���܂�
		dropdownLocale.onValueChanged.AddListener((index) =>
		{
			LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[index];
		});
	}
}
