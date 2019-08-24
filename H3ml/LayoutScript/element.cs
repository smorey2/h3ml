using H3ml.Script;
using System;
using System.Collections.Generic;

namespace H3ml.Layout
{
    partial class element : IElement
    {
        readonly Dictionary<string, string> _events = new Dictionary<string, string>();

        char IElement.accessKey { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        NamedNodeMap IElement.attributes => throw new NotImplementedException();
        int IElement.childElementCount => throw new NotImplementedException();
        NodeList IElement.childNodes => throw new NotImplementedException();
        HTMLCollection IElement.children => throw new NotImplementedException();
        DOMTokenList IElement.classList => throw new NotImplementedException();
        string IElement.className { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        int IElement.clientHeight => throw new NotImplementedException();
        int IElement.clientLeft => throw new NotImplementedException();
        int IElement.clientTop => throw new NotImplementedException();
        int IElement.clientWidth => throw new NotImplementedException();
        string IElement.contentEditable { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        string IElement.dir { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        INode IElement.firstChild => throw new NotImplementedException();
        INode IElement.firstElementChild => throw new NotImplementedException();
        string IElement.id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        string IElement.innerHTML { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        string IElement.innerText { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        bool IElement.isContentEditable => throw new NotImplementedException();
        string IElement.lang { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        INode IElement.lastChild => throw new NotImplementedException();
        INode IElement.lastElementChild => throw new NotImplementedException();
        string IElement.namespaceURI => throw new NotImplementedException();
        INode IElement.nextSibling => throw new NotImplementedException();
        INode IElement.nextElementSibling => throw new NotImplementedException();
        string IElement.nodeName => throw new NotImplementedException();
        int IElement.nodeType => throw new NotImplementedException();
        string IElement.nodeValue { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        int IElement.offsetHeight => throw new NotImplementedException();
        int IElement.offsetWidth => throw new NotImplementedException();
        int IElement.offsetLeft => throw new NotImplementedException();
        INode IElement.offsetParent => throw new NotImplementedException();
        int IElement.offsetTop => throw new NotImplementedException();
        IDocument IElement.ownerDocument => throw new NotImplementedException();
        INode IElement.parentNode => throw new NotImplementedException();
        IElement IElement.parentElement => throw new NotImplementedException();
        INode IElement.previousSibling => throw new NotImplementedException();
        INode IElement.previousElementSibling => throw new NotImplementedException();
        int IElement.scrollHeight => throw new NotImplementedException();
        int IElement.scrollLeft => throw new NotImplementedException();
        int IElement.scrollTop => throw new NotImplementedException();
        int IElement.scrollWidth => throw new NotImplementedException();
        IStyle IElement.style => throw new NotImplementedException();
        int IElement.tabIndex { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        string IElement.tagName => throw new NotImplementedException();
        string IElement.textContent { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        string IElement.title { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        void IElement.addEventListener(string @event, string function, bool useCapture) => _events[$"{@event}{(useCapture ? 1 : 0)}"] = function;
        INode IElement.appendChild(INode node) => throw new NotImplementedException();
        void IElement.blur() => throw new NotImplementedException();
        void IElement.click() => throw new NotImplementedException();
        INode IElement.cloneNode(bool deep) => throw new NotImplementedException();
        int IElement.compareDocumentPosition(INode node) => throw new NotImplementedException();
        bool IElement.contains(INode node) => throw new NotImplementedException();
        void IElement.exitFullscreen() => throw new NotImplementedException();
        void IElement.focus() => throw new NotImplementedException();
        string IElement.getAttribute(string attributename) => throw new NotImplementedException();
        IAttr IElement.getAttributeNode(string attributename) => throw new NotImplementedException();
        IRect IElement.getBoundingClientRect() => throw new NotImplementedException();
        NodeList IElement.getElementsByClassName(string classname) => throw new NotImplementedException();
        NodeList IElement.getElementsByTagName(string tagname) => throw new NotImplementedException();
        bool IElement.hasAttribute(string attributename) => throw new NotImplementedException();
        bool IElement.hasAttributes() => throw new NotImplementedException();
        bool IElement.hasChildNodes() => throw new NotImplementedException();
        void IElement.insertAdjacentElement(string position, IElement element) => throw new NotImplementedException();
        void IElement.insertAdjacentHTML(string position, string text) => throw new NotImplementedException();
        void IElement.insertAdjacentText(string position, string text) => throw new NotImplementedException();
        INode IElement.insertBefore(INode newnode, INode existingnode) => throw new NotImplementedException();
        bool IElement.isDefaultNamespace(string namespaceURI) => throw new NotImplementedException();
        bool IElement.isEqualNode(INode node) => throw new NotImplementedException();
        bool IElement.isSameNode(INode node) => throw new NotImplementedException();
        void IElement.normalize() => throw new NotImplementedException();
        IElement IElement.querySelector(string selectors) => throw new NotImplementedException();
        NodeList IElement.querySelectorAll(string selectors) => throw new NotImplementedException();
        void IElement.removeAttribute(string attributename) => throw new NotImplementedException();
        IAttr IElement.removeAttributeNode(IAttr attributenode) => throw new NotImplementedException();
        INode IElement.removeChild(INode node) => throw new NotImplementedException();
        void IElement.removeEventListener(string @event, string function, bool useCapture) => _events.Remove($"{@event}{(useCapture ? 1 : 0)}");
        INode IElement.replaceChild(INode newnode, INode oldnode) => throw new NotImplementedException();
        void IElement.requestFullscreen() => throw new NotImplementedException();
        void IElement.scrollIntoView(bool? alignTo) => throw new NotImplementedException();
        void IElement.setAttribute(string attributename, string attributevalue) => throw new NotImplementedException();
        IAttr IElement.setAttributeNode(IAttr attributenode) => throw new NotImplementedException();
        void IElement.toString() => throw new NotImplementedException();
    }
}
