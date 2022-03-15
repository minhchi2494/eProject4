
// const SERVER_NAME = "10.0.2.2";
// const SERVER_NAME = "localhost";
// const SERVER_NAME = "127.0.0.1";
// const SERVER_NAME = "192.168.0.18";
// const URL_TODOS = "http://$SERVER_NAME:54350/api/";
class Network {
  static const String apiEndpoint = 'http://172.16.0.233:54350/api/';

  static final Uri url_products = Uri.parse(apiEndpoint+'Product');
  static final Uri url_store = Uri.parse(apiEndpoint+'Store');
  static final Uri url_user = Uri.parse(apiEndpoint+'User');
  static final Uri url_target = Uri.parse(apiEndpoint + 'Target');
  static final Uri url_targetUser = Uri.parse(apiEndpoint + 'TargetUser');
  static final Uri url_storeSalesDetail = Uri.parse(apiEndpoint + 'StoreSalesDetail');
}