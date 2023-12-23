import 'package:ea_frontend/widgets/responsive_widget.dart';
import 'package:flutter/material.dart';
import 'package:webview_flutter/webview_flutter.dart';
import 'package:url_launcher/url_launcher.dart';

const address =
    'https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d47956.16731379691!2d1.9750037124235158!3d41.30319719348106!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x12a482b2ea99ef25%3A0x53aec7154de459b3!2sUPC%20Escuela%20de%20Ingenier%C3%ADa%20de%20Telecomunicaci%C3%B3n%20y%20Aeroespacial%20de%20Castelldefels!5e0!3m2!1ses!2ses!4v1687912777877!5m2!1ses!2ses';

final _webController = WebViewController()..loadRequest(Uri.parse(address));

class ContactContent extends ResponsiveWidget {
  const ContactContent({Key? key}) : super(key: key);

  @override
  Widget buildDesktop(BuildContext context) => const DesktopContactContent();

  @override
  Widget buildMobile(BuildContext context) => const MobileContactContent();
}

class DesktopContactContent extends StatelessWidget {
  const DesktopContactContent({super.key});

  @override
  Widget build(BuildContext context) {
    double height = MediaQuery.of(context).size.height;
    double width = MediaQuery.of(context).size.width;
    return SizedBox(
      height: height * 0.87,
      child: Column(
        children: [
          SizedBox(height: height * 0.08),
          Image.asset(
            'images/contact.png',
            height: 63,
            width: width - 50,
          ),
          SizedBox(height: height * 0.15),
          Row(
            mainAxisAlignment: MainAxisAlignment.center,
            children: [
              Column(
                children: [
                  Container(
                    width: width * 0.3,
                    decoration: BoxDecoration(
                        color: const Color.fromRGBO(255, 255, 255, 0.4),
                        borderRadius: BorderRadius.circular(15)),
                    child: const Padding(
                      padding: EdgeInsets.all(15.0),
                      child: Text(
                        "Connect with us on our social media platforms! Find us on YouTube for exclusive content, on Twitter for the latest updates, and on Discord to join our community.\n\nAdditionally, if you're interested in exploring the project's code, feel free to check out our GitHub repository.",
                        style: TextStyle(fontWeight: FontWeight.w500),
                        textAlign: TextAlign.justify,
                      ),
                    ),
                  ),
                  SizedBox(height: height * 0.025),
                  SizedBox(
                    width: width * 0.3,
                    child: Column(
                      mainAxisAlignment: MainAxisAlignment.center,
                      crossAxisAlignment: CrossAxisAlignment.center,
                      children: [
                        //SizedBox(height: height * 0.025),
                        Container(
                          decoration: BoxDecoration(
                              color: Color.fromRGBO(255, 255, 255, 0.4),
                              borderRadius: BorderRadius.circular(15)),
                          child: Padding(
                            padding:
                                const EdgeInsets.only(top: 20.0, bottom: 20.0),
                            child: Row(
                              mainAxisAlignment: MainAxisAlignment.spaceEvenly,
                              crossAxisAlignment: CrossAxisAlignment.center,
                              children: [
                                GestureDetector(
                                  onTap: () {
                                    // ignore: deprecated_member_use
                                    launch(
                                        'https://www.youtube.com/'); // Reemplaza con tu enlace deseado
                                  },
                                  child: Image.asset(
                                    'images/youtube.png',
                                    height: 45,
                                  ),
                                ),
                                GestureDetector(
                                  onTap: () {
                                    // ignore: deprecated_member_use
                                    launch(
                                        'https://twitter.com/Grup4Ea'); // Reemplaza con tu enlace deseado
                                  },
                                  child: Image.asset(
                                    'images/twitter.png',
                                    height: 45,
                                  ),
                                ),
                                GestureDetector(
                                  onTap: () {
                                    // ignore: deprecated_member_use
                                    launch(
                                        'https://discord.gg/W9hMyzbm'); // Reemplaza con tu enlace deseado
                                  },
                                  child: Image.asset(
                                    'images/discord.png',
                                    height: 45,
                                  ),
                                ),
                                GestureDetector(
                                  onTap: () {
                                    // ignore: deprecated_member_use
                                    launch(
                                        'https://github.com/mariaubiergo2/EA-FRONTEND'); // Reemplaza con tu enlace deseado
                                  },
                                  child: Image.asset(
                                    'images/github.png',
                                    height: 45,
                                  ),
                                ),
                              ],
                            ),
                          ),
                        ),
                      ],
                    ),
                  ),
                ],
              ),
              SizedBox(width: width * 0.07),
              SizedBox(
                height: 400,
                width: 400,
                child: WebViewWidget(
                  controller: _webController,
                ),
              ),
            ],
          ),
        ],
      ),
    );
  }
}

