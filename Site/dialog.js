let form = document.querySelector('#dialog__form');
let input = document.querySelector('#dialog__input');
let button = document.querySelector('#dialog__button');
let messanger = document.querySelector('#dialog__messanger');

form.addEventListener('submit', handleForm);

function handleForm() {
	if (input.value != '') {
		messanger.innerHTML += `<div class="dialog__message question">${input.value}</div>`;
		let [answer, photo] = getAnswer(input.value);
		messanger.innerHTML += `<div class="dialog__message answer">${answer}</div>`;
		photo.forEach(element => {
			messanger.innerHTML += element;
		});
		messanger.scrollTop = 99999;

		speechSynthesis.speak(new SpeechSynthesisUtterance(answer));
	}
	input.value = '';
}

input.addEventListener('click', inputClick, false);

function inputClick() {
	speechSynthesis.pause();
}

button.addEventListener('mouseover', buttonOver, false);
button.addEventListener('mouseout', buttonOut, false);
button.addEventListener('click', buttonClick, false);

function buttonOver() {
	button.classList.add('dialog__button-hover');
}

function buttonOut() {
	button.classList.remove('dialog__button-hover');
}

function buttonClick() {
	button.classList.add('dialog__button-listen');

	speechSynthesis.pause();

	let recognizer = new webkitSpeechRecognition();
	recognizer.interimResults = true;
	recognizer.lang = 'ru-Ru';
	recognizer.on;
	recognizer.onresult = function (event) {
		let result = event.results[event.resultIndex];
		if (result.isFinal) {
			input.value = result[0].transcript;
			button.classList.remove('dialog__button-listen');
			handleForm();
		} else {
			input.value = result[0].transcript;
		}
	};
	recognizer.onaudioend = function (event) {
		button.classList.remove('dialog__button-listen');
	};
	recognizer.start();
}

knowledge = [
	[
		'стокс',
		' Джордж Габриель  ',
		' - это английский математик, механик и физик-теоретик ирландского происхождения. Работал в Кембриджском университете, внёс значительный вклад в гидро- и газодинамику, оптику и математическую физику',
	],
	[
		'стокс',
		' Джордж Габриель  ',
		' - это английский математик, механик и физик-теоретик ирландского происхождения. Работал в Кембриджском университете, внёс значительный вклад в гидро- и газодинамику, оптику и математическую физику',
	],
];

// псевдоокончания сказуемых (глаголов, кратких причастий и прилагательных )
let endings = [
	['ет', '(ет|ут|ют)'],
	['ут', '(ет|ут|ют)'],
	['ют', '(ет|ут|ют)'], // 1 спряжение
	['ит', '(ит|ат|ят)'],
	['ат', '(ит|ат|ят)'],
	['ят', '(ит|ат|ят)'], // 2 спряжение
	['ется', '(ет|ут|ют)ся'],
	['утся', '(ет|ут|ют)ся'],
	['ются', '(ет|ут|ют)ся'], // 1 спряжение, возвратные
	['ится', '(ит|ат|ят)ся'],
	['атся', '(ит|ат|ят)ся'],
	['ятся', '(ит|ат|ят)ся'], // 2 спряжение, возвратные
	['ен', 'ен'],
	['ена', 'ена'],
	['ено', 'ено'],
	['ены', 'ены'], // краткие прилагательные
	['ан', 'ан'],
	['ана', 'ана'],
	['ано', 'ано'],
	['аны', 'аны'], // краткие прилагательные
	['жен', 'жен'],
	['жна', 'жна'],
	['жно', 'жно'],
	['жны', 'жны'], // краткие прилагательные
	["такой", "- это"],
	["такое", "- это"], //для вопроса "что такое А?" ответ - "А - это ..."
	["выглядит", "выглядит"],
	["предназначена", "предназначена"],
	["является", "является"],
	["показывает", "показывает"],
	["называют", "называют"],
	["есть", "есть"],
	["равна", "равна"],
	["гласит", "гласит"],
	["измеряет", "измеряет"]
];

// черный список слов, распознаваемых как сказуемые по ошибке
let blacklist = [
	'замена',
	'замены',
	'атрибут',
	'маршрут',
	'член',
	'нет',
	'выглядит',
];

function getEnding(word) {
	// проверка по черному списку
	if (blacklist.indexOf(word) !== -1) return -1;
	// перебор псевдоокончаний
	for (let j = 0; j < endings.length; j++) {
		// проверка, оканчивается ли i-ое слово на j-ое псевдоокончание
		if (word.substring(word.length - endings[j][0].length) == endings[j][0]) {
			return j; // возврат номера псевдоокончания
		}
	}
	return -1;
}

