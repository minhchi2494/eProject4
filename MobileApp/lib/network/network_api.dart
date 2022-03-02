class Network {
  static const String apiEndpoint = 'http://localhost:54350/api/';
  static final Uri url_products = Uri.parse(apiEndpoint+'product');
  static final Uri url_categories = Uri.parse(apiEndpoint+'category');
}