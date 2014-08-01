﻿/*!
        jQuery Autosize v1.16.7
        (c) 2013 Jack Moore - jacklmoore.com
        updated: 2013-03-20
        license: http://www.opensource.org/licenses/mit-license.php
*/
(function (e) {
    var t, o, n = {
        className: "autosizejs",
        append: "",
        callback: !1
    }, i = "hidden",
        s = "border-box",
        a = "lineHeight",
        l = '<textarea tabindex="-1" style="position:absolute; top:-999px; left:0; right:auto; bottom:auto; border:0; -moz-box-sizing:content-box; -webkit-box-sizing:content-box; box-sizing:content-box; word-wrap:break-word; height:0 !important; min-height:0 !important; overflow:hidden;"/>',
        r = ["fontFamily", "fontSize", "fontWeight", "fontStyle", "letterSpacing", "textTransform", "wordSpacing", "textIndent"],
        c = "oninput",
        h = "onpropertychange",
        p = e(l).data("autosize", !0)[0];
    p.style.lineHeight = "99px", "99px" === e(p).css(a) && r.push(a), p.style.lineHeight = "", e.fn.autosize = function (a) {
        return a = e.extend({}, n, a || {}), p.parentNode !== document.body && (e(document.body).append(p), p.value = "\n\n\n", p.scrollTop = 9e4, t = p.scrollHeight === p.scrollTop + p.clientHeight), this.each(function () {
            function n() {
                o = b, p.className = a.className, e.each(r, function (e, t) {
                    p.style[t] = f.css(t)
                })
            }

            function l() {
                var e, s, l;
                if (o !== b && n(), !d) {
                    d = !0, p.value = b.value + a.append, p.style.overflowY = b.style.overflowY, l = parseInt(b.style.height, 10), p.style.width = Math.max(f.width(), 0) + "px", t ? e = p.scrollHeight : (p.scrollTop = 0, p.scrollTop = 9e4, e = p.scrollTop);
                    var r = parseInt(f.css("maxHeight"), 10);
                    r = r && r > 0 ? r : 9e4, e > r ? (e = r, s = "scroll") : u > e && (e = u), e += x, b.style.overflowY = s || i, l !== e && (b.style.height = e + "px", w && a.callback.call(b)), setTimeout(function () {
                        d = !1
                    }, 1)
                }
            }
            var u, d, g, b = this,
                f = e(b),
                x = 0,
                w = e.isFunction(a.callback);
            f.data("autosize") || ((f.css("box-sizing") === s || f.css("-moz-box-sizing") === s || f.css("-webkit-box-sizing") === s) && (x = f.outerHeight() - f.height()), u = Math.max(parseInt(f.css("minHeight"), 10) - x, f.height()), g = "none" === f.css("resize") || "vertical" === f.css("resize") ? "none" : "horizontal", f.css({
                overflow: i,
                overflowY: i,
                wordWrap: "break-word",
                resize: g
            }).data("autosize", !0), h in b ? c in b ? b[c] = b.onkeyup = l : b[h] = l : b[c] = l, e(window).on("resize", function () {
                d = !1, l()
            }), f.on("autosize", function () {
                d = !1, l()
            }), l())
        })
    }
})(window.jQuery || window.Zepto);