// функция, которая делает первую букву большой
function big1(str) {
	return str[0].toUpperCase() + str.slice(1);
}

// главная функция, обрабатывающая запросы клиентов
function getAnswer(question) {
	txt = question.toLowerCase().replace(/[*_#?\'",.!()[\]\\/]/g, '');

	// массив слов и знаков препинания
	let words = txt.split(' ');
	// флаг, найден ли ответ
	let result = false;
	// формируемый функцией ответ на вопрос
	let answer = [];
	answer[0] = '';
	answer[1] = new Array([]);

	if (txt == 'бот кок'){
		answer[0] = 'Ты чатиком ошибся.))0)'
		return answer;
	}
	// перебор слов
	for (let i = 0; i < words.length; i++) {
		// поиск номера псевдоокончания
		let ending = getEnding(words[i]);

		// если псевдоокончание найдено – это сказуемое, подлежащее в вопросе после него
		if (ending >= 0) {
			// ТОЧНЫЙ ПОИСК
			let subject_array = words.slice(i + 1);
			let subject_text = subject_array.join(' ');
			for (let j = 0; j < knowledge.length; j++)
				if (
					((words[i] == knowledge[j][1] || // точное совпадение сказуемого
						words[i].substring(0, words[i].length - endings[ending][0].length) +
							endings[ending][1] ==
							knowledge[j][1]) && // совпадение сказуемого с подстановкой (такое ->- это)
						subject_text == knowledge[j][0]) ||
					subject_text == knowledge[j][2]
				) {
					// совпадение подлежащего
					// создание простого предложения из семантической связи
					answer[0] += big1(
						knowledge[j][0] +
							' ' +
							knowledge[j][1] +
							' ' +
							knowledge[j][2] +
							'.<br/>'
					);
					if (knowledge[j][3]) answer[1].push(knowledge[j][3]);
					result = true;
				}
			if (result == false) {
				// ПОИСК С ПОМОЩЬЮ РЕГУЛЯРНЫХ ВЫРАЖЕНИЙ
				// замена псевдоокончания на набор возможных окончаний
				words[i] =
					words[i].substring(0, words[i].length - endings[ending][0].length) +
					endings[ending][1];
				// создание регулярного выражения для поиска по сказуемому из вопроса
				let predicate = new RegExp(words[i]);
				// для кратких прилагательных захватываем следующее слово
				if (endings[ending][0] == endings[ending][1]) {
					predicate = new RegExp(words[i] + ' ' + words[i + 1]);
					i++;
				}
				let subject_array = words.slice(i + 1);
				// создание регулярного выражения для поиска по подлежащему из вопроса
				// из слов подлежащего выбрасываем короткие предлоги (периметр у квадрата = периметр квадрата)
				for (let j = 0; j < subject_array.length; j++) {
					if (subject_array[j].length < 3) {
						subject_array.splice(j);
						j--;
					}
				}
				let subject_string = subject_array.join('.*');
				// только если в послежащем больше трех символов
				if (subject_string.length > 3) {
					let subject = new RegExp('.*' + subject_string + '.*');
					// поиск совпадений с шаблонами среди связей семантической сети
					for (let j = 0; j < knowledge.length; j++) {
						if (
							predicate.test(knowledge[j][1]) &&
							(subject.test(knowledge[j][0]) || subject.test(knowledge[j][2]))
						) {
							// создание простого предложения из семантической связи
							answer[0] += big1(
								knowledge[j][0] +
									' ' +
									knowledge[j][1] +
									' ' +
									knowledge[j][2] +
									'.<br/>'
							);
							if (knowledge[j][3]) answer[1].push(knowledge[j][3]);
							result = true;
						}
					}
					// если совпадений с двумя шаблонами нет
					if (result == false) {
						// поиск совпадений только с шаблоном подлежащего
						for (let j = 0; j < knowledge.length; j++) {
							if (
								subject.test(knowledge[j][0]) ||
								subject.test(knowledge[j][2])
							) {
								// создание простого предложения из семантической связи
								answer[0] += big1(
									knowledge[j][0] +
										' ' +
										knowledge[j][1] +
										' ' +
										knowledge[j][2] +
										'.<br/>'
								);
								if (knowledge[j][3]) answer[1].push(knowledge[j][3]);
								result = true;
							}
						}
					}
				}
			}
		}
	}
	if (!result) answer[0] = 'Ответ не найден';
	return answer;
}
