import 'package:ea_frontend/widgets/responsive_widget.dart';
import 'package:flutter/material.dart';

class AboutUsContent extends ResponsiveWidget {
  const AboutUsContent({Key? key}) : super(key: key);

  @override
  Widget buildDesktop(BuildContext context) => const DesktopAboutUsContent(200);

  @override
  Widget buildMobile(BuildContext context) => const MobileAboutUsContent();
}

class DesktopAboutUsContent extends StatelessWidget {
  const DesktopAboutUsContent(this.horizontalPadding, {super.key});
  // ignore: prefer_typing_uninitialized_variables
  final horizontalPadding;

  @override
  Widget build(BuildContext context) {
    double height = MediaQuery.of(context).size.height;
    return SizedBox(
      height: height * 0.87,
      child: Padding(
        padding: const EdgeInsets.symmetric(vertical: 48, horizontal: 24),
        child: Column(
          children: [
            SizedBox(height: height * 0.017),
            Image.asset(
              'images/desc.png',
              height: 63,
            ),
            SizedBox(height: height * 0.075),
            const SingleChildScrollView(
              scrollDirection: Axis.horizontal,
              child: Row(
                mainAxisSize: MainAxisSize.max,
                mainAxisAlignment: MainAxisAlignment.spaceBetween,
                children: [
                  LimitedBox(
                    maxHeight: 550,
                    child: _Image(image: "images/screen1.png"),
                  ),
                  LimitedBox(
                    maxHeight: 550,
                    child: _Image(image: "images/screen2.png"),
                  ),
                  LimitedBox(
                    maxHeight: 550,
                    child: _Image(image: "images/screen3.png"),
                  ),
                ],
              ),
            )
          ],
        ),
      ),
    );
  }
}

class _Image extends StatelessWidget {
  final String image;

  const _Image({Key? key, required this.image}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Row(
      children: [
        const SizedBox(width: 16),
        Image.asset(image),
        const SizedBox(width: 16),
      ],
    );
  }
}

class MobileAboutUsContent extends StatelessWidget {
  const MobileAboutUsContent({super.key});

  @override
  Widget build(BuildContext context) {
    double height = MediaQuery.of(context).size.height;
    return SizedBox(
      height: height * 2.2,
      child: Padding(
        padding: const EdgeInsets.symmetric(vertical: 48, horizontal: 24),
        child: Column(
          children: [
            SizedBox(height: height * 0.017),
            Image.asset(
              'images/desc.png',
              height: 63,
            ),
            SizedBox(height: height * 0.075),
            const SingleChildScrollView(
              scrollDirection: Axis.horizontal,
              child: Column(
                mainAxisSize: MainAxisSize.max,
                mainAxisAlignment: MainAxisAlignment.spaceBetween,
                children: [
                  LimitedBox(
                    maxHeight: 550,
                    child: _Image(image: "images/screen1.png"),
                  ),
                  SizedBox(height: 40),
                  LimitedBox(
                    maxHeight: 550,
                    child: _Image(image: "images/screen2.png"),
                  ),
                  SizedBox(height: 40),
                  LimitedBox(
                    maxHeight: 550,
                    child: _Image(image: "images/screen3.png"),
                  ),
                ],
              ),
            )
          ],
        ),
      ),
    );
  }
}
