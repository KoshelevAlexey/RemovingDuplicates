using RemovingDuplicates.JsonService;
using RemovingDuplicates.Logger;
using System;
using System.Collections.Generic;

namespace RemovingDuplicates.RemoveService
{
    public class RemDuplService
    {
        private ILogger _logger;

        private List<JsonObj> _resultList;

        public RemDuplService(ILogger logger) 
        {
            _logger = logger;
        }

        public bool RemoveDuplicatesFromFile(string fileName)
        {
            LogInfo log = new LogInfo();
            log.Description = "Открытие файла. ";
            log.FileName = fileName;

            JsonObj[] arr = null;
            try
            {
                arr = JsonServ.CreateEntityFromJsonFile<JsonObj[]>(fileName);
            }
            catch (Exception ex)
            {
                log.Description += ex.Message;
                _logger.Error(log);
                return false;
            }

            if (arr == null)
            {
                log.Description += "Файл пуст";
                _logger.Info(log);
                return false;
            }
            else
            {
                log.Description += "Всего объектов: " + arr.Length.ToString();
                _logger.Info(log);
            }

            _resultList = JsonServ.CreateNonDuplicatesList(arr);

            if(_resultList.Count == arr.Length)
            {
                log.Description = "Дубликаты отсутствуют";
                _logger.Info(log);
                _resultList = null;
                return false;
            }

            log.Description = "Удаление дубликатов: " + (arr.Length - _resultList.Count).ToString();
            _logger.Info(log);
            return true;
        }

        public bool SaveFile(string fileName)
        {
            LogInfo log = new LogInfo();
            log.FileName = fileName;

            if(_resultList == null && _resultList.Count == 0)
            {
                log.Description += "Файл пуст";
                _logger.Error(log);
                _resultList = null;
                return false;
            }
            try
            {
                JsonServ.SaveListToJsonFile(fileName, _resultList);
                log.Description = "Сохранение файла. Объектов: " + _resultList.Count;
                _logger.Info(log);
            }
            catch (Exception ex)
            {
                log.Description = "Ошибка сохранения: " + ex.Message;
                _logger.Error(log);
                _resultList = null;
                return false;
            }
            return true;
        }
    }
}
