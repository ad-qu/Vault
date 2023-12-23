import 'package:ea_frontend/navbar/nav_bar.dart';
import 'package:ea_frontend/screens/contact_screen.dart';
import 'package:ea_frontend/screens/our_app_screen.dart';
import 'package:ea_frontend/screens/home_screen.dart';
import 'package:ea_frontend/screens/about_us_screen.dart';
import 'package:flutter/material.dart';
import 'package:hooks_riverpod/hooks_riverpod.dart';
// ignore: depend_on_referenced_packages
import 'package:flutter_hooks/flutter_hooks.dart';

final homeKey = GlobalKey();
final ourAppKey = GlobalKey();
final aboutUsKey = GlobalKey();
final contactKey = GlobalKey();

final currentPageProvider = StateProvider<GlobalKey>((_) => homeKey);
final scrolledProvider = StateProvider<bool>((_) => false);

class MyWebPage extends HookConsumerWidget {
  const MyWebPage({super.key});

  void onScroll(ScrollController controller, WidgetRef ref) {
    final isScrolled = ref.read(scrolledProvider);

    if (controller.position.pixels > 5 && !isScrolled) {
      ref.read(scrolledProvider.notifier).state = true;
    } else if (controller.position.pixels <= 5 && isScrolled) {
      ref.read(scrolledProvider.notifier).state = false;
    }
  }

  void scrollTo(GlobalKey key) => Scrollable.ensureVisible(key.currentContext!,
      duration: const Duration(milliseconds: 500));

  @override
  Widget build(BuildContext context, WidgetRef ref) {
    final controller = useScrollController();

    useEffect(() {
      controller.addListener(() => onScroll(controller, ref));
      return controller.dispose;
    }, [controller]);

    ref
        .watch(currentPageProvider.notifier)
        .addListener(scrollTo, fireImmediately: false);

    return Scaffold(
      body: Center(
        child: Stack(
          children: [
            FractionallySizedBox(
              widthFactor: 1.01,
              heightFactor: 1.1,
              child: Container(
                decoration: const BoxDecoration(
                  image: DecorationImage(
                    image: ExactAssetImage('images/wallpaper_web.png'),
                    fit: BoxFit.cover,
                  ),
                ),
              ),
            ),
            Column(
              children: [
                const NavBar(),
                Expanded(
                  child: SingleChildScrollView(
                    controller: controller,
                    child: Column(
                      children: <Widget>[
                        HomeContent(key: homeKey),
                        AboutUsContent(key: ourAppKey),
                        OurAppContent(key: aboutUsKey),
                        ContactContent(key: contactKey),
                      ],
                    ),
                  ),
                ),
              ],
            ),
            Align(
              alignment: Alignment.bottomRight,
              child: Container(
                margin: const EdgeInsets.fromLTRB(8, 8, 16, 8),
                child: const Text(
                  "© 2023 EETAC Go. All rights reserved.",
                  style: TextStyle(
                    fontSize: 11.0,
                    color: Color.fromARGB(255, 49, 49, 49),
                  ),
                ),
              ),
            ),
          ],
        ),
      ),
    );
  }
}
