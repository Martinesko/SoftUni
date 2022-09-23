function editElement(ref , match , rep) {
   const content = ref.textContent;
   const matcher = new RegExp(match,'g');
   const edited = content.replace(matcher, rep);
   ref.textContent = edited;
}