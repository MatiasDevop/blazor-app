/*! jQuery v3.6.0 | (c) OpenJS Foundation and other contributors | jquery.org/license */
!function(e,t){"use strict";"object"==typeof module&&"object"==typeof module.exports?module.exports=e.document?t(e,!0):function(e){if(!e.document)throw new Error("jQuery requires a window with a document");return t(e)}:t(e)}("undefined"!=typeof window?window:this,function(C,e){"use strict";var t=[],r=Object.getPrototypeOf,s=t.slice,g=t.flat?function(e){return t.flat.call(e)}:function(e){return t.concat.apply([],e)},u=t.push,i=t.indexOf,n={},o=n.toString,v=n.hasOwnProperty,a=v.toString,l=a.call(Object),y={},m=function(e){return"function"==typeof e&&"number"!=typeof e.nodeType&&"function"!=typeof e.item},x=function(e){return null!=e&&e===e.window},E=C.document,c={type:!0,src:!0,nonce:!0,noModule:!0};function b(e,t,n){var r,i,o=(n=n||E).createElement("script");if(o.text=e,t)for(r in c)(i=t[r]||t.getAttribute&&t.getAttribute(r))&&o.setAttribute(r,i);n.head.appendChild(o).parentNode.removeChild(o)}function w(e){return null==e?e+"":"object"==typeof e||"function"==typeof e?n[o.call(e)]||"object":typeof e}var f="3.6.0",S=function(e,t){return new S.fn.init(e,t)};function p(e){var t=!!e&&"length"in e&&e.length,n=w(e);return!m(e)&&!x(e)&&("array"===n||0===t||"number"==typeof t&&0<t&&t-1 in e)}S.fn=S.prototype={jquery:f,constructor:S,length:0,toArray:function(){return s.call(this)},get:function(e){return null==e?s.call(this):e<0?this[e+this.length]:this[e]},pushStack:function(e){var t=S.merge(this.constructor(),e);return t.prevObject=this,t},each:function(e){return S.each(this,e)},map:function(n){return this.pushStack(S.map(this,function(e,t){return n.call(e,t,e)}))},slice:function(){return this.pushStack(s.apply(this,arguments))},first:function(){return this.eq(0)},last:function(){return this.eq(-1)},even:function(){return this.pushStack(S.grep(this,function(e,t){return(t+1)%2}))},odd:function(){return this.pushStack(S.grep(this,function(e,t){return t%2}))},eq:function(e){var t=this.length,n=+e+(e<0?t:0);return this.pushStack(0<=n&&n<t?[this[n]]:[])},end:function(){return this.prevObject||this.constructor()},push:u,sort:t.sort,splice:t.splice},S.extend=S.fn.extend=function(){var e,t,n,r,i,o,a=arguments[0]||{},s=1,u=arguments.length,l=!1;for("boolean"==typeof a&&(l=a,a=arguments[s]||{},s++),"object"==typeof a||m(a)||(a={}),s===u&&(a=this,s--);s<u;s++)if(null!=(e=arguments[s]))for(t in e)r=e[t],"__proto__"!==t&&a!==r&&(l&&r&&(S.isPlainObject(r)||(i=Array.isArray(r)))?(n=a[t],o=i&&!Array.isArray(n)?[]:i||S.isPlainObject(n)?n:{},i=!1,a[t]=S.extend(l,o,r)):void 0!==r&&(a[t]=r));return a},S.extend({expando:"jQuery"+(f+Math.random()).replace(/\D/g,""),isReady:!0,error:function(e){throw new Error(e)},noop:function(){},isPlainObject:function(e){var t,n;return!(!e||"[object Object]"!==o.call(e))&&(!(t=r(e))||"function"==typeof(n=v.call(t,"constructor")&&t.constructor)&&a.call(n)===l)},isEmptyObject:function(e){var t;for(t in e)return!1;return!0},globalEval:function(e,t,n){b(e,{nonce:t&&t.nonce},n)},each:function(e,t){var n,r=0;if(p(e)){for(n=e.length;r<n;r++)if(!1===t.call(e[r],r,e[r]))break}else for(r in e)if(!1===t.call(e[r],r,e[r]))break;return e},makeArray:function(e,t){var n=t||[];return null!=e&&(p(Object(e))?S.merge(n,"string"==typeof e?[e]:e):u.call(n,e)),n},inArray:function(e,t,n){return null==t?-1:i.call(t,e,n)},merge:function(e,t){for(var n=+t.length,r=0,i=e.length;r<n;r++)e[i++]=t[r];return e.length=i,e},grep:function(e,t,n){for(var r=[],i=0,o=e.length,a=!n;i<o;i++)!t(e[i],i)!==a&&r.push(e[i]);return r},map:function(e,t,n){var r,i,o=0,a=[];if(p(e))for(r=e.length;o<r;o++)null!=(i=t(e[o],o,n))&&a.push(i);else for(o in e)null!=(i=t(e[o],o,n))&&a.push(i);return g(a)},guid:1,support:y}),"function"==typeof Symbol&&(S.fn[Symbol.iterator]=t[Symbol.iterator]),S.each("Boolean Number String Function Array Date RegExp Object Error Symbol".split(" "),function(e,t){n["[object "+t+"]"]=t.toLowerCase()});var d=function(n){var e,d,b,o,i,h,f,g,w,u,l,T,C,a,E,v,s,c,y,S="sizzle"+1*new Date,p=n.document,k=0,r=0,m=ue(),x=ue(),A=ue(),N=ue(),j=function(e,t){return e===t&&(l=!0),0},D={}.hasOwnProperty,t=[],q=t.pop,L=t.push,H=t.push,O=t.slice,P=function(e,t){for(var n=0,r=e.length;n<r;n++)if(e[n]===t)return n;return-1},R="checked|selected|async|autofocus|autoplay|controls|defer|disabled|hidden|ismap|loop|multiple|open|readonly|required|scoped",M="[\\x20\\t\\r\\n\\f]",I="(?:\\\\[\\da-fA-F]{1,6}"+M+"?|\\\\[^\\r\\n\\f]|[\\w-]|[^\0-\\x7f])+",W="\\["+M+"*("+I+")(?:"+M+"*([*^$|!~]?=)"+M+"*(?:'((?:\\\\.|[^\\\\'])*)'|\"((?:\\\\.|[^\\\\\"])*)\"|("+I+"))|)"+M+"*\\]",F=":("+I+")(?:\\((('((?:\\\\.|[^\\\\'])*)'|\"((?:\\\\.|[^\\\\\"])*)\")|((?:\\\\.|[^\\\\()[\\]]|"+W+")*)|.*)\\)|)",B=new RegExp(M+"+","g"),$=new RegExp("^"+M+"+|((?:^|[^\\\\])(?:\\\\.)*)"+M+"+$","g"),_=new RegExp("^"+M+"*,"+M+"*"),z=new RegExp("^"+M+"*([>+~]|"+M+")"+M+"*"),U=new RegExp(M+"|>"),X=new RegExp(F),V=new RegExp("^"+I+"$"),G={ID:new RegExp("^#("+I+")"),CLASS:new RegExp("^\\.("+I+")"),TAG:new RegExp("^("+I+"|[*])"),ATTR:new RegExp("^"+W),PSEUDO:new RegExp("^"+F),CHILD:new RegExp("^:(only|first|last|nth|nth-last)-(child|of-type)(?:\\("+M+"*(even|odd|(([+-]|)(\\d*)n|)"+M+"*(?:([+-]|)"+M+"*(\\d+)|))"+M+"*\\)|)","i"),bool:new RegExp("^(?:"+R+")$","i"),needsContext:new RegExp("^"+M+"*[>+~]|:(even|odd|eq|gt|lt|nth|first|last)(?:\\("+M+"*((?:-\\d)?\\d*)"+M+"*\\)|)(?=[^-]|$)","i")},Y=/HTML$/i,Q=/^(?:input|select|textarea|button)$/i,J=/^h\d$/i,K=/^[^{]+\{\s*\[native \w/,Z=/^(?:#([\w-]+)|(\w+)|\.([\w-]+))$/,ee=/[+~]/,te=new RegExp("\\\\[\\da-fA-F]{1,6}"+M+"?|\\\\([^\\r\\n\\f])","g"),ne=function(e,t){var n="0x"+e.slice(1)-65536;return t||(n<0?String.fromCharCode(n+65536):String.fromCharCode(n>>10|55296,1023&n|56320))},re=/([\0-\x1f\x7f]|^-?\d)|^-$|[^\0-\x1f\x7f-\uFFFF\w-]/g,ie=function(e,t){return t?"\0"===e?"\ufffd":e.slice(0,-1)+"\\"+e.charCodeAt(e.length-1).toString(16)+" ":"\\"+e},oe=function(){T()},ae=be(function(e){return!0===e.disabled&&"fieldset"===e.nodeName.toLowerCase()},{dir:"parentNode",next:"legend"});try{H.apply(t=O.call(p.childNodes),p.childNodes),t[p.childNodes.length].nodeType}catch(e){H={apply:t.length?function(e,t){L.apply(e,O.call(t))}:function(e,t){var n=e.length,r=0;while(e[n++]=t[r++]);e.length=n-1}}}function se(t,e,n,r){var i,o,a,s,u,l,c,f=e&&e.ownerDocument,p=e?e.nodeType:9;if(n=n||[],"string"!=typeof t||!t||1!==p&&9!==p&&11!==p)return n;if(!r&&(T(e),e=e||C,E)){if(11!==p&&(u=Z.exec(t)))if(i=u[1]){if(9===p){if(!(a=e.getElementById(i)))return n;if(a.id===i)return n.push(a),n}else if(f&&(a=f.getElementById(i))&&y(e,a)&&a.id===i)return n.push(a),n}else{if(u[2])return H.apply(n,e.getElementsByTagName(t)),n;if((i=u[3])&&d.getElementsByClassName&&e.getElementsByClassName)return H.apply(n,e.getElementsByClassName(i)),n}if(d.qsa&&!N[t+" "]&&(!v||!v.test(t))&&(1!==p||"object"!==e.nodeName.toLowerCase())){if(c=t,f=e,1===p&&(U.test(t)||z.test(t))){(f=ee.test(t)&&ye(e.parentNode)||e)===e&&d.scope||((s=e.getAttribute("id"))?s=s.replace(re,ie):e.setAttribute("id",s=S)),o=(l=h(t)).length;while(o--)l[o]=(s?"#"+s:":scope")+" "+xe(l[o]);c=l.join(",")}try{return H.apply(n,f.querySelectorAll(c)),n}catch(e){N(t,!0)}finally{s===S&&e.removeAttribute("id")}}}return g(t.replace($,"$1"),e,n,r)}function ue(){var r=[];return function e(t,n){return r.push(t+" ")>b.cacheLength&&delete e[r.shift()],e[t+" "]=n}}function le(e){return e[S]=!0,e}function ce(e){var t=C.createElement("fieldset");try{return!!e(t)}catch(e){return!1}finally{t.parentNode&&t.parentNode.removeChild(t),t=null}}function fe(e,t){var n=e.split("|"),r=n.length;while(r--)b.attrHandle[n[r]]=t}function pe(e,t){var n=t&&e,r=n&&1===e.nodeType&&1===t.nodeType&&e.sourceIndex-t.sourceIndex;if(r)return r;if(n)while(n=n.nextSibling)if(n===t)return-1;return e?1:-1}function de(t){return function(e){return"input"===e.nodeName.toLowerCase()&&e.type===t}}function he(n){return function(e){var t=e.nodeName.toLowerCase();return("input"===t||"button"===t)&&e.type===n}}function ge(t){return function(e){return"form"in e?e.parentNode&&!1===e.disabled?"label"in e?"label"in e.parentNode?e.parentNode.disabled===t:e.disabled===t:e.isDisabled===t||e.isDisabled!==!t&&ae(e)===t:e.disabled===t:"label"in e&&e.disabled===t}}function ve(a){return le(function(o){return o=+o,le(function(e,t){var n,r=a([],e.length,o),i=r.length;while(i--)e[n=r[i]]&&(e[n]=!(t[n]=e[n]))})})}function ye(e){return e&&"undefined"!=typeof e.getElementsByTagName&&e}for(e in d=se.support={},i=se.isXML=function(e){var t=e&&e.namespaceURI,n=e&&(e.ownerDocument||e).documentElement;return!Y.test(t||n&&n.nodeName||"HTML")},T=se.setDocument=function(e){var t,n,r=e?e.ownerDocument||e:p;return r!=C&&9===r.nodeType&&r.documentElement&&(a=(C=r).documentElement,E=!i(C),p!=C&&(n=C.defaultView)&&n.top!==n&&(n.addEventListener?n.addEventListener("unload",oe,!1):n.attachEvent&&n.attachEvent("onunload",oe)),d.scope=ce(function(e){return a.appendChild(e).appendChild(C.createElement("div")),"undefined"!=typeof e.querySelectorAll&&!e.querySelectorAll(":scope fieldset div").length}),d.attributes=ce(function(e){return e.className="i",!e.getAttribute("className")}),d.getElementsByTagName=ce(function(e){return e.appendChild(C.createComment("")),!e.getElementsByTagName("*").length}),d.getElementsByClassName=K.test(C.getElementsByClassName),d.getById=ce(function(e){return a.appendChild(e).id=S,!C.getElementsByName||!C.getElementsByName(S).length}),d.getById?(b.filter.ID=function(e){var t=e.replace(te,ne);return function(e){return e.getAttribute("id")===t}},b.find.ID=function(e,t){if("undefined"!=typeof t.getElementById&&E){var n=t.getElementById(e);return n?[n]:[]}}):(b.filter.ID=function(e){var n=e.replace(te,ne);return function(e){var t="undefined"!=typeof e.getAttributeNode&&e.getAttributeNode("id");return t&&t.value===n}},b.find.ID=function(e,t){if("undefined"!=typeof t.getElementById&&E){var n,r,i,o=t.getElementById(e);if(o){if((n=o.getAttributeNode("id"))&&n.value===e)return[o];i=t.getElementsByName(e),r=0;while(o=i[r++])if((n=o.getAttributeNode("id"))&&n.value===e)return[o]}return[]}}),b.find.TAG=d.getElementsByTagName?function(e,t){return"undefined"!=typeof t.getElementsByTagName?t.getElementsByTagName(e):d.qsa?t.querySelectorAll(e):void 0}:function(e,t){var n,r=[],i=0,o=t.getElementsByTagName(e);if("*"===e){while(n=o[i++])1===n.nodeType&&r.push(n);return r}return o},b.find.CLASS=d.getElementsByClassName&&function(e,t){if("undefined"!=typeof t.getElementsByClassName&&E)return t.getElementsByClassName(e)},s=[],v=[],(d.qsa=K.test(C.querySelectorAll))&&(ce(function(e){var t;a.appendChild(e).innerHTML="<a id='"+S+"'></a><select id='"+S+"-\r\\' msallowcapture=''><option selected=''></option></select>",e.querySelectorAll("[msallowcapture^='']").length&&v.push("[*^$]="+M+"*(?:''|\"\")"),e.querySelectorAll("[selected]").length||v.push("\\["+M+"*(?:value|"+R+")"),e.querySelectorAll("[id~="+S+"-]").length||v.push("~="),(t=C.createElement("input")).setAttribute("name",""),e.appendChild(t),e.querySelectorAll("[name='']").length||v.push("\\["+M+"*name"+M+"*="+M+"*(?:''|\"\")"),e.querySelectorAll(":checked").length||v.push(":checked"),e.querySelectorAll("a#"+S+"+*").length||v.push(".#.+[+~]"),e.querySelectorAll("\\\f"),v.push("[\\r\\n\\f]")}),ce(function(e){e.innerHTML="<a href='' disabled='disabled'></a><select disabled='disabled'><option/></select>";var t=C.createElement("input");t.setAttribute("type","hidden"),e.appendChild(t).setAttribute("name","D"),e.querySelectorAll("[name=d]").length&&v.push("name"+M+"*[*^$|!~]?="),2!==e.querySelectorAll(":enabled").length&&v.push(":enabled",":disabled"),a.appendChild(e).disabled=!0,2!==e.querySelectorAll(":disabled").length&&v.push(":enabled",":disabled"),e.querySelectorAll("*,:x"),v.push(",.*:")})),(d.matchesSelector=K.test(c=a.matches||a.webkitMatchesSelector||a.mozMatchesSelector||a.oMatchesSelector||a.msMatchesSelector))&&ce(function(e){d.disconnectedMatch=c.call(e,"*"),c.call(e,"[s!='']:x"),s.push("!=",F)}),v=v.length&&new RegExp(v.join("|")),s=s.length&&new RegExp(s.join("|")),t=K.test(a.compareDocumentPosition),y=t||K.test(a.contains)?function(e,t){var n=9===e.nodeType?e.documentElement:e,r=t&&t.parentNode;return e===r||!(!r||1!==r.nodeType||!(n.contains?n.contains(r):e.compareDocumentPosition&&16&e.compareDocumentPosition(r)))}:function(e,t){if(t)while(t=t.parentNode)if(t===e)return!0;return!1},j=t?function(e,t){if(e===t)return l=!0,0;var n=!e.compareDocumentPosition-!t.compareDocumentPosition;return n||(1&(n=(e.ownerDocument||e)==(t.ownerDocument||t)?e.compareDocumentPosition(t):1)||!d.sortDetached&&t.compareDocumentPosition(e)===n?e==C||e.ownerDocument==p&&y(p,e)?-1:t==C||t.ownerDocument==p&&y(p,t)?1:u?P(u,e)-P(u,t):0:4&n?-1:1)}:function(e,t){if(e===t)return l=!0,0;var n,r=0,i=e.parentNode,o=t.parentNode,a=[e],s=[t];if(!i||!o)return e==C?-1:t==C?1:i?-1:o?1:u?P(u,e)-P(u,t):0;if(i===o)return pe(e,t);n=e;while(n=n.parentNode)a.unshift(n);n=t;while(n=n.parentNode)s.unshift(n);while(a[r]===s[r])r++;return r?pe(a[r],s[r]):a[r]==p?-1:s[r]==p?1:0}),C},se.matches=function(e,t){return se(e,null,null,t)},se.matchesSelector=function(e,t){if(T(e),d.matchesSelector&&E&&!N[t+" "]&&(!s||!s.test(t))&&(!v||!v.test(t)))try{var n=c.call(e,t);if(n||d.disconnectedMatch||e.document&&11!==e.document.nodeType)return n}catch(e){N(t,!0)}return 0<se(t,C,null,[e]).length},se.contains=function(e,t){return(e.ownerDocument||e)!=C&&T(e),y(e,t)},se.attr=function(e,t){(e.ownerDocument||e)!=C&&T(e);var n=b.attrHandle[t.toLowerCase()],r=n&&D.call(b.attrHandle,t.toLowerCase())?n(e,t,!E):void 0;return void 0!==r?r:d.attributes||!E?e.getAttribute(t):(r=e.getAttributeNode(t))&&r.specified?r.value:null},se.escape=function(e){return(e+"").replace(re,ie)},se.error=function(e){throw new Error("Syntax error, unrecognized expression: "+e)},se.uniqueSort=function(e){var t,n=[],r=0,i=0;if(l=!d.detectDuplicates,u=!d.sortStable&&e.slice(0),e.sort(j),l){while(t=e[i++])t===e[i]&&(r=n.push(i));while(r--)e.splice(n[r],1)}return u=null,e},o=se.getText=function(e){var t,n="",r=0,i=e.nodeType;if(i){if(1===i||9===i||11===i){if("string"==typeof e.textContent)return e.textContent;for(e=e.firstChild;e;e=e.nextSibling)n+=o(e)}else if(3===i||4===i)return e.nodeValue}else while(t=e[r++])n+=o(t);return n},(b=se.selectors={cacheLength:50,createPseudo:le,match:G,attrHandle:{},find:{},relative:{">":{dir:"parentNode",first:!0}," ":{dir:"parentNode"},"+":{dir:"previousSibling",first:!0},"~":{dir:"previousSibling"}},preFilter:{ATTR:function(e){return e[1]=e[1].replace(te,ne),e[3]=(e[3]||e[4]||e[5]||"").replace(te,ne),"~="===e[2]&&(e[3]=" "+e[3]+" "),e.slice(0,4)},CHILD:function(e){return e[1]=e[1].toLowerCase(),"nth"===e[1].slice(0,3)?(e[3]||se.error(e[0]),e[4]=+(e[4]?e[5]+(e[6]||1):2*("even"===e[3]||"odd"===e[3])),e[5]=+(e[7]+e[8]||"odd"===e[3])):e[3]&&se.error(e[0]),e},PSEUDO:function(e){var t,n=!e[6]&&e[2];return G.CHILD.test(e[0])?null:(e[3]?e[2]=e[4]||e[5]||"":n&&X.test(n)&&(t=h(n,!0))&&(t=n.indexOf(")",n.length-t)-n.length)&&(e[0]=e[0].slice(0,t),e[2]=n.slice(0,t)),e.slice(0,3))}},filter:{TAG:function(e){var t=e.replace(te,ne).toLowerCase();return"*"===e?function(){return!0}:function(e){return e.nodeName&&e.nodeName.toLowerCase()===t}},CLASS:function(e){var t=m[e+" "];return t||(t=new RegExp("(^|"+M+")"+e+"("+M+"|$)"))&&m(e,function(e){return t.test("string"==typeof e.className&&e.className||"undefined"!=typeof e.getAttribute&&e.getAttribute("class")||"")})},ATTR:function(n,r,i){return function(e){var t=se.attr(e,n);return null==t?"!="===r:!r||(t+="","="===r?t===i:"!="===r?t!==i:"^="===r?i&&0===t.indexOf(i):"*="===r?i&&-1<t.indexOf(i):"$="===r?i&&t.slice(-i.length)===i:"~="===r?-1<(" "+t.replace(B," ")+" ").indexOf(i):"|="===r&&(t===i||t.slice(0,i.length+1)===i+"-"))}},CHILD:function(h,e,t,g,v){var y="nth"!==h.slice(0,3),m="last"!==h.slice(-4),x="of-type"===e;return 1===g&&0===v?function(e){return!!e.parentNode}:function(e,t,n){var r,i,o,a,s,u,l=y!==m?"nextSibling":"previousSibling",c=e.parentNode,f=x&&e.nodeName.toLowerCase(),p=!n&&!x,d=!1;if(c){if(y){while(l){a=e;while(a=a[l])if(x?a.nodeName.toLowerCase()===f:1===a.nodeType)return!1;u=l="only"===h&&!u&&"nextSibling"}return!0}if(u=[m?c.firstChild:c.lastChild],m&&p){d=(s=(r=(i=(o=(a=c)[S]||(a[S]={}))[a.uniqueID]||(o[a.uniqueID]={}))[h]||[])[0]===k&&r[1])&&r[2],a=s&&c.childNodes[s];while(a=++s&&a&&a[l]||(d=s=0)||u.pop())if(1===a.nodeType&&++d&&a===e){i[h]=[k,s,d];break}}else if(p&&(d=s=(r=(i=(o=(a=e)[S]||(a[S]={}))[a.uniqueID]||(o[a.uniqueID]={}))[h]||[])[0]===k&&r[1]),!1===d)while(a=++s&&a&&a[l]||(d=s=0)||u.pop())if((x?a.nodeName.toLowerCase()===f:1===a.nodeType)&&++d&&(p&&((i=(o=a[S]||(a[S]={}))[a.uniqueID]||(o[a.uniqueID]={}))[h]=[k,d]),a===e))break;return(d-=v)===g||d%g==0&&0<=d/g}}},PSEUDO:function(e,o){var t,a=b.pseudos[e]||b.setFilters[e.toLowerCase()]||se.error("unsupported pseudo: "+e);return a[S]?a(o):1<a.length?(t=[e,e,"",o],b.setFilters.hasOwnProperty(e.toLowerCase())?le(function(e,t){var n,r=a(e,o),i=r.length;while(i--)e[n=P(e,r[i])]=!(t[n]=r[i])}):function(e){return a(e,0,t)}):a}},pseudos:{not:le(function(e){var r=[],i=[],s=f(e.replace($,"$1"));return s[S]?le(function(e,t,n,r){var i,o=s(e,null,r,[]),a=e.length;while(a--)(i=o[a])&&(e[a]=!(t[a]=i))}):function(e,t,n){return r[0]=e,s(r,null,n,i),r[0]=null,!i.pop()}}),has:le(function(t){return function(e){return 0<se(t,e).length}}),contains:le(function(t){return t=t.replace(te,ne),function(e){return-1<(e.textContent||o(e)).indexOf(t)}}),lang:le(function(n){return V.test(n||"")||se.error("unsupported lang: "+n),n=n.replace(te,ne).toLowerCase(),function(e){var t;do{if(t=E?e.lang:e.getAttribute("xml:lang")||e.getAttribute("lang"))return(t=t.toLowerCase())===n||0===t.indexOf(n+"-")}while((e=e.parentNode)&&1===e.nodeType);return!1}}),target:function(e){var t=n.location&&n.location.hash;return t&&t.slice(1)===e.id},root:function(e){return e===a},focus:function(e){return e===C.activeElement&&(!C.hasFocus||C.hasFocus())&&!!(e.type||e.href||~e.tabIndex)},enabled:ge(!1),disabled:ge(!0),checked:function(e){var t=e.nodeName.toLowerCase();return"input"===t&&!!e.checked||"option"===t&&!!e.selected},selected:function(e){return e.parentNode&&e.parentNode.selectedIndex,!0===e.selected},empty:function(e){for(e=e.firstChild;e;e=e.nextSibling)if(e.nodeType<6)return!1;return!0},parent:function(e){return!b.pseudos.empty(e)},header:function(e){return J.test(e.nodeName)},input:function(e){return Q.test(e.nodeName)},button:function(e){var t=e.nodeName.toLowerCase();return"input"===t&&"button"===e.type||"button"===t},text:function(e){var t;return"input"===e.nodeName.toLowerCase()&&"text"===e.type&&(null==(t=e.getAttribute("type"))||"text"===t.toLowerCase())},first:ve(function(){return[0]}),last:ve(function(e,t){return[t-1]}),eq:ve(function(e,t,n){return[n<0?n+t:n]}),even:ve(function(e,t){for(var n=0;n<t;n+=2)e.push(n);return e}),odd:ve(function(e,t){for(var n=1;n<t;n+=2)e.push(n);return e}),lt:ve(function(e,t,n){for(var r=n<0?n+t:t<n?t:n;0<=--r;)e.push(r);return e}),gt:ve(function(e,t,n){for(var r=n<0?n+t:n;++r<t;)e.push(r);return e})}}).pseudos.nth=b.pseudos.eq,{radio:!0,checkbox:!0,file:!0,password:!0,image:!0})b.pseudos[e]=de(e);for(e in{submit:!0,reset:!0})b.pseudos[e]=he(e);function me(){}function xe(e){for(var t=0,n=e.length,r="";t<n;t++)r+=e[t].value;return r}function be(s,e,t){var u=e.dir,l=e.next,c=l||u,f=t&&"parentNode"===c,p=r++;return e.first?function(e,t,n){while(e=e[u])if(1===e.nodeType||f)return s(e,t,n);return!1}:function(e,t,n){var r,i,o,a=[k,p];if(n){while(e=e[u])if((1===e.nodeType||f)&&s(e,t,n))return!0}else while(e=e[u])if(1===e.nodeType||f)if(i=(o=e[S]||(e[S]={}))[e.uniqueID]||(o[e.uniqueID]={}),l&&l===e.nodeName.toLowerCase())e=e[u]||e;else{if((r=i[c])&&r[0]===k&&r[1]===p)return a[2]=r[2];if((i[c]=a)[2]=s(e,t,n))return!0}return!1}}function we(i){return 1<i.length?function(e,t,n){var r=i.length;while(r--)if(!i[r](e,t,n))return!1;return!0}:i[0]}function Te(e,t,n,r,i){for(var o,a=[],s=0,u=e.length,l=null!=t;s<u;s++)(o=e[s])&&(n&&!n(o,r,i)||(a.push(o),l&&t.push(s)));return a}function Ce(d,h,g,v,y,e){return v&&!v[S]&&(v=Ce(v)),y&&!y[S]&&(y=Ce(y,e)),le(function(e,t,n,r){var i,o,a,s=[],u=[],l=t.length,c=e||function(e,t,n){for(var r=0,i=t.length;r<i;r++)se(e,t[r],n);return n}(h||"*",n.nodeType?[n]:n,[]),f=!d||!e&&h?c:Te(c,s,d,n,r),p=g?y||(e?d:l||v)?[]:t:f;if(g&&g(f,p,n,r),v){i=Te(p,u),v(i,[],n,r),o=i.length;while(o--)(a=i[o])&&(p[u[o]]=!(f[u[o]]=a))}if(e){if(y||d){if(y){i=[],o=p.length;while(o--)(a=p[o])&&i.push(f[o]=a);y(null,p=[],i,r)}o=p.length;while(o--)(a=p[o])&&-1<(i=y?P(e,a):s[o])&&(e[i]=!(t[i]=a))}}else p=Te(p===t?p.splice(l,p.length):p),y?y(null,t,p,r):H.apply(t,p)})}function Ee(e){for(var i,t,n,r=e.length,o=b.relative[e[0].type],a=o||b.relative[" "],s=o?1:0,u=be(function(e){return e===i},a,!0),l=be(function(e){return-1<P(i,e)},a,!0),c=[function(e,t,n){var r=!o&&(n||t!==w)||((i=t).nodeType?u(e,t,n):l(e,t,n));return i=null,r}];s<r;s++)if(t=b.relative[e[s].type])c=[be(we(c),t)];else{if((t=b.filter[e[s].type].apply(null,e[s].matches))[S]){for(n=++s;n<r;n++)if(b.relative[e[n].type])break;return Ce(1<s&&we(c),1<s&&xe(e.slice(0,s-1).concat({value:" "===e[s-2].type?"*":""})).replace($,"$1"),t,s<n&&Ee(e.slice(s,n)),n<r&&Ee(e=e.slice(n)),n<r&&xe(e))}c.push(t)}return we(c)}return me.prototype=b.filters=b.pseudos,b.setFilters=new me,h=se.tokenize=function(e,t){var n,r,i,o,a,s,u,l=x[e+" "];if(l)return t?0:l.slice(0);a=e,s=[],u=b.preFilter;while(a){for(o in n&&!(r=_.exec(a))||(r&&(a=a.slice(r[0].length)||a),s.push(i=[])),n=!1,(r=z.exec(a))&&(n=r.shift(),i.push({value:n,type:r[0].replace($," ")}),a=a.slice(n.length)),b.filter)!(r=G[o].exec(a))||u[o]&&!(r=u[o](r))||(n=r.shift(),i.push({value:n,type:o,matches:r}),a=a.slice(n.length));if(!n)break}return t?a.length:a?se.error(e):x(e,s).slice(0)},f=se.compile=function(e,t){var n,v,y,m,x,r,i=[],o=[],a=A[e+" "];if(!a){t||(t=h(e)),n=t.length;while(n--)(a=Ee(t[n]))[S]?i.push(a):o.push(a);(a=A(e,(v=o,m=0<(y=i).length,x=0<v.length,r=function(e,t,n,r,i){var o,a,s,u=0,l="0",c=e&&[],f=[],p=w,d=e||x&&b.find.TAG("*",i),h=k+=null==p?1:Math.random()||.1,g=d.length;for(i&&(w=t==C||t||i);l!==g&&null!=(o=d[l]);l++){if(x&&o){a=0,t||o.ownerDocument==C||(T(o),n=!E);while(s=v[a++])if(s(o,t||C,n)){r.push(o);break}i&&(k=h)}m&&((o=!s&&o)&&u--,e&&c.push(o))}if(u+=l,m&&l!==u){a=0;while(s=y[a++])s(c,f,t,n);if(e){if(0<u)while(l--)c[l]||f[l]||(f[l]=q.call(r));f=Te(f)}H.apply(r,f),i&&!e&&0<f.length&&1<u+y.length&&se.uniqueSort(r)}return i&&(k=h,w=p),c},m?le(r):r))).selector=e}return a},g=se.select=function(e,t,n,r){var i,o,a,s,u,l="function"==typeof e&&e,c=!r&&h(e=l.selector||e);if(n=n||[],1===c.length){if(2<(o=c[0]=c[0].slice(0)).length&&"ID"===(a=o[0]).type&&9===t.nodeType&&E&&b.relative[o[1].type]){if(!(t=(b.find.ID(a.matches[0].replace(te,ne),t)||[])[0]))return n;l&&(t=t.parentNode),e=e.slice(o.shift().value.length)}i=G.needsContext.test(e)?0:o.length;while(i--){if(a=o[i],b.relative[s=a.type])break;if((u=b.find[s])&&(r=u(a.matches[0].replace(te,ne),ee.test(o[0].type)&&ye(t.parentNode)||t))){if(o.splice(i,1),!(e=r.length&&xe(o)))return H.apply(n,r),n;break}}}return(l||f(e,c))(r,t,!E,n,!t||ee.test(e)&&ye(t.parentNode)||t),n},d.sortStable=S.split("").sort(j).join("")===S,d.detectDuplicates=!!l,T(),d.sortDetached=ce(function(e){return 1&e.compareDocumentPosition(C.createElement("fieldset"))}),ce(function(e){return e.innerHTML="<a href='#'></a>","#"===e.firstChild.getAttribute("href")})||fe("type|href|height|width",function(e,t,n){if(!n)return e.getAttribute(t,"type"===t.toLowerCase()?1:2)}),d.attributes&&ce(function(e){return e.innerHTML="<input/>",e.firstChild.setAttribute("value",""),""===e.firstChild.getAttribute("value")})||fe("value",function(e,t,n){if(!n&&"input"===e.nodeName.toLowerCase())return e.defaultValue}),ce(function(e){return null==e.getAttribute("disabled")})||fe(R,function(e,t,n){var r;if(!n)return!0===e[t]?t.toLowerCase():(r=e.getAttributeNode(t))&&r.specified?r.value:null}),se}(C);S.find=d,S.expr=d.selectors,S.expr[":"]=S.expr.pseudos,S.uniqueSort=S.unique=d.uniqueSort,S.text=d.getText,S.isXMLDoc=d.isXML,S.contains=d.contains,S.escapeSelector=d.escape;var h=function(e,t,n){var r=[],i=void 0!==n;while((e=e[t])&&9!==e.nodeType)if(1===e.nodeType){if(i&&S(e).is(n))break;r.push(e)}return r},T=function(e,t){for(var n=[];e;e=e.nextSibling)1===e.nodeType&&e!==t&&n.push(e);return n},k=S.expr.match.needsContext;function A(e,t){return e.nodeName&&e.nodeName.toLowerCase()===t.toLowerCase()}var N=/^<([a-z][^\/\0>:\x20\t\r\n\f]*)[\x20\t\r\n\f]*\/?>(?:<\/\1>|)$/i;function j(e,n,r){return m(n)?S.grep(e,function(e,t){return!!n.call(e,t,e)!==r}):n.nodeType?S.grep(e,function(e){return e===n!==r}):"string"!=typeof n?S.grep(e,function(e){return-1<i.call(n,e)!==r}):S.filter(n,e,r)}S.filter=function(e,t,n){var r=t[0];return n&&(e=":not("+e+")"),1===t.length&&1===r.nodeType?S.find.matchesSelector(r,e)?[r]:[]:S.find.matches(e,S.grep(t,function(e){return 1===e.nodeType}))},S.fn.extend({find:function(e){var t,n,r=this.length,i=this;if("string"!=typeof e)return this.pushStack(S(e).filter(function(){for(t=0;t<r;t++)if(S.contains(i[t],this))return!0}));for(n=this.pushStack([]),t=0;t<r;t++)S.find(e,i[t],n);return 1<r?S.uniqueSort(n):n},filter:function(e){return this.pushStack(j(this,e||[],!1))},not:function(e){return this.pushStack(j(this,e||[],!0))},is:function(e){return!!j(this,"string"==typeof e&&k.test(e)?S(e):e||[],!1).length}});var D,q=/^(?:\s*(<[\w\W]+>)[^>]*|#([\w-]+))$/;(S.fn.init=function(e,t,n){var r,i;if(!e)return this;if(n=n||D,"string"==typeof e){if(!(r="<"===e[0]&&">"===e[e.length-1]&&3<=e.length?[null,e,null]:q.exec(e))||!r[1]&&t)return!t||t.jquery?(t||n).find(e):this.constructor(t).find(e);if(r[1]){if(t=t instanceof S?t[0]:t,S.merge(this,S.parseHTML(r[1],t&&t.nodeType?t.ownerDocument||t:E,!0)),N.test(r[1])&&S.isPlainObject(t))for(r in t)m(this[r])?this[r](t[r]):this.attr(r,t[r]);return this}return(i=E.getElementById(r[2]))&&(this[0]=i,this.length=1),this}return e.nodeType?(this[0]=e,this.length=1,this):m(e)?void 0!==n.ready?n.ready(e):e(S):S.makeArray(e,this)}).prototype=S.fn,D=S(E);var L=/^(?:parents|prev(?:Until|All))/,H={children:!0,contents:!0,next:!0,prev:!0};function O(e,t){while((e=e[t])&&1!==e.nodeType);return e}S.fn.extend({has:function(e){var t=S(e,this),n=t.length;return this.filter(function(){for(var e=0;e<n;e++)if(S.contains(this,t[e]))return!0})},closest:function(e,t){var n,r=0,i=this.length,o=[],a="string"!=typeof e&&S(e);if(!k.test(e))for(;r<i;r++)for(n=this[r];n&&n!==t;n=n.parentNode)if(n.nodeType<11&&(a?-1<a.index(n):1===n.nodeType&&S.find.matchesSelector(n,e))){o.push(n);break}return this.pushStack(1<o.length?S.uniqueSort(o):o)},index:function(e){return e?"string"==typeof e?i.call(S(e),this[0]):i.call(this,e.jquery?e[0]:e):this[0]&&this[0].parentNode?this.first().prevAll().length:-1},add:function(e,t){return this.pushStack(S.uniqueSort(S.merge(this.get(),S(e,t))))},addBack:function(e){return this.add(null==e?this.prevObject:this.prevObject.filter(e))}}),S.each({parent:function(e){var t=e.parentNode;return t&&11!==t.nodeType?t:null},parents:function(e){return h(e,"parentNode")},parentsUntil:function(e,t,n){return h(e,"parentNode",n)},next:function(e){return O(e,"nextSibling")},prev:function(e){return O(e,"previousSibling")},nextAll:function(e){return h(e,"nextSibling")},prevAll:function(e){return h(e,"previousSibling")},nextUntil:function(e,t,n){return h(e,"nextSibling",n)},prevUntil:function(e,t,n){return h(e,"previousSibling",n)},siblings:function(e){return T((e.parentNode||{}).firstChild,e)},children:function(e){return T(e.firstChild)},contents:function(e){return null!=e.contentDocument&&r(e.contentDocument)?e.contentDocument:(A(e,"template")&&(e=e.content||e),S.merge([],e.childNodes))}},function(r,i){S.fn[r]=function(e,t){var n=S.map(this,i,e);return"Until"!==r.slice(-5)&&(t=e),t&&"string"==typeof t&&(n=S.filter(t,n)),1<this.length&&(H[r]||S.uniqueSort(n),L.test(r)&&n.reverse()),this.pushStack(n)}});var P=/[^\x20\t\r\n\f]+/g;function R(e){return e}function M(e){throw e}function I(e,t,n,r){var i;try{e&&m(i=e.promise)?i.call(e).done(t).fail(n):e&&m(i=e.then)?i.call(e,t,n):t.apply(void 0,[e].slice(r))}catch(e){n.apply(void 0,[e])}}S.Callbacks=function(r){var e,n;r="string"==typeof r?(e=r,n={},S.each(e.match(P)||[],function(e,t){n[t]=!0}),n):S.extend({},r);var i,t,o,a,s=[],u=[],l=-1,c=function(){for(a=a||r.once,o=i=!0;u.length;l=-1){t=u.shift();while(++l<s.length)!1===s[l].apply(t[0],t[1])&&r.stopOnFalse&&(l=s.length,t=!1)}r.memory||(t=!1),i=!1,a&&(s=t?[]:"")},f={add:function(){return s&&(t&&!i&&(l=s.length-1,u.push(t)),function n(e){S.each(e,function(e,t){m(t)?r.unique&&f.has(t)||s.push(t):t&&t.length&&"string"!==w(t)&&n(t)})}(arguments),t&&!i&&c()),this},remove:function(){return S.each(arguments,function(e,t){var n;while(-1<(n=S.inArray(t,s,n)))s.splice(n,1),n<=l&&l--}),this},has:function(e){return e?-1<S.inArray(e,s):0<s.length},empty:function(){return s&&(s=[]),this},disable:function(){return a=u=[],s=t="",this},disabled:function(){return!s},lock:function(){return a=u=[],t||i||(s=t=""),this},locked:function(){return!!a},fireWith:function(e,t){return a||(t=[e,(t=t||[]).slice?t.slice():t],u.push(t),i||c()),this},fire:function(){return f.fireWith(this,arguments),this},fired:function(){return!!o}};return f},S.extend({Deferred:function(e){var o=[["notify","progress",S.Callbacks("memory"),S.Callbacks("memory"),2],["resolve","done",S.Callbacks("once memory"),S.Callbacks("once memory"),0,"resolved"],["reject","fail",S.Callbacks("once memory"),S.Callbacks("once memory"),1,"rejected"]],i="pending",a={state:function(){return i},always:function(){return s.done(arguments).fail(arguments),this},"catch":function(e){return a.then(null,e)},pipe:function(){var i=arguments;return S.Deferred(function(r){S.each(o,function(e,t){var n=m(i[t[4]])&&i[t[4]];s[t[1]](function(){var e=n&&n.apply(this,arguments);e&&m(e.promise)?e.promise().progress(r.notify).done(r.resolve).fail(r.reject):r[t[0]+"With"](this,n?[e]:arguments)})}),i=null}).promise()},then:function(t,n,r){var u=0;function l(i,o,a,s){return function(){var n=this,r=arguments,e=function(){var e,t;if(!(i<u)){if((e=a.apply(n,r))===o.promise())throw new TypeError("Thenable self-resolution");t=e&&("object"==typeof e||"function"==typeof e)&&e.then,m(t)?s?t.call(e,l(u,o,R,s),l(u,o,M,s)):(u++,t.call(e,l(u,o,R,s),l(u,o,M,s),l(u,o,R,o.notifyWith))):(a!==R&&(n=void 0,r=[e]),(s||o.resolveWith)(n,r))}},t=s?e:function(){try{e()}catch(e){S.Deferred.exceptionHook&&S.Deferred.exceptionHook(e,t.stackTrace),u<=i+1&&(a!==M&&(n=void 0,r=[e]),o.rejectWith(n,r))}};i?t():(S.Deferred.getStackHook&&(t.stackTrace=S.Deferred.getStackHook()),C.setTimeout(t))}}return S.Deferred(function(e){o[0][3].add(l(0,e,m(r)?r:R,e.notifyWith)),o[1][3].add(l(0,e,m(t)?t:R)),o[2][3].add(l(0,e,m(n)?n:M))}).promise()},promise:function(e){return null!=e?S.extend(e,a):a}},s={};return S.each(o,function(e,t){var n=t[2],r=t[5];a[t[1]]=n.add,r&&n.add(function(){i=r},o[3-e][2].disable,o[3-e][3].disable,o[0][2].lock,o[0][3].lock),n.add(t[3].fire),s[t[0]]=function(){return s[t[0]+"With"](this===s?void 0:this,arguments),this},s[t[0]+"With"]=n.fireWith}),a.promise(s),e&&e.call(s,s),s},when:function(e){var n=arguments.length,t=n,r=Array(t),i=s.call(arguments),o=S.Deferred(),a=function(t){return function(e){r[t]=this,i[t]=1<arguments.length?s.call(arguments):e,--n||o.resolveWith(r,i)}};if(n<=1&&(I(e,o.done(a(t)).resolve,o.reject,!n),"pending"===o.state()||m(i[t]&&i[t].then)))return o.then();while(t--)I(i[t],a(t),o.reject);return o.promise()}});var W=/^(Eval|Internal|Range|Reference|Syntax|Type|URI)Error$/;S.Deferred.exceptionHook=function(e,t){C.console&&C.console.warn&&e&&W.test(e.name)&&C.console.warn("jQuery.Deferred exception: "+e.message,e.stack,t)},S.readyException=function(e){C.setTimeout(function(){throw e})};var F=S.Deferred();function B(){E.removeEventListener("DOMContentLoaded",B),C.removeEventListener("load",B),S.ready()}S.fn.ready=function(e){return F.then(e)["catch"](function(e){S.readyException(e)}),this},S.extend({isReady:!1,readyWait:1,ready:function(e){(!0===e?--S.readyWait:S.isReady)||(S.isReady=!0)!==e&&0<--S.readyWait||F.resolveWith(E,[S])}}),S.ready.then=F.then,"complete"===E.readyState||"loading"!==E.readyState&&!E.documentElement.doScroll?C.setTimeout(S.ready):(E.addEventListener("DOMContentLoaded",B),C.addEventListener("load",B));var $=function(e,t,n,r,i,o,a){var s=0,u=e.length,l=null==n;if("object"===w(n))for(s in i=!0,n)$(e,t,s,n[s],!0,o,a);else if(void 0!==r&&(i=!0,m(r)||(a=!0),l&&(a?(t.call(e,r),t=null):(l=t,t=function(e,t,n){return l.call(S(e),n)})),t))for(;s<u;s++)t(e[s],n,a?r:r.call(e[s],s,t(e[s],n)));return i?e:l?t.call(e):u?t(e[0],n):o},_=/^-ms-/,z=/-([a-z])/g;function U(e,t){return t.toUpperCase()}function X(e){return e.replace(_,"ms-").replace(z,U)}var V=function(e){return 1===e.nodeType||9===e.nodeType||!+e.nodeType};function G(){this.expando=S.expando+G.uid++}G.uid=1,G.prototype={cache:function(e){var t=e[this.expando];return t||(t={},V(e)&&(e.nodeType?e[this.expando]=t:Object.defineProperty(e,this.expando,{value:t,configurable:!0}))),t},set:function(e,t,n){var r,i=this.cache(e);if("string"==typeof t)i[X(t)]=n;else for(r in t)i[X(r)]=t[r];return i},get:function(e,t){return void 0===t?this.cache(e):e[this.expando]&&e[this.expando][X(t)]},access:function(e,t,n){return void 0===t||t&&"string"==typeof t&&void 0===n?this.get(e,t):(this.set(e,t,n),void 0!==n?n:t)},remove:function(e,t){var n,r=e[this.expando];if(void 0!==r){if(void 0!==t){n=(t=Array.isArray(t)?t.map(X):(t=X(t))in r?[t]:t.match(P)||[]).length;while(n--)delete r[t[n]]}(void 0===t||S.isEmptyObject(r))&&(e.nodeType?e[this.expando]=void 0:delete e[this.expando])}},hasData:function(e){var t=e[this.expando];return void 0!==t&&!S.isEmptyObject(t)}};var Y=new G,Q=new G,J=/^(?:\{[\w\W]*\}|\[[\w\W]*\])$/,K=/[A-Z]/g;function Z(e,t,n){var r,i;if(void 0===n&&1===e.nodeType)if(r="data-"+t.replace(K,"-$&").toLowerCase(),"string"==typeof(n=e.getAttribute(r))){try{n="true"===(i=n)||"false"!==i&&("null"===i?null:i===+i+""?+i:J.test(i)?JSON.parse(i):i)}catch(e){}Q.set(e,t,n)}else n=void 0;return n}S.extend({hasData:function(e){return Q.hasData(e)||Y.hasData(e)},data:function(e,t,n){return Q.access(e,t,n)},removeData:function(e,t){Q.remove(e,t)},_data:function(e,t,n){return Y.access(e,t,n)},_removeData:function(e,t){Y.remove(e,t)}}),S.fn.extend({data:function(n,e){var t,r,i,o=this[0],a=o&&o.attributes;if(void 0===n){if(this.length&&(i=Q.get(o),1===o.nodeType&&!Y.get(o,"hasDataAttrs"))){t=a.length;while(t--)a[t]&&0===(r=a[t].name).indexOf("data-")&&(r=X(r.slice(5)),Z(o,r,i[r]));Y.set(o,"hasDataAttrs",!0)}return i}return"object"==typeof n?this.each(function(){Q.set(this,n)}):$(this,function(e){var t;if(o&&void 0===e)return void 0!==(t=Q.get(o,n))?t:void 0!==(t=Z(o,n))?t:void 0;this.each(function(){Q.set(this,n,e)})},null,e,1<arguments.length,null,!0)},removeData:function(e){return this.each(function(){Q.remove(this,e)})}}),S.extend({queue:function(e,t,n){var r;if(e)return t=(t||"fx")+"queue",r=Y.get(e,t),n&&(!r||Array.isArray(n)?r=Y.access(e,t,S.makeArray(n)):r.push(n)),r||[]},dequeue:function(e,t){t=t||"fx";var n=S.queue(e,t),r=n.length,i=n.shift(),o=S._queueHooks(e,t);"inprogress"===i&&(i=n.shift(),r--),i&&("fx"===t&&n.unshift("inprogress"),delete o.stop,i.call(e,function(){S.dequeue(e,t)},o)),!r&&o&&o.empty.fire()},_queueHooks:function(e,t){var n=t+"queueHooks";return Y.get(e,n)||Y.access(e,n,{empty:S.Callbacks("once memory").add(function(){Y.remove(e,[t+"queue",n])})})}}),S.fn.extend({queue:function(t,n){var e=2;return"string"!=typeof t&&(n=t,t="fx",e--),arguments.length<e?S.queue(this[0],t):void 0===n?this:this.each(function(){var e=S.queue(this,t,n);S._queueHooks(this,t),"fx"===t&&"inprogress"!==e[0]&&S.dequeue(this,t)})},dequeue:function(e){return this.each(function(){S.dequeue(this,e)})},clearQueue:function(e){return this.queue(e||"fx",[])},promise:function(e,t){var n,r=1,i=S.Deferred(),o=this,a=this.length,s=function(){--r||i.resolveWith(o,[o])};"string"!=typeof e&&(t=e,e=void 0),e=e||"fx";while(a--)(n=Y.get(o[a],e+"queueHooks"))&&n.empty&&(r++,n.empty.add(s));return s(),i.promise(t)}});var ee=/[+-]?(?:\d*\.|)\d+(?:[eE][+-]?\d+|)/.source,te=new RegExp("^(?:([+-])=|)("+ee+")([a-z%]*)$","i"),ne=["Top","Right","Bottom","Left"],re=E.documentElement,ie=function(e){return S.contains(e.ownerDocument,e)},oe={composed:!0};re.getRootNode&&(ie=function(e){return S.contains(e.ownerDocument,e)||e.getRootNode(oe)===e.ownerDocument});var ae=function(e,t){return"none"===(e=t||e).style.display||""===e.style.display&&ie(e)&&"none"===S.css(e,"display")};function se(e,t,n,r){var i,o,a=20,s=r?function(){return r.cur()}:function(){return S.css(e,t,"")},u=s(),l=n&&n[3]||(S.cssNumber[t]?"":"px"),c=e.nodeType&&(S.cssNumber[t]||"px"!==l&&+u)&&te.exec(S.css(e,t));if(c&&c[3]!==l){u/=2,l=l||c[3],c=+u||1;while(a--)S.style(e,t,c+l),(1-o)*(1-(o=s()/u||.5))<=0&&(a=0),c/=o;c*=2,S.style(e,t,c+l),n=n||[]}return n&&(c=+c||+u||0,i=n[1]?c+(n[1]+1)*n[2]:+n[2],r&&(r.unit=l,r.start=c,r.end=i)),i}var ue={};function le(e,t){for(var n,r,i,o,a,s,u,l=[],c=0,f=e.length;c<f;c++)(r=e[c]).style&&(n=r.style.display,t?("none"===n&&(l[c]=Y.get(r,"display")||null,l[c]||(r.style.display="")),""===r.style.display&&ae(r)&&(l[c]=(u=a=o=void 0,a=(i=r).ownerDocument,s=i.nodeName,(u=ue[s])||(o=a.body.appendChild(a.createElement(s)),u=S.css(o,"display"),o.parentNode.removeChild(o),"none"===u&&(u="block"),ue[s]=u)))):"none"!==n&&(l[c]="none",Y.set(r,"display",n)));for(c=0;c<f;c++)null!=l[c]&&(e[c].style.display=l[c]);return e}S.fn.extend({show:function(){return le(this,!0)},hide:function(){return le(this)},toggle:function(e){return"boolean"==typeof e?e?this.show():this.hide():this.each(function(){ae(this)?S(this).show():S(this).hide()})}});var ce,fe,pe=/^(?:checkbox|radio)$/i,de=/<([a-z][^\/\0>\x20\t\r\n\f]*)/i,he=/^$|^module$|\/(?:java|ecma)script/i;ce=E.createDocumentFragment().appendChild(E.createElement("div")),(fe=E.createElement("input")).setAttribute("type","radio"),fe.setAttribute("checked","checked"),fe.setAttribute("name","t"),ce.appendChild(fe),y.checkClone=ce.cloneNode(!0).cloneNode(!0).lastChild.checked,ce.innerHTML="<textarea>x</textarea>",y.noCloneChecked=!!ce.cloneNode(!0).lastChild.defaultValue,ce.innerHTML="<option></option>",y.option=!!ce.lastChild;var ge={thead:[1,"<table>","</table>"],col:[2,"<table><colgroup>","</colgroup></table>"],tr:[2,"<table><tbody>","</tbody></table>"],td:[3,"<table><tbody><tr>","</tr></tbody></table>"],_default:[0,"",""]};function ve(e,t){var n;return n="undefined"!=typeof e.getElementsByTagName?e.getElementsByTagName(t||"*"):"undefined"!=typeof e.querySelectorAll?e.querySelectorAll(t||"*"):[],void 0===t||t&&A(e,t)?S.merge([e],n):n}function ye(e,t){for(var n=0,r=e.length;n<r;n++)Y.set(e[n],"globalEval",!t||Y.get(t[n],"globalEval"))}ge.tbody=ge.tfoot=ge.colgroup=ge.caption=ge.thead,ge.th=ge.td,y.option||(ge.optgroup=ge.option=[1,"<select multiple='multiple'>","</select>"]);var me=/<|&#?\w+;/;function xe(e,t,n,r,i){for(var o,a,s,u,l,c,f=t.createDocumentFragment(),p=[],d=0,h=e.length;d<h;d++)if((o=e[d])||0===o)if("object"===w(o))S.merge(p,o.nodeType?[o]:o);else if(me.test(o)){a=a||f.appendChild(t.createElement("div")),s=(de.exec(o)||["",""])[1].toLowerCase(),u=ge[s]||ge._default,a.innerHTML=u[1]+S.htmlPrefilter(o)+u[2],c=u[0];while(c--)a=a.lastChild;S.merge(p,a.childNodes),(a=f.firstChild).textContent=""}else p.push(t.createTextNode(o));f.textContent="",d=0;while(o=p[d++])if(r&&-1<S.inArray(o,r))i&&i.push(o);else if(l=ie(o),a=ve(f.appendChild(o),"script"),l&&ye(a),n){c=0;while(o=a[c++])he.test(o.type||"")&&n.push(o)}return f}var be=/^([^.]*)(?:\.(.+)|)/;function we(){return!0}function Te(){return!1}function Ce(e,t){return e===function(){try{return E.activeElement}catch(e){}}()==("focus"===t)}function Ee(e,t,n,r,i,o){var a,s;if("object"==typeof t){for(s in"string"!=typeof n&&(r=r||n,n=void 0),t)Ee(e,s,n,r,t[s],o);return e}if(null==r&&null==i?(i=n,r=n=void 0):null==i&&("string"==typeof n?(i=r,r=void 0):(i=r,r=n,n=void 0)),!1===i)i=Te;else if(!i)return e;return 1===o&&(a=i,(i=function(e){return S().off(e),a.apply(this,arguments)}).guid=a.guid||(a.guid=S.guid++)),e.each(function(){S.event.add(this,t,i,r,n)})}function Se(e,i,o){o?(Y.set(e,i,!1),S.event.add(e,i,{namespace:!1,handler:function(e){var t,n,r=Y.get(this,i);if(1&e.isTrigger&&this[i]){if(r.length)(S.event.special[i]||{}).delegateType&&e.stopPropagation();else if(r=s.call(arguments),Y.set(this,i,r),t=o(this,i),this[i](),r!==(n=Y.get(this,i))||t?Y.set(this,i,!1):n={},r!==n)return e.stopImmediatePropagation(),e.preventDefault(),n&&n.value}else r.length&&(Y.set(this,i,{value:S.event.trigger(S.extend(r[0],S.Event.prototype),r.slice(1),this)}),e.stopImmediatePropagation())}})):void 0===Y.get(e,i)&&S.event.add(e,i,we)}S.event={global:{},add:function(t,e,n,r,i){var o,a,s,u,l,c,f,p,d,h,g,v=Y.get(t);if(V(t)){n.handler&&(n=(o=n).handler,i=o.selector),i&&S.find.matchesSelector(re,i),n.guid||(n.guid=S.guid++),(u=v.events)||(u=v.events=Object.create(null)),(a=v.handle)||(a=v.handle=function(e){return"undefined"!=typeof S&&S.event.triggered!==e.type?S.event.dispatch.apply(t,arguments):void 0}),l=(e=(e||"").match(P)||[""]).length;while(l--)d=g=(s=be.exec(e[l])||[])[1],h=(s[2]||"").split(".").sort(),d&&(f=S.event.special[d]||{},d=(i?f.delegateType:f.bindType)||d,f=S.event.special[d]||{},c=S.extend({type:d,origType:g,data:r,handler:n,guid:n.guid,selector:i,needsContext:i&&S.expr.match.needsContext.test(i),namespace:h.join(".")},o),(p=u[d])||((p=u[d]=[]).delegateCount=0,f.setup&&!1!==f.setup.call(t,r,h,a)||t.addEventListener&&t.addEventListener(d,a)),f.add&&(f.add.call(t,c),c.handler.guid||(c.handler.guid=n.guid)),i?p.splice(p.delegateCount++,0,c):p.push(c),S.event.global[d]=!0)}},remove:function(e,t,n,r,i){var o,a,s,u,l,c,f,p,d,h,g,v=Y.hasData(e)&&Y.get(e);if(v&&(u=v.events)){l=(t=(t||"").match(P)||[""]).length;while(l--)if(d=g=(s=be.exec(t[l])||[])[1],h=(s[2]||"").split(".").sort(),d){f=S.event.special[d]||{},p=u[d=(r?f.delegateType:f.bindType)||d]||[],s=s[2]&&new RegExp("(^|\\.)"+h.join("\\.(?:.*\\.|)")+"(\\.|$)"),a=o=p.length;while(o--)c=p[o],!i&&g!==c.origType||n&&n.guid!==c.guid||s&&!s.test(c.namespace)||r&&r!==c.selector&&("**"!==r||!c.selector)||(p.splice(o,1),c.selector&&p.delegateCount--,f.remove&&f.remove.call(e,c));a&&!p.length&&(f.teardown&&!1!==f.teardown.call(e,h,v.handle)||S.removeEvent(e,d,v.handle),delete u[d])}else for(d in u)S.event.remove(e,d+t[l],n,r,!0);S.isEmptyObject(u)&&Y.remove(e,"handle events")}},dispatch:function(e){var t,n,r,i,o,a,s=new Array(arguments.length),u=S.event.fix(e),l=(Y.get(this,"events")||Object.create(null))[u.type]||[],c=S.event.special[u.type]||{};for(s[0]=u,t=1;t<arguments.length;t++)s[t]=arguments[t];if(u.delegateTarget=this,!c.preDispatch||!1!==c.preDispatch.call(this,u)){a=S.event.handlers.call(this,u,l),t=0;while((i=a[t++])&&!u.isPropagationStopped()){u.currentTarget=i.elem,n=0;while((o=i.handlers[n++])&&!u.isImmediatePropagationStopped())u.rnamespace&&!1!==o.namespace&&!u.rnamespace.test(o.namespace)||(u.handleObj=o,u.data=o.data,void 0!==(r=((S.event.special[o.origType]||{}).handle||o.handler).apply(i.elem,s))&&!1===(u.result=r)&&(u.preventDefault(),u.stopPropagation()))}return c.postDispatch&&c.postDispatch.call(this,u),u.result}},handlers:function(e,t){var n,r,i,o,a,s=[],u=t.delegateCount,l=e.target;if(u&&l.nodeType&&!("click"===e.type&&1<=e.button))for(;l!==this;l=l.parentNode||this)if(1===l.nodeType&&("click"!==e.type||!0!==l.disabled)){for(o=[],a={},n=0;n<u;n++)void 0===a[i=(r=t[n]).selector+" "]&&(a[i]=r.needsContext?-1<S(i,this).index(l):S.find(i,this,null,[l]).length),a[i]&&o.push(r);o.length&&s.push({elem:l,handlers:o})}return l=this,u<t.length&&s.push({elem:l,handlers:t.slice(u)}),s},addProp:function(t,e){Object.defineProperty(S.Event.prototype,t,{enumerable:!0,configurable:!0,get:m(e)?function(){if(this.originalEvent)return e(this.originalEvent)}:function(){if(this.originalEvent)return this.originalEvent[t]},set:function(e){Object.defineProperty(this,t,{enumerable:!0,configurable:!0,writable:!0,value:e})}})},fix:function(e){return e[S.expando]?e:new S.Event(e)},special:{load:{noBubble:!0},click:{setup:function(e){var t=this||e;return pe.test(t.type)&&t.click&&A(t,"input")&&Se(t,"click",we),!1},trigger:function(e){var t=this||e;return pe.test(t.type)&&t.click&&A(t,"input")&&Se(t,"click"),!0},_default:function(e){var t=e.target;return pe.test(t.type)&&t.click&&A(t,"input")&&Y.get(t,"click")||A(t,"a")}},beforeunload:{postDispatch:function(e){void 0!==e.result&&e.originalEvent&&(e.originalEvent.returnValue=e.result)}}}},S.removeEvent=function(e,t,n){e.removeEventListener&&e.removeEventListener(t,n)},S.Event=function(e,t){if(!(this instanceof S.Event))return new S.Event(e,t);e&&e.type?(this.originalEvent=e,this.type=e.type,this.isDefaultPrevented=e.defaultPrevented||void 0===e.defaultPrevented&&!1===e.returnValue?we:Te,this.target=e.target&&3===e.target.nodeType?e.target.parentNode:e.target,this.currentTarget=e.currentTarget,this.relatedTarget=e.relatedTarget):this.type=e,t&&S.extend(this,t),this.timeStamp=e&&e.timeStamp||Date.now(),this[S.expando]=!0},S.Event.prototype={constructor:S.Event,isDefaultPrevented:Te,isPropagationStopped:Te,isImmediatePropagationStopped:Te,isSimulated:!1,preventDefault:function(){var e=this.originalEvent;this.isDefaultPrevented=we,e&&!this.isSimulated&&e.preventDefault()},stopPropagation:function(){var e=this.originalEvent;this.isPropagationStopped=we,e&&!this.isSimulated&&e.stopPropagation()},stopImmediatePropagation:function(){var e=this.originalEvent;this.isImmediatePropagationStopped=we,e&&!this.isSimulated&&e.stopImmediatePropagation(),this.stopPropagation()}},S.each({altKey:!0,bubbles:!0,cancelable:!0,changedTouches:!0,ctrlKey:!0,detail:!0,eventPhase:!0,metaKey:!0,pageX:!0,pageY:!0,shiftKey:!0,view:!0,"char":!0,code:!0,charCode:!0,key:!0,keyCode:!0,button:!0,buttons:!0,clientX:!0,clientY:!0,offsetX:!0,offsetY:!0,pointerId:!0,pointerType:!0,screenX:!0,screenY:!0,targetTouches:!0,toElement:!0,touches:!0,which:!0},S.event.addProp),S.each({focus:"focusin",blur:"focusout"},function(e,t){S.event.special[e]={setup:function(){return Se(this,e,Ce),!1},trigger:function(){return Se(this,e),!0},_default:function(){return!0},delegateType:t}}),S.each({mouseenter:"mouseover",mouseleave:"mouseout",pointerenter:"pointerover",pointerleave:"pointerout"},function(e,i){S.event.special[e]={delegateType:i,bindType:i,handle:function(e){var t,n=e.relatedTarget,r=e.handleObj;return n&&(n===this||S.contains(this,n))||(e.type=r.origType,t=r.handler.apply(this,arguments),e.type=i),t}}}),S.fn.extend({on:function(e,t,n,r){return Ee(this,e,t,n,r)},one:function(e,t,n,r){return Ee(this,e,t,n,r,1)},off:function(e,t,n){var r,i;if(e&&e.preventDefault&&e.handleObj)return r=e.handleObj,S(e.delegateTarget).off(r.namespace?r.origType+"."+r.namespace:r.origType,r.selector,r.handler),this;if("object"==typeof e){for(i in e)this.off(i,t,e[i]);return this}return!1!==t&&"function"!=typeof t||(n=t,t=void 0),!1===n&&(n=Te),this.each(function(){S.event.remove(this,e,n,t)})}});var ke=/<script|<style|<link/i,Ae=/checked\s*(?:[^=]|=\s*.checked.)/i,Ne=/^\s*<!(?:\[CDATA\[|--)|(?:\]\]|--)>\s*$/g;function je(e,t){return A(e,"table")&&A(11!==t.nodeType?t:t.firstChild,"tr")&&S(e).children("tbody")[0]||e}function De(e){return e.type=(null!==e.getAttribute("type"))+"/"+e.type,e}function qe(e){return"true/"===(e.type||"").slice(0,5)?e.type=e.type.slice(5):e.removeAttribute("type"),e}function Le(e,t){var n,r,i,o,a,s;if(1===t.nodeType){if(Y.hasData(e)&&(s=Y.get(e).events))for(i in Y.remove(t,"handle events"),s)for(n=0,r=s[i].length;n<r;n++)S.event.add(t,i,s[i][n]);Q.hasData(e)&&(o=Q.access(e),a=S.extend({},o),Q.set(t,a))}}function He(n,r,i,o){r=g(r);var e,t,a,s,u,l,c=0,f=n.length,p=f-1,d=r[0],h=m(d);if(h||1<f&&"string"==typeof d&&!y.checkClone&&Ae.test(d))return n.each(function(e){var t=n.eq(e);h&&(r[0]=d.call(this,e,t.html())),He(t,r,i,o)});if(f&&(t=(e=xe(r,n[0].ownerDocument,!1,n,o)).firstChild,1===e.childNodes.length&&(e=t),t||o)){for(s=(a=S.map(ve(e,"script"),De)).length;c<f;c++)u=e,c!==p&&(u=S.clone(u,!0,!0),s&&S.merge(a,ve(u,"script"))),i.call(n[c],u,c);if(s)for(l=a[a.length-1].ownerDocument,S.map(a,qe),c=0;c<s;c++)u=a[c],he.test(u.type||"")&&!Y.access(u,"globalEval")&&S.contains(l,u)&&(u.src&&"module"!==(u.type||"").toLowerCase()?S._evalUrl&&!u.noModule&&S._evalUrl(u.src,{nonce:u.nonce||u.getAttribute("nonce")},l):b(u.textContent.replace(Ne,""),u,l))}return n}function Oe(e,t,n){for(var r,i=t?S.filter(t,e):e,o=0;null!=(r=i[o]);o++)n||1!==r.nodeType||S.cleanData(ve(r)),r.parentNode&&(n&&ie(r)&&ye(ve(r,"script")),r.parentNode.removeChild(r));return e}S.extend({htmlPrefilter:function(e){return e},clone:function(e,t,n){var r,i,o,a,s,u,l,c=e.cloneNode(!0),f=ie(e);if(!(y.noCloneChecked||1!==e.nodeType&&11!==e.nodeType||S.isXMLDoc(e)))for(a=ve(c),r=0,i=(o=ve(e)).length;r<i;r++)s=o[r],u=a[r],void 0,"input"===(l=u.nodeName.toLowerCase())&&pe.test(s.type)?u.checked=s.checked:"input"!==l&&"textarea"!==l||(u.defaultValue=s.defaultValue);if(t)if(n)for(o=o||ve(e),a=a||ve(c),r=0,i=o.length;r<i;r++)Le(o[r],a[r]);else Le(e,c);return 0<(a=ve(c,"script")).length&&ye(a,!f&&ve(e,"script")),c},cleanData:function(e){for(var t,n,r,i=S.event.special,o=0;void 0!==(n=e[o]);o++)if(V(n)){if(t=n[Y.expando]){if(t.events)for(r in t.events)i[r]?S.event.remove(n,r):S.removeEvent(n,r,t.handle);n[Y.expando]=void 0}n[Q.expando]&&(n[Q.expando]=void 0)}}}),S.fn.extend({detach:function(e){return Oe(this,e,!0)},remove:function(e){return Oe(this,e)},text:function(e){return $(this,function(e){return void 0===e?S.text(this):this.empty().each(function(){1!==this.nodeType&&11!==this.nodeType&&9!==this.nodeType||(this.textContent=e)})},null,e,arguments.length)},append:function(){return He(this,arguments,function(e){1!==this.nodeType&&11!==this.nodeType&&9!==this.nodeType||je(this,e).appendChild(e)})},prepend:function(){return He(this,arguments,function(e){if(1===this.nodeType||11===this.nodeType||9===this.nodeType){var t=je(this,e);t.insertBefore(e,t.firstChild)}})},before:function(){return He(this,arguments,function(e){this.parentNode&&this.parentNode.insertBefore(e,this)})},after:function(){return He(this,arguments,function(e){this.parentNode&&this.parentNode.insertBefore(e,this.nextSibling)})},empty:function(){for(var e,t=0;null!=(e=this[t]);t++)1===e.nodeType&&(S.cleanData(ve(e,!1)),e.textContent="");return this},clone:function(e,t){return e=null!=e&&e,t=null==t?e:t,this.map(function(){return S.clone(this,e,t)})},html:function(e){return $(this,function(e){var t=this[0]||{},n=0,r=this.length;if(void 0===e&&1===t.nodeType)return t.innerHTML;if("string"==typeof e&&!ke.test(e)&&!ge[(de.exec(e)||["",""])[1].toLowerCase()]){e=S.htmlPrefilter(e);try{for(;n<r;n++)1===(t=this[n]||{}).nodeType&&(S.cleanData(ve(t,!1)),t.innerHTML=e);t=0}catch(e){}}t&&this.empty().append(e)},null,e,arguments.length)},replaceWith:function(){var n=[];return He(this,arguments,function(e){var t=this.parentNode;S.inArray(this,n)<0&&(S.cleanData(ve(this)),t&&t.replaceChild(e,this))},n)}}),S.each({appendTo:"append",prependTo:"prepend",insertBefore:"before",insertAfter:"after",replaceAll:"replaceWith"},function(e,a){S.fn[e]=function(e){for(var t,n=[],r=S(e),i=r.length-1,o=0;o<=i;o++)t=o===i?this:this.clone(!0),S(r[o])[a](t),u.apply(n,t.get());return this.pushStack(n)}});var Pe=new RegExp("^("+ee+")(?!px)[a-z%]+$","i"),Re=function(e){var t=e.ownerDocument.defaultView;return t&&t.opener||(t=C),t.getComputedStyle(e)},Me=function(e,t,n){var r,i,o={};for(i in t)o[i]=e.style[i],e.style[i]=t[i];for(i in r=n.call(e),t)e.style[i]=o[i];return r},Ie=new RegExp(ne.join("|"),"i");function We(e,t,n){var r,i,o,a,s=e.style;return(n=n||Re(e))&&(""!==(a=n.getPropertyValue(t)||n[t])||ie(e)||(a=S.style(e,t)),!y.pixelBoxStyles()&&Pe.test(a)&&Ie.test(t)&&(r=s.width,i=s.minWidth,o=s.maxWidth,s.minWidth=s.maxWidth=s.width=a,a=n.width,s.width=r,s.minWidth=i,s.maxWidth=o)),void 0!==a?a+"":a}function Fe(e,t){return{get:function(){if(!e())return(this.get=t).apply(this,arguments);delete this.get}}}!function(){function e(){if(l){u.style.cssText="position:absolute;left:-11111px;width:60px;margin-top:1px;padding:0;border:0",l.style.cssText="position:relative;display:block;box-sizing:border-box;overflow:scroll;margin:auto;border:1px;padding:1px;width:60%;top:1%",re.appendChild(u).appendChild(l);var e=C.getComputedStyle(l);n="1%"!==e.top,s=12===t(e.marginLeft),l.style.right="60%",o=36===t(e.right),r=36===t(e.width),l.style.position="absolute",i=12===t(l.offsetWidth/3),re.removeChild(u),l=null}}function t(e){return Math.round(parseFloat(e))}var n,r,i,o,a,s,u=E.createElement("div"),l=E.createElement("div");l.style&&(l.style.backgroundClip="content-box",l.cloneNode(!0).style.backgroundClip="",y.clearCloneStyle="content-box"===l.style.backgroundClip,S.extend(y,{boxSizingReliable:function(){return e(),r},pixelBoxStyles:function(){return e(),o},pixelPosition:function(){return e(),n},reliableMarginLeft:function(){return e(),s},scrollboxSize:function(){return e(),i},reliableTrDimensions:function(){var e,t,n,r;return null==a&&(e=E.createElement("table"),t=E.createElement("tr"),n=E.createElement("div"),e.style.cssText="position:absolute;left:-11111px;border-collapse:separate",t.style.cssText="border:1px solid",t.style.height="1px",n.style.height="9px",n.style.display="block",re.appendChild(e).appendChild(t).appendChild(n),r=C.getComputedStyle(t),a=parseInt(r.height,10)+parseInt(r.borderTopWidth,10)+parseInt(r.borderBottomWidth,10)===t.offsetHeight,re.removeChild(e)),a}}))}();var Be=["Webkit","Moz","ms"],$e=E.createElement("div").style,_e={};function ze(e){var t=S.cssProps[e]||_e[e];return t||(e in $e?e:_e[e]=function(e){var t=e[0].toUpperCase()+e.slice(1),n=Be.length;while(n--)if((e=Be[n]+t)in $e)return e}(e)||e)}var Ue=/^(none|table(?!-c[ea]).+)/,Xe=/^--/,Ve={position:"absolute",visibility:"hidden",display:"block"},Ge={letterSpacing:"0",fontWeight:"400"};function Ye(e,t,n){var r=te.exec(t);return r?Math.max(0,r[2]-(n||0))+(r[3]||"px"):t}function Qe(e,t,n,r,i,o){var a="width"===t?1:0,s=0,u=0;if(n===(r?"border":"content"))return 0;for(;a<4;a+=2)"margin"===n&&(u+=S.css(e,n+ne[a],!0,i)),r?("content"===n&&(u-=S.css(e,"padding"+ne[a],!0,i)),"margin"!==n&&(u-=S.css(e,"border"+ne[a]+"Width",!0,i))):(u+=S.css(e,"padding"+ne[a],!0,i),"padding"!==n?u+=S.css(e,"border"+ne[a]+"Width",!0,i):s+=S.css(e,"border"+ne[a]+"Width",!0,i));return!r&&0<=o&&(u+=Math.max(0,Math.ceil(e["offset"+t[0].toUpperCase()+t.slice(1)]-o-u-s-.5))||0),u}function Je(e,t,n){var r=Re(e),i=(!y.boxSizingReliable()||n)&&"border-box"===S.css(e,"boxSizing",!1,r),o=i,a=We(e,t,r),s="offset"+t[0].toUpperCase()+t.slice(1);if(Pe.test(a)){if(!n)return a;a="auto"}return(!y.boxSizingReliable()&&i||!y.reliableTrDimensions()&&A(e,"tr")||"auto"===a||!parseFloat(a)&&"inline"===S.css(e,"display",!1,r))&&e.getClientRects().length&&(i="border-box"===S.css(e,"boxSizing",!1,r),(o=s in e)&&(a=e[s])),(a=parseFloat(a)||0)+Qe(e,t,n||(i?"border":"content"),o,r,a)+"px"}function Ke(e,t,n,r,i){return new Ke.prototype.init(e,t,n,r,i)}S.extend({cssHooks:{opacity:{get:function(e,t){if(t){var n=We(e,"opacity");return""===n?"1":n}}}},cssNumber:{animationIterationCount:!0,columnCount:!0,fillOpacity:!0,flexGrow:!0,flexShrink:!0,fontWeight:!0,gridArea:!0,gridColumn:!0,gridColumnEnd:!0,gridColumnStart:!0,gridRow:!0,gridRowEnd:!0,gridRowStart:!0,lineHeight:!0,opacity:!0,order:!0,orphans:!0,widows:!0,zIndex:!0,zoom:!0},cssProps:{},style:function(e,t,n,r){if(e&&3!==e.nodeType&&8!==e.nodeType&&e.style){var i,o,a,s=X(t),u=Xe.test(t),l=e.style;if(u||(t=ze(s)),a=S.cssHooks[t]||S.cssHooks[s],void 0===n)return a&&"get"in a&&void 0!==(i=a.get(e,!1,r))?i:l[t];"string"===(o=typeof n)&&(i=te.exec(n))&&i[1]&&(n=se(e,t,i),o="number"),null!=n&&n==n&&("number"!==o||u||(n+=i&&i[3]||(S.cssNumber[s]?"":"px")),y.clearCloneStyle||""!==n||0!==t.indexOf("background")||(l[t]="inherit"),a&&"set"in a&&void 0===(n=a.set(e,n,r))||(u?l.setProperty(t,n):l[t]=n))}},css:function(e,t,n,r){var i,o,a,s=X(t);return Xe.test(t)||(t=ze(s)),(a=S.cssHooks[t]||S.cssHooks[s])&&"get"in a&&(i=a.get(e,!0,n)),void 0===i&&(i=We(e,t,r)),"normal"===i&&t in Ge&&(i=Ge[t]),""===n||n?(o=parseFloat(i),!0===n||isFinite(o)?o||0:i):i}}),S.each(["height","width"],function(e,u){S.cssHooks[u]={get:function(e,t,n){if(t)return!Ue.test(S.css(e,"display"))||e.getClientRects().length&&e.getBoundingClientRect().width?Je(e,u,n):Me(e,Ve,function(){return Je(e,u,n)})},set:function(e,t,n){var r,i=Re(e),o=!y.scrollboxSize()&&"absolute"===i.position,a=(o||n)&&"border-box"===S.css(e,"boxSizing",!1,i),s=n?Qe(e,u,n,a,i):0;return a&&o&&(s-=Math.ceil(e["offset"+u[0].toUpperCase()+u.slice(1)]-parseFloat(i[u])-Qe(e,u,"border",!1,i)-.5)),s&&(r=te.exec(t))&&"px"!==(r[3]||"px")&&(e.style[u]=t,t=S.css(e,u)),Ye(0,t,s)}}}),S.cssHooks.marginLeft=Fe(y.reliableMarginLeft,function(e,t){if(t)return(parseFloat(We(e,"marginLeft"))||e.getBoundingClientRect().left-Me(e,{marginLeft:0},function(){return e.getBoundingClientRect().left}))+"px"}),S.each({margin:"",padding:"",border:"Width"},function(i,o){S.cssHooks[i+o]={expand:function(e){for(var t=0,n={},r="string"==typeof e?e.split(" "):[e];t<4;t++)n[i+ne[t]+o]=r[t]||r[t-2]||r[0];return n}},"margin"!==i&&(S.cssHooks[i+o].set=Ye)}),S.fn.extend({css:function(e,t){return $(this,function(e,t,n){var r,i,o={},a=0;if(Array.isArray(t)){for(r=Re(e),i=t.length;a<i;a++)o[t[a]]=S.css(e,t[a],!1,r);return o}return void 0!==n?S.style(e,t,n):S.css(e,t)},e,t,1<arguments.length)}}),((S.Tween=Ke).prototype={constructor:Ke,init:function(e,t,n,r,i,o){this.elem=e,this.prop=n,this.easing=i||S.easing._default,this.options=t,this.start=this.now=this.cur(),this.end=r,this.unit=o||(S.cssNumber[n]?"":"px")},cur:function(){var e=Ke.propHooks[this.prop];return e&&e.get?e.get(this):Ke.propHooks._default.get(this)},run:function(e){var t,n=Ke.propHooks[this.prop];return this.options.duration?this.pos=t=S.easing[this.easing](e,this.options.duration*e,0,1,this.options.duration):this.pos=t=e,this.now=(this.end-this.start)*t+this.start,this.options.step&&this.options.step.call(this.elem,this.now,this),n&&n.set?n.set(this):Ke.propHooks._default.set(this),this}}).init.prototype=Ke.prototype,(Ke.propHooks={_default:{get:function(e){var t;return 1!==e.elem.nodeType||null!=e.elem[e.prop]&&null==e.elem.style[e.prop]?e.elem[e.prop]:(t=S.css(e.elem,e.prop,""))&&"auto"!==t?t:0},set:function(e){S.fx.step[e.prop]?S.fx.step[e.prop](e):1!==e.elem.nodeType||!S.cssHooks[e.prop]&&null==e.elem.style[ze(e.prop)]?e.elem[e.prop]=e.now:S.style(e.elem,e.prop,e.now+e.unit)}}}).scrollTop=Ke.propHooks.scrollLeft={set:function(e){e.elem.nodeType&&e.elem.parentNode&&(e.elem[e.prop]=e.now)}},S.easing={linear:function(e){return e},swing:function(e){return.5-Math.cos(e*Math.PI)/2},_default:"swing"},S.fx=Ke.prototype.init,S.fx.step={};var Ze,et,tt,nt,rt=/^(?:toggle|show|hide)$/,it=/queueHooks$/;function ot(){et&&(!1===E.hidden&&C.requestAnimationFrame?C.requestAnimationFrame(ot):C.setTimeout(ot,S.fx.interval),S.fx.tick())}function at(){return C.setTimeout(function(){Ze=void 0}),Ze=Date.now()}function st(e,t){var n,r=0,i={height:e};for(t=t?1:0;r<4;r+=2-t)i["margin"+(n=ne[r])]=i["padding"+n]=e;return t&&(i.opacity=i.width=e),i}function ut(e,t,n){for(var r,i=(lt.tweeners[t]||[]).concat(lt.tweeners["*"]),o=0,a=i.length;o<a;o++)if(r=i[o].call(n,t,e))return r}function lt(o,e,t){var n,a,r=0,i=lt.prefilters.length,s=S.Deferred().always(function(){delete u.elem}),u=function(){if(a)return!1;for(var e=Ze||at(),t=Math.max(0,l.startTime+l.duration-e),n=1-(t/l.duration||0),r=0,i=l.tweens.length;r<i;r++)l.tweens[r].run(n);return s.notifyWith(o,[l,n,t]),n<1&&i?t:(i||s.notifyWith(o,[l,1,0]),s.resolveWith(o,[l]),!1)},l=s.promise({elem:o,props:S.extend({},e),opts:S.extend(!0,{specialEasing:{},easing:S.easing._default},t),originalProperties:e,originalOptions:t,startTime:Ze||at(),duration:t.duration,tweens:[],createTween:function(e,t){var n=S.Tween(o,l.opts,e,t,l.opts.specialEasing[e]||l.opts.easing);return l.tweens.push(n),n},stop:function(e){var t=0,n=e?l.tweens.length:0;if(a)return this;for(a=!0;t<n;t++)l.tweens[t].run(1);return e?(s.notifyWith(o,[l,1,0]),s.resolveWith(o,[l,e])):s.rejectWith(o,[l,e]),this}}),c=l.props;for(!function(e,t){var n,r,i,o,a;for(n in e)if(i=t[r=X(n)],o=e[n],Array.isArray(o)&&(i=o[1],o=e[n]=o[0]),n!==r&&(e[r]=o,delete e[n]),(a=S.cssHooks[r])&&"expand"in a)for(n in o=a.expand(o),delete e[r],o)n in e||(e[n]=o[n],t[n]=i);else t[r]=i}(c,l.opts.specialEasing);r<i;r++)if(n=lt.prefilters[r].call(l,o,c,l.opts))return m(n.stop)&&(S._queueHooks(l.elem,l.opts.queue).stop=n.stop.bind(n)),n;return S.map(c,ut,l),m(l.opts.start)&&l.opts.start.call(o,l),l.progress(l.opts.progress).done(l.opts.done,l.opts.complete).fail(l.opts.fail).always(l.opts.always),S.fx.timer(S.extend(u,{elem:o,anim:l,queue:l.opts.queue})),l}S.Animation=S.extend(lt,{tweeners:{"*":[function(e,t){var n=this.createTween(e,t);return se(n.elem,e,te.exec(t),n),n}]},tweener:function(e,t){m(e)?(t=e,e=["*"]):e=e.match(P);for(var n,r=0,i=e.length;r<i;r++)n=e[r],lt.tweeners[n]=lt.tweeners[n]||[],lt.tweeners[n].unshift(t)},prefilters:[function(e,t,n){var r,i,o,a,s,u,l,c,f="width"in t||"height"in t,p=this,d={},h=e.style,g=e.nodeType&&ae(e),v=Y.get(e,"fxshow");for(r in n.queue||(null==(a=S._queueHooks(e,"fx")).unqueued&&(a.unqueued=0,s=a.empty.fire,a.empty.fire=function(){a.unqueued||s()}),a.unqueued++,p.always(function(){p.always(function(){a.unqueued--,S.queue(e,"fx").length||a.empty.fire()})})),t)if(i=t[r],rt.test(i)){if(delete t[r],o=o||"toggle"===i,i===(g?"hide":"show")){if("show"!==i||!v||void 0===v[r])continue;g=!0}d[r]=v&&v[r]||S.style(e,r)}if((u=!S.isEmptyObject(t))||!S.isEmptyObject(d))for(r in f&&1===e.nodeType&&(n.overflow=[h.overflow,h.overflowX,h.overflowY],null==(l=v&&v.display)&&(l=Y.get(e,"display")),"none"===(c=S.css(e,"display"))&&(l?c=l:(le([e],!0),l=e.style.display||l,c=S.css(e,"display"),le([e]))),("inline"===c||"inline-block"===c&&null!=l)&&"none"===S.css(e,"float")&&(u||(p.done(function(){h.display=l}),null==l&&(c=h.display,l="none"===c?"":c)),h.display="inline-block")),n.overflow&&(h.overflow="hidden",p.always(function(){h.overflow=n.overflow[0],h.overflowX=n.overflow[1],h.overflowY=n.overflow[2]})),u=!1,d)u||(v?"hidden"in v&&(g=v.hidden):v=Y.access(e,"fxshow",{display:l}),o&&(v.hidden=!g),g&&le([e],!0),p.done(function(){for(r in g||le([e]),Y.remove(e,"fxshow"),d)S.style(e,r,d[r])})),u=ut(g?v[r]:0,r,p),r in v||(v[r]=u.start,g&&(u.end=u.start,u.start=0))}],prefilter:function(e,t){t?lt.prefilters.unshift(e):lt.prefilters.push(e)}}),S.speed=function(e,t,n){var r=e&&"object"==typeof e?S.extend({},e):{complete:n||!n&&t||m(e)&&e,duration:e,easing:n&&t||t&&!m(t)&&t};return S.fx.off?r.duration=0:"number"!=typeof r.duration&&(r.duration in S.fx.speeds?r.duration=S.fx.speeds[r.duration]:r.duration=S.fx.speeds._default),null!=r.queue&&!0!==r.queue||(r.queue="fx"),r.old=r.complete,r.complete=function(){m(r.old)&&r.old.call(this),r.queue&&S.dequeue(this,r.queue)},r},S.fn.extend({fadeTo:function(e,t,n,r){return this.filter(ae).css("opacity",0).show().end().animate({opacity:t},e,n,r)},animate:function(t,e,n,r){var i=S.isEmptyObject(t),o=S.speed(e,n,r),a=function(){var e=lt(this,S.extend({},t),o);(i||Y.get(this,"finish"))&&e.stop(!0)};return a.finish=a,i||!1===o.queue?this.each(a):this.queue(o.queue,a)},stop:function(i,e,o){var a=function(e){var t=e.stop;delete e.stop,t(o)};return"string"!=typeof i&&(o=e,e=i,i=void 0),e&&this.queue(i||"fx",[]),this.each(function(){var e=!0,t=null!=i&&i+"queueHooks",n=S.timers,r=Y.get(this);if(t)r[t]&&r[t].stop&&a(r[t]);else for(t in r)r[t]&&r[t].stop&&it.test(t)&&a(r[t]);for(t=n.length;t--;)n[t].elem!==this||null!=i&&n[t].queue!==i||(n[t].anim.stop(o),e=!1,n.splice(t,1));!e&&o||S.dequeue(this,i)})},finish:function(a){return!1!==a&&(a=a||"fx"),this.each(function(){var e,t=Y.get(this),n=t[a+"queue"],r=t[a+"queueHooks"],i=S.timers,o=n?n.length:0;for(t.finish=!0,S.queue(this,a,[]),r&&r.stop&&r.stop.call(this,!0),e=i.length;e--;)i[e].elem===this&&i[e].queue===a&&(i[e].anim.stop(!0),i.splice(e,1));for(e=0;e<o;e++)n[e]&&n[e].finish&&n[e].finish.call(this);delete t.finish})}}),S.each(["toggle","show","hide"],function(e,r){var i=S.fn[r];S.fn[r]=function(e,t,n){return null==e||"boolean"==typeof e?i.apply(this,arguments):this.animate(st(r,!0),e,t,n)}}),S.each({slideDown:st("show"),slideUp:st("hide"),slideToggle:st("toggle"),fadeIn:{opacity:"show"},fadeOut:{opacity:"hide"},fadeToggle:{opacity:"toggle"}},function(e,r){S.fn[e]=function(e,t,n){return this.animate(r,e,t,n)}}),S.timers=[],S.fx.tick=function(){var e,t=0,n=S.timers;for(Ze=Date.now();t<n.length;t++)(e=n[t])()||n[t]!==e||n.splice(t--,1);n.length||S.fx.stop(),Ze=void 0},S.fx.timer=function(e){S.timers.push(e),S.fx.start()},S.fx.interval=13,S.fx.start=function(){et||(et=!0,ot())},S.fx.stop=function(){et=null},S.fx.speeds={slow:600,fast:200,_default:400},S.fn.delay=function(r,e){return r=S.fx&&S.fx.speeds[r]||r,e=e||"fx",this.queue(e,function(e,t){var n=C.setTimeout(e,r);t.stop=function(){C.clearTimeout(n)}})},tt=E.createElement("input"),nt=E.createElement("select").appendChild(E.createElement("option")),tt.type="checkbox",y.checkOn=""!==tt.value,y.optSelected=nt.selected,(tt=E.createElement("input")).value="t",tt.type="radio",y.radioValue="t"===tt.value;var ct,ft=S.expr.attrHandle;S.fn.extend({attr:function(e,t){return $(this,S.attr,e,t,1<arguments.length)},removeAttr:function(e){return this.each(function(){S.removeAttr(this,e)})}}),S.extend({attr:function(e,t,n){var r,i,o=e.nodeType;if(3!==o&&8!==o&&2!==o)return"undefined"==typeof e.getAttribute?S.prop(e,t,n):(1===o&&S.isXMLDoc(e)||(i=S.attrHooks[t.toLowerCase()]||(S.expr.match.bool.test(t)?ct:void 0)),void 0!==n?null===n?void S.removeAttr(e,t):i&&"set"in i&&void 0!==(r=i.set(e,n,t))?r:(e.setAttribute(t,n+""),n):i&&"get"in i&&null!==(r=i.get(e,t))?r:null==(r=S.find.attr(e,t))?void 0:r)},attrHooks:{type:{set:function(e,t){if(!y.radioValue&&"radio"===t&&A(e,"input")){var n=e.value;return e.setAttribute("type",t),n&&(e.value=n),t}}}},removeAttr:function(e,t){var n,r=0,i=t&&t.match(P);if(i&&1===e.nodeType)while(n=i[r++])e.removeAttribute(n)}}),ct={set:function(e,t,n){return!1===t?S.removeAttr(e,n):e.setAttribute(n,n),n}},S.each(S.expr.match.bool.source.match(/\w+/g),function(e,t){var a=ft[t]||S.find.attr;ft[t]=function(e,t,n){var r,i,o=t.toLowerCase();return n||(i=ft[o],ft[o]=r,r=null!=a(e,t,n)?o:null,ft[o]=i),r}});var pt=/^(?:input|select|textarea|button)$/i,dt=/^(?:a|area)$/i;function ht(e){return(e.match(P)||[]).join(" ")}function gt(e){return e.getAttribute&&e.getAttribute("class")||""}function vt(e){return Array.isArray(e)?e:"string"==typeof e&&e.match(P)||[]}S.fn.extend({prop:function(e,t){return $(this,S.prop,e,t,1<arguments.length)},removeProp:function(e){return this.each(function(){delete this[S.propFix[e]||e]})}}),S.extend({prop:function(e,t,n){var r,i,o=e.nodeType;if(3!==o&&8!==o&&2!==o)return 1===o&&S.isXMLDoc(e)||(t=S.propFix[t]||t,i=S.propHooks[t]),void 0!==n?i&&"set"in i&&void 0!==(r=i.set(e,n,t))?r:e[t]=n:i&&"get"in i&&null!==(r=i.get(e,t))?r:e[t]},propHooks:{tabIndex:{get:function(e){var t=S.find.attr(e,"tabindex");return t?parseInt(t,10):pt.test(e.nodeName)||dt.test(e.nodeName)&&e.href?0:-1}}},propFix:{"for":"htmlFor","class":"className"}}),y.optSelected||(S.propHooks.selected={get:function(e){var t=e.parentNode;return t&&t.parentNode&&t.parentNode.selectedIndex,null},set:function(e){var t=e.parentNode;t&&(t.selectedIndex,t.parentNode&&t.parentNode.selectedIndex)}}),S.each(["tabIndex","readOnly","maxLength","cellSpacing","cellPadding","rowSpan","colSpan","useMap","frameBorder","contentEditable"],function(){S.propFix[this.toLowerCase()]=this}),S.fn.extend({addClass:function(t){var e,n,r,i,o,a,s,u=0;if(m(t))return this.each(function(e){S(this).addClass(t.call(this,e,gt(this)))});if((e=vt(t)).length)while(n=this[u++])if(i=gt(n),r=1===n.nodeType&&" "+ht(i)+" "){a=0;while(o=e[a++])r.indexOf(" "+o+" ")<0&&(r+=o+" ");i!==(s=ht(r))&&n.setAttribute("class",s)}return this},removeClass:function(t){var e,n,r,i,o,a,s,u=0;if(m(t))return this.each(function(e){S(this).removeClass(t.call(this,e,gt(this)))});if(!arguments.length)return this.attr("class","");if((e=vt(t)).length)while(n=this[u++])if(i=gt(n),r=1===n.nodeType&&" "+ht(i)+" "){a=0;while(o=e[a++])while(-1<r.indexOf(" "+o+" "))r=r.replace(" "+o+" "," ");i!==(s=ht(r))&&n.setAttribute("class",s)}return this},toggleClass:function(i,t){var o=typeof i,a="string"===o||Array.isArray(i);return"boolean"==typeof t&&a?t?this.addClass(i):this.removeClass(i):m(i)?this.each(function(e){S(this).toggleClass(i.call(this,e,gt(this),t),t)}):this.each(function(){var e,t,n,r;if(a){t=0,n=S(this),r=vt(i);while(e=r[t++])n.hasClass(e)?n.removeClass(e):n.addClass(e)}else void 0!==i&&"boolean"!==o||((e=gt(this))&&Y.set(this,"__className__",e),this.setAttribute&&this.setAttribute("class",e||!1===i?"":Y.get(this,"__className__")||""))})},hasClass:function(e){var t,n,r=0;t=" "+e+" ";while(n=this[r++])if(1===n.nodeType&&-1<(" "+ht(gt(n))+" ").indexOf(t))return!0;return!1}});var yt=/\r/g;S.fn.extend({val:function(n){var r,e,i,t=this[0];return arguments.length?(i=m(n),this.each(function(e){var t;1===this.nodeType&&(null==(t=i?n.call(this,e,S(this).val()):n)?t="":"number"==typeof t?t+="":Array.isArray(t)&&(t=S.map(t,function(e){return null==e?"":e+""})),(r=S.valHooks[this.type]||S.valHooks[this.nodeName.toLowerCase()])&&"set"in r&&void 0!==r.set(this,t,"value")||(this.value=t))})):t?(r=S.valHooks[t.type]||S.valHooks[t.nodeName.toLowerCase()])&&"get"in r&&void 0!==(e=r.get(t,"value"))?e:"string"==typeof(e=t.value)?e.replace(yt,""):null==e?"":e:void 0}}),S.extend({valHooks:{option:{get:function(e){var t=S.find.attr(e,"value");return null!=t?t:ht(S.text(e))}},select:{get:function(e){var t,n,r,i=e.options,o=e.selectedIndex,a="select-one"===e.type,s=a?null:[],u=a?o+1:i.length;for(r=o<0?u:a?o:0;r<u;r++)if(((n=i[r]).selected||r===o)&&!n.disabled&&(!n.parentNode.disabled||!A(n.parentNode,"optgroup"))){if(t=S(n).val(),a)return t;s.push(t)}return s},set:function(e,t){var n,r,i=e.options,o=S.makeArray(t),a=i.length;while(a--)((r=i[a]).selected=-1<S.inArray(S.valHooks.option.get(r),o))&&(n=!0);return n||(e.selectedIndex=-1),o}}}}),S.each(["radio","checkbox"],function(){S.valHooks[this]={set:function(e,t){if(Array.isArray(t))return e.checked=-1<S.inArray(S(e).val(),t)}},y.checkOn||(S.valHooks[this].get=function(e){return null===e.getAttribute("value")?"on":e.value})}),y.focusin="onfocusin"in C;var mt=/^(?:focusinfocus|focusoutblur)$/,xt=function(e){e.stopPropagation()};S.extend(S.event,{trigger:function(e,t,n,r){var i,o,a,s,u,l,c,f,p=[n||E],d=v.call(e,"type")?e.type:e,h=v.call(e,"namespace")?e.namespace.split("."):[];if(o=f=a=n=n||E,3!==n.nodeType&&8!==n.nodeType&&!mt.test(d+S.event.triggered)&&(-1<d.indexOf(".")&&(d=(h=d.split(".")).shift(),h.sort()),u=d.indexOf(":")<0&&"on"+d,(e=e[S.expando]?e:new S.Event(d,"object"==typeof e&&e)).isTrigger=r?2:3,e.namespace=h.join("."),e.rnamespace=e.namespace?new RegExp("(^|\\.)"+h.join("\\.(?:.*\\.|)")+"(\\.|$)"):null,e.result=void 0,e.target||(e.target=n),t=null==t?[e]:S.makeArray(t,[e]),c=S.event.special[d]||{},r||!c.trigger||!1!==c.trigger.apply(n,t))){if(!r&&!c.noBubble&&!x(n)){for(s=c.delegateType||d,mt.test(s+d)||(o=o.parentNode);o;o=o.parentNode)p.push(o),a=o;a===(n.ownerDocument||E)&&p.push(a.defaultView||a.parentWindow||C)}i=0;while((o=p[i++])&&!e.isPropagationStopped())f=o,e.type=1<i?s:c.bindType||d,(l=(Y.get(o,"events")||Object.create(null))[e.type]&&Y.get(o,"handle"))&&l.apply(o,t),(l=u&&o[u])&&l.apply&&V(o)&&(e.result=l.apply(o,t),!1===e.result&&e.preventDefault());return e.type=d,r||e.isDefaultPrevented()||c._default&&!1!==c._default.apply(p.pop(),t)||!V(n)||u&&m(n[d])&&!x(n)&&((a=n[u])&&(n[u]=null),S.event.triggered=d,e.isPropagationStopped()&&f.addEventListener(d,xt),n[d](),e.isPropagationStopped()&&f.removeEventListener(d,xt),S.event.triggered=void 0,a&&(n[u]=a)),e.result}},simulate:function(e,t,n){var r=S.extend(new S.Event,n,{type:e,isSimulated:!0});S.event.trigger(r,null,t)}}),S.fn.extend({trigger:function(e,t){return this.each(function(){S.event.trigger(e,t,this)})},triggerHandler:function(e,t){var n=this[0];if(n)return S.event.trigger(e,t,n,!0)}}),y.focusin||S.each({focus:"focusin",blur:"focusout"},function(n,r){var i=function(e){S.event.simulate(r,e.target,S.event.fix(e))};S.event.special[r]={setup:function(){var e=this.ownerDocument||this.document||this,t=Y.access(e,r);t||e.addEventListener(n,i,!0),Y.access(e,r,(t||0)+1)},teardown:function(){var e=this.ownerDocument||this.document||this,t=Y.access(e,r)-1;t?Y.access(e,r,t):(e.removeEventListener(n,i,!0),Y.remove(e,r))}}});var bt=C.location,wt={guid:Date.now()},Tt=/\?/;S.parseXML=function(e){var t,n;if(!e||"string"!=typeof e)return null;try{t=(new C.DOMParser).parseFromString(e,"text/xml")}catch(e){}return n=t&&t.getElementsByTagName("parsererror")[0],t&&!n||S.error("Invalid XML: "+(n?S.map(n.childNodes,function(e){return e.textContent}).join("\n"):e)),t};var Ct=/\[\]$/,Et=/\r?\n/g,St=/^(?:submit|button|image|reset|file)$/i,kt=/^(?:input|select|textarea|keygen)/i;function At(n,e,r,i){var t;if(Array.isArray(e))S.each(e,function(e,t){r||Ct.test(n)?i(n,t):At(n+"["+("object"==typeof t&&null!=t?e:"")+"]",t,r,i)});else if(r||"object"!==w(e))i(n,e);else for(t in e)At(n+"["+t+"]",e[t],r,i)}S.param=function(e,t){var n,r=[],i=function(e,t){var n=m(t)?t():t;r[r.length]=encodeURIComponent(e)+"="+encodeURIComponent(null==n?"":n)};if(null==e)return"";if(Array.isArray(e)||e.jquery&&!S.isPlainObject(e))S.each(e,function(){i(this.name,this.value)});else for(n in e)At(n,e[n],t,i);return r.join("&")},S.fn.extend({serialize:function(){return S.param(this.serializeArray())},serializeArray:function(){return this.map(function(){var e=S.prop(this,"elements");return e?S.makeArray(e):this}).filter(function(){var e=this.type;return this.name&&!S(this).is(":disabled")&&kt.test(this.nodeName)&&!St.test(e)&&(this.checked||!pe.test(e))}).map(function(e,t){var n=S(this).val();return null==n?null:Array.isArray(n)?S.map(n,function(e){return{name:t.name,value:e.replace(Et,"\r\n")}}):{name:t.name,value:n.replace(Et,"\r\n")}}).get()}});var Nt=/%20/g,jt=/#.*$/,Dt=/([?&])_=[^&]*/,qt=/^(.*?):[ \t]*([^\r\n]*)$/gm,Lt=/^(?:GET|HEAD)$/,Ht=/^\/\//,Ot={},Pt={},Rt="*/".concat("*"),Mt=E.createElement("a");function It(o){return function(e,t){"string"!=typeof e&&(t=e,e="*");var n,r=0,i=e.toLowerCase().match(P)||[];if(m(t))while(n=i[r++])"+"===n[0]?(n=n.slice(1)||"*",(o[n]=o[n]||[]).unshift(t)):(o[n]=o[n]||[]).push(t)}}function Wt(t,i,o,a){var s={},u=t===Pt;function l(e){var r;return s[e]=!0,S.each(t[e]||[],function(e,t){var n=t(i,o,a);return"string"!=typeof n||u||s[n]?u?!(r=n):void 0:(i.dataTypes.unshift(n),l(n),!1)}),r}return l(i.dataTypes[0])||!s["*"]&&l("*")}function Ft(e,t){var n,r,i=S.ajaxSettings.flatOptions||{};for(n in t)void 0!==t[n]&&((i[n]?e:r||(r={}))[n]=t[n]);return r&&S.extend(!0,e,r),e}Mt.href=bt.href,S.extend({active:0,lastModified:{},etag:{},ajaxSettings:{url:bt.href,type:"GET",isLocal:/^(?:about|app|app-storage|.+-extension|file|res|widget):$/.test(bt.protocol),global:!0,processData:!0,async:!0,contentType:"application/x-www-form-urlencoded; charset=UTF-8",accepts:{"*":Rt,text:"text/plain",html:"text/html",xml:"application/xml, text/xml",json:"application/json, text/javascript"},contents:{xml:/\bxml\b/,html:/\bhtml/,json:/\bjson\b/},responseFields:{xml:"responseXML",text:"responseText",json:"responseJSON"},converters:{"* text":String,"text html":!0,"text json":JSON.parse,"text xml":S.parseXML},flatOptions:{url:!0,context:!0}},ajaxSetup:function(e,t){return t?Ft(Ft(e,S.ajaxSettings),t):Ft(S.ajaxSettings,e)},ajaxPrefilter:It(Ot),ajaxTransport:It(Pt),ajax:function(e,t){"object"==typeof e&&(t=e,e=void 0),t=t||{};var c,f,p,n,d,r,h,g,i,o,v=S.ajaxSetup({},t),y=v.context||v,m=v.context&&(y.nodeType||y.jquery)?S(y):S.event,x=S.Deferred(),b=S.Callbacks("once memory"),w=v.statusCode||{},a={},s={},u="canceled",T={readyState:0,getResponseHeader:function(e){var t;if(h){if(!n){n={};while(t=qt.exec(p))n[t[1].toLowerCase()+" "]=(n[t[1].toLowerCase()+" "]||[]).concat(t[2])}t=n[e.toLowerCase()+" "]}return null==t?null:t.join(", ")},getAllResponseHeaders:function(){return h?p:null},setRequestHeader:function(e,t){return null==h&&(e=s[e.toLowerCase()]=s[e.toLowerCase()]||e,a[e]=t),this},overrideMimeType:function(e){return null==h&&(v.mimeType=e),this},statusCode:function(e){var t;if(e)if(h)T.always(e[T.status]);else for(t in e)w[t]=[w[t],e[t]];return this},abort:function(e){var t=e||u;return c&&c.abort(t),l(0,t),this}};if(x.promise(T),v.url=((e||v.url||bt.href)+"").replace(Ht,bt.protocol+"//"),v.type=t.method||t.type||v.method||v.type,v.dataTypes=(v.dataType||"*").toLowerCase().match(P)||[""],null==v.crossDomain){r=E.createElement("a");try{r.href=v.url,r.href=r.href,v.crossDomain=Mt.protocol+"//"+Mt.host!=r.protocol+"//"+r.host}catch(e){v.crossDomain=!0}}if(v.data&&v.processData&&"string"!=typeof v.data&&(v.data=S.param(v.data,v.traditional)),Wt(Ot,v,t,T),h)return T;for(i in(g=S.event&&v.global)&&0==S.active++&&S.event.trigger("ajaxStart"),v.type=v.type.toUpperCase(),v.hasContent=!Lt.test(v.type),f=v.url.replace(jt,""),v.hasContent?v.data&&v.processData&&0===(v.contentType||"").indexOf("application/x-www-form-urlencoded")&&(v.data=v.data.replace(Nt,"+")):(o=v.url.slice(f.length),v.data&&(v.processData||"string"==typeof v.data)&&(f+=(Tt.test(f)?"&":"?")+v.data,delete v.data),!1===v.cache&&(f=f.replace(Dt,"$1"),o=(Tt.test(f)?"&":"?")+"_="+wt.guid+++o),v.url=f+o),v.ifModified&&(S.lastModified[f]&&T.setRequestHeader("If-Modified-Since",S.lastModified[f]),S.etag[f]&&T.setRequestHeader("If-None-Match",S.etag[f])),(v.data&&v.hasContent&&!1!==v.contentType||t.contentType)&&T.setRequestHeader("Content-Type",v.contentType),T.setRequestHeader("Accept",v.dataTypes[0]&&v.accepts[v.dataTypes[0]]?v.accepts[v.dataTypes[0]]+("*"!==v.dataTypes[0]?", "+Rt+"; q=0.01":""):v.accepts["*"]),v.headers)T.setRequestHeader(i,v.headers[i]);if(v.beforeSend&&(!1===v.beforeSend.call(y,T,v)||h))return T.abort();if(u="abort",b.add(v.complete),T.done(v.success),T.fail(v.error),c=Wt(Pt,v,t,T)){if(T.readyState=1,g&&m.trigger("ajaxSend",[T,v]),h)return T;v.async&&0<v.timeout&&(d=C.setTimeout(function(){T.abort("timeout")},v.timeout));try{h=!1,c.send(a,l)}catch(e){if(h)throw e;l(-1,e)}}else l(-1,"No Transport");function l(e,t,n,r){var i,o,a,s,u,l=t;h||(h=!0,d&&C.clearTimeout(d),c=void 0,p=r||"",T.readyState=0<e?4:0,i=200<=e&&e<300||304===e,n&&(s=function(e,t,n){var r,i,o,a,s=e.contents,u=e.dataTypes;while("*"===u[0])u.shift(),void 0===r&&(r=e.mimeType||t.getResponseHeader("Content-Type"));if(r)for(i in s)if(s[i]&&s[i].test(r)){u.unshift(i);break}if(u[0]in n)o=u[0];else{for(i in n){if(!u[0]||e.converters[i+" "+u[0]]){o=i;break}a||(a=i)}o=o||a}if(o)return o!==u[0]&&u.unshift(o),n[o]}(v,T,n)),!i&&-1<S.inArray("script",v.dataTypes)&&S.inArray("json",v.dataTypes)<0&&(v.converters["text script"]=function(){}),s=function(e,t,n,r){var i,o,a,s,u,l={},c=e.dataTypes.slice();if(c[1])for(a in e.converters)l[a.toLowerCase()]=e.converters[a];o=c.shift();while(o)if(e.responseFields[o]&&(n[e.responseFields[o]]=t),!u&&r&&e.dataFilter&&(t=e.dataFilter(t,e.dataType)),u=o,o=c.shift())if("*"===o)o=u;else if("*"!==u&&u!==o){if(!(a=l[u+" "+o]||l["* "+o]))for(i in l)if((s=i.split(" "))[1]===o&&(a=l[u+" "+s[0]]||l["* "+s[0]])){!0===a?a=l[i]:!0!==l[i]&&(o=s[0],c.unshift(s[1]));break}if(!0!==a)if(a&&e["throws"])t=a(t);else try{t=a(t)}catch(e){return{state:"parsererror",error:a?e:"No conversion from "+u+" to "+o}}}return{state:"success",data:t}}(v,s,T,i),i?(v.ifModified&&((u=T.getResponseHeader("Last-Modified"))&&(S.lastModified[f]=u),(u=T.getResponseHeader("etag"))&&(S.etag[f]=u)),204===e||"HEAD"===v.type?l="nocontent":304===e?l="notmodified":(l=s.state,o=s.data,i=!(a=s.error))):(a=l,!e&&l||(l="error",e<0&&(e=0))),T.status=e,T.statusText=(t||l)+"",i?x.resolveWith(y,[o,l,T]):x.rejectWith(y,[T,l,a]),T.statusCode(w),w=void 0,g&&m.trigger(i?"ajaxSuccess":"ajaxError",[T,v,i?o:a]),b.fireWith(y,[T,l]),g&&(m.trigger("ajaxComplete",[T,v]),--S.active||S.event.trigger("ajaxStop")))}return T},getJSON:function(e,t,n){return S.get(e,t,n,"json")},getScript:function(e,t){return S.get(e,void 0,t,"script")}}),S.each(["get","post"],function(e,i){S[i]=function(e,t,n,r){return m(t)&&(r=r||n,n=t,t=void 0),S.ajax(S.extend({url:e,type:i,dataType:r,data:t,success:n},S.isPlainObject(e)&&e))}}),S.ajaxPrefilter(function(e){var t;for(t in e.headers)"content-type"===t.toLowerCase()&&(e.contentType=e.headers[t]||"")}),S._evalUrl=function(e,t,n){return S.ajax({url:e,type:"GET",dataType:"script",cache:!0,async:!1,global:!1,converters:{"text script":function(){}},dataFilter:function(e){S.globalEval(e,t,n)}})},S.fn.extend({wrapAll:function(e){var t;return this[0]&&(m(e)&&(e=e.call(this[0])),t=S(e,this[0].ownerDocument).eq(0).clone(!0),this[0].parentNode&&t.insertBefore(this[0]),t.map(function(){var e=this;while(e.firstElementChild)e=e.firstElementChild;return e}).append(this)),this},wrapInner:function(n){return m(n)?this.each(function(e){S(this).wrapInner(n.call(this,e))}):this.each(function(){var e=S(this),t=e.contents();t.length?t.wrapAll(n):e.append(n)})},wrap:function(t){var n=m(t);return this.each(function(e){S(this).wrapAll(n?t.call(this,e):t)})},unwrap:function(e){return this.parent(e).not("body").each(function(){S(this).replaceWith(this.childNodes)}),this}}),S.expr.pseudos.hidden=function(e){return!S.expr.pseudos.visible(e)},S.expr.pseudos.visible=function(e){return!!(e.offsetWidth||e.offsetHeight||e.getClientRects().length)},S.ajaxSettings.xhr=function(){try{return new C.XMLHttpRequest}catch(e){}};var Bt={0:200,1223:204},$t=S.ajaxSettings.xhr();y.cors=!!$t&&"withCredentials"in $t,y.ajax=$t=!!$t,S.ajaxTransport(function(i){var o,a;if(y.cors||$t&&!i.crossDomain)return{send:function(e,t){var n,r=i.xhr();if(r.open(i.type,i.url,i.async,i.username,i.password),i.xhrFields)for(n in i.xhrFields)r[n]=i.xhrFields[n];for(n in i.mimeType&&r.overrideMimeType&&r.overrideMimeType(i.mimeType),i.crossDomain||e["X-Requested-With"]||(e["X-Requested-With"]="XMLHttpRequest"),e)r.setRequestHeader(n,e[n]);o=function(e){return function(){o&&(o=a=r.onload=r.onerror=r.onabort=r.ontimeout=r.onreadystatechange=null,"abort"===e?r.abort():"error"===e?"number"!=typeof r.status?t(0,"error"):t(r.status,r.statusText):t(Bt[r.status]||r.status,r.statusText,"text"!==(r.responseType||"text")||"string"!=typeof r.responseText?{binary:r.response}:{text:r.responseText},r.getAllResponseHeaders()))}},r.onload=o(),a=r.onerror=r.ontimeout=o("error"),void 0!==r.onabort?r.onabort=a:r.onreadystatechange=function(){4===r.readyState&&C.setTimeout(function(){o&&a()})},o=o("abort");try{r.send(i.hasContent&&i.data||null)}catch(e){if(o)throw e}},abort:function(){o&&o()}}}),S.ajaxPrefilter(function(e){e.crossDomain&&(e.contents.script=!1)}),S.ajaxSetup({accepts:{script:"text/javascript, application/javascript, application/ecmascript, application/x-ecmascript"},contents:{script:/\b(?:java|ecma)script\b/},converters:{"text script":function(e){return S.globalEval(e),e}}}),S.ajaxPrefilter("script",function(e){void 0===e.cache&&(e.cache=!1),e.crossDomain&&(e.type="GET")}),S.ajaxTransport("script",function(n){var r,i;if(n.crossDomain||n.scriptAttrs)return{send:function(e,t){r=S("<script>").attr(n.scriptAttrs||{}).prop({charset:n.scriptCharset,src:n.url}).on("load error",i=function(e){r.remove(),i=null,e&&t("error"===e.type?404:200,e.type)}),E.head.appendChild(r[0])},abort:function(){i&&i()}}});var _t,zt=[],Ut=/(=)\?(?=&|$)|\?\?/;S.ajaxSetup({jsonp:"callback",jsonpCallback:function(){var e=zt.pop()||S.expando+"_"+wt.guid++;return this[e]=!0,e}}),S.ajaxPrefilter("json jsonp",function(e,t,n){var r,i,o,a=!1!==e.jsonp&&(Ut.test(e.url)?"url":"string"==typeof e.data&&0===(e.contentType||"").indexOf("application/x-www-form-urlencoded")&&Ut.test(e.data)&&"data");if(a||"jsonp"===e.dataTypes[0])return r=e.jsonpCallback=m(e.jsonpCallback)?e.jsonpCallback():e.jsonpCallback,a?e[a]=e[a].replace(Ut,"$1"+r):!1!==e.jsonp&&(e.url+=(Tt.test(e.url)?"&":"?")+e.jsonp+"="+r),e.converters["script json"]=function(){return o||S.error(r+" was not called"),o[0]},e.dataTypes[0]="json",i=C[r],C[r]=function(){o=arguments},n.always(function(){void 0===i?S(C).removeProp(r):C[r]=i,e[r]&&(e.jsonpCallback=t.jsonpCallback,zt.push(r)),o&&m(i)&&i(o[0]),o=i=void 0}),"script"}),y.createHTMLDocument=((_t=E.implementation.createHTMLDocument("").body).innerHTML="<form></form><form></form>",2===_t.childNodes.length),S.parseHTML=function(e,t,n){return"string"!=typeof e?[]:("boolean"==typeof t&&(n=t,t=!1),t||(y.createHTMLDocument?((r=(t=E.implementation.createHTMLDocument("")).createElement("base")).href=E.location.href,t.head.appendChild(r)):t=E),o=!n&&[],(i=N.exec(e))?[t.createElement(i[1])]:(i=xe([e],t,o),o&&o.length&&S(o).remove(),S.merge([],i.childNodes)));var r,i,o},S.fn.load=function(e,t,n){var r,i,o,a=this,s=e.indexOf(" ");return-1<s&&(r=ht(e.slice(s)),e=e.slice(0,s)),m(t)?(n=t,t=void 0):t&&"object"==typeof t&&(i="POST"),0<a.length&&S.ajax({url:e,type:i||"GET",dataType:"html",data:t}).done(function(e){o=arguments,a.html(r?S("<div>").append(S.parseHTML(e)).find(r):e)}).always(n&&function(e,t){a.each(function(){n.apply(this,o||[e.responseText,t,e])})}),this},S.expr.pseudos.animated=function(t){return S.grep(S.timers,function(e){return t===e.elem}).length},S.offset={setOffset:function(e,t,n){var r,i,o,a,s,u,l=S.css(e,"position"),c=S(e),f={};"static"===l&&(e.style.position="relative"),s=c.offset(),o=S.css(e,"top"),u=S.css(e,"left"),("absolute"===l||"fixed"===l)&&-1<(o+u).indexOf("auto")?(a=(r=c.position()).top,i=r.left):(a=parseFloat(o)||0,i=parseFloat(u)||0),m(t)&&(t=t.call(e,n,S.extend({},s))),null!=t.top&&(f.top=t.top-s.top+a),null!=t.left&&(f.left=t.left-s.left+i),"using"in t?t.using.call(e,f):c.css(f)}},S.fn.extend({offset:function(t){if(arguments.length)return void 0===t?this:this.each(function(e){S.offset.setOffset(this,t,e)});var e,n,r=this[0];return r?r.getClientRects().length?(e=r.getBoundingClientRect(),n=r.ownerDocument.defaultView,{top:e.top+n.pageYOffset,left:e.left+n.pageXOffset}):{top:0,left:0}:void 0},position:function(){if(this[0]){var e,t,n,r=this[0],i={top:0,left:0};if("fixed"===S.css(r,"position"))t=r.getBoundingClientRect();else{t=this.offset(),n=r.ownerDocument,e=r.offsetParent||n.documentElement;while(e&&(e===n.body||e===n.documentElement)&&"static"===S.css(e,"position"))e=e.parentNode;e&&e!==r&&1===e.nodeType&&((i=S(e).offset()).top+=S.css(e,"borderTopWidth",!0),i.left+=S.css(e,"borderLeftWidth",!0))}return{top:t.top-i.top-S.css(r,"marginTop",!0),left:t.left-i.left-S.css(r,"marginLeft",!0)}}},offsetParent:function(){return this.map(function(){var e=this.offsetParent;while(e&&"static"===S.css(e,"position"))e=e.offsetParent;return e||re})}}),S.each({scrollLeft:"pageXOffset",scrollTop:"pageYOffset"},function(t,i){var o="pageYOffset"===i;S.fn[t]=function(e){return $(this,function(e,t,n){var r;if(x(e)?r=e:9===e.nodeType&&(r=e.defaultView),void 0===n)return r?r[i]:e[t];r?r.scrollTo(o?r.pageXOffset:n,o?n:r.pageYOffset):e[t]=n},t,e,arguments.length)}}),S.each(["top","left"],function(e,n){S.cssHooks[n]=Fe(y.pixelPosition,function(e,t){if(t)return t=We(e,n),Pe.test(t)?S(e).position()[n]+"px":t})}),S.each({Height:"height",Width:"width"},function(a,s){S.each({padding:"inner"+a,content:s,"":"outer"+a},function(r,o){S.fn[o]=function(e,t){var n=arguments.length&&(r||"boolean"!=typeof e),i=r||(!0===e||!0===t?"margin":"border");return $(this,function(e,t,n){var r;return x(e)?0===o.indexOf("outer")?e["inner"+a]:e.document.documentElement["client"+a]:9===e.nodeType?(r=e.documentElement,Math.max(e.body["scroll"+a],r["scroll"+a],e.body["offset"+a],r["offset"+a],r["client"+a])):void 0===n?S.css(e,t,i):S.style(e,t,n,i)},s,n?e:void 0,n)}})}),S.each(["ajaxStart","ajaxStop","ajaxComplete","ajaxError","ajaxSuccess","ajaxSend"],function(e,t){S.fn[t]=function(e){return this.on(t,e)}}),S.fn.extend({bind:function(e,t,n){return this.on(e,null,t,n)},unbind:function(e,t){return this.off(e,null,t)},delegate:function(e,t,n,r){return this.on(t,e,n,r)},undelegate:function(e,t,n){return 1===arguments.length?this.off(e,"**"):this.off(t,e||"**",n)},hover:function(e,t){return this.mouseenter(e).mouseleave(t||e)}}),S.each("blur focus focusin focusout resize scroll click dblclick mousedown mouseup mousemove mouseover mouseout mouseenter mouseleave change select submit keydown keypress keyup contextmenu".split(" "),function(e,n){S.fn[n]=function(e,t){return 0<arguments.length?this.on(n,null,e,t):this.trigger(n)}});var Xt=/^[\s\uFEFF\xA0]+|[\s\uFEFF\xA0]+$/g;S.proxy=function(e,t){var n,r,i;if("string"==typeof t&&(n=e[t],t=e,e=n),m(e))return r=s.call(arguments,2),(i=function(){return e.apply(t||this,r.concat(s.call(arguments)))}).guid=e.guid=e.guid||S.guid++,i},S.holdReady=function(e){e?S.readyWait++:S.ready(!0)},S.isArray=Array.isArray,S.parseJSON=JSON.parse,S.nodeName=A,S.isFunction=m,S.isWindow=x,S.camelCase=X,S.type=w,S.now=Date.now,S.isNumeric=function(e){var t=S.type(e);return("number"===t||"string"===t)&&!isNaN(e-parseFloat(e))},S.trim=function(e){return null==e?"":(e+"").replace(Xt,"")},"function"==typeof define&&define.amd&&define("jquery",[],function(){return S});var Vt=C.jQuery,Gt=C.$;return S.noConflict=function(e){return C.$===S&&(C.$=Gt),e&&C.jQuery===S&&(C.jQuery=Vt),S},"undefined"==typeof e&&(C.jQuery=C.$=S),S});
/* eslint-env jquery */

// restores any previous $ https://api.jquery.com/jquery.noconflict/
jQuery.noConflict();

if ($ && $.fn && $.fn.jquery && jQuery.fn.jquery !== $.fn.jquery) {
    console.log("Using jQuery in noConflict mode: " + jQuery.fn.jquery + ", Global $: " + $.fn.jquery);
} else if (this.$ === undefined) {
    this.$ = jQuery;
    console.log("Using jQuery: " + jQuery.fn.jquery);
} else {
    console.log("Using jQuery in noConflict mode: " + jQuery.fn.jquery)
}
;
/* Begin scope */
new (function () { const self = this;
/* eslint-env commonjs, amd */

// UMD based on https://github.com/umdjs/umd/blob/master/templates/returnExports.js
// TODO: move to ES6 and transpiler

(function (root, factory) {
    if (typeof define === 'function' && define.amd) {
        // AMD. Register as an anonymous module.
        define([], factory);
    } else if (typeof module === 'object' && module.exports) {
        // Node. Does not work with strict CommonJS, but
        // only CommonJS-like environments that support module.exports,
        // like Node.
        module.exports = factory();
    } else {
        // Browser globals (root is window)
        root.wvy = factory();
    }
}(typeof self !== 'undefined' ? self : this, function () {
    //console.debug("wvy.js", window.name);

    /**
     * Module wrappper for wvy namespace
     * 
     * @module wvy
     * @returns {Object}
     */

    let root = self !== undefined ? self : window;
    let wvy = root.wvy || {};

    /**
     * Translation retriever. 
     * Gets any translated string or returns the original string if translation is not present.
     * 
     * Note: Translations are stored in window.wvy and not in root scope.
     * 
     * @param {string} key - The string to translate.
     */
    wvy.t = function (key) {
        var text = window.wvy && window.wvy.resources != null ? window.wvy.resources[key] : key;
        return text || key;
    }

    return wvy;
}));
/* eslint-env commonjs, amd */

// UMD based on https://github.com/umdjs/umd/blob/master/templates/returnExports.js
// TODO: move to ES6 and transpiler

(function (root, factory) {
    if (typeof define === 'function' && define.amd) {
        // AMD. Register as an anonymous module.
        define([], factory);
    } else if (typeof module === 'object' && module.exports) {
        // Node. Does not work with strict CommonJS, but
        // only CommonJS-like environments that support module.exports,
        // like Node.
        module.exports = factory();
    } else {
        // Browser globals (root is window)
        root.wvy = root.wvy || {};
        root.wvy.utils = factory();
    }
}(typeof self !== 'undefined' ? self : this, function () {
    //console.debug("utils.js", window.name);

    /**
     * Module for misc utils
     * 
     * @module utils
     * @returns {WeavyUtils}
     */

    var WeavyUtils = {};

    /**
     * Generate a S4 alphanumeric 4 character sequence suitable for non-sensitive GUID generation etc.
     */
    WeavyUtils.S4 = function () {
        return (((1 + Math.random()) * 0x10000) | 0).toString(16).substring(1);
    };

    /**
     * Parse any HTML string into a HTMLCollection. Use WeavyUtils.parseHTML(html)[0] to get the first HTMLElement.
     * 
     * @param {any} html
     * @returns {HTMLCollection} List of all parsed HTMLElements
     */
    WeavyUtils.parseHTML = function (html) {
        if ('content' in document.createElement('template')) {
            var template = document.createElement('template');
            template.innerHTML = html.trim();
            return template.content.children;
        } else {
            // IE etc
            var parseDoc = document.implementation.createHTMLDocument();
            parseDoc.body.innerHTML = html.trim();
            return parseDoc.body.children;
        }
    }

    /*!
     * is-plain-object <https://github.com/jonschlinkert/is-plain-object>
     *
     * Copyright (c) 2014-2017, Jon Schlinkert.
     * Released under the MIT License.
     */

    /**
     * 
     * @param {any} maybeObject - The object to check
     * @returns {boolean} True if the object is an object
     */
    WeavyUtils.isObject = function(maybeObject) {
        return Object.prototype.toString.call(maybeObject) === '[object Object]';
    }

    /**
     * Checks if an object is a plain object {}, similar to jQuery.isPlainObject()
     * 
     * @param {any} maybePlainObject - The object to check
     * @returns {boolean} True if the object is plain
     */
    WeavyUtils.isPlainObject = function (maybePlainObject) {
        var ctor, prot;

        if (WeavyUtils.isObject(maybePlainObject) === false) return false;

        // If has modified constructor
        ctor = maybePlainObject.constructor;
        if (ctor === undefined) return true;

        // If has modified prototype
        prot = ctor.prototype;
        if (WeavyUtils.isObject(prot) === false) return false;

        // If constructor does not have an Object-specific method
        if (Object.prototype.hasOwnProperty.call(prot, "isPrototypeOf") === false) {
            return false;
        }

        // Most likely a plain Object
        return true;
    };

    /**
     * Check if an object is a jquery collection containing at least one item
     * 
     * @param {any} maybeJQuery
     * @returns {boolean} True if object is jQuery containing at least one item
     */
    WeavyUtils.isJQuery = function (maybeJQuery) {
        return !!(maybeJQuery && maybeJQuery.jquery && maybeJQuery.length)
    }

    /**
     * Method for extending plainObjects/options, similar to Object.assign() but with deep/recursive merging. If the recursive setting is applied it will merge any plain object children. Note that Arrays are treated as data and not as tree structure when merging. 
     * 
     * The original options passed are left untouched.
     * 
     * @name WeavyUtils#assign
     * @function
     * @param {Object} source - Original options.
     * @param {Object} properties - Merged options that will replace options from the source.
     * @param {boolean} [recursive=false] True will merge any sub-objects of the options recursively. Otherwise sub-objects are treated as data.
     * @returns {Object} A new object containing the merged options.
     */
    WeavyUtils.assign = function (source, properties, recursive) {
        source = source || {};
        properties = properties || {};

        var property;

        // Make a copy
        var copy = {};
        for (property in source) {
            if (Object.prototype.hasOwnProperty.call(source, property)) {
                copy[property] = source[property];
            }
        }

        // Apply properties to copy
        for (property in properties) {
            if (Object.prototype.hasOwnProperty.call(properties, property)) {
                if (recursive && copy[property] && WeavyUtils.isPlainObject(copy[property]) && WeavyUtils.isPlainObject(properties[property])) {
                    copy[property] = WeavyUtils.assign(copy[property], properties[property], recursive);
                } else {
                    copy[property] = properties[property];
                }
            }
        }
        return copy;
    };

    /**
     * Always returns an Array.
     * 
     * @example
     * WeavyUtils.asArray(1); // [1]
     * WeavyUtils.asArray([1]); // [1]
     * 
     * @param {any} maybeArray
     */
    WeavyUtils.asArray = function (maybeArray) {
        return maybeArray && (Array.isArray(maybeArray) ? maybeArray : [maybeArray]) || [];
    };

    /**
     * Returns an element from an HTMLElement, string query selector, html string or jquery element
     * 
     * @param {any} elementOrSelector
     * @returns {HTMLElement}
     */
    WeavyUtils.asElement = function (elementOrSelector) {
        if (elementOrSelector) {
            if (elementOrSelector instanceof HTMLElement) {
                return elementOrSelector;
            }

            if (typeof elementOrSelector === "string") {
                if (elementOrSelector.indexOf("<") === 0) {
                    return WeavyUtils.parseHTML(elementOrSelector)[0];
                } else {
                    return document.querySelector(elementOrSelector);
                }
            }

            if (WeavyUtils.isJQuery(elementOrSelector)) {
                console.warn("Weavy: providing jQuery elements is deprecated, please provide a HTMLElement or selector query instead.")
                return elementOrSelector[0];
            }
        }
    }

    /**
     * Case insensitive string comparison
     * 
     * @param {any} str1 - The first string to compare
     * @param {any} str2 - The second string to compare
     * @param {boolean} ignoreType - Skipe type check and use any stringified value
     */
    WeavyUtils.eqString = function (str1, str2, ignoreType) {
        return (ignoreType || typeof str1 === "string" && typeof str2 === "string") && String(str1).toUpperCase() === String(str2).toUpperCase();
    };

    /**
     * Compares two plain objects. Compares all the properties in a to any properties in b.
     * 
     * @param {any} a - The plain object to compare with b
     * @param {any} b - The plain object to compare properties from a to
     * @param {any} skipLength - Do not compare the number of properties
     */
    WeavyUtils.eqObjects = function (a, b, skipLength) {
        if (!WeavyUtils.isPlainObject(a) || !WeavyUtils.isPlainObject(b)) {
            return false;
        }

        var aProps = Object.getOwnPropertyNames(a);
        var bProps = Object.getOwnPropertyNames(b);

        if (!skipLength && aProps.length !== bProps.length) {
            return false;
        }

        for (var i = 0; i < aProps.length; i++) {
            var propName = aProps[i];
            var propA = a[propName];
            var propB = b[propName];

            if (propA !== propB && !WeavyUtils.eqJQuery(propA, propB) && !WeavyUtils.eqObjects(propA, propB)) {
                return false;
            }
        }

        return true;
    };

    /**
     * Compares two jQuery objects.
     *
     * @param {any} a - The first jQuery object to compare
     * @param {any} b - The second jQuery object to compare
     */
    WeavyUtils.eqJQuery = function (a, b) {
        return a && b && a.jquery && b.jquery && a.jquery === b.jquery && a.length === b.length && a.length === a.filter(b).length;
    }


    // JSON HELPERS

    /**
     * Removes HTMLElement and Node from object before serializing. Used with JSON.stringify().
     * 
     * @example
     * var jsonString = JSON.stringify(data, WeavyUtils.sanitizeJSON);
     * 
     * @param {string} key
     * @param {any} value
     * @returns {any} - Returns the value or undefined if removed.
     */
    WeavyUtils.sanitizeJSON = function (key, value) {
        // Filtering out DOM Elements and nodes
        if (value instanceof HTMLElement || value instanceof Node) {
            return undefined;
        }
        return value;
    };

    /**
     * Changes a string to camelCase from PascalCase, spinal-case and snake_case
     * @param {string} name - The string to change to camel case
     * @returns {string} - The processed string as camelCase
     */
    WeavyUtils.toCamel = function (name) {
        // from PascalCase
        name = name[0].toLowerCase() + name.substring(1);

        // from snake_case and spinal-case
        return name.replace(/([-_][a-z])/ig, function ($1) {
            return $1.toUpperCase()
                .replace('-', '')
                .replace('_', '');
        });
    };

    /**
     * Changes all object keys recursively to camelCase from PascalCase, spinal-case and snake_case
     * @param {Object} obj - The object containing keys to 
     * @returns {Object} - The processed object with any camelCase keys
     */
    WeavyUtils.keysToCamel = function (obj) {
        if (WeavyUtils.isPlainObject(obj)) {
            const n = {};

            Object.keys(obj)
                .forEach(function (k) {
                    n[WeavyUtils.toCamel(k)] = WeavyUtils.keysToCamel(obj[k]);
                });

            return n;
        } else if (Array.isArray(obj)) {
            return obj.map(function (i) {
                return WeavyUtils.keysToCamel(i);
            });
        }

        return obj;
    };
    
    /**
     * Processing of JSON in a fetch response
     * 
     * @param {external:Response} response - The fetch response to parse
     * @returns {Object|Response} The data if sucessful parsing, otherwise the response or an rejected error
     */
    WeavyUtils.processJSONResponse = function (response) {
        let contentType = (response.headers.has("content-type") ? response.headers.get("content-type") : "").split(";")[0];

        if (response.ok) {
            if (contentType === "application/json") {
                try {
                    return response.json().then(function (jsonResponse) {
                        return WeavyUtils.keysToCamel(jsonResponse);
                    }).catch(function (e) {
                        return null;
                    });
                } catch (e) {
                    return null;
                }
            }
            return response;
        } else {
            if (contentType === "application/json") {
                try {
                    return response.json().then(function (responseError) {
                        return Promise.reject(new Error(responseError.message || response.statusText));
                    }, function (e) {
                        return Promise.reject(new Error(response.statusText));
                    });
                } catch (e) { }
            }
            return Promise.reject(new Error(response.statusText));
        }
    };

    // OTHER HELPERS

    /**
     * Stores data for the current domain in the weavy namespace.
     * 
     * @category options
     * @param {string} key - The name of the data
     * @param {data} value - Data to store
     * @param {boolean} [asJson=false] - True if the data in value should be stored as JSON
     */
    WeavyUtils.storeItem = function (key, value, asJson) {
        localStorage.setItem('weavy_' + window.location.hostname + "_" + key, asJson ? JSON.stringify(value) : value);
    };

    /**
     * Retrieves data for the current domain from the weavy namespace.
     * 
     * @category options
     * @param {string} key - The name of the data to retrieve
     * @param {boolean} [isJson=false] - True if the data shoul be decoded from JSON
     */
    WeavyUtils.retrieveItem = function (key, isJson) {
        var value = localStorage.getItem('weavy_' + window.location.hostname + "_" + key);
        if (value && isJson) {
            return JSON.parse(value)
        }

        return value;
    };

    /**
     * Same as jQuery.ready()
     * 
     * @param {Function} fn
     */
    WeavyUtils.ready = function(fn) {
        if (document.readyState !== 'loading') {
            fn();
        } else {
            document.addEventListener('DOMContentLoaded', fn);
        }
    }

    return WeavyUtils;
}));


/**
 * @external Response
 * @see https://developer.mozilla.org/en-US/docs/Web/API/Response
 */

/**
 * @external Promise
 * @see https://developer.mozilla.org/en-US/docs/Web/JavaScript/Guide/Using_promises
 */
;
/* eslint-env commonjs, amd */

// UMD based on https://github.com/umdjs/umd/blob/master/templates/returnExports.js
// TODO: move to ES6 and transpiler

(function (root, factory) {
    if (typeof define === 'function' && define.amd) {
        // AMD. Register as an anonymous module.
        define(factory);
    } else if (typeof module === 'object' && module.exports) {
        // Node. Does not work with strict CommonJS, but
        // only CommonJS-like environments that support module.exports,
        // like Node.
        module.exports = factory();
    } else {
        // Browser globals (root is window)
        root.wvy = root.wvy || {};
        root.wvy.promise = factory();
    }
}(typeof self !== 'undefined' ? self : this, function () {
    //console.debug("promise.js", window.name);

    // This event is handled using same-origin script policy
    window.addEventListener("unhandledrejection", function (e) {
        if (e.promise.weavy) {
            //console.debug("Uncaught (in weavy promise)", e.reason);
            e.preventDefault();
        }
    });

    /**
     * Unifying wrapper for deferred promises. 
     * Works both as a traditional promise and a deferred promise.
     * Use promise.reset() to replace the promise with a new promise.
     * Use the promise as a function (or via .promise()) to return the actual promise.
     * 
     * @example
     * // Traditional style promise
     * new WeavyPromise(function(resolve, reject) {
     *     resolve()
     * }).then(function() {
     *     console.log("resolved");
     * })
     * 
     * @example
     * // jQuery deferred style promise
     * var myPromise = new WeavyPromise();
     * 
     * // as variable
     * myPromise.then(function() {
     *     console.log("resolved")
     * });
     * 
     * // or as function()
     * myPromise().then(function() {
     *     console.log("resolved")
     * });
     * 
     * myPromise.resolve();
     *
     * @class WeavyPromise
     * @classdesc Unified promises that can be reset
     * @param {function} executor - Function to be executed while constructing the promise
     * @returns {external:Promise} - A function that acts as the deferred or returns the promise when called
     * @see {@link https://developer.mozilla.org/en-US/docs/Web/JavaScript/Guide/Using_promises}
     **/
    var WeavyPromiseWrapper = function (executor) {
        var promise, state = "pending";
        var WeavyPromise = function WeavyPromise() { return promise };

        /**
         * Returns the native promise.
         * Equal to calling the WeavyPromise as a function.
         * Return the native promise in public methods to avoid unintended promise resolving or rejecting.
         * 
         * @example
         * var myPromise = new WeavyPromise();
         * 
         * myPromise() === mypromise.promise();
         * 
         **/
        WeavyPromise.promise = WeavyPromise.bind(WeavyPromise);

        /**
         * Gets the state of the promise
         * - "pending"
         * - "resolved"
         * - "rejected"
         * 
         * @name WeavyPromise#state
         * @function
         **/
        WeavyPromise.state = function () {
            return state;
        };

        /**
         * Resets the promise so that it can be resolved or rejected again.
         * 
         * @example
         * var myPromise = new WeavyPromise();
         * 
         * myPromise.resolve(123);
         * myPromise.reset();
         * 
         * myPromise.then(function(num) {
         *     console.log("the number is", num); // 456
         * });
         * myPromise.resolve(456);
         * 
         * @name WeavyPromise#reset
         * @function
         **/
        (WeavyPromise.reset = function () {
            var resolve, reject;

            state = "pending";

            promise = new Promise(function (_resolve, _reject) {
                resolve = function () { state = "resolved"; _resolve.apply(this, arguments); };
                reject = function () { state = "rejected"; _reject.apply(this, arguments); };
            });

            promise.weavy = true;

            WeavyPromise.resolve = function () {
                resolve.apply(promise, arguments);
                return WeavyPromise;
            };

            WeavyPromise.reject = function () {
                reject.apply(promise, arguments);
                return WeavyPromise;
            };

            if (typeof executor === "function") {
                executor(resolve, reject);
            }
            return WeavyPromise;
        })();

        /**
         * Wrapper for Promise.prototype.then 
         **/
        WeavyPromise.then = function () {
            promise = promise.then.apply(promise, arguments);
            promise.weavy = true;
            return WeavyPromise;
        };

        /**
         * Wrapper for Promise.prototype.catch
         **/
        WeavyPromise.catch = function () {
            promise = promise.catch.apply(promise, arguments);
            promise.weavy = true;
            return WeavyPromise;
        };

        /**
         * Wrapper for Promise.prototype.finally
         **/
        WeavyPromise.finally = function () {
            promise = promise.finally.apply(promise, arguments);
            promise.weavy = true;
            return WeavyPromise;
        };

        return WeavyPromise;
    }

    /**
     * Return an instantly resolved WeavyPromise
     * 
     * @example
     * function doSomething() {
     *    return WeavyPromise.resolve(1234);
     * }
     * 
     * @name WeavyPromise.resolve
     * @function
     * @param {any} value
     */
    WeavyPromiseWrapper.resolve = function (value) {
        var promise = WeavyPromiseWrapper();
        promise.resolve(value);
        return promise;
    }

    /**
     * Return an instantly rejected WeavyPromise
     * 
     * @example
     * function doSomething() {
     *    return WeavyPromise.reject({ errorcode: 404 });
     * }
     * 
     * @name WeavyPromise.reject
     * @function
     * @param {any} value
     */
    WeavyPromiseWrapper.reject = function (value) {
        var promise = WeavyPromiseWrapper();
        promise.reject(value);
        return promise;
    }

    return WeavyPromiseWrapper;
}));


/**
 * @external Promise
 * @see https://developer.mozilla.org/en-US/docs/Web/JavaScript/Guide/Using_promises
 */
;
/* eslint-env commonjs, amd */

// UMD based on https://github.com/umdjs/umd/blob/master/templates/returnExports.js
// TODO: move to ES6 and transpiler

(function (root, factory) {
    if (typeof define === 'function' && define.amd) {
        // AMD. Register as an anonymous module.
        define([
            './utils'
        ], factory);
    } else if (typeof module === 'object' && module.exports) {
        // Node. Does not work with strict CommonJS, but
        // only CommonJS-like environments that support module.exports,
        // like Node.
        module.exports = factory(
            require('./utils')
        );
    } else {
        // Browser globals (root is window)
        root.wvy = root.wvy || {};
        root.wvy.console = root.wvy.console || factory(
            root.wvy.utils
        );
    }
}(typeof self !== 'undefined' ? self : this, function (WeavyUtils) {
    //console.debug("console.js", self.name);

    // LOGGING FUNCTIONS

    // Weavy colors
    const colors = [
        "#36ace2", // LightBlue-500
        "#6599eb", // Blue-400
        "#646fed", // Indigo-400
        "#773bde", // DeepPurple-500
        "#bc4bce", // Purple-500
        "#d54487", // Pink-500
        "#de4b3b", // Red-500
        "#e17637", // DeepOrange-500
        "#e3a135", // Orange-500
        "#c9a018", // Amber-600
        "#a4c51b", // Lime-600
        "#cbbc15", // Yellow-600
        "#7cd345", // LightGreen-500
        "#53c657", // Green-500
        "#45d391", // Teal-500
        "#38dde0"  // Cyan-500
    ];

    const gray = "#8c8c8c";

    /**
     * Wrapper for applying colors/styles to the log functions.
     * 
     * @function
     * @param {function} logMethod - Native logging function to wrap, such as console.log
     * @param {string} [id] - Optional id as prefix, needs a color if used
     * @param {string} [color] - The hex color of the prefix
     * @param {Array} logArguments - Any number of log arguments 
     */
    function colorLog(logMethod, name, color) {
        // Binding needed to get proper line numbers/file reference in console
        // Binding needed for console.log.apply to work in IE

        if (name) {
            if (color) {
                return Function.prototype.bind.call(logMethod, console, "%c%s", "color: " + color, name);
            } else {
                return Function.prototype.bind.call(logMethod, console, "%c%s", "color: " + gray, name);
            }
        } else {
            return Function.prototype.bind.call(logMethod, console, "%cWeavy", "color: " + gray);
        }
    }

    /**
     * @class WeavyConsole
     * @classdesc 
     * Class for wrapping native console logging.
     * - Options for turning on/off logging
     * - Optional prefix by id with color
     **/

    /**
     * @constructor
     * @hideconstrucor
     * @param {string|Object} [context] - The unique id displayed by console logging.
     * @param {WeavyConsole#options} [options] - Options for which logging to enable/disable
     */
    var WeavyConsole = function (context, options) {
        /** 
         *  Reference to this instance
         *  @lends WeavyConsole#
         */
        var weavyConsole = this;

        var _nameSelf = self.name ? self.name + ":" : "";
        var _nameType = context.type || context.constructor && context.constructor.name || "";
        var _nameInstance = context && context.name ? (_nameType ? "." : "") + context.name : (context.id ? "#" + context.id : "");
        var _name = typeof context === "string" ? _nameSelf + context : _nameSelf + _nameType + _nameInstance;

        var _options = WeavyConsole.defaults;

        // Select a color based on _nameSelf
        var _selectedColor = Array.from(_nameSelf).reduce(function (sum, ch) { return sum + ch.charCodeAt(0); }, 0) % colors.length;
        var _uniqueColor = colors[_selectedColor];

        var _color = gray;

        var noop = function () { };

        /**
        * Enable logging messages in console. Set the individual logging types to true/false or the entire property to true/false;
        *
        * @example
        * weavy.console.logging = {
        *     log: true,
        *     debug: true,
        *     info: true,
        *     warn: true,
        *     error: true
        * };
        *
        * @example
        * weavy.console.logging = false;
        *
        * @name options
        * @memberof WeavyConsole#
        * @typedef
        * @type {Object|boolean}
        * @property {string} color - A hex color to use for id. A random color will be chosen if omitted.
        * @property {boolean} log=true - Enable log messages in console
        * @property {boolean} debug=true - Enable debug messages in console
        * @property {boolean} info=true - Enable info messages in console
        * @property {boolean} warn=true - Enable warn messages in console
        * @property {boolean} error=true - Enable error messages in console
        */
        Object.defineProperty(this, "options", {
            get: function () {
                return _options;
            },
            set: function (options) {
                // Merge default options, current options and new options
                _options = WeavyUtils.assign(WeavyUtils.assign(WeavyConsole.defaults, _options), options);

                // Set color
                if (_options === true) {
                    _color = _uniqueColor;
                } else if (_options.color === false) {
                    _color = gray;
                } else if (typeof _options.color === "string") {
                    _color = _options.color;
                } else {
                    _color = _uniqueColor;
                }

                // Turn on/off logging
                this.log   = _options === true || _options.log   ? colorLog(window.console.log, _name, _color)   : noop;
                this.debug = _options === true || _options.debug ? colorLog(window.console.debug, _name, _color) : noop;
                this.info  = _options === true || _options.info  ? colorLog(window.console.info, _name, _color)  : noop;
                this.warn  = _options === true || _options.warn  ? colorLog(window.console.warn, _name, _color)  : noop;
                this.error = _options === true || _options.error ? colorLog(window.console.error, _name, _color) : noop;
            }
        });

        // Set initial logging
        this.options = options;
    };

    /**
     * Default class options, may be defined in weavy options.
     * 
     * @example
     * Weavy.defaults.console = {
     *     color: true,
     *     log: true,
     *     debug: true,
     *     info: true,
     *     warn: true,
     *     error: true
     * };
     * 
     * @name defaults
     * @memberof WeavyConsole
     * @type {Object}
     * @property {boolean} log=true - Enable log messages in console
     * @property {boolean} debug=false - Enable debug messages in console
     * @property {boolean} info=true - Enable info messages in console
     * @property {boolean} warn=true - Enable warn messages in console
     * @property {boolean} error=true - Enable error messages in console
     */
    WeavyConsole.defaults = {
        color: true,
        log: true,
        debug: false,
        info: true,
        warn: true,
        error: true
    };

    return WeavyConsole;
}));


/**
 * @external Promise
 * @see https://developer.mozilla.org/en-US/docs/Web/JavaScript/Guide/Using_promises
 */

/**
 * @external "console.debug"
 * @see https://developer.mozilla.org/en-US/docs/Web/API/Console/debug
 */

/**
 * @external "console.error"
 * @see https://developer.mozilla.org/en-US/docs/Web/API/Console/error
 */

/**
 * @external "console.info"
 * @see https://developer.mozilla.org/en-US/docs/Web/API/Console/info
 */

/**
 * @external "console.log"
 * @see https://developer.mozilla.org/en-US/docs/Web/API/Console/log
 */

/**
 * @external "console.warn"
 * @see https://developer.mozilla.org/en-US/docs/Web/API/Console/want
 */
;
/* eslint-env commonjs, amd */

// UMD based on https://github.com/umdjs/umd/blob/master/templates/returnExports.js
// TODO: move to ES6 and transpiler

(function (root, factory) {
    if (typeof define === 'function' && define.amd) {
        // AMD. Register as an anonymous module.
        define(['./utils', './promise', './console', './wvy'], factory);
    } else if (typeof module === 'object' && module.exports) {
        // Node. Does not work with strict CommonJS, but
        // only CommonJS-like environments that support module.exports,
        // like Node.
        module.exports = factory(require('./utils'), require('./promise'), require('./console'), require('./wvy'));
    } else {
        // Browser globals (root is window)
        root.wvy = root.wvy || {};
        root.wvy.postal = factory(root.wvy.utils, root.wvy.promise, root.wvy.console, root.wvy);
    }
}(typeof self !== 'undefined' ? self : this, function (WeavyUtils, WeavyPromise, WeavyConsole, wvy) {

    //console.debug("postal.js", self.name);

    function WeavyPostal(options) {

        var console = new WeavyConsole("WeavyPostal");

        this.timeout = options && options.timeout || 2000;

        var inQueue = [];
        var messageListeners = [];
        var contentWindows = new Set();
        var contentWindowsByWeavyId = new Map();
        var contentWindowOrigins = new WeakMap();
        var contentWindowNames = new WeakMap();
        var contentWindowWeavyIds = new WeakMap();
        var contentWindowDomain = new WeakMap();

        var _whenLeader = new WeavyPromise();
        var _isLeader = null;

        var _parentWeavyId = null;
        var _parentWindow = null;
        var _parentOrigin = null;
        var _parentName = null;
        var _origin = extractOrigin(window.location.href);

        function extractOrigin(url) {
            var extractOrigin = null;
            try {
                extractOrigin = /^((?:https?:\/\/[^/]+)|(?:file:\/\/))\/?/.exec(url)[1]
            } catch (e) {
                console.error("Unable to resolve location origin. Make sure you are using http, https or file protocol and have a valid location URL.");
            }
            return extractOrigin;
        }

        function distributeMessage(e) {
            var fromSelf = e.source === window && e.origin === _origin;
            var fromParent = e.source === _parentWindow && e.origin === _parentOrigin;
            var fromFrame = contentWindowOrigins.has(e.source) && e.origin === contentWindowOrigins.get(e.source);

            if (fromSelf || fromParent || fromFrame) {

                var genericDistribution = !e.data.weavyId || e.data.weavyId === true;

                if (fromFrame && !e.data.windowName) {
                    e.data.windowName = contentWindowNames.get(e.source);
                }

                var messageName = e.data.name;
                if (messageName === "distribute") {
                    if (_isLeader) {
                        return;
                    }
                    e.data.name = e.data.distributeName;
                }

                //console.debug("message from", fromSelf && "self" || fromParent && "parent" || fromFrame && "frame " + e.data.windowName, e.data.name);

                messageListeners.forEach(function (listener) {
                    var matchingName = listener.name === messageName || listener.name === "message";
                    var genericListener = listener.selector === null;
                    var matchingWeavyId = listener.selector === e.data.weavyId;
                    var matchingDataSelector = WeavyUtils.isPlainObject(listener.selector) && WeavyUtils.eqObjects(listener.selector, e.data, true);

                    if (matchingName && (genericDistribution || genericListener || matchingWeavyId || matchingDataSelector)) {

                        listener.handler(e, e.data);

                        if (listener.once) {
                            off(listener.name, listener.selector, listener.handler);
                        }
                    }
                });
            }
        }

        window.addEventListener("message", function (e) {
            if (e.data.name && e.data.weavyId !== undefined) {
                if (e.data.weavyMessageId && e.data.name !== "message-receipt") {
                    console.debug("sending message receipt", e.data.weavyMessageId, e.data.name)
                    try {
                        e.source.postMessage({ name: "message-receipt", weavyId: e.data.weavyId, weavyMessageId: e.data.weavyMessageId }, e.origin);
                    } catch (e) {
                        console.error("could not post back message-receipt to source");
                    }
                }

                switch (e.data.name) {
                    case "register-child":
                        if (!_parentWindow) {
                            if (!contentWindowWeavyIds.has(e.source)) {
                                console.warn("register-child: contentwindow not pre-registered");
                            }

                            if (contentWindowOrigins.get(e.source) !== e.origin) {
                                console.error("register-child: " + contentWindowNames.get(e.source) + " has invalid origin", e.origin);
                                return;
                            }

                            try {
                                var weavyId = contentWindowWeavyIds.get(e.source);
                                var contentWindowName = contentWindowNames.get(e.source);

                                if (contentWindowName) {
                                    e.source.postMessage({
                                        name: "register-window",
                                        windowName: contentWindowName,
                                        weavyId: weavyId || true,
                                    }, e.origin);
                                }
                            } catch (e) {
                                console.error("could not register frame window", weavyId, contentWindowName, e);
                            }
                        }
                        break;
                    case "register-window":
                        if (!_parentWindow) {
                            //console.debug("registering frame window");
                            _parentOrigin = e.origin;
                            _parentWindow = e.source;
                            _parentName = e.data.windowName;
                            _parentWeavyId = e.data.weavyId;
                        }

                        console.debug("is not leader");
                        _isLeader = false;
                        _whenLeader.resolve(false);

                        var statusCode = wvy.context && wvy.context.statusCode;
                        var statusDescription = wvy.context && wvy.context.statusDescription;

                        try {
                            e.source.postMessage({ name: "ready", windowName: e.data.windowName, weavyId: e.data.weavyId, location: window.location.href, statusCode: statusCode, statusDescription: statusDescription }, e.origin);
                        } catch (e) {
                            console.error("register-window could not post back ready-message to source", e);
                        }

                        if (wvy.whenLoaded) {
                            wvy.whenLoaded.then(function () {
                                postToParent({ name: "load" });
                            });
                        }

                        if (inQueue.length) {
                            inQueue.forEach(function (messageEvent) {
                                distributeMessage(messageEvent)
                            });
                            inQueue = [];
                        }

                        break;
                    case "ready":
                        if (contentWindowsByWeavyId.has(e.data.weavyId) && contentWindowNames.has(e.source) && contentWindowsByWeavyId.get(e.data.weavyId).get(contentWindowNames.get(e.source))) {
                            contentWindowDomain.set(e.source, e.origin);
                            distributeMessage(e);
                        }

                        break;
                    case "reload":
                        console.debug("reload", _parentName, !!e.data.force);
                        window.location.reload(e.data.force);

                        break;
                    default:
                        if (e.source === window || _parentWindow || contentWindowsByWeavyId.size) {
                            distributeMessage(e);
                        } else {
                            inQueue.push(e);
                        }

                        break;
                }
            }
        });

        function on(name, selector, handler) {
            if (typeof arguments[1] === "function") {
                // omit weavyId argument
                handler = arguments[1];
                selector = null;
            }
            messageListeners.push({ name: name, handler: handler, selector: selector });
        }

        function one(name, selector, handler) {
            if (typeof arguments[1] === "function") {
                // omit weavyId argument
                handler = arguments[1];
                selector = null;
            }
            messageListeners.push({ name: name, handler: handler, selector: selector, once: true });
        }

        function off(name, selector, handler) {
            if (typeof arguments[1] === "function") {
                // omit weavyId argument
                handler = arguments[1];
                selector = null;
            }
            messageListeners = messageListeners.filter(function (listener) {
                var nameMatch = name === listener.name;
                var handlerMatch = handler === listener.handler;
                var stringSelectorMatch = typeof selector === "string" && selector === listener.selector;
                var plainObjectMatch = WeavyUtils.isPlainObject(selector) && WeavyUtils.eqObjects(selector, listener.selector);
                var offMatch = nameMatch && handlerMatch && (stringSelectorMatch || plainObjectMatch);
                return !(offMatch);
            });
        }

        /**
         * Sends the id of a frame to the frame content scripts, so that the frame gets aware of which id it has.
         * The frame needs to have a unique name attribute.
         *
         * @category panels
         * @param {string} weavyId - The id of the group or entity which the contentWindow belongs to.
         * @param {Window} contentWindow - The frame window to send the data to.
         */
        function registerContentWindow(contentWindow, contentWindowName, weavyId, contentOrigin) {
            try {
                if (!contentWindowName) {
                    console.error("registerContentWindow() No valid contentWindow to register, must be a window and have a name.");
                    return;
                }
            } catch (e) {
                console.error("registerContentWindow() cannot access contentWindowName")
            }

            if (contentWindow.self) {
                contentWindow = contentWindow.self;
            }

            if (!weavyId || weavyId === "true") {
                weavyId = true;
            }

            if (!contentWindowsByWeavyId.has(weavyId)) {
                contentWindowsByWeavyId.set(weavyId, new Map());
            }

            contentWindowsByWeavyId.get(weavyId).set(contentWindowName, contentWindow);
            contentWindows.add(contentWindow);
            contentWindowNames.set(contentWindow, contentWindowName);
            contentWindowWeavyIds.set(contentWindow, weavyId);
            contentWindowOrigins.set(contentWindow, contentOrigin);
        }

        function unregisterWeavyId(weavyId) {
            if (contentWindowsByWeavyId.has(weavyId)) {
                contentWindowsByWeavyId.get(weavyId).forEach(function (contentWindow, contentWindowName) {
                    unregisterContentWindow(contentWindowName, weavyId);
                });
                contentWindowsByWeavyId.get(weavyId)
                contentWindowsByWeavyId.delete(weavyId);
            }
        }

        function unregisterContentWindow(windowName, weavyId) {
            if (contentWindowsByWeavyId.has(weavyId)) {
                if (contentWindowsByWeavyId.get(weavyId).has(windowName)) {
                    var contentWindow = contentWindowsByWeavyId.get(weavyId).get(windowName);
                    try {
                        contentWindows.delete(contentWindow);
                        contentWindowNames.delete(contentWindow);
                        contentWindowWeavyIds.delete(contentWindow);
                        contentWindowOrigins.delete(contentWindow);
                    } catch (e) {}
                }
                contentWindowsByWeavyId.get(weavyId).delete(windowName);
                if (contentWindowsByWeavyId.get(weavyId).size === 0) {
                    try {
                        contentWindowsByWeavyId.delete(weavyId);
                    } catch (e) {}
                }
            }
        }

        function whenPostMessage(contentWindow, message, transfer) {
            var whenReceipt = new WeavyPromise();

            if (transfer === null) {
                // Chrome does not allow transfer to be null
                transfer = undefined;
            }
            
            var toSelf = contentWindow === window.self;
            var toParent = _parentWindow && _parentWindow !== window && _parentWindow === contentWindow;
            var origin = toSelf ? extractOrigin(window.location.href) :
                         toParent ? _parentOrigin :
                         contentWindowOrigins.get(contentWindow);
            var validWindow = toSelf || toParent || contentWindow && origin === contentWindowDomain.get(contentWindow)

            if (validWindow) {
                if (!message.weavyMessageId) {
                    message.weavyMessageId = WeavyUtils.S4() + WeavyUtils.S4();
                }

                queueMicrotask(() => {
                    console.debug("whenPostMessage", message.name, message.weavyMessageId);

                    var messageWatchdog = setTimeout(function () {
                        if (whenReceipt.state() === "pending") {
                            whenReceipt.reject(new Error("postMessage() receipt timed out: " + message.weavyMessageId + ", " + message.name));
                        }
                    }, this.timeout || 2000);

                    on("message-receipt", { weavyId: message.weavyId, weavyMessageId: message.weavyMessageId }, function () {
                        console.debug("message-receipt received", message.weavyMessageId, message.name);
                        clearTimeout(messageWatchdog);
                        whenReceipt.resolve();
                    });

                    try {
                        contentWindow.postMessage(message, origin, transfer);
                    } catch (e) {
                        whenReceipt.reject(e);
                    }
                })
            } else {
                whenReceipt.reject(new Error("postMessage() Invalid window origin: " + origin + ", " + message.name));
            }

            return whenReceipt();
        }

        function postToChildren(message, transfer) {
            if (typeof message !== "object" || !message.name) {
                console.error("postToChildren() Invalid message format", message);
                return;
            }

            if (transfer === null) {
                // Chrome does not allow transfer to be null
                transfer = undefined;
            }

            message.distributeName = message.name;
            message.name = "distribute";
            message.weavyId = message.weavyId || true;

            contentWindows.forEach(function (contentWindow) {
                if (contentWindowOrigins.get(contentWindow) === contentWindowDomain.get(contentWindow)) {
                    try {
                        contentWindow.postMessage(message, contentWindowOrigins.get(contentWindow), transfer);
                    } catch (e) {
                        console.warn("postToChildren() could not distribute message to " + contentWindowNames.get(contentWindow))
                    }
                }
            })

        }

        function postToFrame(windowName, weavyId, message, transfer) {
            if (typeof message !== "object" || !message.name) {
                console.error("postToFrame() Invalid message format", message);
                return;
            }

            var contentWindow;
            try {
                contentWindow = contentWindowsByWeavyId.get(weavyId).get(windowName);
            } catch (e) {
                console.error("postToFrame() Window not registered", weavyId, windowName);
            }

            message.weavyId = weavyId;

            return whenPostMessage(contentWindow, message, transfer);
        }

        function postToSelf(message, transfer) {
            if (typeof message !== "object" || !message.name) {
                console.error("postToSelf() Invalid message format", message);
                return;
            }

            message.weavyId = message.weavyId || true;

            return whenPostMessage(window.self, message, transfer);
        }

        function postToParent(message, transfer) {
            if (typeof message !== "object" || !message.name) {
                console.error("postToParent() Invalid message format", message);
                return;
            }

            return _whenLeader().then(function (isLeader) {
                if (!isLeader) {
                    if (message.weavyId === undefined) {
                        message.weavyId = _parentWeavyId;
                    }

                    if (message.windowName === undefined) {
                        message.windowName = _parentName;
                    }

                    return whenPostMessage(_parentWindow, message, transfer);
                } else {
                    return WeavyPromise.resolve();
                }
            });
        }

        function postToSource(e, message, transfer) {
            if (e.source && e.data.weavyId !== undefined) {
                var fromSelf = e.source === window.self && e.origin === _origin;
                var fromParent = e.source === _parentWindow && e.origin === _parentOrigin;
                var fromFrame = contentWindowOrigins.has(e.source) && e.origin === contentWindowOrigins.get(e.source);

                if (transfer === null) {
                    // Chrome does not allow transfer to be null
                    transfer = undefined;
                }

                if (fromSelf || fromParent || fromFrame) {
                    message.weavyId = e.data.weavyId;

                    try {
                        e.source.postMessage(message, e.origin, transfer);
                    } catch (e) {
                        console.error("postToSource() Could not post message back to source");
                    }
                }
            }
        }

        function setLeader() {
            if (_whenLeader.state() === "pending") {
                console.debug("Is leader");
                _isLeader = true;
                _whenLeader.resolve(_isLeader);
            }
        }

        function init() {

            // Register in parent or opener
            var parent = window.self.opener !== window.self && window.self.opener || window.self.parent !== window.self && window.self.parent;

            if (parent) {
                var parentOrigins;

                try {
                    // Server configured cors-origins
                    // Origins containing wildcards will be treated as generic wildcard origin
                    if (!parentOrigins) {
                        let corsOrigins = wvy.config.corsOrigins;
                        if (corsOrigins && !(corsOrigins.length === 1 && corsOrigins[0] === "*")) {
                            parentOrigins = corsOrigins;
                            console.debug("Using CORS origin");
                        }
                    }
                } catch (e) { }

                try {
                    // Same-domain origin, only available when samedomain is successfully configured
                    if (!parentOrigins)  {
                        parentOrigins = [parent.location.origin];
                        if (parentOrigins) {
                            console.log("Using same-domain origin");
                        }
                    }
                } catch (e) { }

                // Default if no origin is configured
                parentOrigins = parentOrigins || ["*"];

                // Filter and sort
                parentOrigins = Array.from(parentOrigins)
                    .map(e => e.indexOf("*") !== -1 ? "*" : e) // Uniform wildcards
                    .filter((e, i, a) => a.indexOf(e) === i) // Unique entries
                    .sort((a, b) => a.indexOf("*") - b.indexOf("*")); // Sort explicit origins before any wildcards

                // Filter by ancestor to exclude mismatching origins
                if (parentOrigins.length > 1) {
                    var parentAncestor;

                    // Try ancestorOrigins
                    if ('ancestorOrigins' in window.location) {
                        parentAncestor = window.location.ancestorOrigins[0];
                    }

                    // Try accessing same-site location
                    if (!parentAncestor) {
                        try {
                            parentAncestor = parent.location.origin;
                        } catch (e) { }
                    }

                    // Try using document referrer (FF)
                    if (!parentAncestor && document.referrer) {
                        if (new URL(document.referrer).origin !== window.location.origin) {
                            parentAncestor = new URL(document.referrer).origin;
                        }
                    }

                    if (parentAncestor && parentOrigins.indexOf(parentAncestor) >= 0) {
                        parentOrigins = [parentAncestor];
                    } else {
                        console.warn("Frame registration may cause " + (parentOrigins.length - 1) + " origin error messages in the console due to multiple cors-origins configured.");
                    }
                }

                if (parentOrigins.length) {
                    console.debug("Checking for parent");

                    parentOrigins.forEach(function (parentOrigin) {
                        if (parentOrigin === "*") {
                            console.warn("Using wildcard origin for registration.")
                        }

                        try {
                            parent.postMessage({ name: "register-child", weavyId: true }, parentOrigin);
                        } catch (e) {
                            console.error("Error checking for parent", e);
                        }
                    })
                } else {
                    console.warning("Could not find any parent with valid origin.")
                }

                requestAnimationFrame(function () {
                    window.setTimeout(setLeader, parentOrigins.length ? 2000 : 1);
                });

            } else {
                setLeader();
            }

        }

        this.on = on;
        this.one = one;
        this.off = off;
        this.registerContentWindow = registerContentWindow;
        this.unregisterContentWindow = unregisterContentWindow;
        this.unregisterAll = unregisterWeavyId;
        this.postToFrame = postToFrame;
        this.postToParent = postToParent;
        this.postToSelf = postToSelf;
        this.postToSource = postToSource;
        this.postToChildren = postToChildren;
        this.whenLeader = function () { return _whenLeader(); };

        Object.defineProperty(this, "isLeader", {
            get: function () { return _isLeader; }
        });
        Object.defineProperty(this, "parentWeavyId", {
            get: function () { return _parentWeavyId; }
        });
        Object.defineProperty(this, "parentName", {
            get: function () { return _parentName; }
        });
        Object.defineProperty(this, "parentOrigin", {
            get: function () { return _parentOrigin; }
        });

        init();
    }


    return new WeavyPostal();
}));


/**
 * @external Promise
 * @see https://developer.mozilla.org/en-US/docs/Web/JavaScript/Guide/Using_promises
 */

/**
 * @external jqXHR
 * @see http://api.jquery.com/jQuery.ajax/#jqXHR
 */

/**
 * @external jqAjaxSettings
 * @see http://api.jquery.com/jquery.ajax/#jQuery-ajax-settings
 */


;
/* jquery.signalR.core.js */
/*global window:false */
/*!
 * ASP.NET SignalR JavaScript Library 2.4.2
 * http://signalr.net/
 *
 * Copyright (c) .NET Foundation. All rights reserved.
 * Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
 *
 * CHANGES BY WEAVY:
 * added local variable asyncLocal to ajaxAbort (as a workaround because our minification fails otherwise)
 * stop early return after subsequent calls to start, we need to do check for crossdomain and set connection.withCredentials
 */
(function ($, window, undefined) {

    var resources = {
        nojQuery: "jQuery was not found. Please ensure jQuery is referenced before the SignalR client JavaScript file.",
        noTransportOnInit: "No transport could be initialized successfully. Try specifying a different transport or none at all for auto initialization.",
        errorOnNegotiate: "Error during negotiation request.",
        stoppedWhileLoading: "The connection was stopped during page load.",
        stoppedWhileNegotiating: "The connection was stopped during the negotiate request.",
        errorParsingNegotiateResponse: "Error parsing negotiate response.",
        errorRedirectionExceedsLimit: "Negotiate redirection limit exceeded.",
        errorDuringStartRequest: "Error during start request. Stopping the connection.",
        errorFromServer: "Error message received from the server: '{0}'.",
        stoppedDuringStartRequest: "The connection was stopped during the start request.",
        errorParsingStartResponse: "Error parsing start response: '{0}'. Stopping the connection.",
        invalidStartResponse: "Invalid start response: '{0}'. Stopping the connection.",
        protocolIncompatible: "You are using a version of the client that isn't compatible with the server. Client version {0}, server version {1}.",
        aspnetCoreSignalrServer: "Detected a connection attempt to an ASP.NET Core SignalR Server. This client only supports connecting to an ASP.NET SignalR Server. See https://aka.ms/signalr-core-differences for details.",
        sendFailed: "Send failed.",
        parseFailed: "Failed at parsing response: {0}",
        longPollFailed: "Long polling request failed.",
        eventSourceFailedToConnect: "EventSource failed to connect.",
        eventSourceError: "Error raised by EventSource",
        webSocketClosed: "WebSocket closed.",
        pingServerFailedInvalidResponse: "Invalid ping response when pinging server: '{0}'.",
        pingServerFailed: "Failed to ping server.",
        pingServerFailedStatusCode: "Failed to ping server.  Server responded with status code {0}, stopping the connection.",
        pingServerFailedParse: "Failed to parse ping server response, stopping the connection.",
        noConnectionTransport: "Connection is in an invalid state, there is no transport active.",
        webSocketsInvalidState: "The Web Socket transport is in an invalid state, transitioning into reconnecting.",
        reconnectTimeout: "Couldn't reconnect within the configured timeout of {0} ms, disconnecting.",
        reconnectWindowTimeout: "The client has been inactive since {0} and it has exceeded the inactivity timeout of {1} ms. Stopping the connection.",
        jsonpNotSupportedWithAccessToken: "The JSONP protocol does not support connections that require a Bearer token to connect, such as the Azure SignalR Service."
    };

    if (typeof ($) !== "function") {
        // no jQuery!
        throw new Error(resources.nojQuery);
    }

    var signalR,
        _connection,
        _pageLoaded = (window.document.readyState === "complete"),
        _pageWindow = $(window),
        _negotiateAbortText = "__Negotiate Aborted__",
        events = {
            onStart: "onStart",
            onStarting: "onStarting",
            onReceived: "onReceived",
            onError: "onError",
            onConnectionSlow: "onConnectionSlow",
            onReconnecting: "onReconnecting",
            onReconnect: "onReconnect",
            onStateChanged: "onStateChanged",
            onDisconnect: "onDisconnect"
        },
        ajaxDefaults = {
            processData: true,
            timeout: null,
            async: true,
            global: false,
            cache: false
        },
        log = function (msg, logging) {
            if (logging === false) {
                return;
            }
            var m;
            if (typeof (window.console) === "undefined") {
                return;
            }
            m = "[" + new Date().toTimeString() + "] SignalR: " + msg;
            if (window.console.debug) {
                window.console.debug(m);
            } else if (window.console.log) {
                window.console.log(m);
            }
        },

        changeState = function (connection, expectedState, newState) {
            if (expectedState === connection.state) {
                connection.state = newState;

                $(connection).triggerHandler(events.onStateChanged, [{ oldState: expectedState, newState: newState }]);
                return true;
            }

            return false;
        },

        isDisconnecting = function (connection) {
            return connection.state === signalR.connectionState.disconnected;
        },

        supportsKeepAlive = function (connection) {
            return connection._.keepAliveData.activated &&
                connection.transport.supportsKeepAlive(connection);
        },

        configureStopReconnectingTimeout = function (connection) {
            var stopReconnectingTimeout,
                onReconnectTimeout;

            // Check if this connection has already been configured to stop reconnecting after a specified timeout.
            // Without this check if a connection is stopped then started events will be bound multiple times.
            if (!connection._.configuredStopReconnectingTimeout) {
                onReconnectTimeout = function (connection) {
                    var message = signalR._.format(signalR.resources.reconnectTimeout, connection.disconnectTimeout);
                    connection.log(message);
                    $(connection).triggerHandler(events.onError, [signalR._.error(message, /* source */ "TimeoutException")]);
                    connection.stop(/* async */ false, /* notifyServer */ false);
                };

                connection.reconnecting(function () {
                    var connection = this;

                    // Guard against state changing in a previous user defined even handler
                    if (connection.state === signalR.connectionState.reconnecting) {
                        stopReconnectingTimeout = window.setTimeout(function () { onReconnectTimeout(connection); }, connection.disconnectTimeout);
                    }
                });

                connection.stateChanged(function (data) {
                    if (data.oldState === signalR.connectionState.reconnecting) {
                        // Clear the pending reconnect timeout check
                        window.clearTimeout(stopReconnectingTimeout);
                    }
                });

                connection._.configuredStopReconnectingTimeout = true;
            }
        };

    signalR = function (url, qs, logging) {
        /// <summary>Creates a new SignalR connection for the given url</summary>
        /// <param name="url" type="String">The URL of the long polling endpoint</param>
        /// <param name="qs" type="Object">
        ///     [Optional] Custom querystring parameters to add to the connection URL.
        ///     If an object, every non-function member will be added to the querystring.
        ///     If a string, it's added to the QS as specified.
        /// </param>
        /// <param name="logging" type="Boolean">
        ///     [Optional] A flag indicating whether connection logging is enabled to the browser
        ///     console/log. Defaults to false.
        /// </param>

        return new signalR.fn.init(url, qs, logging);
    };

    signalR._ = {
        defaultContentType: "application/x-www-form-urlencoded; charset=UTF-8",

        ieVersion: (function () {
            var version,
                matches;

            if (window.navigator.appName === 'Microsoft Internet Explorer') {
                // Check if the user agent has the pattern "MSIE (one or more numbers).(one or more numbers)";
                matches = /MSIE ([0-9]+\.[0-9]+)/.exec(window.navigator.userAgent);

                if (matches) {
                    version = window.parseFloat(matches[1]);
                }
            }

            // undefined value means not IE
            return version;
        })(),

        error: function (message, source, context) {
            var e = new Error(message);
            e.source = source;

            if (typeof context !== "undefined") {
                e.context = context;
            }

            return e;
        },

        transportError: function (message, transport, source, context) {
            var e = this.error(message, source, context);
            e.transport = transport ? transport.name : undefined;
            return e;
        },

        format: function () {
            /// <summary>Usage: format("Hi {0}, you are {1}!", "Foo", 100) </summary>
            var s = arguments[0];
            for (var i = 0; i < arguments.length - 1; i++) {
                s = s.replace("{" + i + "}", arguments[i + 1]);
            }
            return s;
        },

        firefoxMajorVersion: function (userAgent) {
            // Firefox user agents: http://useragentstring.com/pages/Firefox/
            var matches = userAgent.match(/Firefox\/(\d+)/);
            if (!matches || !matches.length || matches.length < 2) {
                return 0;
            }
            return parseInt(matches[1], 10 /* radix */);
        },

        configurePingInterval: function (connection) {
            var config = connection._.config,
                onFail = function (error) {
                    $(connection).triggerHandler(events.onError, [error]);
                };

            if (config && !connection._.pingIntervalId && config.pingInterval) {
                connection._.pingIntervalId = window.setInterval(function () {
                    signalR.transports._logic.pingServer(connection).fail(onFail);
                }, config.pingInterval);
            }
        }
    };

    signalR.events = events;

    signalR.resources = resources;

    signalR.ajaxDefaults = ajaxDefaults;

    signalR.changeState = changeState;

    signalR.isDisconnecting = isDisconnecting;

    signalR.connectionState = {
        connecting: 0,
        connected: 1,
        reconnecting: 2,
        disconnected: 4
    };

    signalR.hub = {
        start: function () {
            // This will get replaced with the real hub connection start method when hubs is referenced correctly
            throw new Error("SignalR: Error loading hubs. Ensure your hubs reference is correct, e.g. <script src='/signalr/js'></script>.");
        }
    };

    // .on() was added in version 1.7.0, .load() was removed in version 3.0.0 so we fallback to .load() if .on() does
    // not exist to not break existing applications
    if (typeof _pageWindow.on == "function") {
        _pageWindow.on("load", function () { _pageLoaded = true; });
    }
    else {
        _pageWindow.load(function () { _pageLoaded = true; });
    }

    function validateTransport(requestedTransport, connection) {
        /// <summary>Validates the requested transport by cross checking it with the pre-defined signalR.transports</summary>
        /// <param name="requestedTransport" type="Object">The designated transports that the user has specified.</param>
        /// <param name="connection" type="signalR">The connection that will be using the requested transports.  Used for logging purposes.</param>
        /// <returns type="Object" />

        if ($.isArray(requestedTransport)) {
            // Go through transport array and remove an "invalid" tranports
            for (var i = requestedTransport.length - 1; i >= 0; i--) {
                var transport = requestedTransport[i];
                if ($.type(transport) !== "string" || !signalR.transports[transport]) {
                    connection.log("Invalid transport: " + transport + ", removing it from the transports list.");
                    requestedTransport.splice(i, 1);
                }
            }

            // Verify we still have transports left, if we dont then we have invalid transports
            if (requestedTransport.length === 0) {
                connection.log("No transports remain within the specified transport array.");
                requestedTransport = null;
            }
        } else if (!signalR.transports[requestedTransport] && requestedTransport !== "auto") {
            connection.log("Invalid transport: " + requestedTransport.toString() + ".");
            requestedTransport = null;
        } else if (requestedTransport === "auto" && signalR._.ieVersion <= 8) {
            // If we're doing an auto transport and we're IE8 then force longPolling, #1764
            return ["longPolling"];

        }

        return requestedTransport;
    }

    function getDefaultPort(protocol) {
        if (protocol === "http:") {
            return 80;
        } else if (protocol === "https:") {
            return 443;
        }
    }

    function addDefaultPort(protocol, url) {
        // Remove ports  from url.  We have to check if there's a / or end of line
        // following the port in order to avoid removing ports such as 8080.
        if (url.match(/:\d+$/)) {
            return url;
        } else {
            return url + ":" + getDefaultPort(protocol);
        }
    }

    function ConnectingMessageBuffer(connection, drainCallback) {
        var that = this,
            buffer = [];

        that.tryBuffer = function (message) {
            if (connection.state === $.signalR.connectionState.connecting) {
                buffer.push(message);

                return true;
            }

            return false;
        };

        that.drain = function () {
            // Ensure that the connection is connected when we drain (do not want to drain while a connection is not active)
            if (connection.state === $.signalR.connectionState.connected) {
                while (buffer.length > 0) {
                    drainCallback(buffer.shift());
                }
            }
        };

        that.clear = function () {
            buffer = [];
        };
    }

    signalR.fn = signalR.prototype = {
        init: function (url, qs, logging) {
            var $connection = $(this);

            this.url = url;
            this.qs = qs;
            this.lastError = null;
            this._ = {
                keepAliveData: {},
                connectingMessageBuffer: new ConnectingMessageBuffer(this, function (message) {
                    $connection.triggerHandler(events.onReceived, [message]);
                }),
                lastMessageAt: new Date().getTime(),
                lastActiveAt: new Date().getTime(),
                beatInterval: 5000, // Default value, will only be overridden if keep alive is enabled,
                beatHandle: null,
                totalTransportConnectTimeout: 0, // This will be the sum of the TransportConnectTimeout sent in response to negotiate and connection.transportConnectTimeout
                redirectQs: null
            };
            if (typeof (logging) === "boolean") {
                this.logging = logging;
            }
        },

        _parseResponse: function (response) {
            var that = this;

            if (!response) {
                return response;
            } else if (typeof response === "string") {
                return that.json.parse(response);
            } else {
                return response;
            }
        },

        _originalJson: window.JSON,

        json: window.JSON,

        isCrossDomain: function (url, against) {
            /// <summary>Checks if url is cross domain</summary>
            /// <param name="url" type="String">The base URL</param>
            /// <param name="against" type="Object">
            ///     An optional argument to compare the URL against, if not specified it will be set to window.location.
            ///     If specified it must contain a protocol and a host property.
            /// </param>
            var link;

            url = $.trim(url);

            against = against || window.location;

            if (url.indexOf("http") !== 0) {
                return false;
            }

            // Create an anchor tag.
            link = window.document.createElement("a");
            link.href = url;

            // When checking for cross domain we have to special case port 80 because the window.location will remove the
            return link.protocol + addDefaultPort(link.protocol, link.host) !== against.protocol + addDefaultPort(against.protocol, against.host);
        },

        ajaxDataType: "text",

        contentType: "application/json; charset=UTF-8",

        logging: false,

        state: signalR.connectionState.disconnected,

        clientProtocol: "2.1",

        // We want to support older servers since the 2.0 change is to support redirection results, which isn't
        // really breaking in the protocol. So if a user updates their client to 2.0 protocol version there's
        // no reason they can't still connect to a 1.5 server. The 2.1 protocol is sent by the client so the SignalR
        // service knows the client will use they query string returned via the RedirectUrl for subsequent requests.
        // It doesn't matter whether the server reflects back 2.1 or continues using 2.0 as the protocol version.
        supportedProtocols: ["1.5", "2.0", "2.1"],

        negotiateRedirectSupportedProtocols: ["2.0", "2.1"],

        reconnectDelay: 2000,

        transportConnectTimeout: 0,

        disconnectTimeout: 30000, // This should be set by the server in response to the negotiate request (30s default)

        reconnectWindow: 30000, // This should be set by the server in response to the negotiate request

        keepAliveWarnAt: 2 / 3, // Warn user of slow connection if we breach the X% mark of the keep alive timeout

        start: function (options, callback) {
            /// <summary>Starts the connection</summary>
            /// <param name="options" type="Object">Options map</param>
            /// <param name="callback" type="Function">A callback function to execute when the connection has started</param>
            var connection = this,
                config = {
                    pingInterval: 300000,
                    waitForPageLoad: true,
                    transport: "auto",
                    jsonp: false
                },
                initialize,
                deferred = connection._deferral || $.Deferred(), // Check to see if there is a pre-existing deferral that's being built on, if so we want to keep using it
                parser = window.document.createElement("a"),
                setConnectionUrl = function (connection, url) {
                    // NOTE: commented out next three lines - we need to check for cross domain and set withCredentials
                    //if (connection.url === url && connection.baseUrl) {
                    //    // when the url related properties are already set
                    //    return;
                    //}

                    connection.url = url;

                    // Resolve the full url
                    parser.href = connection.url;
                    if (!parser.protocol || parser.protocol === ":") {
                        connection.protocol = window.document.location.protocol;
                        connection.host = parser.host || window.document.location.host;
                    } else {
                        connection.protocol = parser.protocol;
                        connection.host = parser.host;
                    }

                    connection.baseUrl = connection.protocol + "//" + connection.host;

                    // Set the websocket protocol
                    connection.wsProtocol = connection.protocol === "https:" ? "wss://" : "ws://";

                    // If the url is protocol relative, prepend the current windows protocol to the url.
                    if (connection.url.indexOf("//") === 0) {
                        connection.url = window.location.protocol + connection.url;
                        connection.log("Protocol relative URL detected, normalizing it to '" + connection.url + "'.");
                    }

                    if (connection.isCrossDomain(connection.url)) {
                        connection.log("Auto detected cross domain url.");

                        if (config.transport === "auto") {
                            // Cross-domain does not support foreverFrame
                            config.transport = ["webSockets", "serverSentEvents", "longPolling"];
                        }

                        if (typeof connection.withCredentials === "undefined") {
                            connection.withCredentials = true;
                        }

                        // Determine if jsonp is the only choice for negotiation, ajaxSend and ajaxAbort.
                        // i.e. if the browser doesn't supports CORS
                        // If it is, ignore any preference to the contrary, and switch to jsonp.
                        if (!$.support.cors) {
                            connection.ajaxDataType = "jsonp";
                            connection.log("Using jsonp because this browser doesn't support CORS.");
                        }

                        connection.contentType = signalR._.defaultContentType;
                    }
                };

            connection.lastError = null;

            // Persist the deferral so that if start is called multiple times the same deferral is used.
            connection._deferral = deferred;

            if (!connection.json) {
                // no JSON!
                throw new Error("SignalR: No JSON parser found. Please ensure json2.js is referenced before the SignalR.js file if you need to support clients without native JSON parsing support, e.g. IE<8.");
            }

            if ($.type(options) === "function") {
                // Support calling with single callback parameter
                callback = options;
            } else if ($.type(options) === "object") {
                $.extend(config, options);
                if ($.type(config.callback) === "function") {
                    callback = config.callback;
                }
            }

            config.transport = validateTransport(config.transport, connection);

            // If the transport is invalid throw an error and abort start
            if (!config.transport) {
                throw new Error("SignalR: Invalid transport(s) specified, aborting start.");
            }

            connection._.config = config;

            // Check to see if start is being called prior to page load
            // If waitForPageLoad is true we then want to re-direct function call to the window load event
            if (!_pageLoaded && config.waitForPageLoad === true) {
                connection._.deferredStartHandler = function () {
                    connection.start(options, callback);
                };
                _pageWindow.bind("load", connection._.deferredStartHandler);

                return deferred.promise();
            }

            // If we're already connecting just return the same deferral as the original connection start
            if (connection.state === signalR.connectionState.connecting) {
                return deferred.promise();
            } else if (changeState(connection,
                signalR.connectionState.disconnected,
                signalR.connectionState.connecting) === false) {
                // We're not connecting so try and transition into connecting.
                // If we fail to transition then we're either in connected or reconnecting.

                deferred.resolve(connection);
                return deferred.promise();
            }

            configureStopReconnectingTimeout(connection);

            // If jsonp with no/auto transport is specified, then set the transport to long polling
            // since that is the only transport for which jsonp really makes sense.
            // Some developers might actually choose to specify jsonp for same origin requests
            // as demonstrated by Issue #623.
            if (config.transport === "auto" && config.jsonp === true) {
                config.transport = "longPolling";
            }

            connection.withCredentials = config.withCredentials;

            // Save the original url so that we can reset it when we stop and restart the connection
            connection._originalUrl = connection.url;

            connection.ajaxDataType = config.jsonp ? "jsonp" : "text";

            setConnectionUrl(connection, connection.url);

            $(connection).bind(events.onStart, function (e, data) {
                if ($.type(callback) === "function") {
                    callback.call(connection);
                }
                deferred.resolve(connection);
            });

            connection._.initHandler = signalR.transports._logic.initHandler(connection);

            initialize = function (transports, index) {
                var noTransportError = signalR._.error(resources.noTransportOnInit);

                index = index || 0;
                if (index >= transports.length) {
                    if (index === 0) {
                        connection.log("No transports supported by the server were selected.");
                    } else if (index === 1) {
                        connection.log("No fallback transports were selected.");
                    } else {
                        connection.log("Fallback transports exhausted.");
                    }

                    // No transport initialized successfully
                    $(connection).triggerHandler(events.onError, [noTransportError]);
                    deferred.reject(noTransportError);
                    // Stop the connection if it has connected and move it into the disconnected state
                    connection.stop();
                    return;
                }

                // The connection was aborted
                if (connection.state === signalR.connectionState.disconnected) {
                    return;
                }

                var transportName = transports[index],
                    transport = signalR.transports[transportName],
                    onFallback = function () {
                        initialize(transports, index + 1);
                    };

                connection.transport = transport;

                try {
                    connection._.initHandler.start(transport, function () { // success
                        // Firefox 11+ doesn't allow sync XHR withCredentials: https://developer.mozilla.org/en-US/docs/Web/API/XMLHttpRequest#withCredentials
                        var isFirefox11OrGreater = signalR._.firefoxMajorVersion(window.navigator.userAgent) >= 11,
                            asyncAbort = true;

                        connection.log("The start request succeeded. Transitioning to the connected state.");

                        if (supportsKeepAlive(connection)) {
                            signalR.transports._logic.monitorKeepAlive(connection);
                        }

                        if (connection._.keepAliveData.activated) {
                            signalR.transports._logic.startHeartbeat(connection);
                        }

                        // Used to ensure low activity clients maintain their authentication.
                        // Must be configured once a transport has been decided to perform valid ping requests.
                        signalR._.configurePingInterval(connection);

                        if (!changeState(connection,
                            signalR.connectionState.connecting,
                            signalR.connectionState.connected)) {
                            connection.log("WARNING! The connection was not in the connecting state.");
                        }

                        // Drain any incoming buffered messages (messages that came in prior to connect)
                        connection._.connectingMessageBuffer.drain();

                        $(connection).triggerHandler(events.onStart);

                        // wire the stop handler for when the user leaves the page
                        _pageWindow.bind("unload", function () {
                            connection.log("Window unloading, stopping the connection.");

                            connection.stop(asyncAbort);
                        });

                        if (isFirefox11OrGreater) {
                            // Firefox does not fire cross-domain XHRs in the normal unload handler on tab close.
                            // #2400
                            _pageWindow.bind("beforeunload", function () {
                                // If connection.stop() runs runs in beforeunload and fails, it will also fail
                                // in unload unless connection.stop() runs after a timeout.
                                window.setTimeout(function () {
                                    connection.stop(asyncAbort);
                                }, 0);
                            });
                        }
                    }, onFallback);
                }
                catch (error) {
                    connection.log(transport.name + " transport threw '" + error.message + "' when attempting to start.");
                    onFallback();
                }
            };

            var url = connection.url + "/negotiate",
                onFailed = function (error, connection) {
                    var err = signalR._.error(resources.errorOnNegotiate, error, connection._.negotiateRequest);

                    $(connection).triggerHandler(events.onError, err);
                    deferred.reject(err);
                    // Stop the connection if negotiate failed
                    connection.stop();
                };

            $(connection).triggerHandler(events.onStarting);

            url = signalR.transports._logic.prepareQueryString(connection, url);

            connection.log("Negotiating with '" + url + "'.");

            // Save the ajax negotiate request object so we can abort it if stop is called while the request is in flight.
            connection._.negotiateRequest = function () {
                var res,
                    redirects = 0,
                    MAX_REDIRECTS = 100,
                    keepAliveData,
                    protocolError,
                    transports = [],
                    supportedTransports = [],
                    negotiate = function (connection, onSuccess) {
                        var url = signalR.transports._logic.prepareQueryString(connection, connection.url + "/negotiate");
                        connection.log("Negotiating with '" + url + "'.");
                        var options = {
                            url: url,
                            error: function (error, statusText) {
                                // We don't want to cause any errors if we're aborting our own negotiate request.
                                if (statusText !== _negotiateAbortText) {
                                    onFailed(error, connection);
                                } else {
                                    // This rejection will noop if the deferred has already been resolved or rejected.
                                    deferred.reject(signalR._.error(resources.stoppedWhileNegotiating, null /* error */, connection._.negotiateRequest));
                                }
                            },
                            success: onSuccess
                        };

                        if (connection.accessToken) {
                            options.headers = { "Authorization": "Bearer " + connection.accessToken };
                        }

                        return signalR.transports._logic.ajax(connection, options);
                    },
                    callback = function (result) {
                        try {
                            res = connection._parseResponse(result);
                        } catch (error) {
                            onFailed(signalR._.error(resources.errorParsingNegotiateResponse, error), connection);
                            return;
                        }

                        // Check if the server is an ASP.NET Core app
                        if (res.availableTransports) {
                            protocolError = signalR._.error(resources.aspnetCoreSignalrServer);
                            $(connection).triggerHandler(events.onError, [protocolError]);
                            deferred.reject(protocolError);
                            return;
                        }

                        if (!res.ProtocolVersion || (connection.supportedProtocols.indexOf(res.ProtocolVersion) === -1)) {
                            protocolError = signalR._.error(signalR._.format(resources.protocolIncompatible, connection.clientProtocol, res.ProtocolVersion));
                            $(connection).triggerHandler(events.onError, [protocolError]);
                            deferred.reject(protocolError);

                            return;
                        }

                        // Check for a redirect response (which must have a ProtocolVersion of 2.0 or greater)
                        // ProtocolVersion 2.1 is the highest supported by the client, so we can just check for 2.0 or 2.1 for now
                        // instead of trying to do proper version string comparison in JavaScript.
                        if (connection.negotiateRedirectSupportedProtocols.indexOf(res.ProtocolVersion) !== -1) {
                            if (res.Error) {
                                protocolError = signalR._.error(signalR._.format(resources.errorFromServer, res.Error));
                                $(connection).triggerHandler(events.onError, [protocolError]);
                                deferred.reject(protocolError);
                                return;
                            }
                            else if (res.RedirectUrl) {
                                if (redirects === MAX_REDIRECTS) {
                                    onFailed(signalR._.error(resources.errorRedirectionExceedsLimit), connection);
                                    return;
                                }

                                if (config.transport === "auto") {
                                    // Redirected connections do not support foreverFrame
                                    config.transport = ["webSockets", "serverSentEvents", "longPolling"];
                                }

                                connection.log("Received redirect to: " + res.RedirectUrl);
                                connection.accessToken = res.AccessToken;

                                var splitUrlAndQs = res.RedirectUrl.split("?", 2);
                                setConnectionUrl(connection, splitUrlAndQs[0]);

                                // Update redirectQs with query string from only the most recent RedirectUrl.
                                connection._.redirectQs = splitUrlAndQs.length === 2 ? splitUrlAndQs[1] : null;

                                if (connection.ajaxDataType === "jsonp" && connection.accessToken) {
                                    onFailed(signalR._.error(resources.jsonpNotSupportedWithAccessToken), connection);
                                    return;
                                }

                                redirects++;
                                negotiate(connection, callback);
                                return;
                            }
                        }

                        keepAliveData = connection._.keepAliveData;
                        connection.appRelativeUrl = res.Url;
                        connection.id = res.ConnectionId;
                        connection.token = res.ConnectionToken;
                        connection.webSocketServerUrl = res.WebSocketServerUrl;

                        // The long poll timeout is the ConnectionTimeout plus 10 seconds
                        connection._.pollTimeout = res.ConnectionTimeout * 1000 + 10000; // in ms

                        // Once the server has labeled the PersistentConnection as Disconnected, we should stop attempting to reconnect
                        // after res.DisconnectTimeout seconds.
                        connection.disconnectTimeout = res.DisconnectTimeout * 1000; // in ms

                        // Add the TransportConnectTimeout from the response to the transportConnectTimeout from the client to calculate the total timeout
                        connection._.totalTransportConnectTimeout = connection.transportConnectTimeout + res.TransportConnectTimeout * 1000;

                        // If we have a keep alive
                        if (res.KeepAliveTimeout) {
                            // Register the keep alive data as activated
                            keepAliveData.activated = true;

                            // Timeout to designate when to force the connection into reconnecting converted to milliseconds
                            keepAliveData.timeout = res.KeepAliveTimeout * 1000;

                            // Timeout to designate when to warn the developer that the connection may be dead or is not responding.
                            keepAliveData.timeoutWarning = keepAliveData.timeout * connection.keepAliveWarnAt;

                            // Instantiate the frequency in which we check the keep alive.  It must be short in order to not miss/pick up any changes
                            connection._.beatInterval = (keepAliveData.timeout - keepAliveData.timeoutWarning) / 3;
                        } else {
                            keepAliveData.activated = false;
                        }

                        connection.reconnectWindow = connection.disconnectTimeout + (keepAliveData.timeout || 0);

                        $.each(signalR.transports, function (key) {
                            if ((key.indexOf("_") === 0) || (key === "webSockets" && !res.TryWebSockets)) {
                                return true;
                            }
                            supportedTransports.push(key);
                        });

                        if ($.isArray(config.transport)) {
                            $.each(config.transport, function (_, transport) {
                                if ($.inArray(transport, supportedTransports) >= 0) {
                                    transports.push(transport);
                                }
                            });
                        } else if (config.transport === "auto") {
                            transports = supportedTransports;
                        } else if ($.inArray(config.transport, supportedTransports) >= 0) {
                            transports.push(config.transport);
                        }

                        initialize(transports);
                    };

                return negotiate(connection, callback);
            }();

            return deferred.promise();
        },

        starting: function (callback) {
            /// <summary>Adds a callback that will be invoked before anything is sent over the connection</summary>
            /// <param name="callback" type="Function">A callback function to execute before the connection is fully instantiated.</param>
            /// <returns type="signalR" />
            var connection = this;
            $(connection).bind(events.onStarting, function (e, data) {
                callback.call(connection);
            });
            return connection;
        },

        send: function (data) {
            /// <summary>Sends data over the connection</summary>
            /// <param name="data" type="String">The data to send over the connection</param>
            /// <returns type="signalR" />
            var connection = this;

            if (connection.state === signalR.connectionState.disconnected) {
                // Connection hasn't been started yet
                throw new Error("SignalR: Connection must be started before data can be sent. Call .start() before .send()");
            }

            if (connection.state === signalR.connectionState.connecting) {
                // Connection hasn't been started yet
                throw new Error("SignalR: Connection has not been fully initialized. Use .start().done() or .start().fail() to run logic after the connection has started.");
            }

            connection.transport.send(connection, data);
            // REVIEW: Should we return deferred here?
            return connection;
        },

        received: function (callback) {
            /// <summary>Adds a callback that will be invoked after anything is received over the connection</summary>
            /// <param name="callback" type="Function">A callback function to execute when any data is received on the connection</param>
            /// <returns type="signalR" />
            var connection = this;
            $(connection).bind(events.onReceived, function (e, data) {
                callback.call(connection, data);
            });
            return connection;
        },

        stateChanged: function (callback) {
            /// <summary>Adds a callback that will be invoked when the connection state changes</summary>
            /// <param name="callback" type="Function">A callback function to execute when the connection state changes</param>
            /// <returns type="signalR" />
            var connection = this;
            $(connection).bind(events.onStateChanged, function (e, data) {
                callback.call(connection, data);
            });
            return connection;
        },

        error: function (callback) {
            /// <summary>Adds a callback that will be invoked after an error occurs with the connection</summary>
            /// <param name="callback" type="Function">A callback function to execute when an error occurs on the connection</param>
            /// <returns type="signalR" />
            var connection = this;
            $(connection).bind(events.onError, function (e, errorData, sendData) {
                connection.lastError = errorData;
                // In practice 'errorData' is the SignalR built error object.
                // In practice 'sendData' is undefined for all error events except those triggered by
                // 'ajaxSend' and 'webSockets.send'.'sendData' is the original send payload.
                callback.call(connection, errorData, sendData);
            });
            return connection;
        },

        disconnected: function (callback) {
            /// <summary>Adds a callback that will be invoked when the client disconnects</summary>
            /// <param name="callback" type="Function">A callback function to execute when the connection is broken</param>
            /// <returns type="signalR" />
            var connection = this;
            $(connection).bind(events.onDisconnect, function (e, data) {
                callback.call(connection);
            });
            return connection;
        },

        connectionSlow: function (callback) {
            /// <summary>Adds a callback that will be invoked when the client detects a slow connection</summary>
            /// <param name="callback" type="Function">A callback function to execute when the connection is slow</param>
            /// <returns type="signalR" />
            var connection = this;
            $(connection).bind(events.onConnectionSlow, function (e, data) {
                callback.call(connection);
            });

            return connection;
        },

        reconnecting: function (callback) {
            /// <summary>Adds a callback that will be invoked when the underlying transport begins reconnecting</summary>
            /// <param name="callback" type="Function">A callback function to execute when the connection enters a reconnecting state</param>
            /// <returns type="signalR" />
            var connection = this;
            $(connection).bind(events.onReconnecting, function (e, data) {
                callback.call(connection);
            });
            return connection;
        },

        reconnected: function (callback) {
            /// <summary>Adds a callback that will be invoked when the underlying transport reconnects</summary>
            /// <param name="callback" type="Function">A callback function to execute when the connection is restored</param>
            /// <returns type="signalR" />
            var connection = this;
            $(connection).bind(events.onReconnect, function (e, data) {
                callback.call(connection);
            });
            return connection;
        },

        stop: function (async, notifyServer) {
            /// <summary>Stops listening</summary>
            /// <param name="async" type="Boolean">Whether or not to asynchronously abort the connection</param>
            /// <param name="notifyServer" type="Boolean">Whether we want to notify the server that we are aborting the connection</param>
            /// <returns type="signalR" />
            var connection = this,
                // Save deferral because this is always cleaned up
                deferral = connection._deferral;

            // Verify that we've bound a load event.
            if (connection._.deferredStartHandler) {
                // Unbind the event.
                _pageWindow.unbind("load", connection._.deferredStartHandler);
            }

            // Always clean up private non-timeout based state.
            delete connection._.config;
            delete connection._.deferredStartHandler;

            // This needs to be checked despite the connection state because a connection start can be deferred until page load.
            // If we've deferred the start due to a page load we need to unbind the "onLoad" -> start event.
            if (!_pageLoaded && (!connection._.config || connection._.config.waitForPageLoad === true)) {
                connection.log("Stopping connection prior to negotiate.");

                // If we have a deferral we should reject it
                if (deferral) {
                    deferral.reject(signalR._.error(resources.stoppedWhileLoading));
                }

                // Short-circuit because the start has not been fully started.
                return;
            }

            if (connection.state === signalR.connectionState.disconnected) {
                return;
            }

            connection.log("Stopping connection.");

            // Clear this no matter what
            window.clearTimeout(connection._.beatHandle);
            window.clearInterval(connection._.pingIntervalId);

            if (connection.transport) {
                connection.transport.stop(connection);

                if (notifyServer !== false) {
                    connection.transport.abort(connection, async);
                }

                if (supportsKeepAlive(connection)) {
                    signalR.transports._logic.stopMonitoringKeepAlive(connection);
                }

                connection.transport = null;
            }

            if (connection._.negotiateRequest) {
                // If the negotiation request has already completed this will noop.
                connection._.negotiateRequest.abort(_negotiateAbortText);
                delete connection._.negotiateRequest;
            }

            // Ensure that initHandler.stop() is called before connection._deferral is deleted
            if (connection._.initHandler) {
                connection._.initHandler.stop();
            }

            delete connection._deferral;
            delete connection.messageId;
            delete connection.groupsToken;
            delete connection.id;
            delete connection._.pingIntervalId;
            delete connection._.lastMessageAt;
            delete connection._.lastActiveAt;

            // Clear out our message buffer
            connection._.connectingMessageBuffer.clear();

            // Clean up this event
            $(connection).unbind(events.onStart);

            // Reset the URL and clear the access token
            delete connection.accessToken;
            delete connection.protocol;
            delete connection.host;
            delete connection.baseUrl;
            delete connection.wsProtocol;
            delete connection.contentType;
            connection.url = connection._originalUrl;
            connection._.redirectQs = null;

            // Trigger the disconnect event
            changeState(connection, connection.state, signalR.connectionState.disconnected);
            $(connection).triggerHandler(events.onDisconnect);

            return connection;
        },

        log: function (msg) {
            log(msg, this.logging);
        }
    };

    signalR.fn.init.prototype = signalR.fn;

    signalR.noConflict = function () {
        /// <summary>Reinstates the original value of $.connection and returns the signalR object for manual assignment</summary>
        /// <returns type="signalR" />
        if ($.connection === signalR) {
            $.connection = _connection;
        }
        return signalR;
    };

    if ($.connection) {
        _connection = $.connection;
    }

    $.connection = $.signalR = signalR;

}(window.jQuery, window));
/* jquery.signalR.transports.common.js */
// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

/*global window:false */
/// <reference path="jquery.signalR.core.js" />

(function ($, window, undefined) {

    var signalR = $.signalR,
        events = $.signalR.events,
        changeState = $.signalR.changeState,
        startAbortText = "__Start Aborted__",
        transportLogic;

    signalR.transports = {};

    function beat(connection) {
        if (connection._.keepAliveData.monitoring) {
            checkIfAlive(connection);
        }

        // Ensure that we successfully marked active before continuing the heartbeat.
        if (transportLogic.markActive(connection)) {
            connection._.beatHandle = window.setTimeout(function () {
                beat(connection);
            }, connection._.beatInterval);
        }
    }

    function checkIfAlive(connection) {
        var keepAliveData = connection._.keepAliveData,
            timeElapsed;

        // Only check if we're connected
        if (connection.state === signalR.connectionState.connected) {
            timeElapsed = new Date().getTime() - connection._.lastMessageAt;

            // Check if the keep alive has completely timed out
            if (timeElapsed >= keepAliveData.timeout) {
                connection.log("Keep alive timed out.  Notifying transport that connection has been lost.");

                // Notify transport that the connection has been lost
                connection.transport.lostConnection(connection);
            } else if (timeElapsed >= keepAliveData.timeoutWarning) {
                // This is to assure that the user only gets a single warning
                if (!keepAliveData.userNotified) {
                    connection.log("Keep alive has been missed, connection may be dead/slow.");
                    $(connection).triggerHandler(events.onConnectionSlow);
                    keepAliveData.userNotified = true;
                }
            } else {
                keepAliveData.userNotified = false;
            }
        }
    }

    function getAjaxUrl(connection, path) {
        var url = connection.url + path;

        if (connection.transport) {
            url += "?transport=" + connection.transport.name;
        }

        return transportLogic.prepareQueryString(connection, url);
    }

    function InitHandler(connection) {
        this.connection = connection;

        this.startRequested = false;
        this.startCompleted = false;
        this.connectionStopped = false;
    }

    InitHandler.prototype = {
        start: function (transport, onSuccess, onFallback) {
            var that = this,
                connection = that.connection,
                failCalled = false;

            if (that.startRequested || that.connectionStopped) {
                connection.log("WARNING! " + transport.name + " transport cannot be started. Initialization ongoing or completed.");
                return;
            }

            connection.log(transport.name + " transport starting.");

            transport.start(connection, function () {
                if (!failCalled) {
                    that.initReceived(transport, onSuccess);
                }
            }, function (error) {
                // Don't allow the same transport to cause onFallback to be called twice
                if (!failCalled) {
                    failCalled = true;
                    that.transportFailed(transport, error, onFallback);
                }

                // Returns true if the transport should stop;
                // false if it should attempt to reconnect
                return !that.startCompleted || that.connectionStopped;
            });

            that.transportTimeoutHandle = window.setTimeout(function () {
                if (!failCalled) {
                    failCalled = true;
                    connection.log(transport.name + " transport timed out when trying to connect.");
                    that.transportFailed(transport, undefined, onFallback);
                }
            }, connection._.totalTransportConnectTimeout);
        },

        stop: function () {
            this.connectionStopped = true;
            window.clearTimeout(this.transportTimeoutHandle);
            signalR.transports._logic.tryAbortStartRequest(this.connection);
        },

        initReceived: function (transport, onSuccess) {
            var that = this,
                connection = that.connection;

            if (that.startRequested) {
                connection.log("WARNING! The client received multiple init messages.");
                return;
            }

            if (that.connectionStopped) {
                return;
            }

            that.startRequested = true;
            window.clearTimeout(that.transportTimeoutHandle);

            connection.log(transport.name + " transport connected. Initiating start request.");
            signalR.transports._logic.ajaxStart(connection, function () {
                that.startCompleted = true;
                onSuccess();
            });
        },

        transportFailed: function (transport, error, onFallback) {
            var connection = this.connection,
                deferred = connection._deferral,
                wrappedError;

            if (this.connectionStopped) {
                return;
            }

            window.clearTimeout(this.transportTimeoutHandle);

            if (!this.startRequested) {
                transport.stop(connection);

                connection.log(transport.name + " transport failed to connect. Attempting to fall back.");
                onFallback();
            } else if (!this.startCompleted) {
                // Do not attempt to fall back if a start request is ongoing during a transport failure.
                // Instead, trigger an error and stop the connection.
                wrappedError = signalR._.error(signalR.resources.errorDuringStartRequest, error);

                connection.log(transport.name + " transport failed during the start request. Stopping the connection.");
                $(connection).triggerHandler(events.onError, [wrappedError]);
                if (deferred) {
                    deferred.reject(wrappedError);
                }

                connection.stop();
            } else {
                // The start request has completed, but the connection has not stopped.
                // No need to do anything here. The transport should attempt its normal reconnect logic.
            }
        }
    };

    transportLogic = signalR.transports._logic = {
        ajax: function (connection, options) {
            return $.ajax(
                $.extend(/*deep copy*/ true, {}, $.signalR.ajaxDefaults, {
                    type: "GET",
                    data: {},
                    xhrFields: { withCredentials: connection.withCredentials },
                    contentType: connection.contentType,
                    dataType: connection.ajaxDataType
                }, options));
        },

        pingServer: function (connection) {
            /// <summary>Pings the server</summary>
            /// <param name="connection" type="signalr">Connection associated with the server ping</param>
            /// <returns type="signalR" />
            var url,
                xhr,
                deferral = $.Deferred();

            if (connection.transport) {
                url = connection.url + "/ping";

                url = transportLogic.addQs(url, connection.qs);

                xhr = transportLogic.ajax(connection, {
                    url: url,
                    headers: connection.accessToken ? { "Authorization": "Bearer " + connection.accessToken } : {},
                    success: function (result) {
                        var data;

                        try {
                            data = connection._parseResponse(result);
                        }
                        catch (error) {
                            deferral.reject(
                                signalR._.transportError(
                                    signalR.resources.pingServerFailedParse,
                                    connection.transport,
                                    error,
                                    xhr
                                )
                            );
                            connection.stop();
                            return;
                        }

                        if (data.Response === "pong") {
                            deferral.resolve();
                        }
                        else {
                            deferral.reject(
                                signalR._.transportError(
                                    signalR._.format(signalR.resources.pingServerFailedInvalidResponse, result),
                                    connection.transport,
                                    null /* error */,
                                    xhr
                                )
                            );
                        }
                    },
                    error: function (error) {
                        if (error.status === 401 || error.status === 403) {
                            deferral.reject(
                                signalR._.transportError(
                                    signalR._.format(signalR.resources.pingServerFailedStatusCode, error.status),
                                    connection.transport,
                                    error,
                                    xhr
                                )
                            );
                            connection.stop();
                        }
                        else {
                            deferral.reject(
                                signalR._.transportError(
                                    signalR.resources.pingServerFailed,
                                    connection.transport,
                                    error,
                                    xhr
                                )
                            );
                        }
                    }
                });
            }
            else {
                deferral.reject(
                    signalR._.transportError(
                        signalR.resources.noConnectionTransport,
                        connection.transport
                    )
                );
            }

            return deferral.promise();
        },

        prepareQueryString: function (connection, url) {
            var preparedUrl;

            // Use addQs to start since it handles the ?/& prefix for us
            preparedUrl = transportLogic.addQs(url, "clientProtocol=" + connection.clientProtocol);

            if (typeof (connection._.redirectQs) === "string") {
                // Add the redirect-specified query string params if any
                preparedUrl = transportLogic.addQs(preparedUrl, connection._.redirectQs);
            } else {
                // Otherwise, add the user-specified query string params if any
                preparedUrl = transportLogic.addQs(preparedUrl, connection.qs);
            }

            if (connection.token) {
                preparedUrl += "&connectionToken=" + window.encodeURIComponent(connection.token);
            }

            if (connection.data) {
                preparedUrl += "&connectionData=" + window.encodeURIComponent(connection.data);
            }

            return preparedUrl;
        },

        addQs: function (url, qs) {
            var appender = url.indexOf("?") !== -1 ? "&" : "?",
                firstChar;

            if (!qs) {
                return url;
            }

            if (typeof (qs) === "object") {
                return url + appender + $.param(qs);
            }

            if (typeof (qs) === "string") {
                firstChar = qs.charAt(0);

                if (firstChar === "?" || firstChar === "&") {
                    appender = "";
                }

                return url + appender + qs;
            }

            throw new Error("Query string property must be either a string or object.");
        },

        // BUG #2953: The url needs to be same otherwise it will cause a memory leak
        getUrl: function (connection, transport, reconnecting, poll, ajaxPost) {
            /// <summary>Gets the url for making a GET based connect request</summary>
            var baseUrl = transport === "webSockets" ? "" : connection.baseUrl,
                url = baseUrl + connection.appRelativeUrl,
                qs = "transport=" + transport;

            if (!ajaxPost && connection.groupsToken) {
                qs += "&groupsToken=" + window.encodeURIComponent(connection.groupsToken);
            }

            if (!reconnecting) {
                url += "/connect";
            } else {
                if (poll) {
                    // longPolling transport specific
                    url += "/poll";
                } else {
                    url += "/reconnect";
                }

                if (!ajaxPost && connection.messageId) {
                    qs += "&messageId=" + window.encodeURIComponent(connection.messageId);
                }
            }
            url += "?" + qs;
            url = transportLogic.prepareQueryString(connection, url);

            // With sse or ws, access_token in request header is not supported
            if (connection.transport && connection.accessToken) {
                if (connection.transport.name === "serverSentEvents" || connection.transport.name === "webSockets") {
                    url += "&access_token=" + window.encodeURIComponent(connection.accessToken);
                }
            }

            if (!ajaxPost) {
                url += "&tid=" + Math.floor(Math.random() * 11);
            }

            return url;
        },

        maximizePersistentResponse: function (minPersistentResponse) {
            return {
                MessageId: minPersistentResponse.C,
                Messages: minPersistentResponse.M,
                Initialized: typeof (minPersistentResponse.S) !== "undefined" ? true : false,
                ShouldReconnect: typeof (minPersistentResponse.T) !== "undefined" ? true : false,
                LongPollDelay: minPersistentResponse.L,
                GroupsToken: minPersistentResponse.G,
                Error: minPersistentResponse.E
            };
        },

        updateGroups: function (connection, groupsToken) {
            if (groupsToken) {
                connection.groupsToken = groupsToken;
            }
        },

        stringifySend: function (connection, message) {
            if (typeof (message) === "string" || typeof (message) === "undefined" || message === null) {
                return message;
            }
            return connection.json.stringify(message);
        },

        ajaxSend: function (connection, data) {
            var payload = transportLogic.stringifySend(connection, data),
                url = getAjaxUrl(connection, "/send"),
                xhr,
                onFail = function (error, connection) {
                    $(connection).triggerHandler(events.onError, [signalR._.transportError(signalR.resources.sendFailed, connection.transport, error, xhr), data]);
                };


            xhr = transportLogic.ajax(connection, {
                url: url,
                type: connection.ajaxDataType === "jsonp" ? "GET" : "POST",
                contentType: signalR._.defaultContentType,
                headers: connection.accessToken ? { "Authorization": "Bearer " + connection.accessToken } : {},
                data: {
                    data: payload
                },
                success: function (result) {
                    var res;

                    if (result) {
                        try {
                            res = connection._parseResponse(result);
                        }
                        catch (error) {
                            onFail(error, connection);
                            connection.stop();
                            return;
                        }

                        transportLogic.triggerReceived(connection, res);
                    }
                },
                error: function (error, textStatus) {
                    if (textStatus === "abort" || textStatus === "parsererror") {
                        // The parsererror happens for sends that don't return any data, and hence
                        // don't write the jsonp callback to the response. This is harder to fix on the server
                        // so just hack around it on the client for now.
                        return;
                    }

                    onFail(error, connection);
                }
            });

            return xhr;
        },

        ajaxAbort: function (connection, async) {
            if (typeof (connection.transport) === "undefined") {
                return;
            }

            // NOTE: our minification fails on the next line - introduced local variable (async) as a workaround
            // Async by default unless explicitly overidden
            var asyncLocal = typeof async === "undefined" ? true : async;

            var url = getAjaxUrl(connection, "/abort");

            var requestHeaders = connection.accessToken ? { "Authorization": "Bearer " + connection.accessToken } : {};

            //option #1 - send "fetch" with keepalive
            if (window.fetch) {
                // use the fetch API with keepalive
                window.fetch(url, {
                    method: "POST",
                    keepalive: true,
                    headers: requestHeaders
                });
            }
            else { 
                // fetch is not available - fallback to $.ajax
                transportLogic.ajax(connection, {
                    url: url,
                    async: asyncLocal,
                    timeout: 1000,
                    type: "POST",
                    headers: requestHeaders,
                    dataType: "text" // We don't want to use JSONP here even when JSONP is enabled
                });
            }

            connection.log("Fired ajax abort async = " + async + ".");
        },

        ajaxStart: function (connection, onSuccess) {
            var rejectDeferred = function (error) {
                    var deferred = connection._deferral;
                    if (deferred) {
                        deferred.reject(error);
                    }
                },
                triggerStartError = function (error) {
                    connection.log("The start request failed. Stopping the connection.");
                    $(connection).triggerHandler(events.onError, [error]);
                    rejectDeferred(error);
                    connection.stop();
                };

            connection._.startRequest = transportLogic.ajax(connection, {
                url: getAjaxUrl(connection, "/start"),
                headers: connection.accessToken ? { "Authorization": "Bearer " + connection.accessToken } : {},
                success: function (result, statusText, xhr) {
                    var data;

                    try {
                        data = connection._parseResponse(result);
                    } catch (error) {
                        triggerStartError(signalR._.error(
                            signalR._.format(signalR.resources.errorParsingStartResponse, result),
                            error, xhr));
                        return;
                    }

                    if (data.Response === "started") {
                        onSuccess();
                    } else {
                        triggerStartError(signalR._.error(
                            signalR._.format(signalR.resources.invalidStartResponse, result),
                            null /* error */, xhr));
                    }
                },
                error: function (xhr, statusText, error) {
                    if (statusText !== startAbortText) {
                        triggerStartError(signalR._.error(
                            signalR.resources.errorDuringStartRequest,
                            error, xhr));
                    } else {
                        // Stop has been called, no need to trigger the error handler
                        // or stop the connection again with onStartError
                        connection.log("The start request aborted because connection.stop() was called.");
                        rejectDeferred(signalR._.error(
                            signalR.resources.stoppedDuringStartRequest,
                            null /* error */, xhr));
                    }
                }
            });
        },

        tryAbortStartRequest: function (connection) {
            if (connection._.startRequest) {
                // If the start request has already completed this will noop.
                connection._.startRequest.abort(startAbortText);
                delete connection._.startRequest;
            }
        },

        tryInitialize: function (connection, persistentResponse, onInitialized) {
            if (persistentResponse.Initialized && onInitialized) {
                onInitialized();
            } else if (persistentResponse.Initialized) {
                connection.log("WARNING! The client received an init message after reconnecting.");
            }

        },

        triggerReceived: function (connection, data) {
            if (!connection._.connectingMessageBuffer.tryBuffer(data)) {
                $(connection).triggerHandler(events.onReceived, [data]);
            }
        },

        processMessages: function (connection, minData, onInitialized) {
            var data;

            if(minData && (typeof minData.I !== "undefined")) {
                // This is a response to a message the client sent
                transportLogic.triggerReceived(connection, minData);
                return;
            }

            // Update the last message time stamp
            transportLogic.markLastMessage(connection);

            if (minData) {
                // This is a message send directly to the client
                data = transportLogic.maximizePersistentResponse(minData);

                if (data.Error) {
                    // This is a global error, stop the connection.
                    connection.log("Received an error message from the server: " + minData.E);
                    $(connection).triggerHandler(signalR.events.onError, [signalR._.error(minData.E, /* source */ "ServerError")]);
                    connection.stop(/* async */ false, /* notifyServer */ false);
                    return;
                }

                transportLogic.updateGroups(connection, data.GroupsToken);

                if (data.MessageId) {
                    connection.messageId = data.MessageId;
                }

                if (data.Messages) {
                    $.each(data.Messages, function (index, message) {
                        transportLogic.triggerReceived(connection, message);
                    });

                    transportLogic.tryInitialize(connection, data, onInitialized);
                }
            }
        },

        monitorKeepAlive: function (connection) {
            var keepAliveData = connection._.keepAliveData;

            // If we haven't initiated the keep alive timeouts then we need to
            if (!keepAliveData.monitoring) {
                keepAliveData.monitoring = true;

                transportLogic.markLastMessage(connection);

                // Save the function so we can unbind it on stop
                connection._.keepAliveData.reconnectKeepAliveUpdate = function () {
                    // Mark a new message so that keep alive doesn't time out connections
                    transportLogic.markLastMessage(connection);
                };

                // Update Keep alive on reconnect
                $(connection).bind(events.onReconnect, connection._.keepAliveData.reconnectKeepAliveUpdate);

                connection.log("Now monitoring keep alive with a warning timeout of " + keepAliveData.timeoutWarning + ", keep alive timeout of " + keepAliveData.timeout + " and disconnecting timeout of " + connection.disconnectTimeout);
            } else {
                connection.log("Tried to monitor keep alive but it's already being monitored.");
            }
        },

        stopMonitoringKeepAlive: function (connection) {
            var keepAliveData = connection._.keepAliveData;

            // Only attempt to stop the keep alive monitoring if its being monitored
            if (keepAliveData.monitoring) {
                // Stop monitoring
                keepAliveData.monitoring = false;

                // Remove the updateKeepAlive function from the reconnect event
                $(connection).unbind(events.onReconnect, connection._.keepAliveData.reconnectKeepAliveUpdate);

                // Clear all the keep alive data
                connection._.keepAliveData = {};
                connection.log("Stopping the monitoring of the keep alive.");
            }
        },

        startHeartbeat: function (connection) {
            connection._.lastActiveAt = new Date().getTime();
            beat(connection);
        },

        markLastMessage: function (connection) {
            connection._.lastMessageAt = new Date().getTime();
            connection._.lastActiveAt = connection._.lastMessageAt;
        },

        markActive: function (connection) {
            if (transportLogic.verifyLastActive(connection)) {
                connection._.lastActiveAt = new Date().getTime();
                return true;
            }

            return false;
        },

        isConnectedOrReconnecting: function (connection) {
            return connection.state === signalR.connectionState.connected ||
                   connection.state === signalR.connectionState.reconnecting;
        },

        ensureReconnectingState: function (connection) {
            if (changeState(connection,
                        signalR.connectionState.connected,
                        signalR.connectionState.reconnecting) === true) {
                $(connection).triggerHandler(events.onReconnecting);
            }
            return connection.state === signalR.connectionState.reconnecting;
        },

        clearReconnectTimeout: function (connection) {
            if (connection && connection._.reconnectTimeout) {
                window.clearTimeout(connection._.reconnectTimeout);
                delete connection._.reconnectTimeout;
            }
        },

        verifyLastActive: function (connection) {
            // If there is no keep alive configured, we cannot assume that timer callbacks will
            // run frequently enough to keep lastActiveAt updated.
            // https://github.com/SignalR/SignalR/issues/4536
            if (!connection._.keepAliveData.activated ||
                new Date().getTime() - connection._.lastActiveAt < connection.reconnectWindow) {
                return true;
            }

            var message = signalR._.format(signalR.resources.reconnectWindowTimeout, new Date(connection._.lastActiveAt), connection.reconnectWindow);
            connection.log(message);
            $(connection).triggerHandler(events.onError, [signalR._.error(message, /* source */ "TimeoutException")]);
            connection.stop(/* async */ false, /* notifyServer */ false);
            return false;
        },

        reconnect: function (connection, transportName) {
            var transport = signalR.transports[transportName];

            // We should only set a reconnectTimeout if we are currently connected
            // and a reconnectTimeout isn't already set.
            if (transportLogic.isConnectedOrReconnecting(connection) && !connection._.reconnectTimeout) {
                // Need to verify before the setTimeout occurs because an application sleep could occur during the setTimeout duration.
                if (!transportLogic.verifyLastActive(connection)) {
                    return;
                }

                connection._.reconnectTimeout = window.setTimeout(function () {
                    if (!transportLogic.verifyLastActive(connection)) {
                        return;
                    }

                    transport.stop(connection);

                    if (transportLogic.ensureReconnectingState(connection)) {
                        connection.log(transportName + " reconnecting.");
                        transport.start(connection);
                    }
                }, connection.reconnectDelay);
            }
        },

        handleParseFailure: function (connection, result, error, onFailed, context) {
            var wrappedError = signalR._.transportError(
                signalR._.format(signalR.resources.parseFailed, result),
                connection.transport,
                error,
                context);

            // If we're in the initialization phase trigger onFailed, otherwise stop the connection.
            if (onFailed && onFailed(wrappedError)) {
                connection.log("Failed to parse server response while attempting to connect.");
            } else {
                $(connection).triggerHandler(events.onError, [wrappedError]);
                connection.stop();
            }
        },

        initHandler: function (connection) {
            return new InitHandler(connection);
        },

        foreverFrame: {
            count: 0,
            connections: {}
        }
    };

}(window.jQuery, window));
/* jquery.signalR.transports.webSockets.js */
// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.


/*global window:false */
/// <reference path="jquery.signalR.transports.common.js" />

(function ($, window, undefined) {

    var signalR = $.signalR,
        events = $.signalR.events,
        changeState = $.signalR.changeState,
        transportLogic = signalR.transports._logic;

    signalR.transports.webSockets = {
        name: "webSockets",

        supportsKeepAlive: function () {
            return true;
        },

        send: function (connection, data) {
            var payload = transportLogic.stringifySend(connection, data);

            try {
                connection.socket.send(payload);
            } catch (ex) {
                $(connection).triggerHandler(events.onError,
                    [signalR._.transportError(
                        signalR.resources.webSocketsInvalidState,
                        connection.transport,
                        ex,
                        connection.socket
                    ),
                    data]);
            }
        },

        start: function (connection, onSuccess, onFailed) {
            var url,
                opened = false,
                that = this,
                reconnecting = !onSuccess,
                $connection = $(connection);

            if (!window.WebSocket) {
                onFailed();
                return;
            }

            if (!connection.socket) {
                if (connection.webSocketServerUrl) {
                    url = connection.webSocketServerUrl;
                } else {
                    url = connection.wsProtocol + connection.host;
                }

                url += transportLogic.getUrl(connection, this.name, reconnecting);

                connection.log("Connecting to websocket endpoint '" + url + "'.");
                connection.socket = new window.WebSocket(url);

                connection.socket.onopen = function () {
                    opened = true;
                    connection.log("Websocket opened.");

                    transportLogic.clearReconnectTimeout(connection);

                    if (changeState(connection,
                                    signalR.connectionState.reconnecting,
                                    signalR.connectionState.connected) === true) {
                        $connection.triggerHandler(events.onReconnect);
                    }
                };

                connection.socket.onclose = function (event) {
                    var error;

                    // Only handle a socket close if the close is from the current socket.
                    // Sometimes on disconnect the server will push down an onclose event
                    // to an expired socket.

                    if (this === connection.socket) {
                        if (opened && typeof event.wasClean !== "undefined" && event.wasClean === false) {
                            // Ideally this would use the websocket.onerror handler (rather than checking wasClean in onclose) but
                            // I found in some circumstances Chrome won't call onerror. This implementation seems to work on all browsers.
                            error = signalR._.transportError(
                                signalR.resources.webSocketClosed,
                                connection.transport,
                                event);

                            connection.log("Unclean disconnect from websocket: " + (event.reason || "[no reason given]."));
                        } else {
                            connection.log("Websocket closed.");
                        }

                        if (!onFailed || !onFailed(error)) {
                            if (error) {
                                $(connection).triggerHandler(events.onError, [error]);
                            }

                            that.reconnect(connection);
                        }
                    }
                };

                connection.socket.onmessage = function (event) {
                    var data;

                    try {
                        data = connection._parseResponse(event.data);
                    }
                    catch (error) {
                        transportLogic.handleParseFailure(connection, event.data, error, onFailed, event);
                        return;
                    }

                    if (data) {
                        transportLogic.processMessages(connection, data, onSuccess);
                    }
                };
            }
        },

        reconnect: function (connection) {
            transportLogic.reconnect(connection, this.name);
        },

        lostConnection: function (connection) {
            this.reconnect(connection);
        },

        stop: function (connection) {
            // Don't trigger a reconnect after stopping
            transportLogic.clearReconnectTimeout(connection);

            if (connection.socket) {
                connection.log("Closing the Websocket.");
                connection.socket.close();
                connection.socket = null;
            }
        },

        abort: function (connection, async) {
            transportLogic.ajaxAbort(connection, async);
        }
    };

}(window.jQuery, window));
/* jquery.signalR.transports.serverSentEvents.js */
// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.


/*global window:false */
/// <reference path="jquery.signalR.transports.common.js" />

(function ($, window, undefined) {

    var signalR = $.signalR,
        events = $.signalR.events,
        changeState = $.signalR.changeState,
        transportLogic = signalR.transports._logic,
        clearReconnectAttemptTimeout = function (connection) {
            window.clearTimeout(connection._.reconnectAttemptTimeoutHandle);
            delete connection._.reconnectAttemptTimeoutHandle;
        };

    signalR.transports.serverSentEvents = {
        name: "serverSentEvents",

        supportsKeepAlive: function () {
            return true;
        },

        timeOut: 3000,

        start: function (connection, onSuccess, onFailed) {
            var that = this,
                opened = false,
                $connection = $(connection),
                reconnecting = !onSuccess,
                url;

            if (connection.eventSource) {
                connection.log("The connection already has an event source. Stopping it.");
                connection.stop();
            }

            if (!window.EventSource) {
                if (onFailed) {
                    connection.log("This browser doesn't support SSE.");
                    onFailed();
                }
                return;
            }

            url = transportLogic.getUrl(connection, this.name, reconnecting);

            try {
                connection.log("Attempting to connect to SSE endpoint '" + url + "'.");
                connection.eventSource = new window.EventSource(url, { withCredentials: connection.withCredentials });
            }
            catch (e) {
                connection.log("EventSource failed trying to connect with error " + e.Message + ".");
                if (onFailed) {
                    // The connection failed, call the failed callback
                    onFailed();
                } else {
                    $connection.triggerHandler(events.onError, [signalR._.transportError(signalR.resources.eventSourceFailedToConnect, connection.transport, e)]);
                    if (reconnecting) {
                        // If we were reconnecting, rather than doing initial connect, then try reconnect again
                        that.reconnect(connection);
                    }
                }
                return;
            }

            if (reconnecting) {
                connection._.reconnectAttemptTimeoutHandle = window.setTimeout(function () {
                    if (opened === false) {
                        // If we're reconnecting and the event source is attempting to connect,
                        // don't keep retrying. This causes duplicate connections to spawn.
                        if (connection.eventSource.readyState !== window.EventSource.OPEN) {
                            // If we were reconnecting, rather than doing initial connect, then try reconnect again
                            that.reconnect(connection);
                        }
                    }
                },
                that.timeOut);
            }

            connection.eventSource.addEventListener("open", function (e) {
                connection.log("EventSource connected.");

                clearReconnectAttemptTimeout(connection);
                transportLogic.clearReconnectTimeout(connection);

                if (opened === false) {
                    opened = true;

                    if (changeState(connection,
                                         signalR.connectionState.reconnecting,
                                         signalR.connectionState.connected) === true) {
                        $connection.triggerHandler(events.onReconnect);
                    }
                }
            }, false);

            connection.eventSource.addEventListener("message", function (e) {
                var res;

                // process messages
                if (e.data === "initialized") {
                    return;
                }

                try {
                    res = connection._parseResponse(e.data);
                }
                catch (error) {
                    transportLogic.handleParseFailure(connection, e.data, error, onFailed, e);
                    return;
                }

                transportLogic.processMessages(connection, res, onSuccess);
            }, false);

            connection.eventSource.addEventListener("error", function (e) {
                var error = signalR._.transportError(
                    signalR.resources.eventSourceError,
                    connection.transport,
                    e);

                // Only handle an error if the error is from the current Event Source.
                // Sometimes on disconnect the server will push down an error event
                // to an expired Event Source.
                if (this !== connection.eventSource) {
                    return;
                }

                if (onFailed && onFailed(error)) {
                    return;
                }

                connection.log("EventSource readyState: " + connection.eventSource.readyState + ".");

                if (e.eventPhase === window.EventSource.CLOSED) {
                    // We don't use the EventSource's native reconnect function as it
                    // doesn't allow us to change the URL when reconnecting. We need
                    // to change the URL to not include the /connect suffix, and pass
                    // the last message id we received.
                    connection.log("EventSource reconnecting due to the server connection ending.");
                    that.reconnect(connection);
                } else {
                    // connection error
                    connection.log("EventSource error.");
                    $connection.triggerHandler(events.onError, [error]);
                }
            }, false);
        },

        reconnect: function (connection) {
            transportLogic.reconnect(connection, this.name);
        },

        lostConnection: function (connection) {
            this.reconnect(connection);
        },

        send: function (connection, data) {
            transportLogic.ajaxSend(connection, data);
        },

        stop: function (connection) {
            // Don't trigger a reconnect after stopping
            clearReconnectAttemptTimeout(connection);
            transportLogic.clearReconnectTimeout(connection);

            if (connection && connection.eventSource) {
                connection.log("EventSource calling close().");
                connection.eventSource.close();
                connection.eventSource = null;
                delete connection.eventSource;
            }
        },

        abort: function (connection, async) {
            transportLogic.ajaxAbort(connection, async);
        }
    };

}(window.jQuery, window));
/* jquery.signalR.transports.foreverFrame.js */
// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.


/*global window:false */
/// <reference path="jquery.signalR.transports.common.js" />

(function ($, window, undefined) {

    var signalR = $.signalR,
        events = $.signalR.events,
        changeState = $.signalR.changeState,
        transportLogic = signalR.transports._logic,
        createFrame = function () {
            var frame = window.document.createElement("iframe");
            frame.setAttribute("style", "position:absolute;top:0;left:0;width:0;height:0;visibility:hidden;");
            return frame;
        },
        // Used to prevent infinite loading icon spins in older versions of ie
        // We build this object inside a closure so we don't pollute the rest of
        // the foreverFrame transport with unnecessary functions/utilities.
        loadPreventer = (function () {
            var loadingFixIntervalId = null,
                loadingFixInterval = 1000,
                attachedTo = 0;

            return {
                prevent: function () {
                    // Prevent additional iframe removal procedures from newer browsers
                    if (signalR._.ieVersion <= 8) {
                        // We only ever want to set the interval one time, so on the first attachedTo
                        if (attachedTo === 0) {
                            // Create and destroy iframe every 3 seconds to prevent loading icon, super hacky
                            loadingFixIntervalId = window.setInterval(function () {
                                var tempFrame = createFrame();

                                window.document.body.appendChild(tempFrame);
                                window.document.body.removeChild(tempFrame);

                                tempFrame = null;
                            }, loadingFixInterval);
                        }

                        attachedTo++;
                    }
                },
                cancel: function () {
                    // Only clear the interval if there's only one more object that the loadPreventer is attachedTo
                    if (attachedTo === 1) {
                        window.clearInterval(loadingFixIntervalId);
                    }

                    if (attachedTo > 0) {
                        attachedTo--;
                    }
                }
            };
        })();

    signalR.transports.foreverFrame = {
        name: "foreverFrame",

        supportsKeepAlive: function () {
            return true;
        },

        // Added as a value here so we can create tests to verify functionality
        iframeClearThreshold: 50,

        start: function (connection, onSuccess, onFailed) {
            if (connection.accessToken) {
                if (onFailed) {
                    connection.log("Forever Frame does not support connections that require a Bearer token to connect, such as the Azure SignalR Service.");
                    onFailed();
                }
                return;
            }

            var that = this,
                frameId = (transportLogic.foreverFrame.count += 1),
                url,
                frame = createFrame(),
                frameLoadHandler = function () {
                    connection.log("Forever frame iframe finished loading and is no longer receiving messages.");
                    if (!onFailed || !onFailed()) {
                        that.reconnect(connection);
                    }
                };

            if (window.EventSource) {
                // If the browser supports SSE, don't use Forever Frame
                if (onFailed) {
                    connection.log("Forever Frame is not supported by SignalR on browsers with SSE support.");
                    onFailed();
                }
                return;
            }

            frame.setAttribute("data-signalr-connection-id", connection.id);

            // Start preventing loading icon
            // This will only perform work if the loadPreventer is not attached to another connection.
            loadPreventer.prevent();

            // Build the url
            url = transportLogic.getUrl(connection, this.name);
            url += "&frameId=" + frameId;

            // add frame to the document prior to setting URL to avoid caching issues.
            window.document.documentElement.appendChild(frame);

            connection.log("Binding to iframe's load event.");

            if (frame.addEventListener) {
                frame.addEventListener("load", frameLoadHandler, false);
            } else if (frame.attachEvent) {
                frame.attachEvent("onload", frameLoadHandler);
            }

            frame.src = url;
            transportLogic.foreverFrame.connections[frameId] = connection;

            connection.frame = frame;
            connection.frameId = frameId;

            if (onSuccess) {
                connection.onSuccess = function () {
                    connection.log("Iframe transport started.");
                    onSuccess();
                };
            }
        },

        reconnect: function (connection) {
            var that = this;

            // Need to verify connection state and verify before the setTimeout occurs because an application sleep could occur during the setTimeout duration.
            if (transportLogic.isConnectedOrReconnecting(connection) && transportLogic.verifyLastActive(connection)) {
                window.setTimeout(function () {
                    // Verify that we're ok to reconnect.
                    if (!transportLogic.verifyLastActive(connection)) {
                        return;
                    }

                    if (connection.frame && transportLogic.ensureReconnectingState(connection)) {
                        var frame = connection.frame,
                            src = transportLogic.getUrl(connection, that.name, true) + "&frameId=" + connection.frameId;
                        connection.log("Updating iframe src to '" + src + "'.");
                        frame.src = src;
                    }
                }, connection.reconnectDelay);
            }
        },

        lostConnection: function (connection) {
            this.reconnect(connection);
        },

        send: function (connection, data) {
            transportLogic.ajaxSend(connection, data);
        },

        receive: function (connection, data) {
            var cw,
                body,
                response;

            if (connection.json !== connection._originalJson) {
                // If there's a custom JSON parser configured then serialize the object
                // using the original (browser) JSON parser and then deserialize it using
                // the custom parser (connection._parseResponse does that). This is so we
                // can easily send the response from the server as "raw" JSON but still
                // support custom JSON deserialization in the browser.
                data = connection._originalJson.stringify(data);
            }

            response = connection._parseResponse(data);

            transportLogic.processMessages(connection, response, connection.onSuccess);

            // Protect against connection stopping from a callback trigger within the processMessages above.
            if (connection.state === $.signalR.connectionState.connected) {
                // Delete the script & div elements
                connection.frameMessageCount = (connection.frameMessageCount || 0) + 1;
                if (connection.frameMessageCount > signalR.transports.foreverFrame.iframeClearThreshold) {
                    connection.frameMessageCount = 0;
                    cw = connection.frame.contentWindow || connection.frame.contentDocument;
                    if (cw && cw.document && cw.document.body) {
                        body = cw.document.body;

                        // Remove all the child elements from the iframe's body to conserver memory
                        while (body.firstChild) {
                            body.removeChild(body.firstChild);
                        }
                    }
                }
            }
        },

        stop: function (connection) {
            var cw = null;

            // Stop attempting to prevent loading icon
            loadPreventer.cancel();

            if (connection.frame) {
                if (connection.frame.stop) {
                    connection.frame.stop();
                } else {
                    try {
                        cw = connection.frame.contentWindow || connection.frame.contentDocument;
                        if (cw.document && cw.document.execCommand) {
                            cw.document.execCommand("Stop");
                        }
                    }
                    catch (e) {
                        connection.log("Error occurred when stopping foreverFrame transport. Message = " + e.message + ".");
                    }
                }

                // Ensure the iframe is where we left it
                if (connection.frame.parentNode === window.document.documentElement) {
                    window.document.documentElement.removeChild(connection.frame);
                }

                delete transportLogic.foreverFrame.connections[connection.frameId];
                connection.frame = null;
                connection.frameId = null;
                delete connection.frame;
                delete connection.frameId;
                delete connection.onSuccess;
                delete connection.frameMessageCount;
                connection.log("Stopping forever frame.");
            }
        },

        abort: function (connection, async) {
            transportLogic.ajaxAbort(connection, async);
        },

        getConnection: function (id) {
            return transportLogic.foreverFrame.connections[id];
        },

        started: function (connection) {
            if (changeState(connection,
                signalR.connectionState.reconnecting,
                signalR.connectionState.connected) === true) {

                $(connection).triggerHandler(events.onReconnect);
            }
        }
    };

}(window.jQuery, window));
/* jquery.signalR.transports.longPolling.js */
// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.


/*global window:false */
/// <reference path="jquery.signalR.transports.common.js" />

(function ($, window, undefined) {

    var signalR = $.signalR,
        events = $.signalR.events,
        changeState = $.signalR.changeState,
        isDisconnecting = $.signalR.isDisconnecting,
        transportLogic = signalR.transports._logic;

    signalR.transports.longPolling = {
        name: "longPolling",

        supportsKeepAlive: function () {
            return false;
        },

        reconnectDelay: 3000,

        start: function (connection, onSuccess, onFailed) {
            /// <summary>Starts the long polling connection</summary>
            /// <param name="connection" type="signalR">The SignalR connection to start</param>
            var that = this,
                fireConnect = function () {
                    fireConnect = $.noop;

                    connection.log("LongPolling connected.");

                    if (onSuccess) {
                        onSuccess();
                    } else {
                        connection.log("WARNING! The client received an init message after reconnecting.");
                    }
                },
                tryFailConnect = function (error) {
                    if (onFailed(error)) {
                        connection.log("LongPolling failed to connect.");
                        return true;
                    }

                    return false;
                },
                privateData = connection._,
                reconnectErrors = 0,
                fireReconnected = function (instance) {
                    window.clearTimeout(privateData.reconnectTimeoutId);
                    privateData.reconnectTimeoutId = null;

                    if (changeState(instance,
                                    signalR.connectionState.reconnecting,
                                    signalR.connectionState.connected) === true) {
                        // Successfully reconnected!
                        instance.log("Raising the reconnect event");
                        $(instance).triggerHandler(events.onReconnect);
                    }
                },
                // 1 hour
                maxFireReconnectedTimeout = 3600000;

            if (connection.pollXhr) {
                connection.log("Polling xhr requests already exists, aborting.");
                connection.stop();
            }

            connection.messageId = null;

            privateData.reconnectTimeoutId = null;

            privateData.pollTimeoutId = window.setTimeout(function () {
                (function poll(instance, raiseReconnect) {
                    var messageId = instance.messageId,
                        connect = (messageId === null),
                        reconnecting = !connect,
                        polling = !raiseReconnect,
                        url = transportLogic.getUrl(instance, that.name, reconnecting, polling, true /* use Post for longPolling */),
                        postData = {};

                    if (instance.messageId) {
                        postData.messageId = instance.messageId;
                    }

                    if (instance.groupsToken) {
                        postData.groupsToken = instance.groupsToken;
                    }

                    // If we've disconnected during the time we've tried to re-instantiate the poll then stop.
                    if (isDisconnecting(instance) === true) {
                        return;
                    }

                    connection.log("Opening long polling request to '" + url + "'.");
                    instance.pollXhr = transportLogic.ajax(connection, {
                        xhrFields: {
                            onprogress: function () {
                                transportLogic.markLastMessage(connection);
                            }
                        },
                        url: url,
                        type: "POST",
                        contentType: signalR._.defaultContentType,
                        data: postData,
                        timeout: connection._.pollTimeout,
                        headers: connection.accessToken ? { "Authorization": "Bearer " + connection.accessToken } : {},
                        success: function (result) {
                            var minData,
                                delay = 0,
                                data,
                                shouldReconnect;

                            connection.log("Long poll complete.");

                            // Reset our reconnect errors so if we transition into a reconnecting state again we trigger
                            // reconnected quickly
                            reconnectErrors = 0;

                            try {
                                // Remove any keep-alives from the beginning of the result
                                minData = connection._parseResponse(result);
                            }
                            catch (error) {
                                transportLogic.handleParseFailure(instance, result, error, tryFailConnect, instance.pollXhr);
                                return;
                            }

                            // If there's currently a timeout to trigger reconnect, fire it now before processing messages
                            if (privateData.reconnectTimeoutId !== null) {
                                fireReconnected(instance);
                            }

                            if (minData) {
                                data = transportLogic.maximizePersistentResponse(minData);
                            }

                            transportLogic.processMessages(instance, minData, fireConnect);

                            if (data &&
                                $.type(data.LongPollDelay) === "number") {
                                delay = data.LongPollDelay;
                            }

                            if (isDisconnecting(instance) === true) {
                                return;
                            }

                            shouldReconnect = data && data.ShouldReconnect;
                            if (shouldReconnect) {
                                // Transition into the reconnecting state
                                // If this fails then that means that the user transitioned the connection into a invalid state in processMessages.
                                if (!transportLogic.ensureReconnectingState(instance)) {
                                    return;
                                }
                            }

                            // We never want to pass a raiseReconnect flag after a successful poll.  This is handled via the error function
                            if (delay > 0) {
                                privateData.pollTimeoutId = window.setTimeout(function () {
                                    poll(instance, shouldReconnect);
                                }, delay);
                            } else {
                                poll(instance, shouldReconnect);
                            }
                        },

                        error: function (data, textStatus) {
                            var error = signalR._.transportError(signalR.resources.longPollFailed, connection.transport, data, instance.pollXhr);

                            // Stop trying to trigger reconnect, connection is in an error state
                            // If we're not in the reconnect state this will noop
                            window.clearTimeout(privateData.reconnectTimeoutId);
                            privateData.reconnectTimeoutId = null;

                            if (textStatus === "abort") {
                                connection.log("Aborted xhr request.");
                                return;
                            }

                            if (!tryFailConnect(error)) {

                                // Increment our reconnect errors, we assume all errors to be reconnect errors
                                // In the case that it's our first error this will cause Reconnect to be fired
                                // after 1 second due to reconnectErrors being = 1.
                                reconnectErrors++;

                                if (connection.state !== signalR.connectionState.reconnecting) {
                                    connection.log("An error occurred using longPolling. Status = " + textStatus + ".  Response = " + data.responseText + ".");
                                    $(instance).triggerHandler(events.onError, [error]);
                                }

                                // We check the state here to verify that we're not in an invalid state prior to verifying Reconnect.
                                // If we're not in connected or reconnecting then the next ensureReconnectingState check will fail and will return.
                                // Therefore we don't want to change that failure code path.
                                if ((connection.state === signalR.connectionState.connected ||
                                    connection.state === signalR.connectionState.reconnecting) &&
                                    !transportLogic.verifyLastActive(connection)) {
                                    return;
                                }

                                // Transition into the reconnecting state
                                // If this fails then that means that the user transitioned the connection into the disconnected or connecting state within the above error handler trigger.
                                if (!transportLogic.ensureReconnectingState(instance)) {
                                    return;
                                }

                                // Call poll with the raiseReconnect flag as true after the reconnect delay
                                privateData.pollTimeoutId = window.setTimeout(function () {
                                    poll(instance, true);
                                }, that.reconnectDelay);
                            }
                        }
                    });

                    // This will only ever pass after an error has occurred via the poll ajax procedure.
                    if (reconnecting && raiseReconnect === true) {
                        // We wait to reconnect depending on how many times we've failed to reconnect.
                        // This is essentially a heuristic that will exponentially increase in wait time before
                        // triggering reconnected.  This depends on the "error" handler of Poll to cancel this
                        // timeout if it triggers before the Reconnected event fires.
                        // The Math.min at the end is to ensure that the reconnect timeout does not overflow.
                        privateData.reconnectTimeoutId = window.setTimeout(function () { fireReconnected(instance); }, Math.min(1000 * (Math.pow(2, reconnectErrors) - 1), maxFireReconnectedTimeout));
                    }
                }(connection));
            }, 250); // Have to delay initial poll so Chrome doesn't show loader spinner in tab
        },

        lostConnection: function (connection) {
            if (connection.pollXhr) {
                connection.pollXhr.abort("lostConnection");
            }
        },

        send: function (connection, data) {
            transportLogic.ajaxSend(connection, data);
        },

        stop: function (connection) {
            /// <summary>Stops the long polling connection</summary>
            /// <param name="connection" type="signalR">The SignalR connection to stop</param>

            window.clearTimeout(connection._.pollTimeoutId);
            window.clearTimeout(connection._.reconnectTimeoutId);

            delete connection._.pollTimeoutId;
            delete connection._.reconnectTimeoutId;

            if (connection.pollXhr) {
                connection.pollXhr.abort();
                connection.pollXhr = null;
                delete connection.pollXhr;
            }
        },

        abort: function (connection, async) {
            transportLogic.ajaxAbort(connection, async);
        }
    };

}(window.jQuery, window));
/* jquery.signalR.hubs.js */
// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

/*global window:false */
/// <reference path="jquery.signalR.core.js" />

(function ($, window, undefined) {

    var nextGuid = 0;
    var eventNamespace = ".hubProxy",
        signalR = $.signalR;

    function makeEventName(event) {
        return event + eventNamespace;
    }

    // Equivalent to Array.prototype.map
    function map(arr, fun, thisp) {
        var i,
            length = arr.length,
            result = [];
        for (i = 0; i < length; i += 1) {
            if (arr.hasOwnProperty(i)) {
                result[i] = fun.call(thisp, arr[i], i, arr);
            }
        }
        return result;
    }

    function getArgValue(a) {
        return $.isFunction(a) ? null : ($.type(a) === "undefined" ? null : a);
    }

    function hasMembers(obj) {
        for (var key in obj) {
            // If we have any properties in our callback map then we have callbacks and can exit the loop via return
            if (obj.hasOwnProperty(key)) {
                return true;
            }
        }

        return false;
    }

    function clearInvocationCallbacks(connection, error) {
        /// <param name="connection" type="hubConnection" />
        var callbacks = connection._.invocationCallbacks,
            callback;

        if (hasMembers(callbacks)) {
            connection.log("Clearing hub invocation callbacks with error: " + error + ".");
        }

        // Reset the callback cache now as we have a local var referencing it
        connection._.invocationCallbackId = 0;
        delete connection._.invocationCallbacks;
        connection._.invocationCallbacks = {};

        // Loop over the callbacks and invoke them.
        // We do this using a local var reference and *after* we've cleared the cache
        // so that if a fail callback itself tries to invoke another method we don't
        // end up with its callback in the list we're looping over.
        for (var callbackId in callbacks) {
            callback = callbacks[callbackId];
            callback.method.call(callback.scope, { E: error });
        }
    }

    function isCallbackFromGeneratedHubProxy(callback) {
        // https://github.com/SignalR/SignalR/issues/4310
        // The stringified callback from the old generated hub proxy is 137 characters in Edge, Firefox and Chrome.
        // We slice to avoid wasting too many cycles searching through the text of a long large function.
        return $.isFunction(callback) && callback.toString().slice(0, 256).indexOf("// Call the client hub method") >= 0;
    }

    // hubProxy
    function hubProxy(hubConnection, hubName) {
        /// <summary>
        ///     Creates a new proxy object for the given hub connection that can be used to invoke
        ///     methods on server hubs and handle client method invocation requests from the server.
        /// </summary>
        return new hubProxy.fn.init(hubConnection, hubName);
    }

    hubProxy.fn = hubProxy.prototype = {
        init: function (connection, hubName) {
            this.state = {};
            this.connection = connection;
            this.hubName = hubName;
            this._ = {
                callbackMap: {}
            };
        },

        constructor: hubProxy,

        hasSubscriptions: function () {
            return hasMembers(this._.callbackMap);
        },

        on: function (eventName, callback, callbackIdentity) {
            /// <summary>Wires up a callback to be invoked when a invocation request is received from the server hub.</summary>
            /// <param name="eventName" type="String">The name of the hub event to register the callback for.</param>
            /// <param name="callback" type="Function">The callback to be invoked.</param>
            /// <param name="callbackIdentity" type="Object">An optional object to use as the "identity" for the callback when checking if the handler has already been registered. Defaults to the value of 'callback' if not provided.</param>
            var that = this,
                callbackMap = that._.callbackMap,
                isFromOldGeneratedHubProxy = !callbackIdentity && isCallbackFromGeneratedHubProxy(callback);

            // We need the third "identity" argument because the registerHubProxies call made by signalr/js wraps the user-provided callback in a custom wrapper which breaks the identity comparison.
            // callbackIdentity allows the caller of `on` to provide a separate object to use as the "identity". `registerHubProxies` uses the original user callback as this identity object.
            callbackIdentity = callbackIdentity || callback;

            // Assign a global ID to the identity object. This tags the object so we can detect the same object when it comes back.
            if(!callbackIdentity._signalRGuid) {
                callbackIdentity._signalRGuid = nextGuid++;
            }

            // Normalize the event name to lowercase
            eventName = eventName.toLowerCase();

            // If there is not an event registered for this callback yet we want to create its event space in the callback map.
            var callbackSpace = callbackMap[eventName];
            if (!callbackSpace) {
                callbackSpace = [];
                callbackMap[eventName] = callbackSpace;
            }

            // Check if there's already a registration
            var registration;
            for (var i = 0; i < callbackSpace.length; i++) {
                if (callbackSpace[i].guid === callbackIdentity._signalRGuid || (isFromOldGeneratedHubProxy && callbackSpace[i].isFromOldGeneratedHubProxy)) {
                    registration = callbackSpace[i];
                }
            }

            // Create a registration if there isn't one already
            if (!registration) {
                registration = {
                    guid: callbackIdentity._signalRGuid,
                    eventHandlers: [],
                    isFromOldGeneratedHubProxy: isFromOldGeneratedHubProxy
                };
                callbackMap[eventName].push(registration);
            }

            var handler = function (e, data) {
                callback.apply(that, data);
            };
            registration.eventHandlers.push(handler);

            $(that).bind(makeEventName(eventName), handler);

            return that;
        },

        off: function (eventName, callback, callbackIdentity) {
            /// <summary>Removes the callback invocation request from the server hub for the given event name.</summary>
            /// <param name="eventName" type="String">The name of the hub event to unregister the callback for.</param>
            /// <param name="callback" type="Function">The callback to be removed.</param>
            /// <param name="callbackIdentity" type="Object">An optional object to use as the "identity" when looking up the callback. Corresponds to the same parameter provided to 'on'. Defaults to the value of 'callback' if not provided.</param>
            var that = this,
                callbackMap = that._.callbackMap,
                callbackSpace,
                isFromOldGeneratedHubProxy = !callbackIdentity && isCallbackFromGeneratedHubProxy(callback);

            callbackIdentity = callbackIdentity || callback;

            // Normalize the event name to lowercase
            eventName = eventName.toLowerCase();

            callbackSpace = callbackMap[eventName];

            // Verify that there is an event space to unbind
            if (callbackSpace) {

                if (callback) {
                    // Find the callback registration
                    var callbackRegistration;
                    var callbackIndex;
                    for (var i = 0; i < callbackSpace.length; i++) {
                        if (callbackSpace[i].guid === callbackIdentity._signalRGuid || (isFromOldGeneratedHubProxy && callbackSpace[i].isFromOldGeneratedHubProxy)) {
                            callbackIndex = i;
                            callbackRegistration = callbackSpace[i];
                        }
                    }

                    // Only unbind if there's an event bound with eventName and a callback with the specified callback
                    if (callbackRegistration) {
                        // Unbind all event handlers associated with the registration.
                        for (var j = 0; j < callbackRegistration.eventHandlers.length; j++) {
                            $(that).unbind(makeEventName(eventName), callbackRegistration.eventHandlers[j]);
                        }

                        // Remove the registration from the list
                        callbackSpace.splice(i, 1);

                        // Check if there are any registrations left, if not we need to destroy it.
                        if (callbackSpace.length === 0) {
                            delete callbackMap[eventName];
                        }
                    }
                } else if (!callback) { // Check if we're removing the whole event and we didn't error because of an invalid callback
                    $(that).unbind(makeEventName(eventName));

                    delete callbackMap[eventName];
                }
            }

            return that;
        },

        invoke: function (methodName) {
            /// <summary>Invokes a server hub method with the given arguments.</summary>
            /// <param name="methodName" type="String">The name of the server hub method.</param>

            var that = this,
                connection = that.connection,
                args = $.makeArray(arguments).slice(1),
                argValues = map(args, getArgValue),
                data = { H: that.hubName, M: methodName, A: argValues, I: connection._.invocationCallbackId },
                d = $.Deferred(),
                callback = function (minResult) {
                    var result = that._maximizeHubResponse(minResult),
                        source,
                        error;

                    // Update the hub state
                    $.extend(that.state, result.State);

                    if (result.Progress) {
                        if (d.notifyWith) {
                            // Progress is only supported in jQuery 1.7+
                            d.notifyWith(that, [result.Progress.Data]);
                        } else if (!connection._.progressjQueryVersionLogged) {
                            connection.log("A hub method invocation progress update was received but the version of jQuery in use (" + $.prototype.jquery + ") does not support progress updates. Upgrade to jQuery 1.7+ to receive progress notifications.");
                            connection._.progressjQueryVersionLogged = true;
                        }
                    } else if (result.Error) {
                        // Server hub method threw an exception, log it & reject the deferred
                        if (result.StackTrace) {
                            connection.log(result.Error + "\n" + result.StackTrace + ".");
                        }

                        // result.ErrorData is only set if a HubException was thrown
                        source = result.IsHubException ? "HubException" : "Exception";
                        error = signalR._.error(result.Error, source);
                        error.data = result.ErrorData;

                        connection.log(that.hubName + "." + methodName + " failed to execute. Error: " + error.message);
                        d.rejectWith(that, [error]);
                    } else {
                        // Server invocation succeeded, resolve the deferred
                        connection.log("Invoked " + that.hubName + "." + methodName);
                        d.resolveWith(that, [result.Result]);
                    }
                };

            connection._.invocationCallbacks[connection._.invocationCallbackId.toString()] = { scope: that, method: callback };
            connection._.invocationCallbackId += 1;

            if (!$.isEmptyObject(that.state)) {
                data.S = that.state;
            }

            connection.log("Invoking " + that.hubName + "." + methodName);
            connection.send(data);

            return d.promise();
        },

        _maximizeHubResponse: function (minHubResponse) {
            return {
                State: minHubResponse.S,
                Result: minHubResponse.R,
                Progress: minHubResponse.P ? {
                    Id: minHubResponse.P.I,
                    Data: minHubResponse.P.D
                } : null,
                Id: minHubResponse.I,
                IsHubException: minHubResponse.H,
                Error: minHubResponse.E,
                StackTrace: minHubResponse.T,
                ErrorData: minHubResponse.D
            };
        }
    };

    hubProxy.fn.init.prototype = hubProxy.fn;

    // hubConnection
    function hubConnection(url, options) {
        /// <summary>Creates a new hub connection.</summary>
        /// <param name="url" type="String">[Optional] The hub route url, defaults to "/signalr".</param>
        /// <param name="options" type="Object">[Optional] Settings to use when creating the hubConnection.</param>
        var settings = {
            qs: null,
            logging: false,
            useDefaultPath: true
        };

        $.extend(settings, options);

        if (!url || settings.useDefaultPath) {
            url = (url || "") + "/signalr";
        }
        return new hubConnection.fn.init(url, settings);
    }

    hubConnection.fn = hubConnection.prototype = $.connection();

    hubConnection.fn.init = function (url, options) {
        var settings = {
            qs: null,
            logging: false,
            useDefaultPath: true
        },
            connection = this;

        $.extend(settings, options);

        // Call the base constructor
        $.signalR.fn.init.call(connection, url, settings.qs, settings.logging);

        // Object to store hub proxies for this connection
        connection.proxies = {};

        connection._.invocationCallbackId = 0;
        connection._.invocationCallbacks = {};

        // Wire up the received handler
        connection.received(function (minData) {
            var data, proxy, dataCallbackId, callback, hubName, eventName;
            if (!minData) {
                return;
            }

            // We have to handle progress updates first in order to ensure old clients that receive
            // progress updates enter the return value branch and then no-op when they can't find
            // the callback in the map (because the minData.I value will not be a valid callback ID)
            // Process progress notification
            if (typeof (minData.P) !== "undefined") {
                dataCallbackId = minData.P.I.toString();
                callback = connection._.invocationCallbacks[dataCallbackId];
                if (callback) {
                    callback.method.call(callback.scope, minData);
                }
            } else if (typeof (minData.I) !== "undefined") {
                // We received the return value from a server method invocation, look up callback by id and call it
                dataCallbackId = minData.I.toString();
                callback = connection._.invocationCallbacks[dataCallbackId];
                if (callback) {
                    // Delete the callback from the proxy
                    connection._.invocationCallbacks[dataCallbackId] = null;
                    delete connection._.invocationCallbacks[dataCallbackId];

                    // Invoke the callback
                    callback.method.call(callback.scope, minData);
                }
            } else {
                data = this._maximizeClientHubInvocation(minData);

                // We received a client invocation request, i.e. broadcast from server hub
                connection.log("Triggering client hub event '" + data.Method + "' on hub '" + data.Hub + "'.");

                // Normalize the names to lowercase
                hubName = data.Hub.toLowerCase();
                eventName = data.Method.toLowerCase();

                // Trigger the local invocation event
                proxy = this.proxies[hubName];

                // Update the hub state
                $.extend(proxy.state, data.State);
                $(proxy).triggerHandler(makeEventName(eventName), [data.Args]);
            }
        });

        connection.error(function (errData, origData) {
            var callbackId, callback;

            if (!origData) {
                // No original data passed so this is not a send error
                return;
            }

            callbackId = origData.I;
            callback = connection._.invocationCallbacks[callbackId];

            // Verify that there is a callback bound (could have been cleared)
            if (callback) {
                // Delete the callback
                connection._.invocationCallbacks[callbackId] = null;
                delete connection._.invocationCallbacks[callbackId];

                // Invoke the callback with an error to reject the promise
                callback.method.call(callback.scope, { E: errData });
            }
        });

        connection.reconnecting(function () {
            if (connection.transport && connection.transport.name === "webSockets") {
                clearInvocationCallbacks(connection, "Connection started reconnecting before invocation result was received.");
            }
        });

        connection.disconnected(function () {
            clearInvocationCallbacks(connection, "Connection was disconnected before invocation result was received.");
        });
    };

    hubConnection.fn._maximizeClientHubInvocation = function (minClientHubInvocation) {
        return {
            Hub: minClientHubInvocation.H,
            Method: minClientHubInvocation.M,
            Args: minClientHubInvocation.A,
            State: minClientHubInvocation.S
        };
    };

    hubConnection.fn._registerSubscribedHubs = function () {
        /// <summary>
        ///     Sets the starting event to loop through the known hubs and register any new hubs
        ///     that have been added to the proxy.
        /// </summary>
        var connection = this;

        if (!connection._subscribedToHubs) {
            connection._subscribedToHubs = true;
            connection.starting(function () {
                // Set the connection's data object with all the hub proxies with active subscriptions.
                // These proxies will receive notifications from the server.
                var subscribedHubs = [];

                $.each(connection.proxies, function (key) {
                    if (this.hasSubscriptions()) {
                        subscribedHubs.push({ name: key });
                        connection.log("Client subscribed to hub '" + key + "'.");
                    }
                });

                if (subscribedHubs.length === 0) {
                    connection.log("No hubs have been subscribed to.  The client will not receive data from hubs.  To fix, declare at least one client side function prior to connection start for each hub you wish to subscribe to.");
                }

                connection.data = connection.json.stringify(subscribedHubs);
            });
        }
    };

    hubConnection.fn.createHubProxy = function (hubName) {
        /// <summary>
        ///     Creates a new proxy object for the given hub connection that can be used to invoke
        ///     methods on server hubs and handle client method invocation requests from the server.
        /// </summary>
        /// <param name="hubName" type="String">
        ///     The name of the hub on the server to create the proxy for.
        /// </param>

        // Normalize the name to lowercase
        hubName = hubName.toLowerCase();

        var proxy = this.proxies[hubName];
        if (!proxy) {
            proxy = hubProxy(this, hubName);
            this.proxies[hubName] = proxy;
        }

        this._registerSubscribedHubs();

        return proxy;
    };

    hubConnection.fn.init.prototype = hubConnection.fn;

    $.hubConnection = hubConnection;

}(window.jQuery, window));
/* jquery.signalR.version.js */
// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.


/*global window:false */
/// <reference path="jquery.signalR.core.js" />
(function ($, undefined) {
    // This will be modified by the build script
    $.signalR.version = "2.4.2";
}(window.jQuery));
/* eslint-env commonjs, amd, jquery */

// UMD based on https://github.com/umdjs/umd/blob/master/templates/returnExports.js
// TODO: move to ES6 and transpiler

(function (root, factory) {
    if (typeof define === 'function' && define.amd) {
        // AMD. Register as an anonymous module.
        define([
            'jquery',
            './utils',
            './promise',
            './console',
            './wvy'
        ], factory);
    } else if (typeof module === 'object' && module.exports) {
        // Node. Does not work with strict CommonJS, but
        // only CommonJS-like environments that support module.exports,
        // like Node.
        root.wvy = root.wvy || {};
        module.exports = factory(
            require('jquery'),
            require('./utils'),
            require('./promise'),
            require('./console'),
            require('./wvy')
        );
    } else {
        // Browser globals (root is window)
        //root.wvy = root.wvy || {};
        root.wvy.connection = root.wvy.connection || new factory(jQuery, root.wvy.utils, root.wvy.promise, root.wvy.console, root.wvy);
    }
}(typeof self !== 'undefined' ? self : this, function ($, WeavyUtils, WeavyPromise, WeavyConsole, wvy) {


    //console.debug("connection.js", window.name);

    function sanitizeObject(obj) {
        return JSON.parse(JSON.stringify(obj, WeavyUtils.sanitizeJSON));
    }

    var connections = this;

    // CONNECTION HANDLING
    var _connections = new Map();

    function WeavyConnection(url) {
        /**
         *  Reference to this instance
         *  @lends WeavyConnection#
         */
        var weavyConnection = this;

        var console = new WeavyConsole("WeavyConnection");

        var initialized = false;
        var reconnecting = false;

        // use configured transport or fallback to "auto"
        // REVIEW: looks like it performs negotiation even if we explicitly specify a transport?
        var transport = wvy.config && wvy.config.transport || "auto";

        // Set explicit self url
        url = url || window.location.origin + (wvy.config && wvy.config.applicationPath || "/");

        // Remove trailing slash
        url = /\/$/.test(url) ? url.slice(0, -1) : url;

        var connectionUrl = url + "/signalr";

        // create a new hub connection
        var connection = $.hubConnection(connectionUrl, { useDefaultPath: false });

        // configure logging and connection lifetime events
        //connection.logging = true;

        // create hub proxy (why multiple? do we have a client hub?)
        //var hubProxies = { rtm: connection.createHubProxy('rtm'), client: connection.createHubProxy('client') }; 
        var hubProxies = { rtm: connection.createHubProxy('rtm') };

        // we have to register (at least one) event handler before calling the start method
        hubProxies["rtm"].on("eventReceived", rtmEventRecieved);

        var _events = [];
        var _reconnectMessageTimeout = null;
        var _reconnectInterval = null;
        var reconnectRetries = 0;
        var explicitlyDisconnected = false;

        var whenConnectionStart;
        var whenConnected = new WeavyPromise();
        var whenLeaderElected = new WeavyPromise();
        var whenAuthenticated = new WeavyPromise();

        var states = $.signalR.connectionState;

        // Provide reverse readable state strings
        // And convert strings to int
        for (var stateName in states) {
            if (Object.prototype.hasOwnProperty.call(states, stateName)) {
                states[states[stateName]] = stateName;
                states[stateName] = parseInt(states[stateName]);
            }
        }

        var state = parseInt(states.disconnected);
        var childConnection = null;
        var connectedAt = null;


        //----------------------------------------------------------
        // Init the connection
        // url: the url to the /signalr 
        // windows: initial [] of windows to post incoming events to when embedded
        // force: if to connect event if the user is not logged in
        //----------------------------------------------------------
        function init(connectAfterInit, authentication) {
            if (!initialized) {
                initialized = true;
                console.debug("init" + (!window.name ? "self" : "") + " to " + url, connectAfterInit ? "and connect" : "");

                wvy.postal.whenLeader().then(function (isLeader) {
                    if (isLeader) {
                        console.debug("is leader, let's go");
                        childConnection = false;
                        whenLeaderElected.resolve(true);
                    } else {
                        childConnection = true;
                        whenLeaderElected.resolve(false);
                    }
                });

                authentication = authentication || wvy.authentication.get(url);

                authentication.whenAuthenticated().then(function () {
                    whenAuthenticated.resolve();
                });

                authentication.on("user", function (e, auth) {
                    if (auth.state !== "updated") {
                        disconnectAndConnect();
                    }
                });

                on("reconnected.connection.weavy", function (e) {
                    if (authentication.isAuthenticated()) {
                        // Check if user state is still valid
                        authentication.updateUserState("wvy.connection:reconnected");
                    }
                });

                wvy.postal.on("distribute", { weavyId: "wvy.connection", connectionUrl: connectionUrl }, onParentMessageReceived);
                wvy.postal.on("message", { weavyId: "wvy.connection", connectionUrl: connectionUrl }, onChildMessageReceived);
            }

            if (connectAfterInit) {
                // Only explicitly connect the leader
                return whenLeaderElected().then(function (leader) {
                    if (leader) {
                        connectionStart();
                    }
                    return whenConnected();
                });
            } else {
                return whenLeaderElected();
            }
        }

        function connect() {
            return whenLeaderElected().then(function (leader) {
                if (leader) {
                    connectionStart();
                } else {
                    wvy.postal.postToParent({ name: "request:connection-start", weavyId: "wvy.connection", connectionUrl: connectionUrl });
                }
                return whenConnected();
            });
        }

        // start the connection
        function connectionStart() {
            return whenAuthenticated().then(function () {
                explicitlyDisconnected = false;

                if (status() === states.disconnected) {
                    state = states.connecting;
                    triggerEvent("state-changed.connection.weavy", { state: state });

                    whenConnectionStart = connection.start({ transport: transport }).always(function () {
                        console.debug((childConnection ? "child " : "") + "connection started");
                        wvy.postal.postToChildren({ name: "connection-started", weavyId: "wvy.connection", connectionUrl: connectionUrl });
                        whenConnected.resolve();
                    }).catch(function (error) {
                        console.warn((childConnection ? "child " : "") + "could not start connection")
                    });
                }

                return whenConnectionStart;
            });
        }

        // stop connection
        function disconnect(async, notify) {
            if (!childConnection && connection.state !== states.disconnected && explicitlyDisconnected === false) {
                explicitlyDisconnected = true;
                whenConnected.reset();

                try {
                    connection.stop(async === true, notify !== false).then(function () {
                        return Promise.resolve();
                    }).catch(function () {
                        return Promise.resolve();
                    });
                } catch (e) {
                    return Promise.resolve();
                }
            } else {
                return Promise.resolve();
            }
        }

        function disconnectAndConnect() {
            return new Promise(function (resolve) {
                if (!childConnection && connection.state !== states.disconnected) {
                    explicitlyDisconnected = false;
                    disconnect(true, false).then(function () {
                        connect().then(resolve);
                    });
                } else {
                    resolve();
                }
            });
        }

        function status() {
            return parseInt(state);
        }

        // attach an event handler for the specified connection or server event, e.g. "presence", "typing" etc (see PushService for a list of built-in events)
        function on(event, handler) {
            if (event.indexOf(".connection") !== -1) {
                // .connection.weavy (connection events)
                event = event.indexOf(".weavy") === -1 ? event + ".weavy" : event;
            } else {
                // .rtmweavy (realtime events)
                event = event.indexOf(".rtmweavy") === -1 ? event + ".rtmweavy" : event;
            }
            _events.push([event, handler]);
            $(weavyConnection).on(event, null, null, handler);
        }

        function off(event, handler) {
            if (event.indexOf(".connection") !== -1) {
                // .connection.weavy (connection events)
                event = event.indexOf(".weavy") === -1 ? event + ".weavy" : event;
            } else {
                // .rtmweavy (realtime events)
                event = event.indexOf(".rtmweavy") === -1 ? event + ".rtmweavy" : event;
            }

            _events = _events.filter(function (eventHandler) {
                if (eventHandler[0] === event && eventHandler[1] === handler) {
                    $(weavyConnection).off(event, null, handler);
                    return false;
                } else {
                    return true;
                }
            })
        }

        function triggerEvent(name) {
            console.debug("triggering event " + name);
            var event = $.Event(name);

            // trigger event (with json object instead of string), handle any number of json objects passed from hub (args)
            var argumentArray = [].slice.call(arguments, 1);
            var data = argumentArray.map(function (a) {
                if (a && !$.isArray(a) && !$.isPlainObject(a)) {
                    try {
                        return JSON.parse(a);
                    } catch (e) {
                        console.warn((childConnection ? "child " : "") + "could not parse event data;", name);
                    }
                }
                return a;
            });

            $(weavyConnection).triggerHandler(event, data);
            triggerToChildren("distribute-event", name, data);
        }

        // trigger a message distribute
        function triggerToChildren(name, eventName, data) {
            try {
                wvy.postal.postToChildren({ name: name, eventName: eventName, data: data, weavyId: "wvy.connection", connectionUrl: connectionUrl });
            } catch (e) {
                console.warn((childConnection ? "child " : "") + "could not distribute relay realtime message", { name: name, eventName: eventName }, e);
            }
        }

        // invoke a method on a server hub, e.g. "SetActive" on the RealTimeHub (rtm) or "Typing" on the MessengerHub (messenger).
        function invoke(hub, method, data) {
            var args = data ? [method, sanitizeObject(data)] : [method];

            var whenInvoked = new Promise(function (resolve, reject) {

                whenLeaderElected().then(function (leader) {
                    if (leader) {

                        console.debug("wvy.connection: invoke as leader", hub, args[0]);
                        var proxy = hubProxies[hub];

                        connect().then(function () {
                            proxy.invoke.apply(proxy, args)
                                .then(function (invokeResult) {

                                    // Try JSON parse
                                    if (typeof invokeResult === "string") {
                                        try {
                                            invokeResult = JSON.parse(invokeResult);
                                        } catch (e) { /* Ignore catch */ }
                                    }

                                    resolve(invokeResult);
                                })
                                .catch(function (error) {
                                    //console.warn(error, hub, args);
                                    reject(error);
                                });
                        });
                    } else {
                        // Invoke via parent
                        var invokeId = "wvy.connection-" + Math.random().toString().substr(2);
                        console.debug("invoke via parent", hub, args[0], invokeId);

                        var invokeResult = function (msg) {
                            if (msg.data.name === "invokeResult" && msg.data.invokeId === invokeId) {
                                console.debug("parent invokeResult received", invokeId);
                                if (msg.data.error) {
                                    reject(msg.data.error);
                                } else {
                                    var invokeResult = msg.data.result;

                                    // Try JSON parse
                                    if (typeof invokeResult === "string") {
                                        try {
                                            invokeResult = JSON.parse(invokeResult);
                                        } catch (e) { /* Ignore catch */ }
                                    }
                                    resolve(invokeResult);
                                }
                                wvy.postal.off("invokeResult", { weavyId: "wvy.connection", connectionUrl: connectionUrl }, invokeResult);
                            }
                        };

                        wvy.postal.on("invokeResult", { weavyId: "wvy.connection", connectionUrl: connectionUrl }, invokeResult);

                        wvy.postal.postToParent({ name: "invoke", hub: hub, args: args, invokeId: invokeId, weavyId: "wvy.connection", connectionUrl: connectionUrl });
                    }
                });
            });

            return whenInvoked;
        }




        connection.stateChanged(function (connectionState) {
            // Make sure connectionState is int
            var newState = parseInt(connectionState.newState);

            if (newState === states.connected) {
                if (childConnection) {
                    console.debug("child connected " + connection.id + " (" + connection.transport.name + ")");
                } else {
                    console.log("connected " + connection.id + " (" + connection.transport.name + ")");
                }

                // clear timeouts
                window.clearTimeout(_reconnectMessageTimeout);
                window.clearInterval(_reconnectInterval);

                // reset retries
                reconnectRetries = 0;

                if (wvy.alert) {
                    wvy.alert.close("connection-state");
                } else {
                    triggerToChildren("alert", "close", "connection-state");
                }

                whenConnected.resolve();

                // Trigger reconnected on connect excluding the first connect
                if (connectedAt) {
                    triggerEvent("reconnected.connection.weavy");
                }

                connectedAt = new Date();
            }

            state = newState;
            // trigger event
            triggerEvent("state-changed.connection.weavy", { state: newState });
        });

        connection.reconnected(function () {
            reconnecting = false;
        });

        connection.reconnecting(function () {
            reconnecting = true;
            if (childConnection) {
                console.debug("child reconnecting...");
            } else {
                console.log("reconnecting...");
            }

            // wait 2 seconds before showing message
            if (_reconnectMessageTimeout !== null) {
                window.clearTimeout(_reconnectMessageTimeout);
            }

            _reconnectMessageTimeout = setTimeout(function () {
                if (wvy.alert) {
                    wvy.alert.alert("primary", wvy.t("Reconnecting..."), null, "connection-state");
                } else {
                    triggerToChildren("alert", "show", { type: "primary", title: wvy.t("Reconnecting..."), id: "connection-state" });
                }
            }, 2000);
        });

        connection.disconnected(function () {
            console.debug((childConnection ? "child " : "") + "disconnected");

            if (!explicitlyDisconnected) {
                reconnectRetries++;
                window.clearInterval(_reconnectInterval);

                if (reconnecting) {
                    connection.start({ transport: transport }).catch((reason) => {
                        console.warn("could not connect", reason)

                    });
                    reconnecting = false;
                } else {
                    // connection dropped, try to connect again after 5s
                    _reconnectInterval = window.setInterval(function () {
                        if (window.navigator.onLine) {
                            connection.start({ transport: transport }).catch((reason) => {
                                console.warn("could not reconnect", reason)
                            });
                            window.clearInterval(_reconnectInterval)
                        } else {
                            console.debug("waiting for online")
                        }
                    }, 5000);
                }
            }

            // trigger event
            triggerEvent("disconnected.connection.weavy", { retries: reconnectRetries, explicitlyDisconnected: explicitlyDisconnected });

        });

        // REALTIME EVENTS

        // generic callback used by server to notify clients that a realtime event happened
        // NOTE: we only need to hook this up in standalone, in the weavy client we wrap realtime events in the cross-frame-event and post to the frames
        function rtmEventRecieved(name, args) {
            console.debug("received event " + name);
            name = name.indexOf(".rtmweavy" === -1) ? name + ".rtmweavy" : name;
            triggerEvent(name, args);
        }

        // REALTIME CROSS WINDOW MESSAGE
        // handle cross frame events from rtm
        var onChildMessageReceived = function (e) {
            var msg = e.data;
            switch (msg.name) {
                case "invoke":
                    whenLeaderElected().then(function (leader) {
                        if (leader) {
                            var proxy = hubProxies[msg.hub];
                            var args = msg.args;
                            console.debug("processing invoke request", msg.invokeId, msg.args);
                            connect().then(function () {
                                proxy.invoke.apply(proxy, args)
                                    .then(function (invokeResult) {
                                        console.debug("returning invoke request result", msg.args[0], msg.invokeId);
                                        wvy.postal.postToSource(e, {
                                            name: "invokeResult",
                                            hub: msg.hub,
                                            args: args,
                                            result: invokeResult,
                                            invokeId: msg.invokeId,
                                            weavyId: "wvy.connection",
                                            connectionUrl: connectionUrl
                                        });
                                    })
                                    .catch(function (error) {
                                        console.warn(error);
                                        wvy.postal.postToSource(e, {
                                            name: "invokeResult",
                                            hub: msg.hub,
                                            args: args,
                                            error: error,
                                            invokeId: msg.invokeId,
                                            weavyId: "wvy.connection",
                                            connectionUrl: connectionUrl
                                        });
                                    });
                            });
                        }

                    });
                    break;
                case "request:connection-start":
                    whenLeaderElected().then(function (leader) {
                        if (leader) {
                            //console.debug("processing connect request");
                            connect().then(function () {
                                wvy.postal.postToChildren({ name: "connection-started", weavyId: "wvy.connection", connectionUrl: connectionUrl });
                            });
                        }
                    });
                    break;
                default:
                    return;
            }
        };

        var onParentMessageReceived = function (e) {
            var msg = e.data;
            switch (msg.name) {
                case "connection-started":
                    whenLeaderElected().then(function (leader) {
                        if (!leader) {
                            //console.debug((childConnection ? "child " : "") + "distribute received", msg.name, msg.eventName || "");
                            state = states.connected;
                            whenConnected.resolve();
                        }
                    });
                    break;
                case "distribute-event":
                    var name = msg.eventName;
                    var event = $.Event(name);
                    var data = msg.data;

                    // Extract array with single value
                    if (Array.isArray(data) && data.length === 1) {
                        data = data[0];
                    }

                    if (name === "state-changed.connection.weavy") {
                        state = parseInt(data.state);
                        if (state === states.connected) {
                            whenConnected.resolve();
                        }
                    }

                    //console.debug((childConnection ? "child " : "") + "triggering received distribute-event", name);
                    $(weavyConnection).triggerHandler(event, msg.data);
                    break;
                case "alert":
                    if (wvy.alert) {
                        if (msg.eventName === "show") {
                            console.debug("alert show received", msg.data.title);
                            wvy.alert.alert(msg.data.type, msg.data.title, null, msg.data.id);
                        } else {
                            wvy.alert.close(msg.data);
                        }
                    }
                    break;
                default:
                    return;
            }
        };


        function destroy() {
            disconnect();

            reconnecting = false;

            window.clearTimeout(_reconnectMessageTimeout);
            window.clearTimeout(_reconnectInterval);

            try {
                wvy.postal.off("distribute", { weavyId: "wvy.connection", connectionUrl: connectionUrl }, onParentMessageReceived);
                wvy.postal.off("message", { weavyId: "wvy.connection", connectionUrl: connectionUrl }, onChildMessageReceived);
            } catch (e) { /* Ignore catch */ }

            try {
                hubProxies["rtm"].off("eventReceived", rtmEventRecieved);
            } catch (e) { /* Ignore catch */ }

            _events.forEach(function (eventHandler) {
                var name = eventHandler[0], handler = eventHandler[1];
                $(weavyConnection).off(name, null, handler);
            });
            _events = [];
        }

        this.connect = connect;
        this.destroy = destroy;
        this.disconnect = disconnect;
        this.disconnectAndConnect = disconnectAndConnect;
        this.init = init;
        this.invoke = invoke;
        this.on = on;
        this.off = off;
        this.proxies = hubProxies;
        this.states = states;
        this.status = status;
        this.transport = function () { return connection.transport.name; };
    }

    connections.get = function (url) {
        var sameOrigin = false;

        url = url && String(url);

        var urlExtract;
        try {
            urlExtract = url && /^(https?:\/(\/[^/]+)+)\/?$/.exec(url)
        } catch (e) {
            console.error("Unable to parse connection URL, make sure to connect to a valid domain.")
        }
        if (urlExtract) {
            sameOrigin = window.location.origin === urlExtract[1]
            url = urlExtract[1];
        }
        url = (sameOrigin ? "" : url) || "";
        if (_connections.has(url)) {
            return _connections.get(url);
        } else {
            var connection = new WeavyConnection(url);
            _connections.set(url, connection);
            return connection;
        }
    };

    connections.remove = function (url) {
        url = url && String(url) || "";
        try {
            var connection = _connections.get(url);
            if (connection && connection.destroy) {
                connection.destroy();
            }
            _connections.delete(url);
        } catch (e) {
            console.warn("Could not remove connection", url, e);
        }
    };

    // expose wvy.connection.default. self initiatied upon access and no other connections are active 
    Object.defineProperty(connections, "default", {
        get: function () {
            if (_connections.has("")) {
                return _connections.get("");
            } else {
                var connection = connections.get();

                WeavyUtils.ready(function () {
                    setTimeout(function () {
                        if (_connections.size === 1) {
                            connection.init(true, wvy.authentication.default);
                        }
                    }, 1);
                });

                return connection;
            }
        }
    });

    // Bridge for simple syntax and backward compatibility with the mobile apps
    Object.defineProperty(connections, "on", {
        get: function () {
            return connections.default.on;
        }
    });

    // Bridge for simple syntax
    Object.defineProperty(connections, "invoke", {
        get: function () {
            return connections.default.invoke;
        }
    });
}));


/**
 * @external Promise
 * @see https://developer.mozilla.org/en-US/docs/Web/JavaScript/Guide/Using_promises
 */

/**
 * @external jqXHR
 * @see http://api.jquery.com/jQuery.ajax/#jqXHR
 */

/**
 * @external jqAjaxSettings
 * @see http://api.jquery.com/jquery.ajax/#jQuery-ajax-settings
 */
;
/* eslint-env commonjs, amd, jquery */

// UMD based on https://github.com/umdjs/umd/blob/master/templates/returnExports.js
// TODO: move to ES6 and transpiler

(function (root, factory) {
    if (typeof define === 'function' && define.amd) {
        // AMD. Register as an anonymous module.
        define([
            './utils',
            './promise',
            './console',
            './postal',
            './connection',
            './wvy'
        ], factory);
    } else if (typeof module === 'object' && module.exports) {
        // Node. Does not work with strict CommonJS, but
        // only CommonJS-like environments that support module.exports,
        // like Node.
        module.exports = factory(
            require('./utils'),
            require('./promise'),
            require('./console'),
            require('./postal'),
            require('./connection'),
            require('./wvy')
        );
    } else {
        // Browser globals (root is window)
        root.wvy = root.wvy || {};
        root.wvy.authentication = root.wvy.authentication || new factory(root.wvy.utils, root.wvy.promise, root.wvy.console, root.wvy);
    }
}(typeof self !== 'undefined' ? self : this, function (WeavyUtils, WeavyPromise, WeavyConsole, wvy) {

    //console.debug("authentication.js", window.name);

    var userUrl = "/client/user";
    var ssoUrl = "/client/sign-in";
    var signOutUrl = "/client/sign-out";

    // MULTI AUTHENTICATION HANDLING
    var authentications = this;
    var _authentications = new Map();

    function WeavyAuthentication(baseUrl) {

        /**
         *  Reference to this instance
         *  @lends WeavyAuthentication#
         */
        var weavyAuthentication = this;

        var _initialized = false;

        var console = new WeavyConsole("WeavyAuthentication");

        baseUrl = baseUrl && String(baseUrl) || window.location.origin + (wvy.config && wvy.config.applicationPath || "/");

        if (baseUrl) {
            // Remove trailing slash
            baseUrl = /\/$/.test(baseUrl) ? baseUrl.slice(0, -1) : baseUrl;
        }

        var _events = [];

        var _user = null;

        // Is the user established?
        var _isAuthenticated = null;
        var _whenAuthenticated = new WeavyPromise();
        var _whenAuthorized = new WeavyPromise();

        var _isUpdating = false;
        var _isNavigating = false;

        var _whenSignedOut = new WeavyPromise();
        var _isSigningOut = false;

        window.addEventListener('beforeunload', function () {
            _isNavigating = true;
        });

        window.addEventListener('turbolinks:request-start', function () {
            _isNavigating = true;
        });

        window.addEventListener('turbolinks:load', function () {
            _isNavigating = false;

            // If the user was changed on page load, process the user instantly
            if (_user && wvy.context && wvy.context.user && (_user.id !== wvy.context.user)) {
                processUser({ id: wvy.context.user }, "turbolinks:load/wvy.context.user");
            }
        });


        /**
         * Checks if the provided or authenticated user is signed in
         * 
         * @param {any} [user] - Optional user to check
         */
        function isAuthorized(user) {
            if (user) {
                return user.id && user.id !== -1 || false;
            }
            return _user && _user.id && _user.id !== -1 || false;
        }

        // JWT
        var _jwt;
        var _jwtProvider;

        function setJwt(jwt) {
            console.debug("configuring jwt");
            _jwt = null;
            _jwtProvider = jwt;
        }

        /**
         * Returns the current jwt token; either the specified jwt string or as a result from the supplied function.
         * @param {boolean} [refresh=false] - Set to true if you want to call the host for a new token.
         * @returns {external:Promise}
         */
        function getJwt(refresh) {
            return new Promise(function (resolve, reject) {
                if (_jwt && !refresh) {
                    // jwt already set, return it
                    resolve(_jwt);
                    return;
                }

                if (refresh) {
                    // reset jwt on refresh
                    _jwt = null;
                }

                if (_jwtProvider === undefined) {
                    // no jwt provided, return nothing
                    resolve(false);
                    return;
                }

                if (typeof _jwtProvider === "string") {
                    _jwt = _jwtProvider;
                    resolve(_jwt);
                } else if (typeof _jwtProvider === "function") {
                    var resolvedProvider = _jwtProvider();

                    if (typeof resolvedProvider.then === "function") {
                        return resolvedProvider.then(function (token) {
                            _jwt = token;
                            resolve(_jwt);
                        }, function () {
                            reject("failed to get token from the jwt provider promise");
                        });
                    } else if (typeof resolvedProvider === "string") {
                        _jwt = resolvedProvider;
                        resolve(_jwt);
                    } else {
                        reject("failed to get token from the jwt provider function");
                    }
                } else {
                    reject("jwt option must be a string or a function that returns a promise");
                }
            });
        }

        function clearJwt() {
            console.debug("clearing jwt");
            _jwt = null;
            _jwtProvider = null;
        }

        function init(jwt) {
            if (_isAuthenticated === null || jwt && jwt !== _jwtProvider) {
                if (typeof jwt === "string" || typeof jwt === "function") {
                    setJwt(jwt);
                }

                // Authenticate
                if (_jwtProvider !== undefined) {
                    console.log("authenticate by jwt")
                    // If JWT is defined, it should always be processed
                    wvy.postal.whenLeader().finally(function () { return validateJwt(); })
                } else if (wvy.context && wvy.context.user) {
                    // If user is defined in wvy.context, user is already signed in
                    setUser({ id: wvy.context.user }, "init/wvy.context.user");
                } else {
                    // Check for current user state
                    updateUserState("authenticate()");
                }
            }

            if (!_initialized) {
                _initialized = true;

                // Listen on messages from parent?
                wvy.postal.on("message", { weavyId: "wvy.authentication", baseUrl: baseUrl }, onChildMessageReceived);
                wvy.postal.on("distribute", { weavyId: "wvy.authentication", baseUrl: baseUrl }, onParentMessageReceived);

                console.debug("init", !(baseUrl || window.name) ? "self" : "");

                wvy.connection.get(baseUrl).on("authenticate.weavy.rtmweavy", onConnectionAuthenticate);
            }

            return _whenAuthenticated();
        }

        function setUser(user, originSource) {
            if (user && user.id) {
                if (_user && user && _user.id !== user.id) {
                    console.debug("setUser", user.id, originSource);
                }
                _user = user;
                if (wvy.context) {
                    wvy.context.user = user.id;
                }
                _isAuthenticated = true;
                if (isAuthorized(user)) {
                    _whenAuthorized.resolve();
                } else {
                    // Authenticated but still awaiting auhorization
                    if (_whenAuthorized.state() !== "pending") {
                        _whenAuthorized.reset();
                    }
                    _isSigningOut = false;
                    _whenSignedOut.resolve();
                }

                _whenAuthenticated.resolve(user);
            } else {
                // No valid user, reset states
                _user = null;
                if (wvy.context) {
                    wvy.context.user = null;
                }
                _isAuthenticated = false;

                _whenAuthorized.reset();
            }
        }

        function alert(message, type) {
            if (wvy.alert && !_isNavigating) {
                wvy.alert.alert(type || "info", message, null, "wvy-authentication-alert");
            }
        }

        // EVENTS

        function on(event, handler) {
            event = event.indexOf(".weavy") === -1 ? event + ".weavy" : event;
            _events.push([event, handler]);
            $(weavyAuthentication).on(event, null, null, handler);
        }

        function off(event, handler) {
            event = event.indexOf(".weavy") === -1 ? event + ".weavy" : event;

            _events = _events.filter(function (eventHandler) {
                if (eventHandler[0] === event && eventHandler[1] === handler) {
                    $(weavyAuthentication).off(event, null, handler);
                    return false;
                } else {
                    return true;
                }
            })

        }

        function triggerEvent(name) {
            var event = $.Event(name);

            // trigger event (with json object instead of string), handle any number of json objects passed from hub (args)
            var argumentArray = [].slice.call(arguments, 1);
            var data = argumentArray.map(function (a) {
                if (a && !Array.isArray(a) && !WeavyUtils.isPlainObject(a)) {
                    try {
                        return JSON.parse(a);
                    } catch (e) {
                        console.warn("could not parse event data.", name);
                    }
                }
                return a;
            });

            var eventResult = $(weavyAuthentication).triggerHandler(event, data);
            var eventIsPrevented = event.isDefaultPrevented() || eventResult === false;

            triggerToChildren("distribute-authentication-event", name, data);

            return eventIsPrevented ? false : eventResult;
        }

        // trigger a message distribute
        function triggerToChildren(name, eventName, data) {
            try {
                wvy.postal.postToChildren({ name: name, eventName: eventName, data: data, weavyId: "wvy.authentication", baseUrl: baseUrl });
            } catch (e) {
                console.error("could not distribute authentication message to children.", { name: name, eventName: eventName }, e);
            }
        }

        // AUTHENTICATION

        /**
         * Sign in using Single Sign On JWT token. 
         * 
         * A new JWT provider will replace the current JWT provider, then the JWT will be validated.
         * 
         * @param {string|function} [jwt] - Optional JWT token string or JWT provider function returning a Promise or JWT token string
         */
        function signIn(jwt) {
            if (typeof jwt === "string" || typeof jwt === "function") {
                setJwt(jwt);
            }

            if (_whenAuthenticated.state() !== "pending") {
                _whenAuthenticated.reset();
            }

            if (_whenAuthorized.state() !== "pending") {
                _whenAuthorized.reset();
            }

            wvy.postal.whenLeader().finally(function () { return validateJwt(); })

            return _whenAuthenticated();
        }

        /**
         * Sign out the current user.
         * 
         * @param {boolean} [clear] - Clears JWT provider after signOut
         */
        function signOut(clear) {
            var authUrl = new URL(signOutUrl, baseUrl);
            _isSigningOut = true;

            if (clear) {
                clearJwt();
            }

            triggerEvent("clear-user");

            var fetchSettings = {
                method: "GET",
                mode: 'cors', // no-cors, *cors, same-origin
                cache: 'reload', // *default, no-cache, reload, force-cache, only-if-cached
                credentials: 'include', // include, *same-origin, omit
                headers: {
                    // https://stackoverflow.com/questions/8163703/cross-domain-ajax-doesnt-send-x-requested-with-header
                    "X-Requested-With": "XMLHttpRequest"
                },
                redirect: 'manual', // manual, *follow, error
                referrerPolicy: "no-referrer-when-downgrade", // no-referrer, *no-referrer-when-downgrade, origin, origin-when-cross-origin, same-origin, strict-origin, strict-origin-when-cross-origin, unsafe-url
            };

            window.fetch(authUrl.toString(), fetchSettings).catch(function () {
                console.warn("signOut request fail");
            }).finally(function () {
                console.debug("signout ajax -> processing user");
                processUser({ id: -1 }, "signOut()");
            });

            return _whenSignedOut();
        }

        function processUser(user, originSource) {
            // Default state when user is unauthenticated or has not changed
            var state = "updated";

            var reloadLink = ' <a href="#" onclick="location.reload(); return false;">' + wvy.t("Reload") + '</a>';

            if (user && user.id) {
                if (_isAuthenticated) {
                    if (isAuthorized()) {
                        // When signed in
                        if (user && user.id === -1) {
                            console.log("signed-out");
                            alert(wvy.t("You have been signed out.") + reloadLink);
                            // User signed out
                            state = "signed-out";
                        } else if (user && user.id !== _user.id) {
                            console.log("changed-user");
                            alert(wvy.t("The signed in user has changed.") + reloadLink)
                            // User changed
                            state = "changed-user";
                        }
                    } else {
                        // When signed out
                        if (user && user.id !== -1) {
                            console.log("signed-in", originSource);

                            // Show a message if the user hasn't loaded a new page
                            if (wvy && wvy.context && wvy.context.user && (user.id !== wvy.context.user)) {
                                alert(wvy.t("You have signed in.") + reloadLink);
                            }

                            // User signed in
                            state = "signed-in";
                        }
                    }
                }

                setUser(user, originSource || "processUser()");
                triggerEvent("user", { state: state, authorized: isAuthorized(user), user: user });
            } else {
                // No valid user state
                setUser(null, originSource || "processUser()");
                triggerEvent("clear-user");

                var eventResult = triggerEvent("user", { state: "user-error", authorized: false, user: user });
                if (eventResult !== false) {
                    wvy.postal.whenLeader().then(function (isLeader) {
                        if (isLeader) {
                            alert(wvy.t("Authentication error.") + reloadLink, "danger");
                        }
                    });
                }
            }

            _isUpdating = false;
        }


        function updateUserState(originSource) {
            if (!_isUpdating) {
                _isUpdating = true;
                wvy.postal.whenLeader().then(function (isLeader) {
                    if (isLeader) {
                        console.debug("whenLeader => updateUserState" + (_jwtProvider !== undefined ? ":jwt" : ":cookie"), originSource);

                        if (_whenAuthenticated.state() !== "pending") {
                            _whenAuthenticated.reset();
                        }
                        if (_whenAuthorized.state() !== "pending") {
                            _whenAuthorized.reset();
                        }

                        var url = new URL(userUrl, baseUrl);

                        var fetchSettings = {
                            method: "POST",
                            mode: 'cors', // no-cors, *cors, same-origin
                            cache: 'reload', // *default, no-cache, reload, force-cache, only-if-cached
                            credentials: 'include', // include, *same-origin, omit
                            headers: {
                                'Content-Type': 'application/json',
                                // https://stackoverflow.com/questions/8163703/cross-domain-ajax-doesnt-send-x-requested-with-header
                                "X-Requested-With": "XMLHttpRequest"
                            },
                            redirect: 'manual', // manual, *follow, error
                            referrerPolicy: "no-referrer-when-downgrade", // no-referrer, *no-referrer-when-downgrade, origin, origin-when-cross-origin, same-origin, strict-origin, strict-origin-when-cross-origin, unsafe-url
                        };

                        getJwt().then(function (token) {
                            if (_jwtProvider !== undefined) {
                                if (typeof token !== "string") {
                                    return Promise.reject(new Error("Provided JWT token is invalid."))
                                }

                                fetchSettings.body = JSON.stringify({ jwt: token });
                            }

                            window.fetch(url.toString(), fetchSettings).then(function (response) {
                                if (response.status === 401 && _jwtProvider !== undefined) {
                                    console.warn("JWT failed, trying again");
                                    return getJwt(true).then(function (token) {
                                        fetchSettings.body = JSON.stringify({ jwt: token });
                                        return window.fetch(url.toString(), fetchSettings);
                                    })
                                }
                                return response;
                            }).then(WeavyUtils.processJSONResponse).then(function (actualUser) {
                                console.debug("updateUserState ajax -> processing user")
                                processUser(actualUser, "updateUserState," + originSource);
                            }, function () {
                                console.warn("updateUserState request fail");
                                console.debug("updateUserState ajax fetch fail -> processing user");
                                processUser({ id: null }, "updateUserState," + originSource);
                            });
                        });
                    } else {
                        wvy.postal.postToParent({ name: "request:user", weavyId: "wvy.authentication", baseUrl: baseUrl });
                    }
                });
            }

            return _whenAuthenticated();
        }

        function validateJwt() {
            var whenSSO = new WeavyPromise();
            var authUrl = new URL(ssoUrl, baseUrl);

            if (_isSigningOut) {
                // Wait for signout to complete
                console.log("vaildate jwt awaiting sign-out");
                return _whenSignedOut.then(function () { return validateJwt(); });
            } else if (_whenSignedOut.state() !== "pending") {
                // Reset signed out promise
                _whenSignedOut.reset();
            }

            console.log("validating jwt");

            triggerEvent("signing-in");

            var fetchSettings = {
                method: "GET",
                mode: 'cors', // no-cors, *cors, same-origin
                cache: 'reload', // *default, no-cache, reload, force-cache, only-if-cached
                credentials: 'include', // include, *same-origin, omit
                headers: {
                    'Content-Type': 'application/json',
                    // https://stackoverflow.com/questions/8163703/cross-domain-ajax-doesnt-send-x-requested-with-header
                    "X-Requested-With": "XMLHttpRequest"
                },
                redirect: 'manual', // manual, *follow, error
                referrerPolicy: "no-referrer-when-downgrade", // no-referrer, *no-referrer-when-downgrade, origin, origin-when-cross-origin, same-origin, strict-origin, strict-origin-when-cross-origin, unsafe-url
            };

            return getJwt().then(function (token) {
                if (typeof token !== "string") {
                    return Promise.reject(new Error("Provided JWT token is invalid."))
                }

                fetchSettings.headers.Authorization = "Bearer " + token;

                // Convert url to string to avoid bugs in patched fetch (Dynamics 365)
                return window.fetch(authUrl.toString(), fetchSettings).then(function (response) {
                    if (response.status === 401) {
                        console.warn("JWT failed, trying again");
                        return getJwt(true).then(function (token) {
                            fetchSettings.headers.Authorization = "Bearer " + token;
                            return window.fetch(authUrl.tostring(), fetchSettings);
                        })
                    }
                    return response;

                }).then(WeavyUtils.processJSONResponse).then(function (ssoUser) {
                    processUser(ssoUser);
                    return whenSSO.resolve(ssoUser);
                }).catch(function (error) {
                    console.error("sign in with JWT token failed.", error.message);
                    triggerEvent("authentication-error", { method: "jwt", status: 401, message: error.message });
                    processUser({ id: null });
                });
            })
        }

        // REALTIME CROSS WINDOW MESSAGE
        // handle cross frame events from rtm
        var onChildMessageReceived = function (e) {
            var msg = e.data;
            switch (msg.name) {
                case "request:user":
                    _whenAuthenticated.then(function () {
                        wvy.postal.postToSource(e, { name: "user", user: _user, weavyId: "wvy.authentication", baseUrl: baseUrl });
                    })
                    break;
                default:
                    return;
            }

        };

        var onParentMessageReceived = function (e) {
            var msg = e.data;
            switch (msg.name) {
                case "user":
                    console.debug("parentMessage user -> processing user");
                    processUser(msg.user, "parentMessage:user");
                    break;
                case "distribute-authentication-event":
                    var name = msg.eventName;
                    var event = $.Event(name);
                    var data = msg.data;

                    // Extract array with single value
                    if (Array.isArray(data) && data.length === 1) {
                        data = data[0];
                    }

                    if (name === "user") {
                        console.debug("parentMessage distribute-authentication-event user -> processing user");
                        processUser(data.user, "distribute-authentication-event:user");
                    } else {
                        console.debug("triggering received distribute-event", name);
                        $(weavyAuthentication).triggerHandler(event, msg.data);
                    }

                    break;
                default:
                    return;
            }

        };

        var onConnectionAuthenticate = function (e) {
            console.debug("authenticate.weavy -> updateUserState");
            updateUserState("authenticate.weavy.rtmweavy");
        };


        function destroy() {
            _isAuthenticated = null;
            _user = null;
            _jwt = null;
            _jwtProvider = null;

            wvy.postal.off("message", { weavyId: "wvy.authentication", baseUrl: baseUrl }, onChildMessageReceived);
            wvy.postal.off("distribute", { weavyId: "wvy.authentication", baseUrl: baseUrl }, onParentMessageReceived);

            wvy.connection.get(baseUrl).off("authenticate.weavy.rtmweavy", onConnectionAuthenticate);

            _events.forEach(function (eventHandler) {
                var name = eventHandler[0], handler = eventHandler[1];
                $(weavyAuthentication).off(name, null, handler);
            });
            _events = [];

            _initialized = false;
        }

        // Exports 
        this.init = init;
        this.isAuthorized = isAuthorized;
        this.isAuthenticated = function () { return _isAuthenticated === true; };
        this.isInitialized = function () { return _initialized === true; }
        this.isProvided = function () { return !!_jwtProvider; };
        this.whenAuthenticated = function () { return _whenAuthenticated(); };
        this.whenAuthorized = function () { return _whenAuthorized(); };
        this.on = on;
        this.off = off;
        this.signIn = signIn;
        this.signOut = signOut;
        this.setJwt = setJwt;
        this.getJwt = getJwt;
        this.clearJwt = clearJwt;
        this.updateUserState = updateUserState;
        this.user = function () { return _user };
        this.destroy = destroy;

    }

    authentications.get = function (url) {
        var sameOrigin = false;

        url = url && String(url);

        var urlExtract = url && /^(https?:\/(\/[^/]+)+)\/?$/.exec(url)
        if (urlExtract) {
            sameOrigin = window.location.origin === urlExtract[1];
            url = urlExtract[1];
        }
        url = (sameOrigin ? "" : url) || "";
        if (_authentications.has(url)) {
            return _authentications.get(url);
        } else {
            var authentication = new WeavyAuthentication(url);
            _authentications.set(url, authentication);
            return authentication;
        }
    };

    authentications.remove = function (url) {
        url = url && String(url) || "";
        try {
            var authentication = _authentications.get(url);
            if (authentication && authentication.destroy) {
                authentication.destroy();
            }
            _authentications.delete(url);
        } catch (e) {
            console.error("Could not remove authentication", url, e);
        }
    };

    // expose wvy.authentication.default. self initiatied upon access and no other authentication is active 
    Object.defineProperty(authentications, "default", {
        get: function () {
            if (_authentications.has("")) {
                return _authentications.get("");
            } else {
                var authentication = authentications.get();

                WeavyUtils.ready(function () {
                    setTimeout(function () {
                        if (_authentications.size === 1) {
                            authentication.init();
                        }
                    }, 1);
                });

                return authentication;
            }
        }
    });

    // Bridge for simple syntax and backward compatibility with the mobile apps
    Object.defineProperty(authentications, "on", {
        get: function () {
            return authentications.default.on;
        }
    });

    // Bridge for simple syntax
    Object.defineProperty(authentications, "sso", {
        get: function () {
            return authentications.default.sso;
        }
    });
}));


/**
 * @external Promise
 * @see https://developer.mozilla.org/en-US/docs/Web/JavaScript/Guide/Using_promises
 */
;
/* eslint-env commonjs, amd */

// UMD based on https://github.com/umdjs/umd/blob/master/templates/returnExports.js
// TODO: move to ES6 and transpiler

(function (root, factory) {
    if (typeof define === 'function' && define.amd) {
        // AMD. Register as an anonymous module.
        define([
            '../utils'
        ], factory);
    } else if (typeof module === 'object' && module.exports) {
        // Node. Does not work with strict CommonJS, but
        // only CommonJS-like environments that support module.exports,
        // like Node.
        module.exports = factory(
            require('../utils')
        );
    } else {
        // Browser globals (root is window)
        root.WeavyEvents = factory(
            root.wvy.utils
        );
    }
}(typeof self !== 'undefined' ? self : this, function (WeavyUtils) {
    //console.debug("events.js");

    /**
     * @class WeavyEvents
     * @classdesc 
     * Event handling with event propagation and before and after phases.
     * 
     * The event system provides event-chaining with a bubbling mechanism that propagates all the way from the emitting child trigger to the root instance.
     * 
     * **NOTE:** Each weavy instance has an event handler instance exposed as `weavy.events`. So references to `.triggerEvent()` in this documentation would translate to `weavy.events.triggerEvent()`.
     * For convenience the `.on()`, `.one()` and `.off()` functions are exposed directly on the weavy instance as `weavy.on()`, `weavy.one()` and `weavy.off()`.
     * They are also exposed as child object functions on spaces and apps as `space.on()` and `app.on()` etc.
     * 
     * All events in the client have three phases; before, on and after. Each event phase is a prefix to the event name.
     * - The before:event-name is triggered in an early stage of the event cycle and is a good point to modify event data or cancel the event.
     * - The on:event-name is the normal trigger point for the event. It does not need to be prefixed when registering an event listener, you can simly use the event-name when you register a listener. This is the phase you normally use to register event listeners.
     * - The after:event-name is triggered when everything is processed. This is a good point to execute code that is dependent on that all other listers have been executed.
     * 
     * In each phase, the event is propagated to objects in the hierarchy, much like bubbling in the DOM. 
     * The event chain always contains at least the triggering object and the root, but may have more objects in between. 
     * This means that the root will receive all events regardless of which child-object that was triggering event, but the child objects will only receive the events that they triggered themeselves or any of their child objects triggered.
     * - The event chain starts at the root in the before: phase and works it's way towards the triggering child object. This gives all parent-listeners a chance to modify event data or cancel the event before it reaches the triggering child object.
     * - In the on: phase the event chain starts at the trigger and goes up to the weavy instance, like rings on the water.
     * - Finally, the after: phase goes back from the weavy instance and ends up at the triggering child-object at last.
     * 
     * Cancelling an event by calling `event.stopPropagation()` will stop any propagation and cause all the following phases for the event to be cancelled.
     */

    /**
     * @constructor
     * @hideconstructor
     * @param {Object} rootTarget - The base for all events, usually the Weavy instance. Children may reuse the same methods applying themselves as this.
     */
    var WeavyEvents = function (rootTarget) {
        /** 
         *  Reference to this instance
         *  @lends WeavyEvents#
         */
        var weavyEvents = this;

        // EVENT HANDLING
        var _eventHandlers = [];

        /**
         * Saves a single eventhandler.
         * 
         * @internal
         * @function
         * @param {Object} context - The context for the handler
         * @param {string} event - One or more events. Multiple events are currently not registered individually.
         * @param {string|Object} [selector] - Optional refinement selector
         * @param {function} handler - The handler function. may be wrapped for once-handlers
         * @param {function} originalHandler - The original non-wrapped event handler.
         * @param {boolean} external - Is the handler using an external event system
         */
        function registerEventHandler(context, events, selector, handler, originalHandler, external) {
            _eventHandlers.push({ context: context, events: events, selector: selector, handler: handler, originalHandler: originalHandler, external: external });
        }

        /**
         * Returns the event handler or wrapped event handler. The arguments must match the registered event handler.
         * 
         * @internal
         * @function
         * @param {string} event - The events registered
         * @param {function} handler - The registered handler
         * @param {Object} context - The context for the handler
         * @param {string|Object} [selector] - The optional selector for the handler.
         */
        function getEventHandler(context, events, selector, handler, originalHandler, external) {
            var getHandler = { context: context, events: events, selector: selector, handler: handler, originalHandler: originalHandler, external: external };
            var eventHandler = _eventHandlers.filter(function (eventHandler) {
                // Check if all arguments match
                return WeavyUtils.eqObjects(getHandler, eventHandler, true);
            }).pop();

            return eventHandler && eventHandler.handler;
        }

        /**
         * Unregister an event handler. Arguments must match the registered event handler.
         * 
         * @internal
         * @function
         * @param {string} event - The events registered
         * @param {function} handler - The registered handler
         * @param {Object} context - The context for the handler
         * @param {string|Object} [selector] - The optional selector for the handler.
         * @returns {boolean} - True if any handler was removed
         */
        function unregisterEventHandler(context, events, selector, handler, originalHandler, external) {
            var removeHandler = { context: context, events: events, selector: selector, handler: handler, originalHandler: originalHandler, external: external };
            var handlerRemoved = false;

            _eventHandlers.forEach(function (eventHandler, eventHandlerIndex) {
                // Check if all arguments match
                if (WeavyUtils.eqObjects(removeHandler, eventHandler, true)) {
                    handlerRemoved = true;
                    _eventHandlers.splice(eventHandlerIndex, 1);
                }
            });

            return handlerRemoved;
        }

        /**
         * Triggers any local event handlers registered. Each handler may modify the data and return it or return false to cancel the event chain. .stopPropagation() and .preventDefault() may also be used.
         * 
         * @example
         * weavyEvents.on("myevent", function(e, data) { ... })
         * 
         * triggerHandler(this, "myevent", { key: 1 })
         * 
         * @internal
         * @function
         * @param {any} target - The target in the event chain where the event should be triggered.
         * @param {any} eventName - The name of the event. Event names without prefix will also trigger handlers with the "on:" prefix.
         * @param {any} data - Any data to pass to the handler as second argument
         */
        function triggerHandler(target, eventName, data) {
            var event = new CustomEvent(eventName, { cancelable: true });
            var isCancelled = false;
            //TODO: Handle stopImmediatePropagation using wrapper function

            _eventHandlers.forEach(function (eventHandler) {
                if (!eventHandler.external && eventHandler.context === target) {
                    eventHandler.events.split(" ").forEach(function (eventHandlerName) {
                        // Normalize on:
                        eventHandlerName = eventHandlerName.indexOf("on:") === 0 ? eventHandlerName.split("on:")[1] : eventHandlerName;
                        if (eventName === eventHandlerName) {
                            // Trigger the handler
                            var returnData = eventHandler.handler(event, data);
                            if (returnData) {
                                data = returnData;
                            } else if (returnData === false) {
                                isCancelled = true;
                            }
                        }
                    })
                }
            });

            return isCancelled || event.cancelBubble || event.defaultPrevented ? false : data;
        }

        /**
         * Extracts and normalizes all parts of the events arguments.
         * 
         * @internal
         * @function
         * @param {Object} contextTarget - The context for the events
         * @param {Array.<Object>} eventArguments - The function argument list: `[context], events, [selector], handler`
         * @returns {Object}
         * @property {Object} context - The context for the event. Must have an `.on()` function.
         * @property {string} events - Event names with added namespace for local events.
         * @property {string|Object} selector - The optional selector.
         * @property {function} handler - The handler function
         * @
         */
        function getEventArguments(contextTarget, eventArguments) {
            var context, events, selector, handler;

            var localEvent = typeof eventArguments[1] === "function" && eventArguments[1];

            if (localEvent) {
                // Local event
                handler = typeof eventArguments[1] === 'function' ? eventArguments[1] : eventArguments[2];
                selector = typeof eventArguments[1] === 'function' ? null : eventArguments[1];
                events = eventArguments[0];
                context = weavyEvents === contextTarget ? rootTarget : contextTarget;
            } else {
                // External event
                handler = typeof eventArguments[2] === 'function' ? eventArguments[2] : eventArguments[3];
                selector = typeof eventArguments[2] === 'function' ? null : eventArguments[2];
                events = eventArguments[1];
                context = eventArguments[0];
                context = validateContext(context);
            }

            return { context: context, events: events, selector: selector, handler: handler, external: !localEvent };
        }


        /**
         * Gets an valid context.
         * 
         * @internal
         * @function
         * @param {any} context The context to validate and return if valid.
         * @returns {object} if the context has `.on()` return it, otherwise try to return a context element or lastly return the root context.
         */
        function validateContext(context) {
            if (context) {
                if (context.on && typeof context.on === "function") {
                    return context;
                }

                var contextElement = WeavyUtils.asElement(context);
                if (contextElement) {
                    return contextElement;
                }

                if (context instanceof EventTarget) {
                    return context;
                }
            }

            return rootTarget;
        }

        /**
         * Get the event chain for the triggering object. All the objects in the chain except the root must have a link to their parent defined by a .eventParent property.
         * 
         * @internal
         * @param {Object} currentTarget - The triggering target.
         * @param {Object} rootTarget - The event root target.
         * @returns {Array.<Object>} All objects in the chain. Starts with the currentTarget and ends with the rootTarget.
         */
        function getEventChain(currentTarget, rootTarget) {
            var eventChain = [];
            var currentLevel = currentTarget;
            while (currentLevel !== rootTarget && currentLevel.eventParent) {
                eventChain.push(currentLevel);
                currentLevel = currentLevel.eventParent;
            }
            if (currentLevel === rootTarget) {
                eventChain.push(rootTarget);
                return eventChain;
            } else {
                // No complete chain, return currentTarget and rootTarget
                return [currentTarget, rootTarget];
            }
        }

        /**
         * Registers one or several event listneres. All event listners are managed and automatically unregistered on destroy.
         * 
         * When listening to weavy events, you may also listen to `before:` and `after:` events by simply adding the prefix to a weavy event.
         * Eventhandlers listening to weavy events may return modified data that is returned to the trigger. The data is passed on to the next event in the trigger event chain. If an event handler calls `event.stopPropagation()` or `return false`, the event chain will be stopped and the value is returned.
         *
         * @example <caption>Instance event</caption>
         * weavyEvents.on("before:options", function(e, options) { ... })
         * weavyEvents.on("options", function(e, options) { ... })
         * weavyEvents.on("after:options", function(e, options) { ... })
         *  
         * @example <caption>Realtime event</caption>
         * weavyEvents.on(weavy.connection, "eventname", function(e, message) { ... })
         *   
         * @example <caption>Connection event</caption>
         * weavyEvents.on(weavy.connection, "disconnect.connection", function(e) { ... })
         *   
         * @example <caption>Button event</caption>
         * weavyEvents.on(myButton, "click", function() { ... })
         *   
         * @example <caption>Multiple document event listeners using jQuery context and selector</caption>
         * weavyEvents.on($(document), "show.bs.modal hide.bs.modal", ".modal", function() { ... })
         * 
         * @category eventhandling
         * @function
         * @name WeavyEvents#on
         * @param {Element} [context] - Context Element. If omitted it defaults to the Weavy instance. weavy.connection and wvy.postal may also be used as contexts.
         * @param {string} events - One or several event names separated by spaces. You may provide any namespaces in the names or use the general namespace parameter instead.
         * @param {string|Object} [selector] - Only applicable if the context supports selectors, for instance jQuery.on().
         * @param {function} handler - The listener. The first argument is always the event, followed by any data arguments provided by the trigger.
         */
        this.on = function (context, events, selector, handler) {
            var argumentsArray = Array.from(arguments || []);
            var args = getEventArguments(this, argumentsArray);
            var once = argumentsArray[4];

            if (once) {
                var attachedHandler = function () {
                    var attachedArguments = Array.from(arguments || []);
                    try {
                        args.handler.apply(this, attachedArguments);
                    } catch (e) {
                        try {
                            args.handler();
                        } catch (e) {
                            console.warn("Could not invoke one handler:", e);
                        }
                    }
                    unregisterEventHandler(args.context, args.events, args.selector, null, args.handler, args.external);
                };

                registerEventHandler(args.context, args.events, args.selector, attachedHandler, args.handler, args.external);

                if (args.external) {
                    if (typeof args.selector === "string" || WeavyUtils.isPlainObject(args.selector)) {
                        if (typeof args.context.one === "function") {
                            args.context.one(args.events, args.selector, attachedHandler);
                        } else {
                            rootTarget.warn("external .one() target does not support selectors")
                        }
                    } else {
                        if (typeof args.context.one === "function") {
                            args.context.one(args.events, attachedHandler);
                        } else if (args.context instanceof EventTarget) {
                            args.events.split(" ").forEach(function (eventName) {
                                args.context.addEventListener(eventName, attachedHandler, { once: true });
                            });
                        } else {
                            rootTarget.warn("external target does not have valid event listening");
                        }
                    }
                }
            } else {
                registerEventHandler(args.context, args.events, args.selector, args.handler, args.handler, args.external);

                if (args.external) {
                    if (typeof args.selector === "string" || WeavyUtils.isPlainObject(args.selector)) {
                        if (typeof args.context.one === "function") {
                            args.context.on(args.events, args.selector, args.handler);
                        } else {
                            rootTarget.warn("external .on() target does not support selectors")
                        }
                    } else {
                        if (typeof args.context.on === "function") {
                            args.context.on(args.events, args.handler);
                        } else if (args.context instanceof EventTarget) {
                            args.events.split(" ").forEach(function (eventName) {
                                args.context.addEventListener(eventName, args.handler);
                            });
                        } else {
                            rootTarget.warn("external target does not have valid event listening");
                        }
                    }
                }
            }
        };

        /**
         * Registers one or several event listneres that are executed once. All event listners are managed and automatically unregistered on destroy.
         * 
         * Similar to {@link WeavyEvents#on}.
         * 
         * @category eventhandling
         * @function
         * @name WeavyEvents#one
         * @param {Element} [context] - Context Element. If omitted it defaults to the Weavy instance. weavy.connection and wvy.postal may also be used as contexts.
         * @param {string} events - One or several event names separated by spaces. You may provide any namespaces in the names or use the general namespace parameter instead.
         * @param {string|Object} [selector] - Only applicable if the context supports selectors, for instance jQuery.on().
         * @param {Function} handler - The listener. The first argument is always the event, folowed by any data arguments provided by the trigger.
         */
        this.one = function (context, events, selector, handler) {
            this.on.call(this, context, events, selector, handler, true);
        };

        /**
         * Unregisters event listneres. The arguments must match the arguments provided on registration using .on() or .one().
         *
         * @category eventhandling
         * @function
         * @name WeavyEvents#off
         * @param {Element} [context] - Context Element. If omitted it defaults to the Weavy instance. weavy.connection and wvy.postal may also be used as contexts.
         * @param {string} events - One or several event names separated by spaces. You may provide any namespaces in the names or use the general namespace parameter instead.
         * @param {string} [selector] - Only applicable if the context supports selectors, for instance jQuery.on().
         * @param {function} handler - The listener. The first argument is always the event, folowed by any data arguments provided by the trigger.
         */
        this.off = function (context, events, selector, handler) {
            var args = getEventArguments(this, Array.from(arguments || []));

            var offHandler = getEventHandler(args.events, args.handler, args.context, args.selector);

            var handlerRemoved = unregisterEventHandler(args.context, args.events, args.selector, offHandler, args.handler, args.external);

            if (handlerRemoved && offHandler) {
                if (args.external && args.context) {

                    if (typeof args.selector === "string" || WeavyUtils.isPlainObject(args.selector)) {
                        if (typeof args.context.off === "function") {
                            args.context.off(args.events, args.selector, offHandler);
                        } else {
                            rootTarget.warn("external target does not have valid event listening");
                        }
                            
                    } else {
                        if (typeof args.context.off === "function") {
                            args.context.off(args.events, offHandler);
                        } else if (args.context instanceof EventTarget) {
                            args.events.split(" ").forEach(function (eventName) {
                                args.context.removeEventListener(eventName, offHandler);
                            });
                        } else {
                            rootTarget.warn("external target does not have valid event listening");
                        }
                    }

                }
            } else {
                console.debug("event off: handler not found or already removed;", args.events);
            }
        };

        /**
         * Clears all registered eventhandlers
         * 
         * @category eventhandling
         * @function
         * @name WeavyEvents#clear
         */
        this.clear = function () {
            _eventHandlers.forEach(function (eventHandler) {
                // TODO: Maybe use .off instead?
                if (eventHandler.external && eventHandler.context) {
                    if (typeof eventHandler.selector === "string" || WeavyUtils.isPlainObject(eventHandler.selector)) {
                        if (typeof eventHandler.context.off === "function") {
                            eventHandler.context.off(eventHandler.events, eventHandler.selector, eventHandler.handler);
                        } else {
                            rootTarget.warn("external target does not have valid event listening");
                        }

                    } else {
                        if (typeof eventHandler.context.off === "function") {
                            eventHandler.context.off(eventHandler.events, eventHandler.handler);
                        } else if (eventHandler.context instanceof EventTarget) {
                            eventHandler.events.split(" ").forEach(function (eventName) {
                                eventHandler.context.removeEventListener(eventName, eventHandler.handler);
                            });
                        } else {
                            rootTarget.warn("external target does not have valid event listening");
                        }
                    }

                }
            });

            _eventHandlers.length = 0; // Empty the array without removing references
        }


        /**
         * Trigger a custom event. Events are per default triggered on the weavy instance using the weavy namespace.
         * 
         * The trigger has an event chain that adds `before:` and `after:` events automatically for all events except when any custom `prefix:` is specified. This way you may customize the eventchain by specifying `before:`, `on:` and `after:` in your event name to fire them one at the time. The `on:` prefix will then be removed from the name when the event is fired.
         * 
         * Eventhandlers listening to the event may return modified data that is returned by the trigger event. The data is passed on to the next event in the trigger event chain. If an event handler calls `event.stopPropagation()` or `return false`, the event chain will be stopped and the value is returned.
         * 
         * @example
         * // Normal triggering
         * weavyEvents.triggerEvent("myevent");
         * 
         * // Will trigger the following events on the root instance
         * // 1. before:myevent.event.weavy
         * // 2. myevent.event.weavy
         * // 3. after:myevent.event.weavy
         * 
         * @example
         * // Custom triggering, one at the time
         * weavyEvents.triggerEvent("before:myevent");
         * weavyEvents.triggerEvent("on:myevent");
         * weavyEvents.triggerEvent("after:myevent");
         * 
         * @example
         * // Advanced triggering with data handling
         * 
         * function doSomething() {
         *     // Will trigger the events sequentially and check the response data in between
         *
         *     var myTriggerData = { counter: 123, label: "my label" };
         * 
         *     // Custom triggering, one at the time
         * 
         *     // 1. Trigger before: and save the response data back to myTriggerData
         *     myTriggerData = weavyEvents.triggerEvent("before:myevent", myTriggerData);
         *     
         *     if (myTriggerData === false) {
         *         console.warn("before:myevent was cancelled by event.stopPropagation() or return false");
         *         return;
         *     }
         * 
         *     // ...
         * 
         *     // 2. Continue with on: and save the response data back to myTriggerData
         *     myTriggerData = weavyEvents.triggerEvent("on:myevent", myTriggerData);
         *     
         *     if (myTriggerData === false) {
         *         console.warn("on:myevent was cancelled by event.stopPropagation() or return false");
         *         return;
         *     }
         *
         *     // ...
         * 
         *     // 3. At last trigger after: and save the response data back to myTriggerData
         *     myTriggerData = weavyEvents.triggerEvent("after:myevent", myTriggerData);
         *     
         *     if (myTriggerData === false) {
         *         console.warn("after:myevent was cancelled by event.stopPropagation() or return false");
         *         return;
         *     }
         *     
         *     console.log("myevent was fully executed", myTriggerData);
         *     return myTriggerData;
         * }
         * 
         * @category eventhandling
         * @function
         * @name WeavyEvents#triggerEvent
         * @param {string} name - The name of the event.
         * @param {(Array/Object/JSON)} [data] - Data may be an array or plain object with data or a JSON encoded string.
         * @returns {data} The data passed to the event trigger including any modifications by event handlers. Returns false if the event is cancelled.
         */
        this.triggerEvent = function (name, data) {
            var hasPrefix = name.indexOf(":") !== -1;
            var prefix = name.split(":")[0];
            var eventChain = getEventChain(this, rootTarget);
            var eventChainReverse = eventChain.slice().reverse();

            if (this instanceof HTMLElement && this.isConnected) {
                console.warn("Triggering event on DOM Node may cause unexpected bubbling:", '"' + name + '"', "<" + this.nodeName.toLowerCase() + (this.id ? ' id="' + this.id + '" />' : ' />'));
            }

            name = name.replace("on:", "");

            // Triggers additional before:* and after:* events
            var beforeEventName = "before:" + name;
            var eventName = name;
            var afterEventName = "after:" + name;

            if (data && !Array.isArray(data) && !WeavyUtils.isPlainObject(data)) {
                try {
                    data = JSON.parse(data);
                } catch (e) {
                    rootTarget.warn("Could not parse event data");
                }
            }

            rootTarget.debug("trigger", name);
            var result, currentTarget, ct;

            if (hasPrefix) {
                // Defined prefix. before: on: after: custom:
                // select direction of eventChain
                var singleEventChain = (prefix === "before" || prefix === "after") ? eventChainReverse : eventChain;

                for (ct = 0; ct < singleEventChain.length; ct++) {
                    currentTarget = singleEventChain[ct];
                    result = triggerHandler(currentTarget, eventName, data);
                    data = (result || result === false) ? result : data;
                    if (data === false) { return data; }
                }
            } else {
                // Before
                // eventChain from root
                for (ct = 0; ct < eventChainReverse.length; ct++) {
                    currentTarget = eventChainReverse[ct];
                    result = triggerHandler(currentTarget, beforeEventName, data);
                    data = (result || result === false) ? result : data;
                    if (data === false) { return data; }
                }

                // On
                // eventChain from target
                for (ct = 0; ct < eventChain.length; ct++) {
                    currentTarget = eventChain[ct];
                    result = triggerHandler(currentTarget, eventName, data);
                    data = (result || result === false) ? result : data;
                    if (data === false) { return data; }
                }

                // After
                // eventChain from root
                for (ct = 0; ct < eventChainReverse.length; ct++) {
                    currentTarget = eventChainReverse[ct];
                    result = triggerHandler(currentTarget, afterEventName, data);
                    data = (result || result === false) ? result : data;
                }
            }

            return data;
        };

    };

    return WeavyEvents;
}));
/* eslint-env commonjs, amd */

// UMD based on https://github.com/umdjs/umd/blob/master/templates/returnExports.js
// TODO: move to ES6 and transpiler

(function (root, factory) {
    if (typeof define === 'function' && define.amd) {
        // AMD. Register as an anonymous module.
        define([
            '../promise',
            '../utils'
        ], factory);
    } else if (typeof module === 'object' && module.exports) {
        // Node. Does not work with strict CommonJS, but
        // only CommonJS-like environments that support module.exports,
        // like Node.
        module.exports = factory(
            require('../promise'),
            require('../utils')
        );
    } else {
        // Browser globals (root is window)
        root.WeavyPanels = factory(root.wvy.promise, root.wvy.utils, root.wvy);
    }
}(typeof self !== 'undefined' ? self : this, function (WeavyPromise, WeavyUtils, wvy) {

    //console.debug("panels.js");

    var _isMobile = /iPhone|iPad|iPod|Android/i.test(navigator.userAgent);

    /**
     * Create a {@link WeavyPanels~panel} that has frame handling. If the panel already exists it will return the existing panel.
     * 
     * @function
     * @name WeavyPanels~container#addPanel
     * @param {string} panelId - The id of the panel.
     * @param {url} [url] - Optional url. The page will not be loaded until {@link WeavyPanels~panel#preload} or {@link WeavyPanels~panel#open} is called.
     * @param {Object} [attributes] - All panel attributes are optional
     * @param {string} [attributes.type] - Type added as data-type attribute.
     * @param {boolean} [attributes.persistent] - Should the panel remain when {@link WeavyPanels~panel#remove} or {@link WeavyPanels#clearPanels} are called?
     * @param {boolean} [attributes.preload] - Should the panel be preloaded when idle?
     * @returns {WeavyPanels~panel}
     * @emits WeavyPanels#panel-added
     */

    var WeavyPanel = function (weavy, _panels, panelsContainer, panelId, url, attributes) {
        if (!panelId) {
            weavy.error("new WeavyPanel() is missing panelId");
            return;
        }

        var loadingTimeout = [];

        var _whenClosed = WeavyPromise.resolve();
        weavy.debug("creating panel", panelId);

        var panelElementId = weavy.getId("panel-" + panelId);

        if (!WeavyUtils.isPlainObject(attributes)) {
            attributes = {};
        }

        var createFrame = function(url) {
            // frame
            var frame = document.createElement("iframe");
            frame.className = "weavy-panel-frame";
            frame.id = weavy.getId("panel-" + panelId);
            frame.name = weavy.getId("panel-" + panelId);
            frame.allowFullscreen = 1;
            frame.dataset.weavyId = weavy.getId();

            if (url) {
                // Stores the provided url as data src for load when requested later.
                // If the frame src is unset it means that the frame is unloaded
                // If both data src and src are set it means it's loading
                frame.dataset.src = new URL(url, weavy.url).href;
            }

            return frame;
        }

        /**
         * Wrapped iframe with event handling, states, preloading and postMessage communication.
         * 
         * @typedef WeavyPanels~panel
         * @type {HTMLElement}
         * @typicalname ~panel
         * @property {string} id - Unique id for the container. Using panelId processed with {@link Weavy#getId}.
         * @property {string} panelId - Unprocessed id for the panel.
         * @property {string} className - DOM class: "weavy-panel".
         * @property {string} [dataset.type] - Any provided type.
         * @property {boolean} [dataset.persistent] - Will the panel remain when {@link WeavyPanels~panel#remove} or {@link WeavyPanels#clearPanels} are called?
         * @property {boolean} [dataset.preload] - Should the panel be preloaded when idle
         * @property {IFrame} frame - Reference to the child iframe
         * @property {string} frame.id - Id of the iframe
         * @property {string} frame.className - DOM class: "weavy-panel-frame"
         * @property {string} frame.name - Window name for the frame
         * @property {string} frame.dataset.src - The original url for the panel.
         * @property {string} frame.dataset.weavyId - The id of the weavy instance the frame belongs to. Provided for convenience.
         * @property {string} [frame.dataset.type] - Any provided type.
         * @property {Object} eventParent - Reference to the parent panels container.
         * @property {function} on() - Binding to the [.on()]{@link WeavyEvents#on} eventhandler of the weavy instance.
         * @property {function} one() - Binding to the [.one()]{@link WeavyEvents#one} eventhandler of the weavy instance.
         * @property {function} off() - Binding to the [.off()]{@link WeavyEvents#off}  eventhandler of the weavy instance.
         * @property {function} triggerEvent() - Using {@link WeavyEvents#triggerEvent} of the weavy instance to trigger events on the panel container that propagates to the weavy instance.
         * @property {boolean} isOpen - Get if the panel is open.
         * @property {boolean} isLoading - Get if the panel is loading. Set to true to visually indicate that the panel is loading. Set to false to turn off the visual indication.
         * @property {boolean} isLoaded - Get if the panel is loaded. Set to true to visually indicate that the panel is loading. Set to false to turn off the visual indication.
         **/
        var panel = this;
        panel.panelId = panelId;

        //var panelNode = Reflect.construct(HTMLElement, [], this.constructor);
        panel.node = document.createElement("div");

        panel.node.className = "weavy-panel";
        panel.node.id = panelElementId;
        panel.node.dataset.id = panelId;

        // Create iframe
        panel.frame = createFrame(url);
        panel.node.appendChild(panel.frame);
        panel.node.frame = panel.frame;

        // Events
        panel.eventParent = panelsContainer;
        panel.on = weavy.events.on.bind(panel);
        panel.one = weavy.events.one.bind(panel);
        panel.off = weavy.events.off.bind(panel);
        panel.triggerEvent = weavy.events.triggerEvent.bind(panel);

        if (panel.frame.dataset.src) {
            panel.location = new URL(panel.frame.dataset.src, weavy.url).href;
        }

        if (attributes.type) {
            panel.node.dataset.type = attributes.type;
        }

        if (attributes.persistent !== undefined) {
            panel.node.dataset.persistent = String(attributes.persistent);
        }

        if (attributes.preload !== undefined) {
            panel.node.dataset.preload = String(attributes.preload);
        }

        try {
            weavy.debug("Appending panel", panelId);
            panelsContainer.node.appendChild(panel.node);
            _panels.set(panelId, panel);
        } catch (e) {
            weavy.error("Could not append panel", panelId)
        }

        // States


        // FUNCTIONS

        var _isRegistered = false;
        var _isReady = false;
        var _isLoaded = false;
        var _isLoading = false;

        /**
         * Registers the panel frame window in wvy.postal and adds a ready listener for the panel and inits the loading indication.
         */
        var registerLoading = function (panel) {
            if (!panel.isRegistered) {
                try {
                    wvy.postal.registerContentWindow(panel.frame.contentWindow.self, panel.frame.name, weavy.getId(), weavy.url.origin);
                } catch (e) {
                    weavy.error("Could not register window id", panel.frame.name, e);
                }

                _isRegistered = true;
            }
        }

        /**
         * Set the loading indicator on the specified panel. The loading indicatior is automatically removed on loading. It also makes sure the panel is registered and sets up frame communication when loaded.
         * 
         * @function
         * @param {WeavyPanels~panel} panel - The panel that should update.
         * @emits WeavyPanels#panel-loading
         */
        function updatePanelLoading(panel) {
            if (panel.isLoading) {
                registerLoading(panel);
                loadingTimeout[panelId] = weavy.whenTimeout(30000);
                loadingTimeout[panelId].then(function () { _isLoading = false; updatePanelLoading(panel); });
            } else {
                if (loadingTimeout[panelId]) {
                    loadingTimeout[panelId].cancel();
                    delete loadingTimeout[panelId];
                }
            }

            /**
             * Event triggered when panel is starting to load or stops loading.
             * 
             * @category events
             * @event WeavyPanels#panel-loading
             * @returns {Object}
             * @property {string} panelId - The id of the panel loading.
             * @property {boolean} isLoading - Indicating wheter the panel is loading or not.
             * @property {boolean} fillBackground - True if the panel has an opaque background during loading.
             */
            panel.triggerEvent("panel-loading", { panelId: panelId, isLoading: panel.isLoading, isLoaded: panel.isLoaded });
        }

        panel.loadingStarted = function (replaced) {
            if (replaced) {
                _isLoaded = false;
            }
            _isLoading = true;
            updatePanelLoading(panel);
        }

        panel.loadingFinished = function () {
            _isLoaded = true;
            _isLoading = false;
            updatePanelLoading(panel);
        }

        panel.on("panel-loading", function (e, panelLoading) {
            if (panelLoading.isLoading) {
                panel.node.classList.add("weavy-loading");
            } else {
                panel.node.classList.remove("weavy-loading");
            }

            if (panelLoading.isLoaded) {
                panel.node.classList.add("weavy-loaded");
            } else {
                panel.node.classList.remove("weavy-loaded");
            }
        });

        /**
         * Check if a panel is currently open
         * 
         * @property {boolean} isOpem - True if the panel is open
         */
        Object.defineProperty(panel, "isOpen", {
            get: function () { return panel.node.classList.contains("weavy-open"); }
        });

        /**
         * Check if a panel is currently loading.
         * 
         * @property {boolean} isLoading - True if the panel currently is loading
         */
        Object.defineProperty(panel, "isLoading", {
            get: function () {
                return _isLoading;
            }
        });

        /**
         * Check if the panel frame is registered.
         * 
         * @property {boolean} isRegistered - True if the panel is registered
         */
        Object.defineProperty(panel, "isRegistered", {
            get: function () {
                return _isRegistered;
            }
        });

        /**
         * Check if the panel frame has received ready.
         * 
         * @property {boolean} isReady - True if the panel has received ready
         */
        Object.defineProperty(panel, "isReady", {
            get: function () {
                return _isReady;
            }
        });

        /**
         * Check if a panel has finished loading.
         * 
         * @property {boolean} isLoaded - True if the panel has finished loading.
         */
        Object.defineProperty(panel, "isLoaded", {
            get: function () {
                return _isLoaded;
            }
        });


        // Promises

        /**
         * Promise that resolves when the panel iframe has connected via postMessage.
         * 
         * @type {WeavyPromise}
         * @name WeavyPanels~panel#whenReady
         * @property {string} panelId - The id of the panel
         * @property {string} windowName -  The name of the frame
         * @property {string} location -  The location url of the frame.
         * @property {int} statusCode -  The http status code of the frame.
         * @property {string} statusDescription - The description of the http status code.
         **/
        panel.whenReady = new WeavyPromise();

        var _onReady = function (e, ready) {
            _isReady = true;

            var previousLocation = panel.location;
            var previousStatusCode = panel.statusCode;
            var statusOk = !ready.statusCode || ready.statusCode === 200;

            panel.location = new URL(ready.location, weavy.url).href;
            panel.statusCode = ready.statusCode;

            panel.loadingFinished();

            if (previousStatusCode !== ready.statusCode && !statusOk) {
                weavy.warn(ready.location + " " + ready.statusCode + " " + ready.statusDescription);
            }

            var changedLocation = previousLocation && previousLocation !== panel.location;
            var changedStatusCode = previousStatusCode !== panel.statusCode;
            var originalLocation = panel.location === panel.frame.dataset.src && !panel.isOpen;

            if (panel.isOpen && (changedLocation || changedStatusCode)) {
                if (changedLocation && statusOk && !originalLocation) {
                    panel.stateChangedAt = Date.now();
                } else if (!statusOk || originalLocation) {
                    panel.stateChangedAt = null;
                }
                weavy.history.addState("replace");
            }

            panel.whenReady.resolve({ panelId: panelId, windowName: panel.frame.name, location: ready.location, statusCode: ready.statusCode, statusDescription: ready.statusDescription });
        };

        weavy.on(wvy.postal, "ready", { weavyId: weavy.getId(), windowName: panel.frame.name }, _onReady);

        var unregisterReady = function () {
            weavy.off(wvy.postal, "ready", { weavyId: weavy.getId(), windowName: panel.frame.name }, _onReady);
        };

        /**
         * Promise that resolves when the panel iframe has fully loaded.
         * 
         * @type {WeavyPromise}
         * @name WeavyPanels~panel#whenLoaded
         * @property {string} panelId - The id of the panel
         * @property {string} windowName -  the name of the frame
         **/
        panel.whenLoaded = new WeavyPromise();
        weavy.on(wvy.postal, "load", { weavyId: weavy.getId(), windowName: panel.frame.name }, function () {
            panel.whenLoaded.resolve({ panelId: panelId, windowName: panel.frame.name, location: panel.location });
        });

        // OTHER FUNCTIONS

        /**
         * Loads an url in a frame or sends data into a specific frame. Will replace anything in the frame.
         * 
         * @ignore
         * @param {HTMLIFrameElement} frame - The frame element
         * @param {any} url - URL to load.
         * @param {any} [data] - URL/form encoded data.
         * @param {any} [method=GET] - HTTP Request Method {@link https://developer.mozilla.org/en-US/docs/Web/HTTP/Methods}
         * @returns {external:Promise}
         */
        function sendToFrame(frame, url, data, method) {
            // Todo: return complete promise instead
            return weavy.whenReady().then(function () {
                method = String(method || "get").toLowerCase();

                if (frame) {
                    var frameUrl = url;
                    if (method === "get") {
                        if (data) {
                            // Append data to URL
                            if (frameUrl.indexOf('?') === -1) {
                                frameUrl = frameUrl + "?" + data;
                            } else {
                                frameUrl = frameUrl + "&" + data;
                            }
                        }
                    }

                    if (frame.src !== frameUrl) {
                        // If no url is set yet, set an url
                        frame.src = frameUrl;
                        if (method === "get") {
                            weavy.info("sendToFrame using src");
                            // No need to send a form since data is appended to the url
                            return;
                        }
                    } else if (frame.src && method === "get") {
                        weavy.info("sendToFrame using window.open");
                        window.open(frameUrl, frame.name);
                        return;
                    }

                    weavy.info("sendToFrame using form");

                    // Create a form to send to the frame
                    var requestForm = document.createElement("form");
                    requestForm.action = url;
                    requestForm.method = method;
                    requestForm.target = frame.name;

                    if (data) {
                        data = data.replace(/\+/g, '%20');
                    }
                    var dataArray = data && data.split("&") || [];

                    // Add all data as hidden fields
                    dataArray.forEach(function (pair) {
                        var nameValue = pair.split("=");
                        var name = decodeURIComponent(nameValue[0]);
                        var value = decodeURIComponent(nameValue[1]);
                        
                        var formInput = document.createElement("input");
                        formInput.type = 'hidden';
                        formInput.name = name;
                        formInput.value = value;

                        requestForm.appendChild(formInput);
                    });


                    // Send the form and forget it
                    weavy.nodes.container.appendChild(requestForm);
                    requestForm.submit();
                    requestForm.remove();
                }
            });
        }

        /**
         * Create panel controls for expand/collapse and close. Set control settings in {@link panels.defaults|options}
         * 
         * @returns {Element} 
         */
        function renderControls(panel, options) {

            var controls = document.createElement("div");
            controls.className = "weavy-controls";

            if (options.controls) {
                if (options.controls === true || options.controls.close) {
                    var close = document.createElement("div");
                    close.className = "weavy-icon" + (typeof options.controls.close === "string" ? " " + options.controls.close : "");
                    close.title = wvy.t("Close");
                    close.innerHTML = '<svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24"><path d="M19,6.41L17.59,5L12,10.59L6.41,5L5,6.41L10.59,12L5,17.59L6.41,19L12,13.41L17.59,19L19,17.59L13.41,12L19,6.41Z" /></svg>';
                    weavy.on(close, "click", panel.close.bind(panel));
                    controls.appendChild(close);
                }
            }

            return controls;
        }

        // METHODS

        /**
         * Open a the panel. The open waits for the [weavy.whenReady]{@link Weavy#whenReady} to complete, then opens the panel.
         *
         * Returns a promise that is resolved when the panel is opened and fully loaded.
         * 
         * @function
         * @name WeavyPanels~panel#open
         * @param {string} [destination] - Tells the panel to navigate to a specified url.
         * @emits WeavyPanels#panel-open
         * @returns {external:Promise}
         */
        panel.open = function (destination, noHistory) {

            return weavy.whenReady().then(function () {
                weavy.info("openPanel", panel.panelId + (destination ? " " + destination : ""), noHistory ? "no history" : "with history");

                if (!panel.node.dataset.persistent && !weavy.authentication.isAuthorized()) {
                    return Promise.reject(new Error("Unauthorized, can't open panel " + panel.panelId));
                }

                /**
                 * Event triggered when a panel is opened.
                 * 
                 * @category events
                 * @event WeavyPanels#panel-open
                 * @returns {Object}
                 * @property {string} panelId - The id of the panel being openened.
                 * @property {string} [destination] - Any url being requested to open in the panel.
                 * @property {WeavyPanels~container} panels - The panels container for the panel
                 */
                var openResult = panel.triggerEvent("panel-open", { panelId: panel.panelId, destination: destination, panels: panelsContainer });

                if (openResult !== false && openResult.panelId === panel.panelId) {
                    panel.node.classList.add("weavy-open");
                    return panel.load(openResult.destination, null, null, null, noHistory);
                } else {
                    return Promise.reject(new Error("Prevented open " + panel.panelId));
                }
            });
        };



        /**
         * [Open]{@link WeavyPanels~panel#open} or [close]{@link WeavyPanels~panel#close} the panel.
         * 
         * Returns promise that is resolved when the panel is opened and loaded or closed.
         * 
         * @function
         * @name WeavyPanels~panel#toggle
         * @param {string} [destination] - Tells the panel to navigate to a specified url when opened.
         * @emits WeavyPanels#panel-toggle
         * @returns {external:Promise}
         */
        panel.toggle = function (destination) {
            return weavy.whenReady().then(function () {
                weavy.info("toggling panel", panel.panelId);

                var shouldClose = panel.isOpen;

                /**
                    * Event triggered when a panel is toggled open or closed.
                    * 
                    * @category events
                    * @event WeavyPanels#panel-toggle
                    * @returns {Object}
                    * @property {string} panelId - The id of the panel toggled.
                    * @property {boolean} closed - True if the panel is closed.
                    */
                panel.triggerEvent("panel-toggle", { panelId: panel.panelId, closed: shouldClose });

                if (shouldClose) {
                    return panel.close();
                } else {
                    return panel.open(typeof (destination) === "string" ? destination : null);
                }
            });
        }

        /**
         * Closes the panel.
         * 
         * Returns a promise that is resolved when the panel is closed.
         * 
         * @function
         * @name WeavyPanels~panel#close
         * @returns {external:Promise}
         * @emits WeavyPanels#panel-close
         */
        panel.close = function (noHistory, noEvent) {

            return weavy.whenReady().then(function () {

                if (panel.isOpen) {
                    weavy.info("closePanel", panel.panelId, noEvent === true ? "no event" : "", noHistory === true ? "no history" : "");

                    panel.node.classList.remove("weavy-open");

                    if (noEvent !== true) {
                        /**
                         * Event triggered when weavy closes a panel.
                         * 
                         * @category events
                         * @event WeavyPanels#panel-close
                         * @returns {Object}
                         * @property {string} panelId - The id of the panel
                         * @property {WeavyPanels~container} panels - The panels container for the panel
                         */
                        panel.triggerEvent("panel-close", { panelId: panel.panelId, panels: panelsContainer });

                        if (noHistory !== true) {
                            panel.stateChangedAt = Date.now();
                            weavy.history.addState();
                        }
                    }

                    panel.postMessage({ name: 'close' }).catch(() => {
                        weavy.warn("Unable to close panel", panel.panelId);
                    });


                    // Return timeout promise
                    _whenClosed = weavy.whenTimeout(250);

                    _whenClosed.then(function () {
                        panel.postMessage({ name: 'closed' });
                    });
                }

                return _whenClosed();
            });
        };

        /**
         * Load an url with data directly in the panel. Uses turbolinks forms if the panel is loaded and a form post to the frame if the panel isn't loaded.
         *          
         * Loads the predefined panel url if url parameter is omitted.
         * 
         * Returns a promise that is resolved when the panel is loaded.
         *
         * @function
         * @name WeavyPanels~panel#load
         * @param {string} [url] - The url to load in the panel.
         * @param {any} [data] -  URL/form-encoded data to send
         * @param {string} [method=GET] - HTTP Request Method {@link https://developer.mozilla.org/en-US/docs/Web/HTTP/Methods}
         * @param {bool} [replace] - Replace the content in the panel and load it fresh.
         * @returns {external:Promise}
         */
        panel.load = function (url, data, method, replace, noHistory) {
            return weavy.whenReady().then(function () {
                var frameTarget = panel.frame;

                if (url) {
                    url = new URL(url, weavy.url).href;

                    panel.location = url;

                    // Not yet fully loaded
                    if (!panel.isReady) {
                        panel.loadingStarted(replace);
                        sendToFrame(frameTarget, url, data, method);
                    } else {
                        if (replace) {
                            panel.loadingStarted(true);
                        }
                        // Fully loaded, send using turbolinks
                        panel.postMessage({ name: 'turbolinks-visit', url: url, data: data, method: method, action: "replace" });
                    }

                } else if (!panel.isLoaded && !panel.isLoading) {
                    // start predefined loading
                    weavy.debug("panels:", panelId, "predefined loading");
                    panel.loadingStarted(true);
                    frameTarget.setAttribute("src", frameTarget.dataset.src);
                } else if (panel.isLoaded || panel.isLoading) {
                    // already loaded
                    panel.postMessage({ name: 'show' });
                } else {
                    // No src defined
                    return Promise.resolve();
                }

                // ADD HISTORY
                if (noHistory !== true) {
                    panel.stateChangedAt = Date.now();
                    weavy.debug("panels: adding history state", panelId, panel.location);
                    weavy.history.addState();
                }

                return panel.whenLoaded();
            });
        };

        /**
         * Preload the panel. The frame needs to have data-src attribute set.
         * 
         * Returns a promise that is resolved when the panel is loaded.
         *
         * @function
         * @name WeavyPanels~panel#preload
         * @returns {external:Promise}
         **/
        panel.preload = function () {
            var delayedFrameLoad = function () {
                if (!panel.isLoading && !panel.isLoaded) {
                    weavy.debug("preloading panel:", panelId);
                    panel.load(null, null, null, null, true);
                }
            };

            // Wait for idle
            if (window.requestIdleCallback) {
                window.requestIdleCallback(delayedFrameLoad);
            } else {
                if (document.readyState === "complete") {
                    delayedFrameLoad();
                } else {
                    weavy.one(document, "load", delayedFrameLoad);
                }
            }

            return panel.whenLoaded();
        }

        /**
         * Tells the panel that it needs to reload it's content.
         * 
         * Returns a promise that is resolved when the panel is loaded.
         *
         * @function
         * @name WeavyPanels~panel#reload
         * @emits Weavy#panel-reload
         * @returns {external:Promise}
         **/
        panel.reload = function () {
            return weavy.whenReady().then(function () {
                panel.isLoading = true;

                panel.postMessage({ name: "reload" })

                /**
                 * Event triggered when a panel is reloading it's content.
                 * 
                 * @category events
                 * @event WeavyPanels#panel-reload
                 * @returns {Object}
                 * @property {string} panelId - The id of the panel being reloaded.
                 */
                panel.triggerEvent("panel-reload", { panelId: panelId });
            });
        }

        /** 
         * Creates a new panel iframe and resets the panel to its original url. This can be used if the panel has ended up in an incorrect state.
         * 
         * @function
         * @name WeavyPanels~panel#reset
         * @returns {external:Promise}
         **/
        panel.reset = function () {
            return weavy.whenReady().then(function () {
 
                var oldFrame = panel.frame;

                if (oldFrame) {
                    weavy.log("resetting panel", panelId);

                    var newFrame = createFrame(oldFrame.dataset.src || oldFrame.src);

                    _isRegistered = false;
                    _isReady = false;
                    _isLoaded = false;
                    _isLoading = false;

                    panel.location = null;
                    panel.statusCode = null;

                    panel.whenReady.reset();
                    panel.whenLoaded.reset();

                    var isOpen = panel.isOpen;

                    try {
                        wvy.postal.unregisterContentWindow(oldFrame.name, weavy.getId());
                    } catch (e) {
                        weavy.error("Could not unregister window id", oldFrame.name, e);
                    }

                    panel.node.removeChild(oldFrame);
                    panel.node.appendChild(newFrame);

                    panel.frame = newFrame;

                    /**
                        * Triggered when a panel has been reset.
                        * 
                        * @event WeavyPanels#panel-reset
                        * @category events
                        * @returns {Object}
                        * @property {string} panelId - Id of the reset panel
                        */
                    panel.triggerEvent("panel-reset", { panelId: panelId });


                    if (isOpen) {
                        return panel.load(null, null, null, null, true)
                    }

                    return Promise.resolve();
                } 

                return Promise.resolve();
            });
        }

        /** 
         * Gets the current history state of the panel
         * 
         * @function
         * @name WeavyPanels~panel#getState
         * @returns {WeavyHistory~panelState}
         **/
        panel.getState = function () {
            weavy.debug("getPanelState", panelId);
            return weavy.history.getStateFromPanel(panelId);
        };

        /**
         * Sets the state of the panel.
         * 
         * @function
         * @name WeavyPanels~panel#setState
         * @param {WeavyHistory~panelState} state - The history panel state to apply
         * @returns {external:Promise}
         **/
        panel.setState = function (state) {
            if (!state || state.panelId !== panelId) {
                weavy.warn("setState: State not valid.", panelId);
                return;
            }

            if (new URL(state.location, weavy.url).origin !== weavy.url.origin) {
                weavy.warn("setState: Invalid url origin.", panelId, new URL(state.location, weavy.url).origin);
                return;
            }

            var statusOk = (!state.statusCode || state.statusCode === 200);

            if (!statusOk) {
                weavy.warn("setState: Invalid url http status.", panelId);
                return;
            }

            if (state.isOpen !== panel.isOpen || state.location !== panel.location) {
                panel.stateChangedAt = state.changedAt;
            }

            if (state.isOpen) {
                var panelLocation = state.location !== panel.location ? state.location : null;
                if (panel.isOpen) {
                    return panel.open(panelLocation, true);
                } else {
                    return panel.open(state.location, true);
                }
            } else {
                return panel.close(true);
            }
        }


        /**
         * Triggered when the app receives a postMessage sent from the panel frame.
         *
         * @category events
         * @event WeavyPanels#message
         * @returns {Object}
         * @property {string} panelId - Id of the panel
         */
        weavy.on(wvy.postal, "message", { weavyId: weavy.getId(), windowName: panel.frame.name }, (e, message) => panel.triggerEvent("message", WeavyUtils.assign(message, { panelId: panelId })));

        /**
         * Sends a postMessage to the panel iframe.
         * Returns a promise that is resolved when the message has been delivered and rejected if the message fails or has timed out.
         *
         * @function
         * @name WeavyPanels~panel#postMessage
         * @param {object} message - The Message to send
         * @param {Transferable[]} [transfer] - A sequence of Transferable objects that are transferred with the message.
         * @see {@link https://developer.mozilla.org/en-US/docs/Web/API/Window/postMessage}
         * @returns {external:Promise}
         */
        panel.postMessage = function (message, transfer) {
            return panel.whenReady().then(function () {
                var frameTarget = panel.frame;
                if (frameTarget && wvy.postal) {
                    return wvy.postal.postToFrame(frameTarget.name, weavy.getId(), message, transfer);
                } else {
                    return Promise.reject();
                }
            });
        }

        /**
         * Removes a panel. If the panel is open it will be closed before it's removed.
         * 
         * @function
         * @name WeavyPanels~panel#remove
         * @param {boolean} [force] - True will remove the panel even if it's persistent
         * @emits WeavyPanels#panel-removed
         * @returns {external:Promise}
         */

        panel.remove = function (force, noHistory) {

            var _removePanel = function (noHistory) {
                if (!panel.node.dataset.persistent || force) {
                    if (panel.isOpen) {
                        panel.id = weavy.getId("weavy-panel-removed-" + panelId);
                        return weavy.whenTimeout(0).then(function () {
                            return panel.close(noHistory).then(function () {
                                return panel.remove(force, noHistory);
                            });
                        });
                    } else {
                        unregisterReady();

                        try {
                            wvy.postal.unregisterContentWindow(panel.frame.name, weavy.getId());
                        } catch (e) {
                            weavy.error("Could not unregister window id", panel.frame.name, e);
                        }

                        panel.node.remove();
                        _panels.delete(panelId);

                        /**
                         * Triggered when a panel has been removed.
                         * 
                         * @event WeavyPanels#panel-removed
                         * @category events
                         * @returns {Object}
                         * @property {string} panelId - Id of the removed panel
                         */
                        panelsContainer.triggerEvent("panel-removed", { panelId: panelId });

                        return Promise.resolve();
                    }
                }
            };

            return force ? _removePanel(noHistory) : weavy.whenReady().then(function () { return _removePanel(noHistory); });
        };





        // Frame handling


        // Close the panel from the inside
        weavy.on(wvy.postal, "request:reset", { weavyId: weavy.getId(), windowName: panel.frame.name }, function () {
            panel.reset();
        });

        // Close the panel from the inside
        weavy.on(wvy.postal, "request:close", { weavyId: weavy.getId(), windowName: panel.frame.name }, function () {
            panel.close();
        });

        // External controls

        panel.node.appendChild(renderControls.call(weavy, panel, attributes));

        /**
         * Triggered when a panel is added
         * 
         * @event WeavyPanels#panel-added
         * @category events
         * @returns {Object}
         * @property {Element} panel - The created panel
         * @property {string} panelId - The id of the panel
         * @property {url} url - The url for the frame.
         * @property {Object} attributes - Panel attributes
         * @property {string} attributes.type - Type of the panel.
         * @property {boolean} attributes.persistent - Will the panel remain when {@link WeavyPanels~panel#remove} or {@link WeavyPanels#clearPanels} are called?
         */
        panelsContainer.triggerEvent("panel-added", { panel: panel, panelId: panelId, url: url, attributes: attributes });

        return panel;

    };

    //WeavyPanel.prototype = Object.create(HTMLDivElement.prototype);
    //WeavyPanel.prototype.constructor = WeavyPanel;
    //Object.setPrototypeOf(WeavyPanel, HTMLDivElement);

    //WeavyPanel.prototype.connectedCallback = function () {
        // PANEL MOUNTED
    //};
    //customElements.define('weavy-panel', WeavyPanel);

    /**
     * @class WeavyPanels
     * @classdesc 
     * Panel manager for handling for iframes and their communication.
     * 
     * The panel management is split up into a panels container which can contain multiple panels. 
     * Each panel is essentialy a wrapped iframe. 
     * The panels container provides the possibility to have multiple panels in the same client container
     * and adds the possibility to shift between which panel that is visible in the container as a tab behavior.
     **/

    /**
     * Creates an instance of the panel manager.
     * 
     * @constructor
     * @hidecontructor
     * @param {Weavy} weavy - The weavy instance the panel manager belongs to.
     */
    var WeavyPanels = function (weavy) {

        var _panelsContainers = new Map();

        var _panels = new Map();

        /**
         * Creates a new [panel container]{@link WeavyPanels~container}. The container must be attached to the DOM after being created.
         * 
         * @function
         * @name WeavyPanels#createContainer
         * @param {string} containerId=global - The id of the container.
         * @returns {WeavyPanels~container}
         */
        function createContainer(containerId) {
            containerId = containerId || "global";
            var containerElementId = weavy.getId("panels-" + containerId);

            var panelsContainer = { containerId: containerId };

            /**
             * Container for multiple panels with common functionality for the panels.
             * 
             * Use {@link WeavyPanels~container#addPanel} to create a panel in the container.
             * 
             * Each child panel will propagate it's events to the panel container and all the panel container events will propagate to the weavy instance.
             * 
             * @typedef WeavyPanels~container
             * @typicalname ~container
             * @type {HTMLElement}
             * @property {string} id - Unique id for the container. Using containerId processed with {@link Weavy#getId}
             * @property {string} containerId - The provided id unprocessed.
             * @property {string} className - DOM class: "weavy-panels"
             * @property {function} addPanel - {@link WeavyPanels~container#addPanel} creates a {@link WeavyPanels~panel} in the panel container and returns it.
             * @property {Object} eventParent - Unset. Set the eventParent as a reference to a parent to provide event propagation to that object.
             * @property {function} on - Binding to the [.on()]{@link WeavyEvents#on} eventhandler of the weavy instance.
             * @property {function} one - Binding to the [.one()]{@link WeavyEvents#one} eventhandler of the weavy instance.
             * @property {function} off - Binding to the [.off()]{@link WeavyEvents#off} eventhandler of the weavy instance.
             * @property {function} triggerEvent - Using {@link WeavyEvents#triggerEvent} of the weavy instance to trigger events on the panel container that propagates to the weavy instance.
             **/
            var panelsRoot = document.createElement("div");
            panelsRoot.id = containerElementId;
            panelsRoot.className = "weavy-panels";
            //panelsRoot.containerId = containerId;
            panelsRoot.dataset.containerId = containerId;

            panelsContainer.node = panelsRoot;
            panelsContainer.addPanel = function (panelId, url, attributes) {
                return new WeavyPanel(weavy, _panels, panelsContainer, panelId, url, attributes);
            };

            // Events
            panelsContainer.on = weavy.events.on.bind(panelsContainer);
            panelsContainer.one = weavy.events.one.bind(panelsContainer);
            panelsContainer.off = weavy.events.off.bind(panelsContainer);
            panelsContainer.triggerEvent = weavy.events.triggerEvent.bind(panelsContainer);

            _panelsContainers.set(containerId, panelsContainer);
            return panelsContainer;
        }

        function removeContainer(containerId, force) {
            containerId = containerId || "global";
            var container = _panelsContainers.get(containerId);

            if (force) {

                try {
                    container.node.remove();
                } catch (e) {
                    weavy.warn("Could not remove panels container");
                }

                _panelsContainers.delete(containerId);
                delete container.node;

                weavy.log("Panels container removed", containerId);
            }
        }

        /**
         * Closes all panels except persistent panels.
         * @memberof WeavyPanels#
         * @function
         * @returns {external:Promise}
         */
        function closePanels(noHistory) {
            weavy.debug("closing panels")

            var whenAllPanelsClosed = [];

            _panels.forEach(function (panel) {
                whenAllPanelsClosed.push(panel.close(noHistory));
            });

            return Promise.all(whenAllPanelsClosed)
        }

        /**
         * Removes all panels except persistent panels.
         * @memberof WeavyPanels#
         * @function
         * @param {boolean} force - Forces all panels to be removed including persistent panels
         * @returns {external:Promise}
         */
        function clearPanels(force) {
            weavy.debug("clearing" + (force ? " all" : "") + " panels", _panels.size)

            var whenAllPanelsCleared = [];

            _panels.forEach(function (panel) {
                whenAllPanelsCleared.push(panel.remove(force, true));
            });

            var whenContainersRemoved = Promise.all(whenAllPanelsCleared).then(function () {
                _panelsContainers.forEach(function (container, containerId) {
                    removeContainer(containerId, force);
                })
            })

            return whenContainersRemoved;
        }

        /**
         * Resets all panels to initial state.
         * @memberof WeavyPanels#
         * @function
         * @returns {external:Promise}
         */
        function resetPanels() {
            weavy.debug("resetting panels");

            var whenAllPanelsReset = [];

            _panels.forEach(function (panel) {
                whenAllPanelsReset.push(panel.reset(true));
            });

            return Promise.all(whenAllPanelsReset);
        }


        /**
         * Preload all frames. Frames will be loaded sequentially starting with system frames. 
         * Preloading is ignored on mobile devices.
         * 
         * @name WeavyPanels#preload
         * @function
         * @param {boolean} [force] - Force preloading for all frames, otherwise only system frames will be preloaded.
         */
        function preloadPanels(force) {
            if (_isMobile) {
                return Promise.resolve();
            }

            var preloadRoot = this;

            if ('whenReady' in weavy) {
                return weavy.whenReady().then(function () {
                    var panels;

                    if (preloadRoot instanceof HTMLElement && preloadRoot.dataset.containerId) {
                        panels = _panelsContainers.get(preloadRoot.dataset.containerId).panels;
                    } else {
                        panels = Array.from(_panels.values());
                    }

                    var currentlyLoadingFrames = panels.filter(function (panel) { return panel.isLoading; });
                    if (currentlyLoadingFrames.length) {
                        // Wait until user loaded frames has loaded
                        //weavy.debug("preload waiting for " + currentlyLoadingFrames.length + " panels");
                        return Promise.all(currentlyLoadingFrames.map(function (panel) { return panel.whenLoaded() })).then(function () { return preloadPanels.call(preloadRoot, force); });
                    }

                    var unloadedPanels = panels.filter(function (panel) { return (panel.node.dataset.preload === "true" || panel.node.dataset.preload === "placeholder") && !panel.isLoading && !panel.isLoaded });
                    if (unloadedPanels.length) {
                        // Preload all panels with 'preload: true'
                        return Promise.all(unloadedPanels.map(function (panel) { return panel.preload() })).then(function () { return preloadPanels.call(preloadRoot, force) });
                    } else if (force) {
                        // Preload any other panels except 'preload: false'
                        var remainingPanels = panels.filter(function (panel) { return panel.node.dataset.preload !== "false" && !panel.isLoading && !panel.isLoaded });
                        if (remainingPanels.length) {
                            return remainingPanels[0].preload().then(function () {
                                return weavy.whenTimeout(1500).then(function () {
                                    //preload next after delay
                                    return preloadPanels.call(preloadRoot, true);
                                });
                            });
                        }
                    }

                    weavy.debug("preload done");
                    return Promise.resolve();
                });
            } else {
                return Promise.resolve();
            }

        }


        var startPreload = function () {
            if (weavy.options.preload !== false) {
                weavy.whenTimeout(5000).then(function () { preloadPanels(); })
            }
        };

        weavy.on("load", startPreload);
        weavy.on("clear-user signed-out", function () { closePanels(true) });
        weavy.on("after:clear-user after:signed-out", function () { resetPanels(); });
        weavy.on("user-error", function () { clearPanels(); });
        weavy.on("destroy", function (e, destroy) {
            weavy.off("load", startPreload);
            destroy.whenAllDestroyed.push(clearPanels(true));
        });


        // Exports
        this.clearPanels = clearPanels;
        this.closePanels = closePanels;
        this.createContainer = createContainer;

        /**
         * Get a panels container.
         * 
         * @memberof WeavyPanels#
         * @function
         * @param {string} containerId=global - The id of the panels container
         * @returns {WeavyPanels~container}
         */
        this.getContainer = function (containerId) {
            return _panelsContainers.get(containerId || "global");
        };

        /**
         * Get a panel.
         * 
         * @memberof WeavyPanels#
         * @function
         * @param {string} panelId - The id of the panel
         * @returns {WeavyPanels~panel}
         */
        this.getPanel = function (panelId) {
            return _panels.get(panelId);
        };

        /**
         * Returns an array of all current panels
         * 
         * @memberof WeavyPanels#
         * @function
         * @returns {Array.<WeavyPanels~panel>}
         */
        this.getCurrentPanels = function () {
            return Array.from(_panels.values());
        }

        this.preload = preloadPanels;
        this.resetPanels = resetPanels;

    };

    /**
     * Default panels options
     * 
     * @example
     * WeavyPanels.defaults = {
     *     controls: {
     *         close: true
     *     }
     * };
     *
     * @name defaults
     * @memberof WeavyPanels
     * @type {Object}
     * @property {Object} controls - Set to `false` to disable control buttons
     * @property {boolean} controls.close - Render a close panel control button.
     */
    WeavyPanels.defaults = {
        controls: {
            close: false
        }
    };

    return WeavyPanels;

}));

/* eslint-env commonjs, amd */

// UMD based on https://github.com/umdjs/umd/blob/master/templates/returnExports.js
// TODO: move to ES6 and transpiler

(function (root, factory) {
    if (typeof define === 'function' && define.amd) {
        // AMD. Register as an anonymous module.
        define([
            '../utils',
            '../promise'
        ], factory);
    } else if (typeof module === 'object' && module.exports) {
        // Node. Does not work with strict CommonJS, but
        // only CommonJS-like environments that support module.exports,
        // like Node.
        module.exports = factory(
            require('../utils'),
            require('../promise')
        );
    } else {
        // Browser globals (root is window)
        root.WeavyApp = factory(root.wvy.utils, root.wvy.promise);
    }
}(typeof self !== 'undefined' ? self : this, function (WeavyUtils, WeavyPromise) {
    //console.debug("app.js");

    /**
     * @class WeavyApp
     * @classdesc Base class for representation of apps in Weavy.
     * @example
     * var app = weavy.space(...).app({ key: "myapp1", type: "posts" });
     */

    /**
     * This class is automatically instantiated when defining apps in weavy. 
     * All the methods and properties are accessible in each instance. 
     * The passed options will fetch the app or create it.
     * 
     * @constructor
     * @hideconstructor
     * @param {Weavy} weavy - Weavy instance the app belongs to
     * @param {WeavySpace} space - Weavy Space the app belongs to
     * @param {WeavyApp#options} options - App options
     * @param {Object} [data] - Initial data belonging to the app
     */
    var WeavyApp = function (weavy, space, options, data) {

        weavy.debug("new WeavyApp", options);

        /** 
         * Reference to this instance
         * @lends WeavyApp#
         */
        var app = this;

        /** 
         * The container passed in from {@link WeavyApp#options}.
         * @category properties
         * @type {Element|jQuery|string}
         */
        app.container = null;

        /** 
         * The root object for the container of the app. 
         * @category properties
         * @type {Object}
         * @property {Element} container - The inner container to put nodes in.
         * @property {string} id - The id of the root
         * @property {Element} parent - The element defined in options to contain the app.
         * @property {ShadowRoot} root - The isolated ShadowRoot in the section.
         * @property {Element} section - The &lt;weavy&gt;-section within the parent.
         * @property {Function} remove() - Method for removing the root from the DOM.
         */
        app.root = null;

        /** 
         * The Panel displaying the app.
         * @category properties
         * @type {WeavyPanels~panel}
         */
        app.panel = null;

        /**
         * The url of the app, received from app data.
         * @category properties
         * @type {string}
         */
        app.url = null;

        /**
         * The server id of the app, received from app data.
         * @category properties
         * @type {int}
         */
        app.id = null;

        /**
         * The name of the app, defined in options or received from app data.
         * @category properties
         * @type {string}
         */
        app.name = null;

        /**
         * The key of the app, defined in options or recieved from app data.
         * @category properties
         * @type {string}
         */
        app.key = null;

        /**
         * The guid of the app type. May also be used to define the app type in options.
         * @category properties
         * @type {string}
         */
        app.guid = null;

        /** 
         * The short readable type of the app, such as "files" .
         * @category properties
         * @type {string}
         */
        app.type = null;

        /** 
         * The full type name of the app, such as "Weavy.Core.Models.Files".
         * @category properties
         * @type {string}
         */
        app.typeName = null;

        /** 
         * Will the app open automatically when loaded? Defaults to true. 
         * @see WeavyApp#options
         * @category properties
         * @type {boolean}
         */
        app.autoOpen = null;

        /**
         * The {@link Weavy} instance the app belongs to.
         * @category properties
         * @type {Weavy}
         */
        app.weavy = weavy;

        /**
         * The {@link WeavySpace} the app belongs to.
         * @category properties
         * @type {WeavySpace}
         */
        app.space = space;

        /**
         * Options for defining the app. Key and type is required.
         * 
         * @example
         * space.app({
         *   key: "mykey",
         *   name: "Posts",
         *   type: "posts",
         *   container: "#myappcontainer",
         *   open: false,
         *   controls: true
         * });
         * 
         * @category options
         * @typedef
         * @member
         * @type {Object}
         * @property {int} id - The server id of the app. Usually only used to reference a specific app on the server.
         * @property {string} key - The id representing the app in the context environment.
         * @property {string} name - The display name of the app.
         * @property {boolean} open - Should the app panel open automatically? Looks for the {@link WeavySpace#options} if not defined. Defaults to true unless space.options.tabbed is true
         * @property {Element|jQuery|string} container - The container where the app should be placed.
         * @property {string} type - The kind of app. <br> • posts <br> • files <br> • messenger <br> • search <br> • tasks <br> • notifications <br> • posts <br> • comments
         * @property {boolean} controls - Show or hide the panel controls. Defaults to false unless space.options.controls is true.
         */
        app.options = options;

        /**
         * The server data for the app.
         * 
         * @example
         * {
		 *   id: 2136,
		 *   guid: "523edd88-4bbf-4547-b60f-2859a6d2ddc1",
		 *   key: "files",
		 *   name: "Files",
		 *   url: "/e/apps/2136",
		 *   typeName: "Weavy.Core.Models.Files",
		 *   options: {
		 *     key: "files",
		 *     type: "files"
         *   }
		 * }
         * 
         * @category properties
         * @typedef
         * @member
         * @type {Object}
         * @property {int} id - The server id for the app.
         * @property {string} key - The client key for the app.
         * @property {string} guid - The GUID for the app type.
         * @property {string} name - User readable title for the app.
         * @property {string} url - The base url to the app.
         * @property {string} typeName - The full app type, e.g. "Weavy.Core.Models.Posts"
         * @property {WeavyApp#options} [options] - Any app definition passed to the server. Should match {@link WeavyApp#options}.
         */
        app.data = data;

        // EVENT HANDLERS

        /** 
         * The parent which the events bubbles to.
         * @category eventhandling
         * @type {WeavySpace}
         * @ignore
         */
        app.eventParent = space;

        /**
         * Event listener registration for the specific app. Only recieves events that belong to the app.
         * 
         * @category eventhandling
         * @function
         * @example
         * weavy.space("myspace").app("myapp").on("open", function(e) { ... })
         */
        app.on = weavy.events.on.bind(app);

        /**
         * One time event listener registration for the specific app. Is only triggered once and only recieves events that belong to the app.
         *
         * @category eventhandling
         * @function
         * @example
         * weavy.space("myspace").app("myapp").one("open", function(e) { ... })
         */
        app.one = weavy.events.one.bind(app);

        /**
         * Event listener unregistration for the specific app.
         * 
         * @category eventhandling
         * @function
         * @example
         * weavy.space("myspace").app("myapp").off("open", function(e) { ... })
         */
        app.off = weavy.events.off.bind(app);

        /**
         * Triggers events on the specific app. The events will also bubble up to the space and then the weavy instance.
         *
         * @category eventhandling
         * @function
         * @example
         * weavy.space("myspace").app("myapp").triggerEvent("myevent", [eventData])
         */
        app.triggerEvent = weavy.events.triggerEvent.bind(app);

        /** 
         * Is the app currently open? Returns the open status of the app panel.
         * @category properties
         * @member isOpen
         * @memberof WeavyApp#
         * @type {boolean}
         */
        Object.defineProperty(this, "isOpen", {
            get: function () {
                return app.panel ? app.panel.isOpen : false;
            }
        });

        /**
         * Has the app loaded?
         * @category properties
         * @type {boolean}
         */
        app.isLoaded = false;

        /**
         * Is the app built? 
         * @category properties
         * @type {boolean}
         */
        app.isBuilt = false;

        /**
         * Promise that resolves when the app is loaded.
         * 
         * @category promises
         * @type {WeavyPromise}
         */
        app.whenLoaded = new WeavyPromise();

        /**
         * Promise that resolves when the app is built.
         * 
         * @category promises
         * @type {WeavyPromise}
         */
        app.whenBuilt = new WeavyPromise();

        /**
         * Configure the app with options or data. If the app has data it will also be built. 
         * Currently existing options are extended with new options.
         * Data will resolve {@link WeavyApp#whenLoaded} promise.
         * 
         * @category methods
         * @function
         * @param {WeavyApp#options} options
         * @param {WeavyApp#data} data
         * @resolves {WeavyApp#whenLoaded}
         */
        app.configure = function (options, data) {
            if (options && typeof options === "object") {
                app.options = WeavyUtils.assign(app.options, options, true);
            }

            if (data && typeof data === "object") {
                app.data = data;
            }

            if (app.options && typeof app.options === "object") {
                if (app.autoOpen === null || app.container === null) {
                    app.autoOpen = app.options && app.options.open !== undefined ? app.options.open : (space && space.options && space.options.open !== undefined ? space.options.open : (space && !space.tabbed || false));
                    app.container = app.options.container;
                }

                if (app.id === null && app.options.id) {
                    app.id = app.options.id;
                }

                if (app.key === null && app.options.key) {
                    app.key = app.options.key;
                }

                if (app.name === null && app.options.name) {
                    app.name = app.options.name;
                }

                if (app.type === null && app.options.type) {
                    app.type = app.options.type;
                }
            }

            if (app.data && typeof app.data === "object") {
                app.id = app.data.id;
                app.name = app.data.name;
                app.typeName = app.data.typeName;
                app.guid = app.data.guid;

                app.url = app.data.url;

                // Check if app.data needs to be added in space.data.apps
                if (app.space.data && app.space.data.apps) {
                    var dataApps = WeavyUtils.asArray(app.space.data.apps);

                    var foundAppData = dataApps.filter(function (appData) { return app.match(appData) }).pop();
                    if (!foundAppData) {
                        // Add to space data
                        app.space.data.apps.push(app.data);
                    }
                }

                app.isLoaded = true;
                app.whenLoaded.resolve(app);

                if (!app.isBuilt && app.weavy.isLoaded) {
                    app.build();
                }
            }
        }


        /**
         * Sets options and fetches (or creates) the app on the server. Options will replace existing options.
         * When data is fetched, the {@link WeavyApp#whenLoaded} promise is resolved.
         * 
         * @category methods
         * @function
         * @param {WeavyApp#options} [options] - Optional new app options
         * @returns {WeavyApp#whenLoaded}
         * @resolves {WeavyApp#whenLoaded}
         */
        app.fetchOrCreate = function (options) {

            if (options && typeof options === "object") {
                app.options = options;
            }

            if (app.options && typeof app.options === "object") {

                var initAppUrl = new URL("/client/app", weavy.url);

                var optionsWithSpace = WeavyUtils.assign({ space: space.id || space.key }, app.options);

                weavy.ajax(initAppUrl, optionsWithSpace, "POST").then(function (data) {
                        app.data = data;
                        app.configure.call(app);
                    }).catch(function (error) {
                        app.weavy.error("WeavyApp.fetchOrCreate()", error.message);
                        app.whenLoaded.reject(error);
                    });
            } else {
                app.whenLoaded.reject(new Error("WeavyApp.fetchOrCreate() requires options"));
            }

            return app.whenLoaded();
        }


        /**
         * Converts panel events to app events. Copies all the data from the panel event to the app event. 
         * Set it as an eventhandler to trigger a new event while passing along event data.
         * 
         * @ignore
         * @function
         * @param {string} eventName - The name of the event to trigger.
         * @param {string} panelId - The id of the panel
         * @param {any} triggerData - The additional data to add to the event.
         * @param {Event} e - The panel event.
         * @param {any} data - The data from the panel event.
         */
        function bridgePanelEvent(eventName, panelId, triggerData, e, data) {
            if (data.panelId === panelId) {
                for (var tProp in triggerData) {
                    if (Object.prototype.hasOwnProperty.call(data, tProp)) {
                        triggerData[tProp] = data[tProp];
                    }
                }
                var eventResult = app.triggerEvent(eventName, triggerData);
                if (eventResult === false) {
                    return false;
                } else if (eventResult) {
                    for (var dProp in data) {
                        if (Object.prototype.hasOwnProperty.call(eventResult, dProp)) {
                            data[dProp] = eventResult[dProp];
                        }
                    }
                    return data;
                }
            }
        }

        /**
         * Builds the app. Creates a shadow root and a panel. Is executed on the {@link Weavy#event:build} event.
         * 
         * @category methods
         * @function
         * @resolves {WeavyApp#whenBuilt}
         */
        app.build = function () {
            // TODO: return whenBuilt promise
            weavy.authentication.whenAuthorized().then(function () {
                var root = app.root || app.space && app.space.root;

                if (app.options && app.data) {
                    if (!root && app.container) {
                        try {
                            app.root = root = weavy.createRoot(app.container, "app-" + app.id);
                            root.container.panels = weavy.panels.createContainer("app-container-" + app.id);
                            root.container.panels.eventParent = app;
                            root.container.appendChild(root.container.panels.node);
                        } catch (e) {
                            weavy.warn("could not create app in container", { key: app.key, id: app.id });
                        }
                    }

                    if (!app.isBuilt && root) {
                        app.isBuilt = true;
                        weavy.debug("Building app", app.id);
                        var panelId = "app-" + app.id;
                        var controls = app.options && app.options.controls !== undefined ? app.options.controls : (app.space.options && app.space.options.controls !== undefined ? app.space.options.controls : false);
                        app.panel = root.container.panels.addPanel(panelId, app.url, { controls: controls });

                        /**
                         * Triggered when the app panel is opened.
                         * 
                         * @category events
                         * @event WeavyApp#open
                         * @returns {Object}
                         * @property {WeavySpace} space - The space that the app belongs to
                         * @property {WeavyApp} app - The app that fires the event
                         * @extends WeavyPanel#event:panel-open
                         */
                        weavy.on("panel-open", bridgePanelEvent.bind(app, "open", panelId, { space: app.space, app: app, destination: null }));

                        /**
                         * Triggered when the app panel is toggled. Is always followed by either {@link WeavyApp#event:open} event or {@link WeavyApp#event:close} event.
                         * 
                         * @category events
                         * @event WeavyApp#toggle
                         * @returns {Object}
                         * @property {WeavySpace} space - The space that the app belongs to
                         * @property {WeavyApp} app - The app that fires the event
                         * @extends WeavyPanel#event:panel-toggle
                         */
                        weavy.on("panel-toggle", bridgePanelEvent.bind(app, "toggle", panelId, { space: app.space, app: app, destination: null }));

                        /**
                         * Triggered when the app panel is closed.
                         * 
                         * @category events
                         * @event WeavyApp#close
                         * @returns {Object}
                         * @property {WeavySpace} space - The space that the app belongs to
                         * @property {WeavyApp} app - The app that fires the event
                         * @extends WeavyPanel#event:panel-close
                         */
                        weavy.on("panel-close", bridgePanelEvent.bind(app, "close", panelId, { space: app.space, app: app }));

                        /**
                         * Triggered when the app receives a postMessage sent from the panel frame.
                         * 
                         * @category events
                         * @event WeavyApp#message
                         * @returns {Object}
                         * @property {WeavySpace} space - The space that the app belongs to
                         * @property {WeavyApp} app - The app that fires the event
                         * @extends WeavyPanels#event:message
                         */
                        app.on("before:message", (e, message) => {
                            if (message.panelId === panelId) {
                                return WeavyUtils.assign(message, { space: app.space, app: app });
                            }
                        });

                        app.whenBuilt.resolve(app);
                    }
                }

            })
        };

        weavy.on("build", app.build.bind(app));

        // Opens the app automatically after build
        app.whenBuilt().then(function () {
            weavy.whenReady().then(function () {
                if (app.autoOpen && !app.isOpen) {
                    app.open(null, true);
                }
            });
        });

        weavy.on("after:signed-in", function () {
            weavy.whenReady().then(function () {
                if (app.autoOpen && !app.isOpen) {
                    // Reopen on sign in
                    app.open(null, true);
                }
            });
        });

        app.configure();
    };

    /**
     * Opens the app panel and optionally loads a destination url after waiting for {@link WeavyApp#whenBuilt}.
     * If the space is {@link WeavySpace#tabbed} it also closes the other apps in the space.
     * 
     * @category panel
     * @function WeavyApp#open
     * @param {string} [destination] - Destination url to navigate to on open
     * @returns {external:Promise}
     */
    WeavyApp.prototype.open = function (destination, noHistory) {
        var app = this;
        var weavy = app.weavy;
        var whenBuiltAndLoaded = Promise.all([app.whenBuilt(), weavy.whenLoaded()]);
        return whenBuiltAndLoaded.then(function () {
            var openPromises = [app.panel.open(destination, noHistory)];

            // Sibling apps should be closed if the space is a tabbed space
            if (app.space && app.space.tabbed) {
                Array.from(app.space.apps || []).forEach(function (spaceApp) {
                    if (spaceApp !== app) {
                        openPromises.push(spaceApp.panel.close(true));
                    }
                });
            }

            return Promise.all(openPromises).catch(function (reason) {
                weavy.warn("Could not open app", app.key, reason);
            });
        }, function (reason) {
            weavy.warn("Could not open app", app.key, reason);
        });
    }

    /**
     * Closes the app panel.
     * 
     * @category panel
     * @function WeavyApp#close
     * @returns {external:Promise}
     * */
    WeavyApp.prototype.close = function () {
        var app = this;
        app.autoOpen = false;
        return app.whenBuilt().then(function () {
            return app.panel.close();
        });
    }

    /**
     * Toggles the app panel open or closed. It optionally loads a destination url on toggle open.
     * If the space is {@link WeavySpace#tabbed} it also closes the other apps in the space.
     * 
     * @category panel
     * @function WeavyApp#toggle
     * @param {string} [destination] - Destination url to navigate to on open
     * @returns {external:Promise}
     */
    WeavyApp.prototype.toggle = function (destination) {
        var app = this;
        var weavy = app.weavy;

        return app.whenBuilt().then(function () {
            var togglePromises = [app.panel.toggle(destination)];

            // Sibling apps should be closed if the space is a tabbed space
            if (!app.isOpen && app.space && app.space.tabbed) {
                Array.from(app.space.apps || []).forEach(function (spaceApp) {
                    if (spaceApp !== app) {
                        togglePromises.push(spaceApp.panel.close(true, true));
                    }
                });
            }

            return Promise.all(togglePromises).catch(function (reason) {
                weavy.warn("Could not toggle app", app.key, reason);
            });
        });
    }

    /**
     * Removes the app in the client and the DOM. The app will not be removed on the server and can be added and fetched at any point again.
     * 
     * @category methods
     * @function WeavyApp#remove
     * @returns {external:Promise}
     */
    WeavyApp.prototype.remove = function () {
        var app = this;
        var space = this.space;
        var weavy = this.weavy;

        weavy.debug("Removing app", app.id);

        var whenPanelRemoved = app.panel ? app.panel.remove(null, true) : Promise.resolve();

        var whenRemoved = whenPanelRemoved.then(function () {
            if ('getRoot' in weavy) {
                var appRoot = weavy.getRoot("app-" + app.id);
                if (appRoot) {
                    appRoot.remove();
                }
            }
        });

        space.apps = space.apps.filter(function (a) { return !a.match(app) });

        return whenRemoved;
    }

    /**
     * Sends postMessage to the app panel frame. 
     * Returns a promise that is resolved when the message has been delivered and rejected if the message fails or has timed out.
     * 
     * @category panel
     * @function WeavyApp#postMessage
     * @param {object} message - The Message to send
     * @param {Transferable[]} [transfer] - A sequence of Transferable objects that are transferred with the message.
     * @see {@link https://developer.mozilla.org/en-US/docs/Web/API/Window/postMessage}
     * @returns {external:Promise}
     * */
    WeavyApp.prototype.postMessage = function (message, transfer) {
        var app = this;
        return app.whenBuilt().then(function () {
            return app.panel.postMessage(message, transfer);
        });
    }


    /**
     * Check if another app or an object is matching this app. It checks for a match of the id property or the key property.
     * 
     * @category methods
     * @function WeavyApp#match
     * @param {WeavyApp|Object} options
     * @param {int} [options.id] - Optional id to match.
     * @param {string} [options.key] - Optional key to match.
     * @returns {boolean} 
     */
    WeavyApp.prototype.match = function (options) {
        if (options) {
            if (options.id && this.id) {
                return options.id === this.id
            }

            if (options.key && this.key) {
                return WeavyUtils.eqString(options.key, this.key);
            }
        }

        return false;
    };

    return WeavyApp;
}));


/**
 * @external Promise
 * @see https://developer.mozilla.org/en-US/docs/Web/JavaScript/Guide/Using_promises
 */
;
/* eslint-env commonjs, amd */

// UMD based on https://github.com/umdjs/umd/blob/master/templates/returnExports.js
// TODO: move to ES6 and transpiler

(function (root, factory) {
    if (typeof define === 'function' && define.amd) {
        // AMD. Register as an anonymous module.
        define([
            './app',
            '../utils',
            '../promise'
        ], factory);
    } else if (typeof module === 'object' && module.exports) {
        // Node. Does not work with strict CommonJS, but
        // only CommonJS-like environments that support module.exports,
        // like Node.
        module.exports = factory(
            require('./app'),
            require('../utils'),
            require('../promise')
        );
    } else {
        // Browser globals (root is window)
        root.WeavySpace = factory(
            root.WeavyApp,
            root.wvy.utils,
            root.wvy.promise
        );
    }
}(typeof self !== 'undefined' ? self : this, function (WeavyApp, WeavyUtils, WeavyPromise) {
    //console.debug("space.js");

    /**
     * @class WeavySpace
     * @classdesc Base class for representation of spaces in Weavy.
     * @example
     * var space = weavy.space({ key: "myspace1" });
     */

    /**
     * This class is automatically instantiated when defining spaces in weavy. 
     * All the methods and properties are accessible in each instance. 
     * The passed options will fetch the space or create it. 
     * 
     * @constructor
     * @hideconstructor
     * @param {Weavy} weavy - Weavy instance the space belongs to.
     * @param {WeavySpace#options} options - Options defining the space
     * @param {Object} [data] - Initial data populating the space
     */
    function WeavySpace(weavy, options, data) {
        /** 
         *  Reference to this instance
         *  @lends WeavySpace#
         */
        var space = this;

        /**
         * The server id of the space, received from space data.
         * @category properties
         * @type {int}
         */
        space.id = null;

        /**
         * The name of the space, defined in options or received from space data.
         * @category properties
         * @type {string}
         */
        space.name = null;

        /**
         * The key of the space, defined in options or recieved from space data.
         * @category properties
         * @type {string}
         */
        space.key = null;

        /**
         * The {@link Weavy} instance the space belongs to.
         * @category properties
         * @type {Weavy}
         */
        space.weavy = weavy;

        /**
         * Options for defining the space. Key (or existing id) is required.
         * 
         * @example
         * weavy.space({
         *     key: "myspace",
         *     name: "My space",
         *     description: "A tabbed space for the team",
         *     container: "#space-area",
         *     controls: true,
         *     tabbed: true,
         *     apps: [
         *         { key: "myposts", type: "posts", open:: true },
         *         { key: "myfiles", type: "files" }
         *     ]
         * })
         * 
         * @category options
         * @typedef
         * @member
         * @type {Object}
         * @property {int} [id] - The server id of the space. Usually only used to reference a specific space on the server.
         * @property {string} key - The id representing the space in the context environment.
         * @property {string} [name] - User readable title for the space.
         * @property {string} [description] - Description of the space.
         * @property {Element|jQuery|string} [container] - Container for all apps in the space. May be overridden in individual apps.
         * @property {boolean} controls - Show or hide the panel controls for the apps in the space. May be overridden in individual apps.
         * @property {boolean} tabbed - Makes the apps in the space act as {@link WeavySpace#tabbed}, so that only one is open at the time.
         * @property {Array.<WeavyApp#options>} apps - List of app definitions for the space.
         */
        space.options = options;

        /**
         * The server data for the space.
         * 
         * @example
         * {
		 *   id: 1081,
		 *   key: "test-space",
		 *   name: "Test space",
		 *   tags: ["test"],
		 *   thumb: "/spaces/1081/avatar-{options}.svg?v=f2ae1b0",
		 *   apps: [{
		 *     id: 2150,
		 *     guid: "f667c9ee-b1f1-49e6-b32f-8a363f5cdb96",
	     *     key: "notifications",
		 *     name: "Notifications",
		 *     url: "/e/apps/2150",
		 *     typeName: "Weavy.Areas.Apps.Models.Notifications",
		 *     options: {
		 *       key: "notifications",
		 *       type: "notifications"
		 *     }
		 *   }],
		 *   options: {
		 *     key: "test-space",
		 *     name: "Test space"
		 *   }
         * }
         * 
         * @category properties
         * @typedef
         * @member
         * @type {Object}
         * @property {int} id - The server id for the space.
         * @property {string} key - The client key for the space.
         * @property {string} name - User readable title for the space.
         * @property {Array.<string>} tags - List of tags for the space.
         * @property {string} thumb - Server relative URL to the thumb for the space. \{options\} must be replaced with thumb options.
         * @property {Array.<WeavyApp#data>} apps - List of data for apps in the space.
         * @property {WeavySpace#options} [options] - Any space definition sent to the server. Should match {@link WeavySpace#options}.
         */
        space.data = data;

        /**
         * Array of all the apps defined in the space 
         * @category apps
         * @type {Array.<WeavyApp>}
         */
        space.apps = new Array();

        // EVENT HANDLERS

        /** 
         * The parent which the events bubbles to.
         * @category eventhandling
         * @type {Weavy}
         * @ignore
         */
        space.eventParent = weavy;

        /**
         * Event listener registration for the specific space. Only recieves events that belong to the space or any descendant apps.
         * 
         * @category eventhandling
         * @function
         * @example
         * weavy.space("myspace").on("open", function(e) { ... })
         */
        space.on = weavy.events.on.bind(space);

        /**
         * One time event listener registration for the specific space. Is only triggered once and only recieves events that belong to the space or any descendant apps.
         *
         * @category eventhandling
         * @function
         * @example
         * weavy.space("myspace").one("open", function(e) { ... })
         */
        space.one = weavy.events.one.bind(space);

        /**
         * Event listener unregistration for the specific space.
         * 
         * @category eventhandling
         * @function
         * @example
         * weavy.space("myspace").off("open", function(e) { ... })
         */
        space.off = weavy.events.off.bind(space);

        /**
         * Triggers events on the specific app. The events will also bubble up to the space and then the weavy instance.
         *
         * @category eventhandling
         * @function
         * @example
         * weavy.space("myspace").triggerEvent("myevent", [eventData])
         */
        space.triggerEvent = weavy.events.triggerEvent.bind(space);

        /**
         * Is the space currently loading?
         * @category properties
         * @type {boolean}
         */
        space.isLoading = false;

        /**
         * Has the space loaded?
         * @category properties
         * @type {boolean}
         */
        space.isLoaded = false;

        /**
         * Is the space built? 
         * @category properties
         * @type {boolean}
         */
        space.isBuilt = false;

        /**
         * Promise that resolves when the space is loaded.
         * 
         * @category promises
         * @type {WeavyPromise}
         */
        space.whenLoaded = new WeavyPromise();

        /**
         * Promise that resolves when the space is built.
         * 
         * @category promises
         * @type {WeavyPromise}
         */
        space.whenBuilt = new WeavyPromise();

        // Use tabbed option otherwise false.
        /**
         * Is the space tabbed? Defined in {@link WeavySpace#options}. If true only one app will be open at the time in the space.
         * 
         * Defaults to false.
         * 
         * @category properties
         * @type {boolean}
         */
        space.tabbed = options.tabbed !== undefined ? options.tabbed : false;

        /**
         * Configure the space with options or data. If the space has data it will also be built. 
         * Currently existing options are extended with new options.
         * Data will resolve {@link WeavySpace#whenLoaded} promise.
         * 
         * @category methods
         * @function
         * @param {WeavySpace#options} options
         * @param {WeavySpace#data} data
         * @resolves {WeavySpace#whenLoaded}
         */
        space.configure = function (options, data) {

            if (options && typeof options === "object") {
                space.options = WeavyUtils.assign(space.options, options, true);
            }

            if (data && typeof data === "object") {
                space.data = data;
            }

            if (space.options && typeof space.options === "object") {
                space.container = space.options.container;

                if (space.id === null && space.options.id) {
                    space.id = space.options.id;
                }

                if (space.key === null && space.options.key) {
                    space.key = space.options.key;
                }

                if (space.name === null && space.options.name) {
                    space.name = space.options.name;
                }

                if (space.options.apps) {
                    var optionsApps = WeavyUtils.asArray(space.options.apps);

                    optionsApps.forEach(function (appOptions) {
                        var foundApps = space.apps.filter(function (app) { return app.match(appOptions); });
                        if (foundApps.length === 0) {
                            space.apps.push(new WeavyApp(weavy, space, appOptions));
                        }
                    });
                }


            }

            if (space.data && typeof space.data === "object") {
                space.id = space.data.id;
                space.name = space.data.name;

                if (!space.key && space.data.key) {
                    space.key = space.data.key;
                }

                if (space.data.apps) {
                    var dataApps = WeavyUtils.asArray(space.data.apps);

                    space.apps.forEach(function (app) {
                        var foundAppData = dataApps.filter(function (appData) { return app.match(appData) }).pop();
                        if (foundAppData) {
                            weavy.debug("Populating app data", { id: foundAppData.id, key: foundAppData.key || app.key, type: foundAppData.type || app.type });
                            app.data = foundAppData;
                            app.configure();
                        }
                    })
                }

                space.isLoading = false;
                space.isLoaded = true;
                space.whenLoaded.resolve(space);

                if (space.weavy.isLoaded) {
                    space.build();
                }

            }
        }

        /**
         * Sets options and fetches (or creates) the space on the server. Options will replace existing options.
         * When data is fetched, the {@link WeavySpace#whenLoaded} promise is resolved.
         * 
         * @category methods
         * @function
         * @param {WeavySpace#options} [options] - Optional new space options
         * @returns {WeavySpace#whenLoaded}
         * @resolves {WeavySpace#whenLoaded}
         */
        space.fetchOrCreate = function (options) {
            var waitFor = [];

            if (options && typeof options === "object") {
                space.options = options;
            }

            if (space.isLoading) {
                waitFor.push(space.whenLoaded);
            }

            return Promise.all(waitFor).then(() => {
                if (space.options && typeof space.options === "object") {
                    space.isLoading = true;

                    var initSpaceUrl = new URL("/client/space", weavy.url).href;

                    weavy.ajax(initSpaceUrl, space.options, "POST").then(function (data) {
                        space.data = data;
                        space.configure.call(space);
                    }).catch(function (error) {
                        space.weavy.error("WeavySpace.fetchOrCreate()", error);
                        space.whenLoaded.reject(error);
                    });
                } else {
                    space.whenLoaded.reject(new Error("WeavySpace.fetchOrCreate() requires options"));
                }
                return space.whenLoaded();
            });
        }

        /**
         * Builds the space. Creates a shadow root if needed. Is executed on the {@link Weavy#event:build} event.
         * 
         * @category methods
         * @function
         * @resolves {WeavySpace#whenBuilt}
         */
        space.build = function (e, build) {
            // TODO: return whenBuilt promise
            var space = this;
            var weavy = this.weavy;
            if (weavy.authentication.isAuthorized() && space.data && typeof space.data === "object") {
                weavy.debug("Building space", space.id);

                if (!space.root && space.container) {
                    space.isBuilt = true;
                    space.root = weavy.createRoot(space.container, "space-" + space.id);
                    space.root.container.panels = weavy.panels.createContainer();
                    space.root.container.appendChild(space.root.container.panels.node);
                    space.whenBuilt.resolve(space);
                }
            }
        }

        space.weavy.on("build", space.build.bind(space));

        space.configure();
    }

    /**
     * Function for making an id/key/object in to an app definition object
     * 
     * @category apps
     * @ignore
     * @function WeavySpace~getAppSelector
     * @param {int|string|WeavyApp#options} options - The id/key/object to parse
     * @returns {Object} appSelector
     * @returns {boolean} appSelector.isId - Is appOptions parsed as id (int)?
     * @returns {boolean} appSelector.isKey - Is appOptions parsed as a key (string)?
     * @returns {boolean} appSelector.isConfig - Is AppOptions parsed as an app definition (Object)?
     * @returns {Object} appSelector.selector - App definition object
     */
    function getAppSelector(options) {
        var isId = Number.isInteger(options);
        var isKey = typeof options === "string";
        var isConfig = WeavyUtils.isPlainObject(options);

        var selector = isConfig && options || isId && { id: options } || isKey && { key: options };

        if (!selector) {
            if ('id' in options) {
                selector = { id: options.id };
            } else if ('key' in options) {
                selector = { key: options.key };
            }
        }

        return { isId: isId, isKey: isKey, isConfig: isConfig, selector: selector };
    }

    /**
     * Selects, fetches or creates an app in the space. 
     * 
     * The app needs to be defined using an app definition object containing at least a key, which will fetch or create the app on the server. 
     * If the defined app already has been defined, the app will only be selected in the client. 
     * After the app is defined it can be quickly selected in the client using only the id (int) or the key (string) of the app, which never will create nor fetch the app from the server.
     * 
     * @example
     * // Define an app that will be fetched or created on the server
     * var app = space.app({ key: "mykey", type: "files", container: "#mycontainer" });
     * 
     * // Select the newly defined app
     * var appAgain = space.app("mykey");
     * 
     * @category apps
     * @function WeavySpace#app
     * @param {int|string|WeavyApp#options} options - app id, app key or app definition object.
     * @returns {WeavyApp}
     */
    WeavySpace.prototype.app = function (options) {
        var space = this;
        var weavy = this.weavy;
        var app;

        var appSelector = getAppSelector(options);

        if (appSelector.selector) {
            try {
                app = space.apps.filter(function (a) { return a.match(appSelector.selector) }).pop();
            } catch (e) { }

            if (!app) {
                if (appSelector.isConfig) {
                    app = new WeavyApp(weavy, space, options);
                    space.apps.push(app);
                    Promise.all([weavy.authentication.whenAuthorized(), weavy.whenInitialized(), space.whenLoaded()]).then(function () {
                        app.fetchOrCreate();
                    }).catch(function (reason) {
                        weavy.warn("Could not fetchOrCreate space", reason || "");
                    });
                } else {
                    weavy.warn("App " + JSON.stringify(appSelector.selector) + " does not exist." + (appSelector.isId ? "" : " \n Use weavy.space(" + (space.key && "\"" + space.key + "\"" || space.id || "...") + ").app(" + JSON.stringify(appSelector.selector) + ") to create the app."))
                }
            }
        }

        return app;
    }

    /**
     * Removes the space and all it's apps from the client and the DOM. The space will not be removed on the server and can be added and fetched at any point again.
     * 
     * @category methods
     * @function WeavySpace#remove
     * @returns {external:Promise}
     */

    WeavySpace.prototype.remove = function () {
        var space = this;
        var weavy = this.weavy;

        weavy.debug("Removing space", space.id);

        var whenAllRemoved = [];

        this.apps.forEach(function (app) {
            whenAllRemoved.push(app.remove());
        })

        weavy.spaces = weavy.spaces.filter(function (s) { return !s.match(space) });

        return Promise.all(whenAllRemoved).then(function () {
            var spaceRoot = weavy.getRoot("space-" + space.id);
            if (spaceRoot) {
                spaceRoot.remove();
            }
        }, function (reason) {
            weavy.warn("Could not remove apps in space " + space.id + ".", reason);
        });
    }

    /**
     * Check if another space or an object is matching this space. It checks for a match of the id property or the key property.
     * 
     * @category methods
     * @function WeavySpace#match
     * @param {WeavySpace|Object} options
     * @param {int} [options.id] - Optional id to match.
     * @param {string} [options.key] - Optional key to match.
     * @returns {boolean}
     */
    WeavySpace.prototype.match = function (options) {
        if (options) {
            if (options.id && this.id) {
                return options.id === this.id
            }

            if (options.key && this.key) {
                return WeavyUtils.eqString(options.key, this.key);
            }
        }

        return false;
    };

    return WeavySpace;
}));


/**
 * @external Promise
 * @see https://developer.mozilla.org/en-US/docs/Web/JavaScript/Guide/Using_promises
 */

;
/* eslint-env commonjs, amd */

// UMD based on https://github.com/umdjs/umd/blob/master/templates/returnExports.js
// TODO: move to ES6 and transpiler

(function (root, factory) {
    if (typeof define === 'function' && define.amd) {
        // AMD. Register as an anonymous module.
        define([
            '../promise',
            '../utils'
        ], factory);
    } else if (typeof module === 'object' && module.exports) {
        // Node. Does not work with strict CommonJS, but
        // only CommonJS-like environments that support module.exports,
        // like Node.
        module.exports = factory(
            require('../promise'),
            require('../utils')
        );
    } else {
        // Browser globals (root is window)
        root.WeavyNavigation = factory(root.wvy.promise, root.wvy.utils, root.wvy);
    }
}(typeof self !== 'undefined' ? self : this, function (WeavyPromise, WeavyUtils, wvy) {
    //console.debug("navigation.js");

    /**
     * @class WeavyNavigation
     * @classdesc Class for handling internal/external navigation
     */

    /**
     * Class for handling internal/external navigation.
     * 
     * @constructor
     * @hideconstructor
     * @param {Weavy} weavy - Weavy instance
     */
    var WeavyNavigation = function (weavy) {
        /**
         *  Reference to this instance
         *  @lends WeavyNavigation#
         */
        var weavyNavigation = this;

        /**
         * Tries to open a navigation request.
         * 
         * @param {WeavyNavigation~navigationRequest} request - The navigation request object to open
         * @returns {external:Promise}
         * @resolved When the request successfully is opened
         * @rejected When the request can't be opened
         */
        function openRequest(request) {
            var whenOpened = new WeavyPromise();

            if (request.target === "overlay" && weavy.plugins.preview) {
                weavy.log("navigation: opening preview " + request.url);
                weavy.plugins.preview.open(request.url).then(function (open) {
                    whenOpened.resolve(open);
                });
            } else {

                if (request.space && request.app && (request.space.id || request.space.key) && (request.app.id || request.app.key)) {

                    weavy.whenLoaded().then(function () {
                        var openSpace = weavy.space(request.space.id || request.space.key);

                        var openApp;
                        if (openSpace) {
                            openApp = openSpace.app(request.app.id || request.app.key);
                        }

                        if (openApp) {
                            if (weavy.plugins.preview) {
                                weavy.plugins.preview.closeAll(true);
                            }

                            openApp.open(request.url).then(function (open) {
                                whenOpened.resolve(open);
                            });
                        } else {
                            weavy.info("navigation: requested app was not found");
                            whenOpened.reject();
                        }
                    });
                } else {
                    weavy.warn("navigation: url was not resolved to an app");
                    whenOpened.reject();
                }
            }

            return whenOpened();
        }

        /**
         * Try to open an url in the app where it belongs. 
         * Automatically finds out where to open the url via a server call unless routing data is directly provided in a {@link WeavyNavigation~navigationRequest} object.
         * 
         * @param {string|WeavyNavigation~navigationRequest} request - String Url or a {@link WeavyNavigation~navigationRequest} object with route data.
         * @returns {external:Promise}
         * @resolved When the request successfully is opened
         * @rejected When the request can't be opened
         */
        weavyNavigation.open = function (request) {
            var isUrl = typeof request === "string";
            var isNavigationRequest = WeavyUtils.isPlainObject(request) && request.url;

            if (isUrl) {
                return weavy.ajax("/client/click?url=" + encodeURIComponent(request)).then(openRequest);
            } else if (isNavigationRequest) {
                return openRequest(request);
            }
            return WeavyPromise.reject();
        };


        weavy.on(wvy.postal, "navigation-open", weavy.getId(), function (e) {
            /**
             * Navigation event triggered when a page should be opened in another space or app.
             * 
             * @category events
             * @event WeavyNavigation#navigate
             * @property {WeavyNavigation~navigationRequest} route - Data about the requested navigation
             * 
             */
            var route = weavy.triggerEvent("before:navigate", e.data.route);
            if (route !== false) {
                weavy.info("navigate: trying internal auto navigation");
                weavyNavigation.open(route).catch(function () {
                    // Only trigger on: and after: if .open was unsuccessful
                    route = weavy.triggerEvent("on:navigate", route);
                    if (route !== false) {
                        weavy.triggerEvent("after:navigate", route);
                    }
                });
            }
        })


    };

    return WeavyNavigation;
}));

/**
 * The data for a navigation request. Some of the data is provided from the server just as meta data. It's received through the {@link WeavyNavigation#event:navigate} event and can be passed into the {@link WeavyNavigation#open} method.
 * 
 * @example
 * var navigationRoute = {
 *   "entity": {
 *     "id": 203,
 *     "type": "content"
 *   },
 *   "app": {
 *     "id": 2149,
 *     "key": "files",
 *     "name": "Files"
 *   },
 *   "space": {
 *     "id": 1077,
 *     "key": "client-test-demo",
 *     "name": "Demo Space"
 *   },
 *   "target": "overlay",
 *   "url": "/e/content/203"
 * };
 * 
 * @typedef WeavyNavigation~navigationRequest
 * @type Object
 * @property {Object} space
 * @property {int} space.id - The server generated id for the space
 * @property {string} space.key - The key identifier the space
 * @property {string} [space.name] - The name of the space
 * @property {Object} app
 * @property {int} app.id - The server generated id for the app
 * @property {string} app.key - The key identifier for the app
 * @property {string} [app.name] - The name of the app
 * @property {Object} entity
 * @property {int} entity.id - The server generated id for the item 
 * @property {string} [entity.type] - The type of the item
 * @property {string} url - The url to open
 * @property {string} target - Recommended target to open the url in, for instance "overlay", which may oven the preview overlay.
 */ 


/**
 * @external Promise
 * @see https://developer.mozilla.org/en-US/docs/Web/JavaScript/Guide/Using_promises
 */
;
/* eslint-env commonjs, amd */

// UMD based on https://github.com/umdjs/umd/blob/master/templates/returnExports.js
// TODO: move to ES6 and transpiler

(function (root, factory) {
    if (typeof define === 'function' && define.amd) {
        // AMD. Register as an anonymous module.
        define([
            '../promise',
            '../utils'
        ], factory);
    } else if (typeof module === 'object' && module.exports) {
        // Node. Does not work with strict CommonJS, but
        // only CommonJS-like environments that support module.exports,
        // like Node.
        module.exports = factory(
            require('../promise'),
            require('../utils')
        );
    } else {
        // Browser globals (root is window)
        root.WeavyHistory = factory(root.wvy.promise, root.wvy.utils);
    }
}(typeof self !== 'undefined' ? self : this, function (WeavyPromise, WeavyUtils) {
    //console.debug("history.js");

    /**
     * @class WeavyHistory
     * @classdesc Class for handling history states
     */

    /**
     * Class for handling history states.
     * 
     * @constructor
     * @hideconstructor
     * @param {Weavy} weavy - Weavy instance
     */
    var WeavyHistory = function (weavy) {
        /**
         *  Reference to this instance
         *  @lends WeavyHistory#
         */
        var weavyHistory = this;

        /**
         * Try to open a weavy uri in the app where it belongs. 
         * 
         * @param {WeavyHistory~weavyUri} uri - String weavy Uri to open in a panel.
         * @returns {external:Promise}
         * @resolved When the uri successfully is opened
         * @rejected When the uri can't be opened
         */
        weavyHistory.openUri = function (uri) {
            var weavyUriState = weavyHistory.getStateFromUri(uri);

            if (weavyUriState && weavyUriState.panels.length) {
                return weavyHistory.openState(weavyUriState);
            }

            return WeavyPromise.reject();
        };

        /**
         * Get a weavy state from one or more {@link WeavyHistory~weavyUri} uris.
         * 
         * @example
         * var weavyState = weavy.history.getStateFromUri("wvy://app-123@wvy-id/e/apps/123");
         * 
         * @example
         * var weavyUris = [
         *   "wvy://app-123@wvy-id/e/apps/123",
         *   "wvy://app-456/e/apps/456"
         * ];
         * 
         * var weavyState = weavy.history.getStateFromUri(weavyUris);
         * 
         * @param {Array.<WeavyHistory~weavyUri>} weavyUris
         * @returns {WeavyHistory~weavyState}
         */
        weavyHistory.getStateFromUri = function(weavyUris) {
            weavyUris = WeavyUtils.asArray(weavyUris);
            var panels = [];
            weavyUris.forEach(function (uri) {
                var isUrl = typeof uri === "string";
                if (isUrl && uri.indexOf("wvy://") === 0) {
                    var weavyUri = /^wvy:\/\/([^@/]*)@?([^/]*)(.*)$/.exec(uri);
                    if (weavyUri && weavyUri.length) {
                        var panelId = weavyUri[1];
                        var weavyId = weavyUri[2];
                        var id = "panel-" + panelId + "__" + (weavyId || weavy.getId());
                        var panelPath = weavyUri[3];
                        weavy.debug("history: parsed wvy url", weavyId, panelId);
                        panels.push({
                            id: id,
                            panelId: panelId,
                            isOpen: true,
                            location: panelPath,
                            statusCode: 200,
                            weavyId: weavyId,
                            weavyUri: uri,
                            changedAt: Date.now()
                        });

                    }
                }
            });

            return { panels: panels };
        }

        /**
         * Gets the panel state from a specified panel. May also be accessed via {@WeavyPanels~panel#getState}
         * 
         * @param {string} panelId - The id of the panel
         * @returns {WeavyHistory~panelState}
         */
        weavyHistory.getStateFromPanel = function (panelId) {
            var panel = weavy.panels.getPanel(panelId);

            if (!panel) {
                weavy.warn("history: getStateFromPanel; Panel not found " + panelId);
                return;
            }

            var weavyId = weavy.options.id && weavy.getId();
            var weavyUriId = (weavy.options.id ? weavy.getId(panelId).replace("__", "@") : panelId);

            var relUrl = panel.location && new URL(panel.location, weavy.url).pathname;
            var weavyUri = "wvy://" + weavyUriId + (relUrl || "")

            return {
                id: panel.node.id,
                panelId: panelId,
                isOpen: panel.isOpen,
                location: panel.location,
                statusCode: panel.statusCode,
                weavyId: weavyId,
                weavyUri: weavyUri,
                changedAt: panel.stateChangedAt
            };
        }


        /**
         * Gets the current state of the weavy instance, including all panel states.
         * 
         * @returns {WeavyHistory~weavyState}
         */
        weavyHistory.getCurrentState = function () {
            var panelStates = weavy.panels.getCurrentPanels().map(function (panel) {
                return panel.getState();
            }).sort(function (a, b) {
                var sortByOpen = a.isOpen - b.isOpen;
                var sortByTime = (a.changedAt || 0) - (b.changedAt || 0)
                return sortByOpen || sortByTime;
            });

            var state = {
                panels: panelStates,
            };

            return state;
        }

        function extendPanelStates(panels, additionalPanels) {
            if (additionalPanels) {
                additionalPanels.forEach(function (addPanelState) {
                    var found = false;
                    panels = panels.map(function (panelState) {
                        var weavyMatch = !panelState.weavyId && !addPanelState.weavyId || panelState.weavyId === addPanelState.weavyId;
                        var panelMatch = panelState.panelId === addPanelState.panelId;
                        if (weavyMatch && panelMatch) {
                            found = true;
                            return addPanelState;
                        } else {
                            return panelState;
                        }
                    })
                    if (!found) {
                        panels.push(addPanelState);
                    }
                })

                panels.sort(function (a, b) {
                    var sortByOpen = a.isOpen - b.isOpen;
                    var sortByTime = (a.changedAt || 0) - (b.changedAt || 0)
                    return sortByOpen || sortByTime;
                });
            }
            return panels;
        }

        /**
         * Gets the global state for all weavy instances combined, stored in the browser history state.
         * The state has the same structure as a single weavy instance state.
         * 
         * @returns {WeavyHistory~weavyState}
         */
        weavyHistory.getBrowserState = function () {
            return window.history.state && window.history.state.weavy;
        }


        /**
         * Saves a weavy state to the browser history by either push or replace. 
         * Any existing state will be preserved and existing states from other weavy instances will be merged.
         * 
         * @param {WeavyHistory~weavyState} state - The state to add to any existing state
         * @param {string} [action] - If set to "replace", the current history state will be updated.
         * @param {any} [url] - Any new url to use for the state. If omitted, the current location will be reused.
         */
        weavyHistory.setBrowserState = function(state, action, url) {
            if (state) {
                weavy.debug("history: " + (action || "setting") + " browser state");

                // Always modify any existing state
                var currentHistoryState = window.history.state || {};
                currentHistoryState.weavy = currentHistoryState.weavy || {};

                currentHistoryState.weavy.panels = extendPanelStates(currentHistoryState.weavy.panels || [], state.panels);

                url = url && String(url) || window.location.href;

                try {
                    if (action === "replace") {
                        window.history.replaceState(currentHistoryState, null, url);
                    } else {
                        window.history.pushState(currentHistoryState, null, url);
                    }
                } catch (e) {
                    weavy.warn("history: Could not push history state.", e);
                }
            }
        }

        /**
         * Adds a state to the browser history, by either push or replace. 
         * This is usually used automatically by internal components.
         * 
         * @emits {WeavyHistory#history}
         * @param {string} [action] - "push" or "replace". Indicates if the state should generate a new history point or replace the existing.
         * @param {WeavyHistory~weavyState} [state] - The state to add. Defaults to the current state of the weavy instance.
         * @returns {WeavyHistory~weavyState}
         */
        weavyHistory.addState = function (action, state) {
            state = state || weavyHistory.getCurrentState()

            // Always modify any existing state
            var currentHistoryState = window.history.state || {};
            var globalState = currentHistoryState.weavy = currentHistoryState.weavy || {};

            var history = {
                state: state,
                action: action || "push", // push, replace
                url: window.location.href,
                globalState: globalState
            };

            /**
             * Triggered when a weavy state is added or updated. 
             * The global weavy state will be stored in `window.history.state.weavy` unless default is prevented.
             * 
             * This is where you can modify the url or the state just before it will be pushed or replaced.
             * If you call event.preventDefault() you need do save the state to the browser history by yourself.
             * 
             * @example
             * // Modify the history URL to include the last opened panel as a hash and return the data
             * weavy.on("history", function (e, history) {
             *     // Get only panels that has been interactively opened/closed (changedAt) and is currently open.
             *     var allOpenPanels = history.globalState.panels.filter(function (panelState) {
             *         return panelState.changedAt && panelState.isOpen;
             *     });
             *     var lastOpenPanel = allOpenPanels.pop();
             * 
             *     // Set the url
             *     if(lastOpenPanel) {
             *         // Set the hash to the last opened panel
             *         history.url = "#" + lastOpenPanel.weavyUri;
             *     } else {
             *         // Remove the hash if no changed panel is open
             *         history.url = history.url.split("#")[0];
             *     }
             * 
             *     // Return the modified data to apply it
             *     return history;
             * });
             * 
             * @category events
             * @event WeavyHistory#history
             * @returns {Object}
             * @property {WeavyHistory~weavyState} state - The state of the weavy instance
             * @property {string} action - Indicates what the intention of the history state is "push" or "replace" 
             * @property {string} url - The url to set in the browser history.
             * @property {WeavyHistory~weavyState} globalState - The current combined global state for all weavy instances.
             */

            history = weavy.triggerEvent("before:history", history);

            if (history !== false) {

                // Combine global panel list
                history.globalState.panels = extendPanelStates(history.globalState.panels || [], history.state.panels);

                history = weavy.triggerEvent("on:history", history);

                if (history !== false) {
                    weavy.debug("history: " + history.action + " history state");
                    weavyHistory.setBrowserState(history.state, history.action, history.url)
                    weavy.triggerEvent("after:history", history);
                }
            }

            return history.state;
        }

        /**
         * Restores all the matching panels in a weavy state. 
         * It will open or close the panels and restore their location.
         * It will not genrate any new history.
         * 
         * @param {WeavyHistory~weavyState} state - The state to restore
         * @returns {external:Promise}
         */
        weavyHistory.openState = function (state) {
            if (state) {
                if (state.panels) {
                    if (state.panels && Array.isArray(state.panels)) {
                        return weavy.whenLoaded().then(function () {
                            weavy.debug("history: opening state");
                            return Promise.all(state.panels.map(function (panelState) {
                                if (!panelState.weavyId && !weavy.options.id || panelState.weavyId === weavy.getId()) {
                                    var panel = weavy.panels.getPanel(panelState.panelId);
                                    if (panel) {
                                        weavy.debug("history: setting panel state", panelState.panelId)
                                        return panel.setState(panelState);
                                    }
                                    return WeavyPromise.resolve();
                                }
                            }));
                        })
                    }
                }
            }
            return WeavyPromise.reject("Error opening state");
        }

        function setCurrentHistoryState() {
            weavy.debug("history: set current state");
            var state = weavyHistory.getCurrentState();
            weavyHistory.setBrowserState(state, "replace");
        }

        weavy.on(window, "popstate", function (e) {
            var state = weavyHistory.getBrowserState();
            if (state) {
                weavy.log("history: popstate");
                weavyHistory.openState(state);
            }
        });

        weavy.whenLoaded().then(function () {
            var state = weavyHistory.getBrowserState();
            if (state) {
                weavy.debug("history: load state");
                weavyHistory.openState(state)
            }

            weavy.whenReady().then(weavy.whenTimeout(1)).then(setCurrentHistoryState);

        });
    };

    return WeavyHistory;
}));

/**
 * The data for a panel state. Indicates which location the panel has and if it's open.
 * The `changedAt` property is not set at the initial state load, only when the state changes.
 * May be applied to a panel using {@link WeavyPanels~panel#setState}.
 * 
 * @example
 * var panelState = {
 *   id: "panel-app-123__wy-41d751e8",
 *   panelId: "app-123",
 *   isOpen: true,
 *   location: "/e/apps/123,
 *   statusCode: 200,
 *   weavyId: "wy-41d751e8",
 *   weavyUri: "wvy://app-123@wy-41d751e8/e/apps/123",
 *   changedAt: 1614596627434
 * }
 * 
 * @typedef WeavyHistory~panelState
 * @type Object
 * @property {string} id - The DOM id of the panel.
 * @property {string} panelId - The internal id of the panel.
 * @property {boolean} isOpen - Indicates whether the panel is open or not.
 * @property {string} location - The relative current location for the panel.
 * @property {int} statusCode - The http code of the location of the panel.
 * @property {string} weavyId - The explicitly set weavy id. Null if id is not set in options.
 * @property {WeavyHistory~weavyUri} - The Weavy Uri for the panel
 * @property {int} changedAt - Timestamp if the state of the panel was changed since weavy loaded.
 */

/**
 * An Uri for a location in a specific panel. May be opened using {@link WeavyHistory#openUri}.
 * 
 * @example
 * "wvy://app-123@wvy-id/e/apps/123"
 * 
 * @typedef WeavyHistory~weavyUri
 * @type String
 */

/**
 * The combined state of all panels in the weavy instance.
 * 
 * @example
 * var weavyState = {
 *   panels: [
 *      panel1State,
 *      panel2State,
 *      ...
 *   ]
 * }
 * 
 * @typedef WeavyHistory~weavyState
 * @type Object
 * @property {Array.<WeavyHistory~panelState>} panels
 */

/**
 * @external Promise
 * @see https://developer.mozilla.org/en-US/docs/Web/JavaScript/Guide/Using_promises
 */
;
/* eslint-env commonjs, amd */

// UMD based on https://github.com/umdjs/umd/blob/master/templates/returnExports.js
// TODO: move to ES6 and transpiler

(function (root, factory) {
    if (typeof define === 'function' && define.amd) {
        // AMD. Register as an anonymous module.
        define([
            './events',
            './panels',
            './space',
            './navigation',
            './history',
            '../utils',
            '../console',
            '../promise'
        ], factory);
    } else if (typeof module === 'object' && module.exports) {
        // Node. Does not work with strict CommonJS, but
        // only CommonJS-like environments that support module.exports,
        // like Node.
        module.exports = factory(
            require('./events'),
            require('./panels'),
            require('./space'),
            require('./navigation'),
            require('./history'),
            require('../utils'),
            require('../console'),
            require('../promise')
        );
    } else {
        // Browser globals (root is window)
        window.Weavy = root.Weavy = factory(
            root.WeavyEvents,
            root.WeavyPanels,
            root.WeavySpace,
            root.WeavyNavigation,
            root.WeavyHistory,
            root.wvy.utils,
            root.wvy.console,
            root.wvy.promise,
            root.wvy.connection,
            root.wvy.authentication,
            root.wvy.postal
        );
    }
}(typeof self !== 'undefined' ? self : this, function (WeavyEvents, WeavyPanels, WeavySpace, WeavyNavigation, WeavyHistory, WeavyUtils, WeavyConsole, WeavyPromise, WeavyConnections, WeavyAuthentications, WeavyPostal) {
    //console.info("weavy.js");

    // DEFINE CUSTOM ELEMENTS AND STYLES

    /**
     * Three custom elements are used <weavy>, <weavy-root> and <weavy-container>
     * <weavy> can't be defined and acts only as a DOM placeholder.
     **/
    if ('customElements' in window) {
        try {
            window.customElements.define('weavy-root', HTMLElement.prototype);
            window.customElements.define('weavy-container', HTMLElement.prototype);
        } catch(e) { }
    } 

    // <weavy> and <weavy-root> should have no layout of their own.
    var weavyElementCSS = 'weavy, weavy-root { display: contents; }';

    // <weavy> and <weavy-root> gets layout only if needed 
    if (!('CSS' in window && CSS.supports('display', 'contents'))) {
        weavyElementCSS = 'weavy, weavy-root { display: flex; position: absolute; top: 0; left: 0; right: 0; bottom: 0; pointer-events: none; }';
    }

    // Prefer modern CSS registration
    if (document.adoptedStyleSheets) {
        var sheet = new CSSStyleSheet();
        sheet.replaceSync(weavyElementCSS);
        document.adoptedStyleSheets = Array.prototype.concat.call(document.adoptedStyleSheets, [sheet]);
    } else {
        // Fallback CSS registration
        var elementStyleSheet = document.createElement("style");
        elementStyleSheet.type = "text/css";
        elementStyleSheet.styleSheet ? elementStyleSheet.styleSheet.cssText = weavyElementCSS : elementStyleSheet.appendChild(document.createTextNode(weavyElementCSS));

        document.getElementsByTagName("head")[0].appendChild(elementStyleSheet);
    }

    // WEAVY

    var _weavyIds = [];

    /**
     * All options are optional. You may use multiple Weavy.presets together with options when constructing a weavy instance. Multiple option sets are merged together.
     * 
     * If you want to connect to a specific server use the [url option]{@link Weavy#options}.
     * 
     * These option presets are available for easy configuration
     * * Weavy.presets.noplugins - Disable all plugins
     * * Weavy.presets.core - Use the minimal core plugin configuration without additional plugins.
     * 
     * @example
     * var weavy = new Weavy();
     * 
     * var devSettings = {
     *     logging: true
     * };
     * 
     * var coreDevWeavy = new Weavy(Weavy.presets.core, devSettings, { url: "http://myweavysite.dev" });
     * 
     * @class Weavy
     * @classdesc The core class for the Weavy client.
     * @param {...Weavy#options} options - One or multiple option sets. Options will be merged together in order.
     */

    var Weavy = function () {
        /** 
         * Reference to this instance
         * @lends Weavy#
         */
        var weavy = this;

        /**
         * Main options for Weavy. The JWT option is required.
         * When weavy initializes, it connects to the server and processes the options as well as using them internally. 
         * 
         * @see [Client Options]{@link https://docs.weavy.com/client/development/options}
         * @typedef 
         * @type {Object}
         * @member
         * @property {boolean} [connect=true] - Enable automatic realtime connect after init. When `false` connection can be started using `weavy.connection.connect()`.
         * @property {Element} [container] - Container where weavy should be placed. If no Element is provided, a &lt;weavy&gt; root is created next to the &lt;body&gt;-element.
         * @property {string} [className] - Additional classNames added to weavy.
         * @property {string} [https=adaptive] - How to enforce https-links. <br> • **force** -  makes urls https.<br> • **adaptive** - enforces https if the calling site uses https.<br> • **default** - makes no change.
         * @property {string} [id] - An id for the instance. A unique id is always generated.
         * @property {string} jwt - The JWT token passed to {@link WeavyAuthentication}.
         * @property {boolean} [init=true] - Should weavy initialize automatically?
         * @property {boolean} [includePlugins=true] - Whether all registered plugins should be enabled by default. If false, then each plugin needs to be enabled in plugin-options.
         * @property {string} [lang] - [Language code]{@link https://en.wikipedia.org/wiki/ISO_639-1} of preferred user interface language, e.g. <code>en</code> for English. When set, it must match one of your [configured languages]{@link https://docs.weavy.com/server/localization}.
         * @property {Object|boolean} [logging] - Options for console logging. Set to false to disable.
         * @property {string} [logging.color] - Hex color (#bada55) used for logging. A random color is generated as default.
         * @property {boolean} [logging.log] - Enable log messages in console.
         * @property {boolean} [logging.debug] - Enable debug messages in console.
         * @property {boolean} [logging.info] - Enable info messages in console.
         * @property {boolean} [logging.warn] - Enable warn messages in console.
         * @property {boolean} [logging.error] - Enable error messages in console.
         * @property {Object.<string, Object>} [plugins] - Properties with the name of the plugins to configure. Each plugin may be enabled or disabled by setting the options to true or false. Providing an Object instead of true will enable the plugin and pass options to the plugin. See the reference for each plugin for available options.
         * @property {boolean} [preload] - Start automatic preloading after load
         * @property {boolean} [shadowMode=closed] - Set whether ShadowRoots should be `closed` or `open` (not recommended).
         * @property {Array.<WeavySpace#options>} spaces - Array of space definititions with apps to initialize spaces directly at initialization. See {@link Weavy#space}.
         * @property {string} [tz] - Timezone identifier, e.g. <code>Pacific Standard Time</code>. When specified, this setting overrides the timezone setting on a user´s profile. The list of valid timezone identifiers can depend on the version and operating system of your Weavy server.
         * @property {string} [url] - The URL of the Weavy-installation to connect to. Defaults to the installation where the script came from.
         */
        weavy.options = WeavyUtils.assign(Weavy.defaults);

        // Extend default options with the passed in arguments
        for (var arg in arguments) {
            if (arguments[arg] && typeof arguments[arg] === "object") {
                weavy.options = WeavyUtils.assign(weavy.options, arguments[arg], true);
            }
        }

        function generateId(id) {
            id = "wy-" + (id ? id.replace(/^wy-/, '') : WeavyUtils.S4() + WeavyUtils.S4());

            // Make sure id is unique
            if (_weavyIds.indexOf(id) !== -1) {
                id = generateId(id + WeavyUtils.S4());
            }

            return id;
        }

        var _id = generateId(weavy.options.id);

        /**
         * The weavy instance id
         * @member {string} Weavy#id
         **/
        Object.defineProperty(weavy, "id", { get: function () { return _id } });

        _weavyIds.push(weavy.id);

        // Logging

        /**
         * Class for wrapping native console logging.
         * - Options for turning on/off logging
         * - Optional prefix by id with color
         * 
         * @type {WeavyConsole}
         * @category logging
         * @borrows WeavyConsole#log as Weavy#log
         * @borrows WeavyConsole#debug as Weavy#debug
         * @borrows WeavyConsole#warn as Weavy#warn
         * @borrows WeavyConsole#error as Weavy#error
         * @borrows WeavyConsole#info as Weavy#info
         */
        weavy.console = new WeavyConsole(this, weavy.options.logging);

        weavy.log = weavy.console.log;
        weavy.debug = weavy.console.debug;
        weavy.warn = weavy.console.warn;
        weavy.error = weavy.console.error;
        weavy.info = weavy.console.info;

        // ID functions

        /**
         * Appends the weavy-id to an id. This makes the id unique per weavy instance. You may define a specific weavy-id for the instance in the {@link Weavy#options}. If no id is provided it only returns the weavy id. The weavy id will not be appended more than once.
         * 
         * @param {string} [id] - Any id that should be completed with the weavy id.
         * @returns {string} Id completed with weavy-id. If no id was provided it returns the weavy-id only.
         */
        weavy.getId = function (id) {
            return id ? weavy.removeId(id) + "__" + weavy.id : weavy.id;
        }

        /**
         * Removes the weavy id from an id created with {@link Weavy#getId}
         * 
         * @param {string} id - The id from which the weavy id will be removed.
         * @returns {string} Id without weavy id.
         */
        weavy.removeId = function (id) {
            return id ? String(id).replace(new RegExp("__" + weavy.getId() + "$"), '') : id;
        };

        /**
         * The hardcoded semver version of the weavy-script.
         * @member {string} Weavy.version 
         */
        if (Weavy.version) {
            weavy.log(Weavy.version);
        }

        // Weavy URL
        var _url;

        try {
            if (!weavy.options.url || weavy.options.url === "/" || !new URL(weavy.options.url)) {
                throw new Error();
            } else {
                _url = weavy.options.url;

                // Check protocol
                if (weavy.options.https === "enforce") {
                    _url = _url.replace(/^http:/, "https:");
                } else if (weavy.options.https === "adaptive") {
                    _url = _url.replace(/^http:/, window.location.protocol);
                }
            }
        } catch (e) {
            weavy.error("Required url not specified.\nnew Weavy({ url: \"https://mytestsite.weavycloud.com/\" })");
            return;
        }

        /**
         * The url of the weavy server.
         * 
         * @member {URL} Weavy#url
         **/
        Object.defineProperty(weavy, "url", { get: function () { return new URL(_url); } });

        /**
         * Data about the current user.
         * Use weavy.user.id to get the id of the user.
         * 
         * @category authentication
         * @type {Object}
         */
        weavy.user = null;


        /**
         * Client configuration data from the server. Based on what is passed in {@link Weavy#options} to the server and currently defined spaces.
         * 
         * @typedef
         * @type {Object}
         * @property {Array.<WeavySpace#data>} spaces - List of configured spaces.
         * @property {Object} plugins - Options for configured plugins.
         * @property {Object} [plugins.theme] - Options for the theme plugin
         * @property {string} plugins.theme.logo - Thumb URL for the global installation logo.
         * @property {string} plugins.theme.themeColor - Primary color for the theme in Hex color.
         * @property {string} plugins.theme.clientCss - The CSS for the client. Gets injected in weavy roots.
         * @property {string} status - Status of the server. Should be "ok".
         * @property {string} version - Semver string of the server version. Should match the script {@link Weavy.version}.
         **/
        weavy.data = null;

        /**
         * True when inatialization has started
         * 
         * @type {boolean}
         */
        weavy.isInitialized = false;

        /**
         * True when frames are blocked by Content Policy or the browser
         * 
         * @type {boolean}
         */
        weavy.isBlocked = false;

        /**
         * True when weavy is loading options from the server.
         * 
         * @type {boolean}
         */
        weavy.isLoading = false;

        /**
         * True when weavy has loaded options from the server.
         * 
         * @type {boolean}
         */
        weavy.isLoaded = false;


        // EVENT HANDLING

        /**
         * Instance of {@link WeavyEvents} which enables propagation and before and after phases for events.
         *
         * The event system provides event chaining with a bubbling mechanism that propagates all the way from the emitting child trigger to the weavy instance.
         * 
         * All events in the client have three phases; before, on and after. Each event phase is a prefix to the event name.
         * - The before:event-name is triggered in an early stage of the event cycle and is a good point to modify event data or cancel the event.
         * - The on:event-name is the normal trigger point for the event. It does not need to be prefixed when registering an event listener, you can simly use the event-name when you register a listener. This is the phase you normally use to register event listeners.
         * - The after:event-name is triggered when everything is processed. This is a good point to execute code that is dependent on that all other listers have been executed.
         * 
         * Cancelling an event by calling `event.stopPropagation()` will stop any propagation and cause all the following phases for the event to be cancelled.
         * 
         * @type {WeavyEvents}
         * @category eventhandling
         * @borrows WeavyEvents#on as Weavy#on
         * @borrows WeavyEvents#one as Weavy#one
         * @borrows WeavyEvents#off as Weavy#off
         * @borrows WeavyEvents#triggerEvent as Weavy#triggerEvent
         **/
        weavy.events = new WeavyEvents(weavy);
        weavy.on = weavy.events.on;
        weavy.one = weavy.events.one;
        weavy.off = weavy.events.off;
        weavy.triggerEvent = weavy.events.triggerEvent;


        // AUTHENTICATION & JWT

        /**
         * Reference to the instance of the WeavyAuthentication for the current server.
         * 
         * You always need to define a JWT provider in your {@link Weavy#options}. 
         * This may be a function that returns a JWT string or returns a promise that resolves a JWT string. 
         * The function will be called again whenever a new JWT token is needed.
         * You may also provide a JWT string directly, then you can't benifit from weavy requesting a new token when needed.
         * 
         * See [Client Authentication]{@link https://docs.weavy.com/client/authentication} for full authentication documentation.
         * 
         * @type {WeavyAuthentication}
         * @category authentication
         * @borrows WeavyAuthentication#setJwt as Weavy#authentication#setJwt
         * @borrows WeavyAuthentication#signIn as Weavy#authentication#signIn
         * @borrows WeavyAuthentication#signOut as Weavy#authentication#signOut
         */
        weavy.authentication = WeavyAuthentications.get(weavy.url);

        if (weavy.options.jwt === undefined && !weavy.authentication.isProvided()) {
            weavy.error("specify a jwt string or a provider function in your options");
        }

        if (!weavy.authentication.isProvided() || !weavy.authentication.isInitialized()) {
            weavy.authentication.init(weavy.options.jwt);
        }

        weavy.on(weavy.authentication, "user", function (e, auth) {
            weavy.user = auth.user;

            if (/^signed-in|signed-out|changed-user|user-error$/.test(auth.state)) {

                if (!weavy.isLoading) {
                    if (weavy.isLoaded) {
                        weavy.whenLoaded.reset();
                    }
                    weavy.isLoaded = false;
                    weavy.data = null;
                }


                if (auth.state === "changed-user") {
                    // TODO: document these events
                    weavy.triggerEvent("signed-out", { id: -1 });
                    weavy.triggerEvent("signed-in", auth);
                } else {
                    weavy.triggerEvent(auth.state, auth);
                }

                // Refresh client data
                loadClientData();
            }
        });

        weavy.on(weavy.authentication, "signing-in", function (e) {
            /**
             * Triggered when the authentication process has started.
             * @event Weavy#signing-in
             * @category authentication
             */
            weavy.triggerEvent("signing-in");
        });

        weavy.on(weavy.authentication, "clear-user", function (e) {
            /**
             * Triggered when user data needs to be cleared. For example when a user is signing out.
             * @event Weavy#clear-user
             * @category authentication
             */
            weavy.triggerEvent("clear-user");
        });

        weavy.on(weavy.authentication, "authentication-error", function (e, error) {
            /**
             * Triggered when the authentication process was unsuccessful.
             * 
             * @event Weavy#authentication-error
             * @category authentication
             * @returns {Object}
             * @property {string} method - Which metod that was used to authenticate "jwt" or "panel"
             * @property {int} status - The HTTP error code from the server, like 401 for an unauthorized user
             * @property {string} message - The message from the server, like "Unauthorized"
             */
            weavy.triggerEvent("authentication-error", error);
        });

        // WEAVY REALTIME CONNECTION

        /**
         * Reference to the instance of the realtime connection to the server.
         * 
         * @type {WeavyConnection}
         **/
        weavy.connection = WeavyConnections.get(weavy.url);


        // PANELS

        /**
         * Placeholder for all DOM node references. Put any created elements or DOM related objects here.
         * 
         * @category panels
         * @namespace Weavy#nodes
         * @typicalname .nodes
         * @type {Object}
         * @property {Element} container - The main container under the root. This is where all common weavy Elements are placed.
         * @property {Element} overlay - Container for displaying elements that needs to be full viewport and on top of other elements.
         */
        weavy.nodes = {};
        weavy.nodes.container = null;
        weavy.nodes.overlay = null;


        /**
         * Placeholder for all panels.
         * 
         * @type {Object}
         * @category panels
         * @namespace Weavy#nodes#panels
         * @typicalname .nodes.panels
         **/
        weavy.nodes.panels = {};

        /**
         * Instance of the panel manager for all iframes in the weavy instance.
         * 
         * @type {WeavyPanels}
         * @category panels
         **/
        weavy.panels = new WeavyPanels(weavy);

        weavy.on("before:build", function () {
            if (!weavy.nodes.panels.drawer) {
                /**
                 * Side drawer panel container. Slides in/out automatically when a child panel is opened or closed. Attached to {@link Weavy#nodes#overlay}.
                 * 
                 * @type {WeavyPanels~container}
                 * @category panels
                 * @name Weavy#nodes#panels#drawer
                 **/
                weavy.nodes.panels.drawer = weavy.panels.createContainer();
                weavy.nodes.panels.drawer.node.classList.add("weavy-drawer");
                weavy.nodes.overlay.appendChild(weavy.nodes.panels.drawer.node);
            }

            if (!weavy.nodes.panels.preview) {
                /**
                 * Preview panel container. Attached to {@link Weavy#nodes#overlay}.
                 * 
                 * @type {WeavyPanels~container}
                 * @category panels
                 * @name Weavy#nodes#panels#preview
                 **/
                weavy.nodes.panels.preview = weavy.panels.createContainer();
                weavy.nodes.panels.preview.node.classList.add("weavy-preview");
                weavy.nodes.overlay.appendChild(weavy.nodes.panels.preview.node);
            }
        });

        weavy.on("after:panel-open", function (e, open) {
            if (open.panels === weavy.nodes.panels.drawer) {
                weavy.nodes.panels.drawer.node.classList.add("weavy-drawer-in");
            }
        });

        weavy.on("after:panel-close", function (e, close) {
            if (close.panels === weavy.nodes.panels.drawer) {
                weavy.nodes.panels.drawer.node.classList.remove("weavy-drawer-in");
            }
        });


        // SPACES

        /**
         * List of all current defined spaces as an Array.
         * @category spaces
         * @type {Array.<WeavySpace>}
         **/
        weavy.spaces = new Array();

        /**
         * Selects, fetches or creates a space in the weavy instance.
         *
         * The space needs to be defined using a space definition object containing at least a key, which will fetch or create the space on the server.
         * If the defined space already has been set up, the space will only be selected in the client.
         * After the space is defined it can be quickly selected in the client using only the id (int) or the key (string) of the space, 
         * which never will create nor fetch the space from the server.
         *
         * @example
         * // Define a space that will be fetched or created on the server
         * var space = weavy.space({ key: "mykey", name: "My Space" });
         *
         * // Select the newly defined space
         * var spaceAgain = weavy.space("mykey");
         * 
         * @category spaces
         * @function
         * @param {int|string|WeavySpace#options} options - space id, space key or space definition object.
         * @returns {WeavySpace}
         * @see {@link WeavySpace#options}
         */

        weavy.space = function (options) {
            var space;

            var isSpaceId = Number.isInteger(options);
            var isSpaceKey = typeof options === "string";
            var isSpaceConfig = WeavyUtils.isPlainObject(options);
            var spaceSelector = isSpaceConfig && options || isSpaceId && { id: options } || isSpaceKey && { key: options };

            if (spaceSelector) {
                try {
                    space = weavy.spaces.filter(function (s) { return s.match(spaceSelector) }).pop();
                } catch (e) {}

                if (!space) {
                    if (isSpaceConfig) {
                        space = new WeavySpace(weavy, options);
                        weavy.spaces.push(space);
                        Promise.all([weavy.authentication.whenAuthorized(), weavy.whenInitialized()]).then(function () {
                            space.fetchOrCreate();
                        });
                    } else {
                        weavy.warn("Space " + (isSpaceConfig ? JSON.stringify(spaceSelector) : options) + " does not exist." + (isSpaceId ? "" : " \n Use weavy.space(" + JSON.stringify(spaceSelector) + ") to create the space."))
                    }
                }
            }
            return space;
        };

        // TIMEOUT HANDLING 

        var _timeouts = [];

        /**
         * Clears all current timouts 
         **/
        function clearTimeouts() {
            _timeouts.forEach(clearTimeout);
            _timeouts = [];
        }


        /**
         * Creates a managed timeout promise. Use this instead of window.setTimeout to get a timeout that is automatically managed and unregistered on destroy.
         * 
         * @example
         * var mytimeout = weavy.whenTimeout(200).then(function() { ... });
         * mytimeout.cancel(); // Cancel the timeout
         * 
         * @category promises
         * @function
         * @param {int} time=0 - Timeout in milliseconds
         * @returns {WeavyPromise}
         */
        weavy.whenTimeout = function (time) {
            var timeoutId;
            var whenTimeout = new WeavyPromise();

            var removeIndex = function () {
                var timeoutIndex = _timeouts.indexOf(timeoutId);
                if (timeoutIndex >= 0) {
                    _timeouts.splice(timeoutIndex, 1);
                }
            }

            _timeouts.push(timeoutId = setTimeout(function () { whenTimeout.resolve(); }, time));

            whenTimeout.then(removeIndex);
            whenTimeout.catch(function () {
                removeIndex();
                clearTimeout(timeoutId);
                return Promise.reject(new Error("Timeout cancelled"));
            });

            whenTimeout.cancel = function () {
                removeIndex();
                clearTimeout(timeoutId);
            }
            
            return whenTimeout;
        };

        // PROMISES

        /**
         * Promise that the blocking check has finished. Resolves when {@link Weavy#event:frame-check} is triggered.
         *
         * @example
         * weavy.whenReady().then(function() { ... })
         *
         * @category promises
         * @function
         * @returns {WeavyPromise}
         * @resolved when frames are not blocked.
         * @rejected when frames are blocked
         * */
        weavy.whenReady = new WeavyPromise();

        /**
         * Promise that resolves when the initialization has been started
         * 
         * @category promises
         * @function
         * @returns {WeavyPromise}
         * @resolved when init event has been fully executed
         */
        weavy.whenInitialized = new WeavyPromise();

        // Register init before any plugins do
        weavy.on("init", function () {

            // Prepopulate spaces
            if (weavy.options.spaces) {
                var spaces = WeavyUtils.asArray(weavy.options.spaces);

                spaces.forEach(function (spaceOptions) {
                    if (weavy.spaces.filter(function (space) { return space.match(spaceOptions); }).length === 0) {
                        weavy.spaces.push(new WeavySpace(weavy, spaceOptions));
                    }
                });
            }

            loadClientData().then(function () {
                var wFrameStatusCheck = frameStatusCheck.call(weavy);
                var wConnectionInit = weavy.connection.init(weavy.options.connect, weavy.authentication);
                Promise.all([wFrameStatusCheck, wConnectionInit]).then(function () {
                    weavy.whenReady.resolve();
                });
            });
        });

        weavy.on("after:init", function () {
            weavy.isInitialized = true;
            weavy.whenInitialized.resolve();
        });

        /**
         * Initializes weavy. This is done automatically unless you specify `init: false` in {@link Weavy#options}.
         * 
         * @param {Weavy#options} [options] Any new or additional options.
         * @emits Weavy#init
         * @returns {Weavy#whenInitialized}
         * @resolved When the weavy instance is initialized, ready and loaded.
         */
        weavy.init = function (options) {

            weavy.options = WeavyUtils.assign(weavy.options, options);

            /**
             * Event that is triggered when the weavy instance is initiated. This is done automatically unless you specify `init: false` in {@link Weavy#options}.
             * You may use the `before:init` event together with `event.stopPropagation()` if you want to intercept the initialization.
             * 
             * @category events
             * @event Weavy#init
             * @returns {external:Promise}
             */
            weavy.triggerEvent("init");

            return weavy.whenInitialized();
        }        

        /**
         * Promise that weavy has recieved the after:load event
         *
         * @example
         * weavy.whenLoaded().then(function() { ... })
         *
         * @category promises
         * @function
         * @returns {WeavyPromise}
         * @resolved when init is called, the websocket has connected, data is received from the server and weavy is built and the load event has finished.
         */
        weavy.whenLoaded = new WeavyPromise();

        function allSpacesAndAppsLoaded() {
            var spacesLoaded = weavy.spaces.reduce(function (allSpacesLoaded, space) {
                // Check if space is loaded, then also check if all apps in the space are loaded
                return allSpacesLoaded && space.isLoaded && space.apps.reduce(function (allSpaceAppsLoaded, app) {
                    return allSpaceAppsLoaded && app.isLoaded;
                }, true);
            }, true);

            return spacesLoaded;
        }

        function whenAllLoaded() {
            if (allSpacesAndAppsLoaded()) {
                return WeavyPromise.resolve();
            } else {
                var spacesAndAppsLoaded = weavy.spaces.reduce(function (loadPromises, space) {
                    // Append space load promise
                    loadPromises.push(space.whenLoaded());

                    return loadPromises.concat(space.apps.map(function (app) {
                        // Append app load promise
                        return app.whenLoaded();
                    }));
                }, []);

                // Try again when all current promises are fulfilled
                return Promise.all(spacesAndAppsLoaded).then(whenAllLoaded);
            }
        }

        weavy.whenAllLoaded = whenAllLoaded;

        weavy.on("processed:load", function () {
            whenAllLoaded().then(function () {
                weavy.whenLoaded.resolve();
            });
        });

        // INTERNAL FUNCTIONS

        function disconnect(async, notify) {
            weavy.log("disconnecting weavy");

            // NOTE: stop/disconnect directly if we are not authenticated 
            // signalr does not allow the user identity to change in an active connection
            return weavy.connection.disconnect(async, notify);
        }

        function loadClientData() {
            if (!weavy.isLoading) {
                if (weavy.isLoaded) {
                    weavy.whenLoaded.reset();
                }

                weavy.isLoaded = false;
                weavy.isLoading = true;
 
                weavy.options.href = window.location.href;

                var initUrl = new URL("/client/init", weavy.url).href;

                var initData = {
                    spaces: weavy.spaces.map(function (space) {
                        if (!space.isLoading) {
                            space.isLoading = true;
                            return space.options;
                        }
                    }).filter((s) => s), // Remove empty
                    plugins: weavy.options.plugins,
                    version: Weavy.version
                }

                if (weavy.options.lang) {
                    initData.lang = weavy.options.lang;
                }
                if (weavy.options.tz) {
                    initData.tz = weavy.options.tz;
                }
                if (weavy.options.theme) {
                    initData.theme = weavy.options.theme;
                }

                weavy.ajax(initUrl, initData, "POST", null, true).then(function (clientData) {

                    /**
                     * Triggered when init data has been loaded from the server.
                     * 
                     * @event Weavy#client-data
                     * @category events
                     * @returns {Weavy#data}
                     **/
                    weavy.triggerEvent("client-data", clientData);
                });
            }
            return weavy.whenLoaded();
        }


        var _roots = new Map();

        /**
         * Creates an isolated shadow root in the DOM tree to place nodes in.
         * 
         * @param {Element|string} parentSelector - The node to place the root in.
         * @param {string} id - Id of the root.
         * @emits Weavy#create-root
         * @returns {Weavy~root}
         */
        weavy.createRoot = function (parentSelector, id) {
            var supportsShadowDOM = !!HTMLElement.prototype.attachShadow;

            var rootId = weavy.getId(id);
            var parentElement = WeavyUtils.asElement(parentSelector);

            if (!parentElement) {
                weavy.error("No parent container defined for createRoot", rootId);
                return;
            }
            if (_roots.has(rootId)) {
                weavy.warn("Root already created", rootId);
                return _roots.get(rootId);
            }

            var rootSection = document.createElement("weavy");

            rootSection.id = rootId;

            var rootDom = document.createElement("weavy-root");
            rootDom.setAttribute("data-version", Weavy.version);

            var rootContainer = document.createElement("weavy-container");
            rootContainer.className = "weavy-container";
            rootContainer.id = weavy.getId("weavy-container-" + weavy.removeId(rootId));     

            /**
             * Weavy shadow root to enable closed scopes in the DOM that also can be managed and removed.
             * The shadow root will isolate styles and nodes within the root.
             * 
             * Structure:
             * 
             * {parent} ➜ &lt;weavy/&gt; ➜ {ShadowDOM} ➜ {container}
             * 
             * @typedef Weavy~root 
             * @type {Object}
             * @property {Element} parent - The parent DOM node where the root is attached.
             * @property {Element} section - The &lt;weavy/&gt; node which is the placeholder for the root. Attached to the parent.
             * @property {ShadowDOM} root - The &lt;weavy-root/&gt; that by default is a closed ShadowDOM node. Attached to the section.
             * @property {Element} container - The &lt;weavy-container/&gt; where you safely can place elements. Attached to the root.
             * @property {string} id - The id of the root.
             * @property {function} remove() - Function to remove the root from the DOM.
             * @see {@link https://developer.mozilla.org/en-US/docs/Web/Web_Components/Using_shadow_DOM}
             **/
            var root = { parent: parentElement, section: rootSection, root: rootDom, container: rootContainer, id: rootId };

            // TODO: use returned/modified data
            weavy.triggerEvent("before:create-root", root);

            parentElement.appendChild(rootSection);
            rootSection.appendChild(rootDom);

            if (supportsShadowDOM) {
                if (weavy.options.shadowMode === "open") {
                    weavy.warn("Using ShadowDOM in open mode", rootId);
                }
                root.root = rootDom = rootDom.attachShadow({ mode: weavy.options.shadowMode || "closed" });
            }
            rootDom.appendChild(rootContainer);

            /**
             * Triggered when a shadow root is created
             * 
             * @category events
             * @event Weavy#create-root
             * @returns {Weavy~root}
             **/
            weavy.triggerEvent("on:create-root", root);

            root.remove = function () {
                weavy.triggerEvent("before:remove-root", root);

                root.container.remove();
                root.section.remove();

                weavy.triggerEvent("on:remove-root", root);

                _roots.delete(rootId);

                weavy.triggerEvent("after:remove-root", root);
            };

            weavy.triggerEvent("after:create-root", root);

            _roots.set(rootId, root);

            return root;
        };

        /**
         * Get a Weavy shadow root by id.
         * 
         * @param {string} id - The id of the root.
         * @returns {Weavy~root}
         */
        weavy.getRoot = function (id) {
            return _roots.get(weavy.getId(id));
        }

        /**
         * Checks that frame communication is not blocked.
         **/
        function frameStatusCheck() {
            var statusUrl = new URL("/client/ping", weavy.url);

            var storageAccessAvailable = 'hasStorageAccess' in document;

            var whenFrameCookiesChecked = new WeavyPromise();
            var whenFrameCookiesEnabled = new WeavyPromise();
            var whenFrameStatusCheck = new WeavyPromise();
            var whenFrameReady = new WeavyPromise();

            var whenStatusTimeout = weavy.whenTimeout(3000);

            var alertCookie, alertStorage;

            if (!weavy.nodes.statusFrame) {
                weavy.log("Frame Check: Started...");

                // frame status checking
                var statusFrame = weavy.nodes.statusFrame = document.createElement("iframe");
                statusFrame.className = "weavy-status-check weavy-hidden";
                statusFrame.style.display = "none";
                statusFrame.id = weavy.getId("weavy-status-check");
                statusFrame.setAttribute("name", weavy.getId("weavy-status-check"));

                var requestStorageAccess = function () {
                    var msg = WeavyUtils.asElement('<span>Third party cookies are required to use this page. </span>')
                    var msgButton = WeavyUtils.asElement('<button class="btn" style="pointer-events: auto;">Enable cookies</button>');
                    var storageAccessWindow;

                    msgButton.onclick = function () {
                        weavy.log('Frame Check: Opening storage access request');
                        storageAccessWindow = window.open(new URL('/cookie-access', weavy.url), weavy.getId("weavy-storage-access"));
                        WeavyPostal.registerContentWindow(storageAccessWindow, weavy.getId("weavy-storage-access"), weavy.getId(), weavy.url.origin);
                    };
                    msg.appendChild(msgButton);

                    alertStorage = weavy.alert(msg, true);

                    weavy.one(WeavyPostal, "storage-access-granted", { weavyId: true, domain: weavy.url.origin }, function () {
                        weavy.log("Frame Check: Storage access was granted, authenticating and reloading status check.");

                        if (alertCookie) {
                            alertCookie.remove();
                            alertCookie = null;
                        }

                        if (alertStorage) {
                            alertStorage.remove();
                            alertStorage = null;
                        }
                        let weavyId = weavy.getId();

                        weavy.authentication.signIn().then(function () {
                            weavy.debug("Frame Check: reloading status check")
                            WeavyPostal.postToFrame(weavy.getId("weavy-status-check"), weavyId, { name: "reload" });
                        });
                    });

                };

                weavy.on(WeavyPostal, "user-status", { weavyId: weavy.getId(), windowName: weavy.getId("weavy-status-check") }, function (e, userStatus) {
                    var cookieIsValid = parseInt(userStatus.id) === parseInt(weavy.authentication.user().id);
                    weavy.debug("Frame Check: user-status received", cookieIsValid);
                    whenFrameCookiesChecked.resolve(cookieIsValid);

                    if (!cookieIsValid) {
                        if (storageAccessAvailable) {
                            requestStorageAccess();
                        } else if (!storageAccessAvailable) {
                            alertCookie = weavy.alert('Allow third party cookies to use this page.');
                        }
                    } else {
                        whenFrameCookiesEnabled.resolve();
                    }
                });


                weavy.one(WeavyPostal, "ready", { weavyId: weavy.getId(), windowName: weavy.getId("weavy-status-check") }, function () {
                    weavy.debug("Frame Check: frame ready")
                    whenFrameReady.resolve();
                });


                // Frame network investigator triggered when status frame timeout
                whenStatusTimeout.then(function () {
                    weavy.ajax(statusUrl).then(function (response) {
                        weavy.warn("Status check timeout. Please make sure your web server is properly configured.")

                        if (response.ok) {
                            if (response.headers.has("X-Frame-Options")) {
                                let frameOptions = response.headers.get("X-Frame-Options");
                                if (frameOptions === "DENY" || frameOptions === "SAMEORIGIN" && statusUrl.origin !== window.location.origin) {
                                    return Promise.reject(new Error("Frames are blocked by header X-Frame-Options"));
                                }
                            }

                            if (response.headers.has("Content-Security-Policy")) {
                                let secPolicy = response.headers.get("Content-Security-Policy").split(";");

                                let frameAncestors = secPolicy.filter(function (policy) {
                                    return policy.indexOf('frame-ancestors') === 0;
                                }).pop();

                                if (frameAncestors) {
                                    let faDomains = frameAncestors.split(" ");
                                    faDomains.splice(0, 1);

                                    let matchingDomains = faDomains.filter(function (domain) {
                                        if (domain === "'self'" && weavy.url.origin === window.location.origin) {
                                            return true;
                                        } else if (domain.indexOf("*")) {
                                            return window.location.origin.endsWith(domain.split("*").pop())
                                        } else if (domain === window.location.origin) {
                                            return true;
                                        }
                                        return false;
                                    });

                                    if (!matchingDomains.length) {
                                        return Promise.reject(new Error("Frames blocked by header Content-Security-Policy: frame-ancestors"));
                                    }
                                }
                            }
                        } else {
                            return Promise.reject(new Error("Error fetching status url: " + response.statusText));
                        }
                    }).catch(function (error) {
                        weavy.error("Frame status error detected: " + error.message);
                    })
                });

                weavy.nodes.container.appendChild(weavy.nodes.statusFrame);

                weavy.whenTimeout(1).then(function () {
                    weavy.nodes.statusFrame.src = statusUrl.href;
                    weavy.isBlocked = true;

                    try {
                        WeavyPostal.registerContentWindow(weavy.nodes.statusFrame.contentWindow, weavy.getId("weavy-status-check"), weavy.getId(), weavy.url.origin);
                    } catch (e) {
                        weavy.warn("Frame postMessage is blocked", e);
                        weavy.triggerEvent("frame-check", { blocked: true });
                    }
                });

                return Promise.all([whenFrameReady(), whenFrameCookiesEnabled()]).then(function () {
                    weavy.log("Frame Check:", "OK");
                    weavy.isBlocked = false;

                    whenStatusTimeout.cancel();

                    if (alertCookie) {
                        alertCookie.remove();
                        alertCookie = null;
                    }

                    if (alertStorage) {
                        alertStorage.remove();
                        alertStorage = null;
                    }

                    /**
                     * Triggered when the frame check is done.
                     * 
                     * @category events
                     * @event Weavy#frame-check
                     * @returns {WeavyPromise}
                     * @property {boolean} blocked - Whether iframes communication is blocked or not.
                     * @resolves {WeavyPromise}
                     **/
                    weavy.triggerEvent("frame-check", { blocked: false });
                    whenFrameStatusCheck.resolve({ blocked: false });
                    return whenFrameStatusCheck();
                }).catch(function (error) {
                    weavy.triggerEvent("frame-check", { blocked: true });
                    whenFrameStatusCheck.reject(new Error("Frame check failed: " + error.message));
                    return whenFrameStatusCheck();
                });
            }
        }

        /**
         * Creates the general weavy root where overlays etc are placed.
         **/
        function initRoot() {
            // add container
            if (!weavy.getRoot()) {
                // append container to target element || html
                var rootParent = WeavyUtils.asElement(weavy.options.container) || document.documentElement;

                var root = weavy.createRoot.call(weavy, rootParent);
                weavy.nodes.container = root.root;
                weavy.nodes.overlay = root.container;

                weavy.nodes.overlay.classList.add("weavy-overlay");
            }
        }


        // PUBLIC METHODS


        /**
         * Method for calling JSON API endpoints on the server. You may send data along with the request or retrieve data from the server.
         * 
         * Fetch API is used internally and you may override or extend any settings in the {@link external:fetch} by providing custom [fetch init settings]{@link external:fetchxSettings}.
         * 
         * You may of course call the endpoints using any other preferred AJAX method, but this method is preconfigured with proper encoding and crossdomain settings.
         *
         * @param {string|URL} url - URL to the JSON endpoint. May be relative to the connected server.
         * @param {object} [data] - Data to send. May be an object that will be encoded or a string with pre encoded data.
         * @param {string} [method=GET] - HTTP Request Method {@link https://developer.mozilla.org/en-US/docs/Web/HTTP/Methods}
         * @param {external:fetchSettings} [settings] - Settings to extend or override [fetch init settings]{@link external:fetchSettings}.
         * @returns {external:Promise}
         * 
         * @example <caption>Requires custom endpoints on the server, normally included in a sandbox installation.</caption>
         * // Create a space and open it as a panel
         * weavy.ajax("/api/spaces/", { name: "My Space" }, "POST").then(function(result) {
         *   weavy.panels.addPanel("space" + result.id, result.url);
         *   weavy.panels.open("space" + result.id);
         * });
         *
         * // Search for a space
         * weavy.ajax("/api/search", { q: "My Space", et: "space"}).then(function(result) {
         *   console.log("Found " + result.count + " results");
         * });
         */
        weavy.ajax = function (url, data, method, settings) {
            url = new URL(url, weavy.url);
            method = method || "GET";
            data = data && typeof data === "string" && data || method !== "GET" && data && JSON.stringify(data, WeavyUtils.sanitizeJSON) || data || "";

            var isUnique = !!(method !== "GET" || data);
            var isSameOrigin = url.origin === weavy.url.origin;

            if (!isSameOrigin) {
                return Promise.reject(new Error("weavy.ajax: Only requests to the weavy server are alllowed."))
            }

            settings = WeavyUtils.assign({
                method: method,
                mode: 'cors', // no-cors, *cors, same-origin
                cache: isUnique ? 'no-cache' : 'default', // *default, no-cache, reload, force-cache, only-if-cached
                credentials: 'include', // include, *same-origin, omit
                headers: {
                    'Content-Type': 'application/json',
                    // 'Content-Type': 'application/x-www-form-urlencoded',
                    // https://stackoverflow.com/questions/8163703/cross-domain-ajax-doesnt-send-x-requested-with-header
                    "X-Requested-With": "XMLHttpRequest"
                },
                redirect: 'manual', // manual, *follow, error
                referrerPolicy: "no-referrer-when-downgrade", // no-referrer, *no-referrer-when-downgrade, origin, origin-when-cross-origin, same-origin, strict-origin, strict-origin-when-cross-origin, unsafe-url
            }, settings, true);

            if (data && method !== "GET") {
                settings.body = data // body data type must match "Content-Type" header
            } else if (data) {
                let urlData = new URLSearchParams(data);
                url.search = (url.search ? url.search + "&" : "") + urlData.toString();
            }
            return weavy.authentication.whenAuthenticated().then(function () {
                return weavy.authentication.getJwt().then(function (token) {
                    if (typeof token !== "string") {
                        return Promise.reject(new Error("weavy.ajax: Provided JWT is empty!"))
                    }

                    // JWT configured, use bearer token
                    settings.headers.Authorization = "Bearer " + token;

                    return window.fetch(url.toString(), settings).then(function (response) {
                        if (response.status === 401) {
                            weavy.warn("weavy.ajax: JWT failed, trying again");
                            return weavy.authentication.getJwt(true).then(function (token) {
                                settings.headers.Authorization = "Bearer " + token;
                                return window.fetch(url.toString(), settings);
                            })
                        }
                        return response;
                    }).then(WeavyUtils.processJSONResponse).catch(function (error) {
                        weavy.error("weavy.ajax: request failed!", error.message);
                        return Promise.reject(error);
                    });
                })
            });
        }
        
        /**
         * Destroys the instance of Weavy. You should also remove any references to weavy after you have destroyed it. The [destroy event]{@link Weavy#event:destroy} will be triggered before anything else is removed so that plugins etc may unregister and clean up, before the instance is gone.
         * @param {boolean} [keepConnection=false] - Set to true if you want the realtime-connection to remain connected.
         * @emits Weavy#destroy
         * @returns {external:Promise}
         */
        weavy.destroy = function (keepConnection) {
            var whenDestroyed = new WeavyPromise();
            var waitFor = [];

            /**
             * Event triggered when the Weavy instance is about to be destroyed. Use this event for clean up. 
             * - Any events registered using {@link Weavy#on} and {@link Weavy#one} will be unregistered automatically. 
             * - Timers using {@link Weavy#whenTimeout} will be cleared automatically.
             * - All elements under the {@link Weavy#nodes#root} will be removed.
             * 
             * @category events
             * @event Weavy#destroy
             * @returns {Object}
             * @property {Array} whenAllDestroyed - List of promises to wait for before destroy resolves. Add promises to wait for in your event handler.
            */
            var destroyResult = weavy.triggerEvent("destroy", { whenAllDestroyed: [] });

            if (destroyResult !== false) {

                weavy.log("destroy: Removing roots");
                _roots.forEach(function (root) {
                    root.remove();
                });

                Promise.all(destroyResult.whenAllDestroyed || []).then(function () {
                    weavy.log("destroy: clearing events");
                    weavy.events.clear();

                    clearTimeouts();

                    // Unregister all content windows
                    try {
                        WeavyPostal.unregisterAll(weavy.getId());
                    } catch (e) {
                        weavy.warn("weavy.destroy: could not unregister postal content windows")
                    }

                    _weavyIds.splice(_weavyIds.indexOf(weavy.getId()), 1);

                    if (!keepConnection && _weavyIds.length === 0) {
                        waitFor.push(disconnect(true, true));
                    }

                    // Delete everything in the instance
                    for (var prop in weavy) {
                        if (Object.prototype.hasOwnProperty.call(weavy, prop)) {
                            delete weavy[prop];
                        }
                    }

                    Promise.all(waitFor).then(function () {
                        whenDestroyed.resolve();
                    });
                }).catch(function () {
                    whenDestroyed.reject();
                });
            } else {
                whenDestroyed.reject();
            }

            return whenDestroyed();
        }


        // REALTIME EVENTS

        weavy.on(weavy.connection, "badge.weavy", function (e, data) {

            /**
             * Triggers when the number of unread conversations or notifications change.
             * 
             * @example
             * weavy.on("badge", function (e, data) {
             *     weavy.log("New notifications count", data.notifications);
             *     weavy.log("Unread conversations count", data.conversations);
             * });
             * 
             * @event Weavy#badge
             * @category events
             * @returns {Object}
             * @property {int} conversations - Number of unread conversations
             * @property {int} notifications - Number of unread notifications
             * @property {int} total - The total number of unread conversations and notifications.
             */
            weavy.triggerEvent("badge", data);
        });

        weavy.on("clear-user signed-out", function () {
            weavy.triggerEvent("badge", { conversations: 0, notifications: 0, total: 0 });
        })

        weavy.on("client-data", function (e, clientData) {

            // Merge options
            //weavy.data = WeavyUtils.assign(weavy.data, clientData, true);
            weavy.data = clientData;

            if (!clientData) {
                weavy.error("Error loading client data");
                weavy.isLoading = false;
                weavy.whenLoaded.reject();
                return;
            }

            // Do a script version mismatch check
            if (Weavy.version !== weavy.data.version) {
                weavy.error("Weavy client/server version mismatch! \nclient: " + Weavy.version + " \nserver: " + weavy.data.version);
            }

            if (weavy.authentication.isAuthorized() && clientData && clientData.spaces) {
                var spaces = WeavyUtils.asArray(clientData.spaces);

                spaces.forEach(function (spaceData) {
                    var foundSpace = weavy.spaces.filter(function (space) { return space.match(spaceData) }).pop();
                    if (foundSpace) {
                        weavy.debug("Populating space data", spaceData.id);
                        foundSpace.data = spaceData;
                        foundSpace.configure();
                    }
                })
            }


            if (weavy.isLoaded === false) {
                initRoot.call(weavy);

                /**
                    * Event triggered when weavy is building up the DOM elements.
                    * 
                    * Use this event to build all your elements and attach them to weavy.
                    * At this point you may safely assume that weavy.nodes.container is built.
                    * 
                    * Good practice is to build all elements in the build event and store them as properties on weavy.
                    * Then you can attach them to other Elements in the after:build event.
                    * This ensures that all Elements are built before they are attached to each other.
                    *
                    * If you have dependencies to Elements built by plugins you should also check that they actually exist before attaching to them.
                    *
                    * Often it's a good idea to check if the user is signed-in using {@link WeavyAuthentication#isAuthenticated} unless you're building something that doesn't require a signed in user.
                    *
                    * @example
                    * weavy.on("build", function(e, root) {
                    *     if (weavy.authentication.isAuthorized()) {
                    *         weavy.nodes.myElement = document.createElement("DIV");
                    *     }
                    * });
                    * 
                    * weavy.on("after:build", function(e, root) {
                    *     if (weavy.authentication.isAuthorized()) {
                    *         if (weavy.nodes.overlay) {
                    *             weavy.nodes.overlay.appendChild(weavy.nodes.myElement);
                    *         }
                    *     }
                    * })
                    *
                    * @category events
                    * @event Weavy#build
                    */

                weavy.isLoaded = true;
                weavy.triggerEvent("build", { container: weavy.nodes.container, overlay: weavy.nodes.overlay });


                /**
                    * Event triggered when weavy has initialized, connected to the server and recieved and processed options, and built all components.
                    * Use this event to do stuff when everything is loaded.
                    * 
                    * Often it's a good idea to check if the user is signed-in using {@link Weavy#isAuthenticated} unless you're building something that doesn't require a signed in user.
                    * 
                    * @example
                    * weavy.on("load", function() {
                    *     if (weavy.authentication.isAuthorized()) {
                    *         weavy.alert("Client successfully loaded");
                    *     }
                    * });
                    * 
                    * @category events
                    * @event Weavy#load
                    */
                weavy.triggerEvent("load");
            }

            weavy.isLoading = false;
            weavy.triggerEvent("processed:load");
        });

        // NAVIGATION & HISTORY
        weavy.navigation = new WeavyNavigation(weavy);
        weavy.history = new WeavyHistory(weavy);

        // RUN PLUGINS

        /**
         * All enabled plugins are available in the plugin list. Anything exposed by the plugin is accessible here. 
         * You may use this to check if a plugin is enabled and active.
         * 
         * Set plugin options and enable/disable plugins using {@link Weavy#options}.
         * 
         * @example
         * if (weavy.plugins.alert) {
         *   weavy.plugins.alert.alert("Alert plugin is enabled");
         * }
         * 
         * @category plugins
         * @type {Object.<string, plugin>}
         */
        weavy.plugins = {};

        var _unsortedDependencies = {};
        var _sortedDependencies = [];
        var _checkedDependencies = [];

        function sortByDependencies(pluginName) {
            if (!pluginName) {
                for (plugin in _unsortedDependencies) {
                    sortByDependencies(plugin);
                }
            } else {
                if (Object.prototype.hasOwnProperty.call(_unsortedDependencies, pluginName)) {
                    var plugin = _unsortedDependencies[pluginName];
                    if (plugin.dependencies.length) {
                        plugin.dependencies.forEach(function (dep) {
                            // Check if plugin is enabled
                            if (typeof Weavy.plugins[dep] !== "function") {
                                weavy.error("plugin dependency needed by " + pluginName + " is not loaded/registered:", dep);
                            } else if (!(weavy.options.includePlugins && weavy.options.plugins[dep] !== false || !weavy.options.includePlugins && weavy.options.plugins[dep])) {
                                weavy.error("plugin dependency needed by " + pluginName + " is disabled:", dep);
                            }

                            if (_checkedDependencies.indexOf(dep) === -1) {
                                _checkedDependencies.push(dep);
                                sortByDependencies(dep);
                            } else {
                                weavy.error("You have circular Weavy plugin dependencies:", pluginName, dep);
                            }
                        });
                    }

                    if (Object.prototype.hasOwnProperty.call(_unsortedDependencies, pluginName)) {
                        _sortedDependencies.push(_unsortedDependencies[pluginName]);
                        delete _unsortedDependencies[pluginName];
                        _checkedDependencies = [];
                        return true;
                    }
                }
            }

            return false;
        }

        // Disable all plugins by setting plugin option to false
        if (weavy.options.plugins !== false) {
            weavy.options.plugins = weavy.options.plugins || {};


            for (plugin in Weavy.plugins) {
                if (typeof Weavy.plugins[plugin] === "function") {

                    // Disable individual plugins by setting plugin options to false
                    if (weavy.options.includePlugins && weavy.options.plugins[plugin] !== false || !weavy.options.includePlugins && weavy.options.plugins[plugin]) {
                        _unsortedDependencies[plugin] = { name: plugin, dependencies: Array.isArray(Weavy.plugins[plugin].dependencies) ? Weavy.plugins[plugin].dependencies : [] };
                    }
                }
            }

            // Sort by dependencies
            sortByDependencies();

            for (var sortedPlugin in _sortedDependencies) {
                var plugin = _sortedDependencies[sortedPlugin].name;

                weavy.debug("Running Weavy plugin:", plugin);

                // Extend plugin options
                weavy.options.plugins[plugin] = WeavyUtils.assign(Weavy.plugins[plugin].defaults, WeavyUtils.isPlainObject(weavy.options.plugins[plugin]) ? weavy.options.plugins[plugin] : {}, true);

                // Run the plugin
                weavy.plugins[plugin] = Weavy.plugins[plugin].call(weavy, weavy.options.plugins[plugin]) || true;
            }

        }

        // INIT
        if (weavy.options.init === true) {
            weavy.init();
        }
    }

    // PROTOTYPE EXTENDING

    Object.defineProperty(Weavy.prototype, "type", { get: () => "Weavy" });

    /**
     * Option preset configurations. Use these for simple configurations of common options. You may add your own presets also. 
     * The presets may be merged with custom options when you create a new Weavy, since the contructor accepts multiple option sets. 
     * 
     * @example
     * // Load the minimal weavy core without any additional plugins.
     * var weavy = new Weavy(Weavy.presets.core, { url: "https://myweavysite.com" });
     * 
     * @name Weavy.presets
     * @type {Object}
     * @property {Weavy#options} Weavy.presets.noplugins - Disable all plugins.
     * @property {Weavy#options} Weavy.presets.core - Enable all core plugins only.
     */
    Weavy.presets = {
        noplugins: {
            includePlugins: false
        },
        core: {
            includePlugins: false,
            plugins: {
                alert: true,
                filebrowser: true,
                preview: true,
                theme: true
            }
        }
    };

    /**
     * Default options. These options are general for all Weavy instances and may be overridden in {@link Weavy#options}. 
     * You may add any general options you like here. The url is always set to the installation where your weavy.js was generated.
     * 
     * @example
     * // Defaults
     * Weavy.defaults = {
     *     connect: true,
     *     container: null,
     *     className: "",
     *     https: "adaptive",
     *     init: true,
     *     includePlugins: true,
     *     preload: true,
     *     url: "/"
     * };
     * 
     * // Set a general url to connect all weavy instances to
     * Weavy.defaults.url = "https://myweavysite.com";
     * var weavy = new Weavy();
     *
     * @type {Object}
     * @name Weavy.defaults
     * @property {boolean} [connect] - Enable automatic realtime connect after init. When `false` connection can be started using `weavy.connection.connect()`.
     * @property {Element} [container] - Container where weavy should be placed. If no Element is provided, a &lt;section&gt; is created next to the &lt;body&gt;-element.
     * @property {string} [className=weavy-default] - Additional classNames added to weavy.
     * @property {string} [https=adaptive] - How to enforce https-links. <br>• **force** -  makes urls https.<br>• **adaptive** -  enforces https if the calling site uses https.<br>• **default** - makes no change.
     * @property {boolean} [init=true] - Should weavy initialize automatically.
     * @property {boolean} [includePlugins=true] - Whether all registered plugins should be enabled by default. If false, then each plugin needs to be enabled in plugin-options.
     * @property {boolean} [preload] - Start automatic preloading after load
     * @property {boolean} [shadowMode=closed] - Set whether ShadowDOMs should be `closed` (recommended) or `open`.
     * @property {string} url - The URL to the Weavy-installation to connect to.
     */
    Weavy.defaults = {
        connect: true,
        container: null,
        https: "adaptive", // force, adaptive or default 
        init: true,
        includePlugins: true,
        logging: {
            log: true,
            info: false,
            debug: false,
            warn: true,
            error: true
        },
        plugins: {
            deeplinks: false
        },
        preload: true,
        shadowMode: "closed",
        url: "/"
    };

    /**
     * Placeholder for registering plugins. Plugins must be registered and available here to be accessible and initialized in the Weavy instance. Register any plugins after you have loaded weavy.js and before you create a new Weavy instance.
     * 
     * @name Weavy.plugins
     * @type {Object.<string, plugin>}
     */
    Weavy.plugins = {};

    /**
     * Id list of all created instances.
     * @name Weavy.instances
     * @type {string[]}
     */
    Object.defineProperty(Weavy, 'instances', {
        get: function () { return _weavyIds.slice(); },
        configurable: false
    });

    return Weavy;

}));

/**
 * @external Promise
 * @see https://developer.mozilla.org/en-US/docs/Web/JavaScript/Guide/Using_promises
 */
;
/* eslint-env commonjs, amd */

// UMD based on https://github.com/umdjs/umd/blob/master/templates/returnExports.js
// TODO: move to ES6 and transpiler

(function (root, factory) {
    if (typeof define === 'function' && define.amd) {
        // AMD. Register as an anonymous module.
        define([
            'weavy'
        ], factory);
    } else if (typeof module === 'object' && module.exports) {
        // Node. Does not work with strict CommonJS, but
        // only CommonJS-like environments that support module.exports,
        // like Node.
        module.exports = factory(
            require('weavy')
        );
    } else {
        // Browser globals (root is window)
        if (typeof root.Weavy === 'undefined' || !root.Weavy.plugins) {
            throw new Error("Weavy must be loaded before registering plugin");
        }

        factory(root.Weavy);
    }
}(typeof self !== 'undefined' ? self : this, function (Weavy) {

    /**
     * Plugin for displaying alert messages.
     * 
     * @mixin AlertPlugin
     * @returns {Weavy.plugins.alert}
     * @property {AlertPlugin#alert} .alert()
     * @typicalname weavy
     */
    var AlertPlugin = function (options) {
        /** 
         * Reference to this instance
         * @lends AlertPlugin#
         */
        var weavy = this;
        var _addMessages = [];

        function displayMessage(message, sticky) {
            if (!sticky) {
                weavy.whenTimeout(5000).then(function () {
                    message.classList.remove("in");
                });
                weavy.whenTimeout(5200).then(function () {
                    message.remove();
                });
            }
            weavy.whenTimeout(1).then(function () {
                message.classList.add("in");
            });
            weavy.nodes.overlay.appendChild(message)
        }

        /**
         * Displays an alert.
         * 
         * @example
         * weavy.alert("Weavy is awesome!", true);
         * 
         * @param {string} message - The message to display
         * @param {boolean} [sticky=false] - Should the alert be sticky and not dismissable?
         */
        weavy.alert = function (message, sticky) {
            var alertMessage = document.createElement("div");
            alertMessage.className = options.className;
            if (message instanceof HTMLElement) {
                alertMessage.appendChild(message);
            } else {
                alertMessage.innerHTML = message;
            }

            if (weavy.nodes.overlay) {
                displayMessage(alertMessage, sticky);
            } else {
                _addMessages.push([alertMessage, sticky]);
            }
            weavy.log("Alert\n" + alertMessage.innerText);

            return alertMessage;
        }

        weavy.on("after:build", function () {
            _addMessages.forEach(function (alertMessage) {
                displayMessage.apply(weavy, alertMessage);
            });
            _addMessages = [];
        });

        // Exports
        return { alert: weavy.alert }
    };

    /**
     * Default plugin options
     * 
     * @example
     * Weavy.plugins.alert.defaults = {
     *     className: "weavy-alert-message fade in"
     * };
     * 
     * @name defaults
     * @memberof AlertPlugin
     * @type {Object}
     * @property {string} [className=weavy-alert-message fade in] - Default classes for the alerts
     */
    AlertPlugin.defaults = {
        className: "weavy-alert-message fade"
    };

    // Register and return plugin
    //console.debug("Registering Weavy plugin: alert");
    return Weavy.plugins.alert = AlertPlugin;

}));
/* eslint-env commonjs, amd */

// UMD based on https://github.com/umdjs/umd/blob/master/templates/returnExports.js
// TODO: move to ES6 and transpiler

(function (root, factory) {
    if (typeof define === 'function' && define.amd) {
        // AMD. Register as an anonymous module.
        define([
            'weavy'
        ], factory);
    } else if (typeof module === 'object' && module.exports) {
        // Node. Does not work with strict CommonJS, but
        // only CommonJS-like environments that support module.exports,
        // like Node.
        module.exports = factory(
            require('weavy')
        );
    } else {
        // Browser globals (root is window)
        if (typeof root.Weavy === 'undefined' || !root.Weavy.plugins) {
            throw new Error("Weavy must be loaded before registering plugin");
        }

        factory(root.Weavy);
    }
}(typeof self !== 'undefined' ? self : this, function (Weavy) {

    /**
     * Plugin for enabling url fragment (hash) deep links. 
     * 
     * Note: This plugin is disabled by default and must be enabled in weavy options.
     * 
     * @example
     * // Url with last opened panel only
     * var weavy = new Weavy({ 
     *   plugins: { 
     *     deeplinks: true 
     *   }
     * })
     * 
     * @example
     * // Url with all opened panels
     * var weavy = new Weavy({ 
     *   plugins: { 
     *     deeplinks: {
     *       multiple: true
     *     }
     *   }
     * })
     * 
     * @mixin DeeplinksPlugin
     * @returns {Weavy.plugins.deeplinks}
     */
    var DeeplinksPlugin = function (options) {
        /**
         *  Reference to this instance
         *  @lends DeeplinksPlugin#
         */
        var weavy = this;

        weavy.on("history", function (e, history) {
            var options = weavy.options.plugins.deeplinks;

            var allOpenPanels = history.globalState.panels.filter(function (panelState) {
                return panelState.changedAt && panelState.isOpen && (!panelState.statusCode || panelState.statusCode === 200);
            });
            var lastOpenPanel = allOpenPanels.slice(-1);
            var panelUrls = (options.multiple ? allOpenPanels : lastOpenPanel).map(function (panelState) { return panelState.weavyUri; });
            history.url = panelUrls.length ? "#" + panelUrls.join(options.delimiter) : history.url.split("#")[0];

            return history;
        });


        // Initital state
        var state = weavy.history.getBrowserState();

        // Set a state from the URL if no state is present
        if (!state && window.location.hash) {
            var weavyUris = window.location.hash.replace(/^#/, "").split(options.delimiter);
            var urlState = weavy.history.getStateFromUri(weavyUris);

            if (urlState.panels.length) {
                weavy.debug("deeplinks: setting initial state");
                weavy.history.setBrowserState(urlState, "replace");
            }
        }

        // Exports
        return {}
    };

    /**
     * Default plugin options
     * 
     * @example
     * Weavy.plugins.deeplinks.defaults = {
     *   multiple: false,
     *   delimiter: ","
     * };
     * 
     * @name defaults
     * @memberof DeeplinksPlugin
     * @type {Object}
     * @property {Boolean} multiple=false - Should all opened panels be added to the hash?
     * @property {String} delimiter="," - Separator for multiple weavy URIs in the hash.
     */
    DeeplinksPlugin.defaults = {
        multiple: false,
        delimiter: ","
    };

    /**
     * Non-optional dependencies.
     * 
     * @name dependencies
     * @memberof DeeplinksPlugin
     * @type {string[]}
     */
    DeeplinksPlugin.dependencies = [];


    // Register and return plugin
    //console.debug("Registering Weavy plugin: deeplinks");
    return Weavy.plugins.deeplinks = DeeplinksPlugin;

}));
/* eslint-env commonjs, amd */

// UMD based on https://github.com/umdjs/umd/blob/master/templates/returnExports.js
// TODO: move to ES6 and transpiler

(function (root, factory) {
    if (typeof define === 'function' && define.amd) {
        // AMD. Register as an anonymous module.
        define([
            'weavy'
        ], factory);
    } else if (typeof module === 'object' && module.exports) {
        // Node. Does not work with strict CommonJS, but
        // only CommonJS-like environments that support module.exports,
        // like Node.
        module.exports = factory(
            require('weavy')
        );
    } else {
        // Browser globals (root is window)
        if (typeof root.Weavy === 'undefined' || !root.Weavy.plugins) {
            throw new Error("Weavy must be loaded before registering plugin");
        }

        factory(root.Weavy, root.wvy);
    }
}(typeof self !== 'undefined' ? self : this, function (Weavy, wvy) {

    /**
     * Filepicker plugin for attaching from Google, O365, Dropbox etc.
     * It listens to `request:origin` messages from frames and responds to the source with a `origin` message containing the `window.location.origin`.
     * 
     * _This plugin has no exposed properties or options._
     * 
     * @mixin FileBrowserPlugin
     * @returns {Weavy.plugins.filebrowser}
     * @typicalname weavy.plugins.filebrowser
     */
    var FileBrowserPlugin = function (options) {
        /** 
         *  Reference to this instance
         *  @lends FileBrowserPlugin#
         */
        var weavy = this;


        // TODO: This belongs in wvy.postal or wvy.browser instead 
        weavy.on(wvy.postal, "request:origin", weavy.getId(), function (e) {
            wvy.postal.postToSource(e, { name: 'origin', url: window.location.origin });
        });

        // Exports
        return {}
    };

    /**
     * Default plugin options
     * 
     * @example
     * Weavy.plugins.filebrowser.defaults = {
     * };
     * 
     * @ignore
     * @name defaults
     * @memberof FileBrowserPlugin
     * @type {Object}
     */
    FileBrowserPlugin.defaults = {
    };

    // Register and return plugin
    //console.debug("Registering Weavy plugin: filebrowser");
    return Weavy.plugins.filebrowser = FileBrowserPlugin;
}));
/* eslint-env commonjs, amd */

// UMD based on https://github.com/umdjs/umd/blob/master/templates/returnExports.js
// TODO: move to ES6 and transpiler

(function (root, factory) {
    if (typeof define === 'function' && define.amd) {
        // AMD. Register as an anonymous module.
        define([
            'weavy'
        ], factory);
    } else if (typeof module === 'object' && module.exports) {
        // Node. Does not work with strict CommonJS, but
        // only CommonJS-like environments that support module.exports,
        // like Node.
        module.exports = factory(
            require('weavy')
        );
    } else {
        // Browser globals (root is window)
        if (typeof root.Weavy === 'undefined' || !root.Weavy.plugins) {
            throw new Error("Weavy must be loaded before registering plugin");
        }

        factory(root.Weavy, root.wvy);
    }
}(typeof self !== 'undefined' ? self : this, function (Weavy, wvy) {

    /**
     * Displaying content and attachments in the full browser window.
     * 
     * @mixin PreviewPlugin
     * @returns {Weavy.plugins.preview}
     * @typicalname weavy.plugins.preview
     */
    var PreviewPlugin = function (options) {
        /** 
         *  Reference to this instance
         *  @lends PreviewPlugin#
         */
        var weavy = this;

        /**
         * The panel for previewing Content
         * @member PreviewPlugin~contentPanel
         * @type {?WeavyPanels~panel}
         * @returns {weavy.nodes.contentPanel}
         * @see {@link Weavy#nodes}
         */
        weavy.nodes.contentPanel = null;

        /**
         * The panel for previewing Attachments
         * @member PreviewPlugin~previewPanel
         * @type {?WeavyPanels~panel}
         * @returns {weavy.nodes.previewPanel}
         * @see {@link Weavy#nodes}
         */
        weavy.nodes.contentPanel = null;

        /**
         * Requests the topmost open panel to make a prev navigation
         * @param {Event} e
         */
        function requestPrev(e) {
            if (weavy.nodes.previewPanel.isOpen) {
                weavy.nodes.previewPanel.postMessage({ name: "request:prev" });
                e.stopImmediatePropagation();
            } else if (weavy.nodes.contentPanel.isOpen) {
                e.stopImmediatePropagation();
                weavy.nodes.contentPanel.postMessage({ name: "request:prev" });
            }
        }

        /**
         * Requests the topmost open panel to make a next navigation
         * @param {Event} e
         */
        function requestNext(e) {
            if (weavy.nodes.previewPanel.isOpen) {
                e.stopImmediatePropagation();
                weavy.nodes.previewPanel.postMessage({ name: "request:next" });
            } else if (weavy.nodes.contentPanel.isOpen) {
                e.stopImmediatePropagation();
                weavy.nodes.contentPanel.postMessage({ name: "request:next" });
            }
        }

        weavy.on(document, "keyup", function (e) {
            if (e.which === 27) { // Esc
                if (weavy.nodes.previewPanel.isOpen) {
                    e.stopImmediatePropagation();
                    weavy.nodes.previewPanel.close();
                } else if (weavy.nodes.contentPanel.isOpen) {
                    e.stopImmediatePropagation();
                    weavy.nodes.contentPanel.close();
                }
            }
            if (e.which === 37) { // Left
                requestPrev(e);
            }
            if (e.which === 39) { // Right
                requestNext();
            }
        })

        /**
         * Recieves a prev request from a panel and sends it to the topmost open preview panel.
         **/
        weavy.on(wvy.postal, "request:prev", weavy.getId(), function (e, message) {
            weavy.log("bouncing request:prev");
            requestPrev(e);
        });

        /**
         * Recieves a next request from a panel and sends it to the topmost open preview panel.
         **/
        weavy.on(wvy.postal, "request:next", weavy.getId(), function (e, message) {
            weavy.log("bouncing request:next");
            requestNext(e);
        });

        // ATTACHMENT PREVIEW
        weavy.on(wvy.postal, "preview-open", weavy.getId(), function (e, message) {
            weavy.log("opening preview");
            var previewUrl = new URL(message.url, weavy.url).href;

            weavy.nodes.previewPanel.open(previewUrl).then(focus);
        });

        // CONTENT PREVIEW
        weavy.on(wvy.postal, "content-open", weavy.getId(), function (e, message) {
            weavy.log("opening content");

            var contentUrl = new URL(message.url, weavy.url).href;

            weavy.nodes.contentPanel.open(contentUrl).then(focus);
        });

        weavy.on("build", function (e, build) {
            // Content panel
            if (!weavy.nodes.contentPanel) {
                weavy.nodes.contentPanel = weavy.nodes.panels.preview.addPanel(options.contentFrameName, "/content/", { controls: { close: true }, persistent: true, preload: "placeholder" });
                weavy.nodes.contentPanel.node.classList.add("weavy-panel-light");

                weavy.nodes.contentPanel.on("before:panel-open", function (e, openPanel) {
                    weavy.nodes.contentPanel.loadingStarted(true);
                });
            }

            // Preview panel
            if (!weavy.nodes.previewPanel) {
                weavy.nodes.previewPanel = weavy.nodes.panels.preview.addPanel(options.previewFrameName, "/attachments/", { controls: { close: true }, persistent: true, preload: "placeholder" });
                weavy.nodes.previewPanel.on("before:panel-open", function (e, openPanel) {
                    weavy.nodes.previewPanel.loadingStarted(true);
                });
                weavy.nodes.previewPanel.on("before:panel-close", function (e, closePanel) {
                    if (weavy.nodes.contentPanel.isOpen) {
                        focus({ panelId: options.contentFrameName });
                    }
                });
            }
        });

        /**
         * Tries to focus a preview panel frame
         * 
         * @param {Object} open - Object with panel data
         * @property {string} open.panelId - The id of the panel to focus; "content" or "preview".
         */
        function focus(open) {
            var panel = open.panelId === options.contentFrameName ? weavy.nodes.contentPanel : weavy.nodes.previewPanel
            try {
                panel.frame.contentWindow.focus();
            } catch (e) {
                panel.frame.focus();
            }
        }

        /**
         * Opens a url in a preview panel. If the url is an attachment url it will open in the preview panel.
         * 
         * @memberof PreviewPlugin#
         * @param {string} url - The url to the preview page to open
         */
        function open(url) {
            return weavy.whenLoaded().then(function () {
                var attachmentUrl = /^(.*)(\/attachments\/[0-9]+\/?)(.+)?$/.exec(url);
                if (attachmentUrl) {
                    return weavy.nodes.previewPanel.open(url).then(focus)
                } else {
                    weavy.nodes.previewPanel.close();
                    return weavy.nodes.contentPanel.open(url).then(focus);
                }
            });
        }

        /**
         * Closes all open preview panels.
         * @memberof PreviewPlugin#
         * @param {boolean} noHistory - Set to true if you want no navigation history generated when closing
         **/
        function closeAll(noHistory) {
            return weavy.whenLoaded().then(function () {
                return Promise.all([weavy.nodes.previewPanel.close(noHistory), weavy.nodes.contentPanel.close(noHistory)]);
            });
        }

        // Exports (not required)
        return {
            open: open,
            closeAll: closeAll
        }
    };

    /**
     * Default plugin options
     * 
     * @example
     * Weavy.plugins.preview.defaults = {
     *   previewFrameName: "preview",
     *   contentFrameName: "content"
     * };
     * 
     * @name defaults
     * @memberof PreviewPlugin
     * @type {Object}
     */
    PreviewPlugin.defaults = {
        previewFrameName: "preview",
        contentFrameName: "content"
    };

    //console.debug("Registering Weavy plugin: preview");
    return Weavy.plugins.preview = PreviewPlugin
}));
/* eslint-env commonjs, amd */

// UMD based on https://github.com/umdjs/umd/blob/master/templates/returnExports.js
// TODO: move to ES6 and transpiler

(function (root, factory) {
    if (typeof define === 'function' && define.amd) {
        // AMD. Register as an anonymous module.
        define([
            'weavy'
        ], factory);
    } else if (typeof module === 'object' && module.exports) {
        // Node. Does not work with strict CommonJS, but
        // only CommonJS-like environments that support module.exports,
        // like Node.
        module.exports = factory(
            require('weavy')
        );
    } else {
        // Browser globals (root is window)
        if (typeof root.Weavy === 'undefined' || !root.Weavy.plugins) {
            throw new Error("Weavy must be loaded before registering plugin");
        }

        factory(root.Weavy);
    }
}(typeof self !== 'undefined' ? self : this, function (Weavy) {

    /**
     * Inject additional styles into the sealed weavy shadow dom. You may define styles by either setting weavy plugin options or by injecting them via {@link ThemePlugin#addCss}
     * 
     * @example
     * ```html
     * <style id="weavyStyleOverrides" media="not all">
     *     // media="not all" keeps it from beeing applied on the page
     *     ...
     * </style>
     * <script>
     *     if (weavy.plugins.theme) {
     *         weavy.plugins.theme.createStyleSheet(weavy.nodes.container, ".weavy-panel{ background: red; }");
     *         weavy.plugins.theme.addCss(weavy.nodes.container, document.getElementById("weavyStyleOverrides").textContent);
     *     }
     *
     * </script>
     * ```
     * 
     * @mixin ThemePlugin
     * @returns {Weavy.plugins.theme}
     * @typicalname weavy.plugins.theme
     */
    var ThemePlugin = function (options) {
        /** 
        *  Reference to this instance
        *  @lends ThemePlugin#
        */
        var weavy = this;

        var supportsShadowDOM = !!HTMLElement.prototype.attachShadow;

        /**
         * Creates a style sheet for weavy and adds any styles
         * together with styles provided in options or by using {@link ThemePlugin#addCss}.
         * This function is automatically called on [before:build]{@link Weavy#event:build}
         * 
         * @memberof ThemePlugin#
         * @param {HTMLElement} root - The dom node where the stylesheet should be attached.
         * @param {string} css - CSS for the stylesheet.
         */
        function createStyleSheet(root, css) {
            if (root.weavyStyles) {
                if (root.weavyStyles.styleSheet) {
                    root.weavyStyles.styleSheet.cssText = css;
                } else {
                    root.weavyStyles.removeChild(root.weavyStyles.firstChild);
                    root.weavyStyles.appendChild(document.createTextNode(css));
                }
            } else {
                root.weavyStyles = document.createElement("style");
                root.weavyStyles.type = "text/css";
                root.weavyStyles.styleSheet ? root.weavyStyles.styleSheet.cssText = css : root.weavyStyles.appendChild(document.createTextNode(css));

                if (supportsShadowDOM) {
                    root.appendChild(root.weavyStyles);
                } else {
                    var styleId = weavy.getId("weavy-styles");
                    if (!document.getElementById(styleId)) {
                        root.weavyStyles.id = styleId;
                        document.getElementsByTagName("head")[0].appendChild(root.weavyStyles);
                    }
                }
            }

        }

        /**
         * Add styles to an existing weavy stylesheet.
         * 
         * @memberof ThemePlugin#
         * @param {HTMLElement} root - The root containing the stylesheet
         * @param {string} css - The styles to apply. Full css including selectors etc may be used.
         */
        function addCss(root, css) {
            css += "\n";

            if (root.weavyStyles) {
                if (root.weavyStyles.styleSheet) {
                    root.weavyStyles.styleSheet.cssText += css;
                } else {
                    root.weavyStyles.appendChild(document.createTextNode(css));
                }
            }
        }

        /**
         * Sets theme cookie and adds class "weavy-theme-{name}" to the body element (via realtime).
         * @param {any} name - The theme suffix name to set.
         */
        function set(name) {
            weavy.ajax("client/theme/" + name, null, "PUT").then(function () {
            });
        }

        /**
        * Clears theme cookie and removes any theme class added to the body element (via realtime).
        */
        function clear() {
            weavy.ajax("client/theme", null, "DELETE").then(function () {
            });
        }

        /**
         * Get the current theme name.
         * */
        function get() {
            return weavy.ajax("client/theme", null, "GET").then(function (data) {
                return data.theme;
            });
        }

        weavy.on("create-root", function (e, createRoot) {
            if (weavy.data && weavy.data.plugins && weavy.data.plugins.theme) {
                var data = weavy.data.plugins.theme;

                // add styles
                createStyleSheet(createRoot.root, data.clientCss);
            }
        });

        weavy.on("destroy", function (e, destroy) {
            var styleId = weavy.getId("weavy-styles");
            var weavyStyles = document.getElementById(styleId);
            if (weavyStyles) {
                weavyStyles.remove();
            }
        });

        // Exports
        return {
            addCss: addCss,
            createStyleSheet: createStyleSheet,
            set: set,
            clear: clear,
            get: get
        };
    };

    /**
     * Default plugin options
     * 
     * @example
     * Weavy.plugins.theme.defaults = {
     * };
     * @ignore
     * @name defaults
     * @memberof ThemePlugin
     * @type {Object}
     */
    ThemePlugin.defaults = {
    };

    //console.debug("Registering Weavy plugin: theme");
    return Weavy.plugins.theme = ThemePlugin;
}));
/* eslint-env commonjs, amd */

// UMD based on https://github.com/umdjs/umd/blob/master/templates/returnExports.js
// TODO: move to ES6 and transpiler

(function (root, factory) {
    if (typeof define === 'function' && define.amd) {
        // AMD. Register as an anonymous module.
        define([
            'weavy'
        ], factory);
    } else if (typeof module === 'object' && module.exports) {
        // Node. Does not work with strict CommonJS, but
        // only CommonJS-like environments that support module.exports,
        // like Node.
        module.exports = factory(
            require('weavy')
        );
    } else {
        // Browser globals (root is window)
        if (typeof root.Weavy === 'undefined' || !root.Weavy.plugins) {
            throw new Error("Weavy must be loaded before registering plugin");
        }

        factory(root.Weavy);
    }
}(typeof self !== 'undefined' ? self : this, function (Weavy) {

    /**
     * Plugin for enabling maximize button.
     * Enable the button by setting options `{ controls: { maximize: true }}` on an app or a panel or by manually using the {@link MaximizePlugin#maximize} method.
     * @example
     * var weavy = new Weavy();
     * var space = weavy.space({
     *   key: "myspace" 
     * });
     * 
     * // Built-in maximize button
     * var app = weavy.app({
     *   key: "myfiles",
     *   type: "files"
     *   container: "#mycontainer"
     *   controls: {
     *     maximize: true
     *   }
     * });
     * 
     * // Built-in maximize button with custom maximize styling
     * var app = weavy.app({
     *   key: "myfiles",
     *   type: "files"
     *   container: "#mycontainer"
     *   controls: {
     *     maximize: {
     *       top: "3rem"
     *     }
     *   }
     * });
     * 
     * @example
     * var weavy = new Weavy();
     * var space = weavy.space({
     *   key: "myspace"
     * });
     * var app = weavy.app({
     *   key: "myfiles",
     *   type: "files"
     *   container: "#mycontainer"
     * });
     * 
     * // Set maximize using custom buttons
     * 
     * // Maximize
     * $("#myMaxButton").on("click", function() {
     *   app.panel.maximize(true);
     * });
     * 
     * // Restore
     * $("#myRestoreButton").on("click", function() {
     *   app.panel.maximize(false);
     * });
     * 
     * // Toggle and custom style
     * $("#myToggleButton").on("click", function() {
     *   app.panel.maximize(null, { top: "3rem" });
     * });
     * 
     * @mixin MaximizePlugin
     * @typicalname panel
     * @returns {Weavy.plugins.maximize}
     */
    var MaximizePlugin = function (options) {
        /**
         *  Reference to this instance
         *  @lends MaximizePlugin#
         */
        var weavy = this;

        /**
         * Toggling maximized mode on a panel. This means the panel will try to take up the whole window. 
         * You may add additional styles as properties in a styles object to fine tune the layout/position in your environment.
         * 
         * @function
         * @name MaximizePlugin#maximize
         * @param {boolean} [maximize] - Set true to maximize, false to restore, null to toggle (default).
         * @param {Object} [styles] - Object with style properties to override on the panel. The names must be the same as style names used in HTMLElement.styles
         */
        function toggleMaximize(maximize, styles) {
            weavy.log("maximize", maximize !== null ? maximize : "toggle", this.panelId);
            var styleName;

            if (maximize === false || this.maximized && maximize !== true) {
                if (this.initialStyles) {
                    weavy.debug("restoring maximize styles");

                    for (styleName in this.initialStyles) {
                        if (Object.prototype.hasOwnProperty.call(this.initialStyles, styleName)) {
                            this.node.style[styleName] = this.initialStyles[styleName];
                        }
                    }
                    delete this.initialStyles;
                }

                this.node.style.position = this.initialPosition;
                this.node.style.zIndex = this.initialZIndex;
                delete this.initialPosition;
                delete this.initialZIndex;

                this.maximized = false;
            } else {
                if (this.initialPosition === undefined) {
                    this.initialPosition = this.node.style.position;
                }
                if (this.initialZIndex === undefined) {
                    this.initialZIndex = this.node.style.zIndex;
                }
                this.node.style.position = "fixed";
                this.node.style.zIndex = 2147483647;

                // Additional/overriding styles
                if (styles && this.initialStyles === undefined) {
                    weavy.debug("setting maximize styles");

                    var initialStyles = {};
                    for (styleName in styles) {
                        if (Object.prototype.hasOwnProperty.call(styles, styleName)) {
                            initialStyles[styleName] = this.node.style[styleName];
                            this.node.style[styleName] = styles[styleName];
                        }
                    }
                    this.initialStyles = initialStyles;
                }

                this.maximized = true;
            }
        }

        function createButton(controls, panel, styles) {
            var maximize = document.createElement("div");
            maximize.className = "weavy-icon";
            maximize.title = "Maximize";
            maximize.innerHTML = '<svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24"><path d="M4,4H20V20H4V4M6,8V18H18V8H6Z" /></svg>';
            weavy.on(maximize, "click", toggleMaximize.bind(panel, null, styles));
            controls.appendChild(maximize);
        }

        weavy.on("panel-added", function (e, panelAdded) {
            // Expose maximize function
            panelAdded.panel.maximize = toggleMaximize.bind(panelAdded.panel)

            if (panelAdded.attributes.controls) {
                if (panelAdded.attributes.controls === true || panelAdded.attributes.controls.maximize) {
                    var maximizeOptions = panelAdded.attributes.controls.maximize;
                    var styles = maximizeOptions && typeof maximizeOptions !== "boolean" && maximizeOptions;
                    /*var parentContainer;
                    try {
                        parentContainer = panelAdded.panel.eventParent.eventParent.root.parent;
                    } catch (e) { }*/

                    weavy.debug("maximize: adding panel control", panelAdded.panelId);
                    var panelControls = panelAdded.panel.node.querySelector(".weavy-controls");
                    if (panelControls) {
                        createButton(panelControls, panelAdded.panel, styles);
                    }
                }
            }
        })

        // Exports
        return {}
    };

    /**
     * Default plugin options
     * 
     * @example
     * Weavy.plugins.maximize.defaults = {
     * };
     * 
     * @ignore
     * @name defaults
     * @memberof MaximizePlugin
     * @type {Object}
     */
    MaximizePlugin.defaults = {
    };

    /**
     * Non-optional dependencies.
     * 
     * @ignore
     * @name dependencies
     * @memberof MaximizePlugin
     * @type {string[]}
     */
    MaximizePlugin.dependencies = [];


    // Register and return plugin
    //console.debug("Registering Weavy plugin: maximize");
    return Weavy.plugins.maximize = MaximizePlugin;

}));
/* End scope */
}) ();
Weavy.version = "8.10.0+weavy.ba528ccce";