class MobileContactContent extends StatelessWidget {
  const MobileContactContent({super.key});

  @override
  Widget build(BuildContext context) {
    double height = MediaQuery.of(context).size.height;
    double width = MediaQuery.of(context).size.width;
    return SizedBox(
      height: height * 1.08,
      child: Column(
        children: [
          SizedBox(height: height * 0.08),
          Image.asset(
            'images/contact.png',
            height: 63,
            width: width - 50,
          ),
          SizedBox(height: height * 0.07),
          Column(
            mainAxisAlignment: MainAxisAlignment.center,
            children: [
              Column(
                children: [
                  Container(
                    width: width * 0.7,
                    decoration: BoxDecoration(
                        color: const Color.fromRGBO(255, 255, 255, 0.4),
                        borderRadius: BorderRadius.circular(15)),
                    child: const Padding(
                      padding: EdgeInsets.all(15.0),
                      child: Text(
                        "Connect with us on our social media platforms! Find us on YouTube for exclusive content, on Twitter for the latest updates, and on Discord to join our community.\n\nAdditionally, if you're interested in exploring the project's code, feel free to check out our GitHub repository.",
                        style: TextStyle(fontWeight: FontWeight.w500),
                        textAlign: TextAlign.justify,
                      ),
                    ),
                  ),
                  SizedBox(height: height * 0.025),
                  SizedBox(
                    width: width * 0.7,
                    child: Column(
                      mainAxisAlignment: MainAxisAlignment.center,
                      crossAxisAlignment: CrossAxisAlignment.center,
                      children: [
                        //SizedBox(height: height * 0.025),
                        Container(
                          decoration: BoxDecoration(
                              color: Color.fromRGBO(255, 255, 255, 0.4),
                              borderRadius: BorderRadius.circular(15)),
                          child: Padding(
                            padding:
                                const EdgeInsets.only(top: 20.0, bottom: 20.0),
                            child: Row(
                              mainAxisAlignment: MainAxisAlignment.spaceEvenly,
                              crossAxisAlignment: CrossAxisAlignment.center,
                              children: [
                                GestureDetector(
                                  onTap: () {
                                    // ignore: deprecated_member_use
                                    launch(
                                        'https://www.youtube.com/'); // Reemplaza con tu enlace deseado
                                  },
                                  child: Image.asset(
                                    'images/youtube.png',
                                    height: 45,
                                  ),
                                ),
                                GestureDetector(
                                  onTap: () {
                                    // ignore: deprecated_member_use
                                    launch(
                                        'https://twitter.com/Grup4Ea'); // Reemplaza con tu enlace deseado
                                  },
                                  child: Image.asset(
                                    'images/twitter.png',
                                    height: 45,
                                  ),
                                ),
                                GestureDetector(
                                  onTap: () {
                                    // ignore: deprecated_member_use
                                    launch(
                                        'https://discord.gg/W9hMyzbm'); // Reemplaza con tu enlace deseado
                                  },
                                  child: Image.asset(
                                    'images/discord.png',
                                    height: 45,
                                  ),
                                ),
                                GestureDetector(
                                  onTap: () {
                                    // ignore: deprecated_member_use
                                    launch(
                                        'https://github.com/mariaubiergo2/EA-FRONTEND'); // Reemplaza con tu enlace deseado
                                  },
                                  child: Image.asset(
                                    'images/github.png',
                                    height: 45,
                                  ),
                                ),
                              ],
                            ),
                          ),
                        ),
                      ],
                    ),
                  ),
                ],
              ),
              SizedBox(
                height: 90,
              ),
              SizedBox(
                height: 400,
                width: 400,
                child: WebViewWidget(
                  controller: _webController,
                ),
              ),
            ],
          ),
        ],
      ),
    );
  }
}
